/* --------------------------------------------------------------------------------------------
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 * ------------------------------------------------------------------------------------------ */

import * as fs from 'fs';
import * as path from 'path';
import * as vscode from 'vscode';
import { workspace, ExtensionContext } from 'vscode';
import axios from 'axios';
import * as https from 'https';

import {
	integer,
	LanguageClient,
	LanguageClientOptions,
	ServerOptions,
	TransportKind
} from 'vscode-languageclient/node';

let client: LanguageClient;

const httpsAgent = new https.Agent({ rejectUnauthorized: false });

export function activate(context: ExtensionContext) {
	// The server is implemented in node
	const serverModule = context.asAbsolutePath(
		path.join('server', 'out', 'server.js')
	);
	// The debug options for the server
	// --inspect=6009: runs the server in Node's Inspector mode so VS Code can attach to the server for debugging
	const debugOptions = { execArgv: ['--nolazy', '--inspect=6009'] };

	// If the extension is launched in debug mode then the debug server options are used
	// Otherwise the run options are used
	const serverOptions: ServerOptions = {
		run: { module: serverModule, transport: TransportKind.ipc },
		debug: {
			module: serverModule,
			transport: TransportKind.ipc,
			options: debugOptions
		}
	};

	// Options to control the language client
	const clientOptions: LanguageClientOptions = {
		// Register the server for plain text documents
		documentSelector: [{ scheme: 'file', language: 'sidl' }], //plaintext
		synchronize: {
			// Notify the server about file changes to '.clientrc files contained in the workspace
			fileEvents: workspace.createFileSystemWatcher('**/.clientrc')
		}
	};

	// Create the language client and start the client.
	client = new LanguageClient(
		'sidlLanguageServer',
		'Sidl Language Server',
		serverOptions,
		clientOptions
	);

	// Start the client. This will also launch the server
	client.start();	


	// webview: graph viewer
	// Only allow a single Cat Coder
	const panels = new Map<string, Array<vscode.WebviewPanel>>();	

	context.subscriptions.push(
		vscode.commands.registerCommand('sidl.visualization.graph.start', () => {
			// Create and show a new webview
			const panel = vscode.window.createWebviewPanel(
				'sidlGraphVisualization', // Identifies the type of the webview. Used internally
				'Sidl Graph', // Title of the panel displayed to the user
				vscode.ViewColumn.Beside, // Editor column to show the new webview panel in.
				{ // Webview options. More on these later.
					enableScripts: true,
					retainContextWhenHidden: true,
					// Only allow the webview to access resources in our extension's media directory
					localResourceRoots: [vscode.Uri.file(path.join(context.extensionPath, 'resources'))]
				}
			);
			
			const rootDoc = vscode.window.activeTextEditor.document;						
			// panel.webview.html = getWebviewContent(rootDoc.fileName, rootDoc.languageId, rootDoc.uri.toString());
			fs.readFile(path.join(context.extensionPath,'views','graph_webview.html'),(err,data) => {
				if(err) {console.error(err);}
				const res = panel.webview.asWebviewUri(vscode.Uri.file(path.join(context.extensionPath, 'resources')));
				const uri = rootDoc.uri.toString();
				const filename = rootDoc.fileName;				
				panel.webview.html = eval("`" + data.toString() + "`");

				if(!panels.has(rootDoc.fileName)) panels.set(rootDoc.fileName, new Array<vscode.WebviewPanel>());
				panels.get(rootDoc.fileName).push(panel);
				
				getGraph(rootDoc.getText()).then(result => {
					if(result != null) {
						panel.webview.postMessage({cmd: "init", text: rootDoc.getText(), graph:result.graph});
					}
				});
			});								
		})		
	);

	vscode.workspace.onDidChangeTextDocument(function(e) {
		// e.document.fileName;
		const p = panels.get(e.document.fileName);
		p.forEach(element => {
			getGraph(e.document.getText()).then(result => {
				if(result != null) {
					element.webview.postMessage({cmd: "update", text: e.document.getText(), graph:result.graph});
				}
			});
			
		});					
	});
	
}

export function deactivate(): Thenable<void> | undefined {
	if (!client) {
		return undefined;
	}
	return client.stop();
}

function getWebviewContent(name:string, languageId:string, uri:string) {

	return `<!DOCTYPE html>
	<html lang="en">
		<head>
			<meta charset="UTF-8">
	  		<meta name="viewport" content="width=device-width, initial-scale=1.0">
			<title>Sidl Visualization: Graph</title>

			<!-- vis.js -->
			<script src="https://cdnjs.cloudflare.com/ajax/libs/vis/4.21.0/vis.min.js" type="text/javascript"></script>
			<link rel="stylesheet" type="text/css" media="all" href="https://cdnjs.cloudflare.com/ajax/libs/vis/4.21.0/vis.min.css" />
		</head>
		<body>
			<div id="graph">FileName: ${name}</div>
			<p>Language: ${languageId}</p>
			<p>uri: ${uri}</p>	
			<br/><br/>	
			<div id="note"></div>
			<div id="mynetwork"></div>
			<script type="text/javascript">
			// create an array with nodes
			var nodes = new vis.DataSet([
				{ id: 1, label: "Node 1" },
				{ id: 2, label: "Node 2" },
				{ id: 3, label: "Node 3" },
				{ id: 4, label: "Node 4" },
				{ id: 5, label: "Node 5" }
			]);

			// create an array with edges
			var edges = new vis.DataSet([
				{ from: 1, to: 3 },
				{ from: 1, to: 2 },
				{ from: 2, to: 4 },
				{ from: 2, to: 5 },
				{ from: 3, to: 3 }
			]);

			// create a network
			var container = document.getElementById("mynetwork");
			var data = {
				nodes: nodes,
				edges: edges
			};
			var options = {};
			var network = new vis.Network(container, data, options);
			</script>
		</body>
		<script>
			const note = document.getElementById('note');
			window.addEventListener('message', event => {
				const message = event.data;
				note.textContent = message.text;
			});
		</script>
	</html>`;
}


// Webview "Graph": client-managed update

type NodeRecord = {
	name: string;
}

type EdgeRecord = {
	name: string;
	from: string;
	to: string;
	payload: string;
}

type GraphRecord = {
	nodes: Array<NodeRecord>;
	edges: Array<EdgeRecord>;
}

// https://dev.to/tuasegun/cleaner-and-better-way-for-calling-apis-with-axios-in-your-react-typescript-applications-3d3k
async function getGraph(text: string) : Promise<{status:integer, graph:GraphRecord}> {

	try {
		const { data, status } = await axios.post<GraphRecord>(
			'https://localhost:7059/sidl/lsp/visualization/graph',
			{ programText: text },
			{
				httpsAgent,
				headers: {
					'Content-Type': 'application/json',
					Accept: 'application/json',
				},
			},
		);		
		// console.log(status);
		// console.log(JSON.stringify(data, null, 4));
		return {status, graph:data};
	} catch (error) {
		if (axios.isAxiosError(error)) {
			console.log('error message: ', error.message);					
			return { status:500, graph:null };
		} else {
			console.log('unexpected error: ', error);
			return { status:500, graph:null };
		}
	}
}




