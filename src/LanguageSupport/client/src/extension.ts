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
	const webviewResources = "views/assets";
	// const webviewResources = "resources";
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
					localResourceRoots: [vscode.Uri.file(path.join(context.extensionPath, webviewResources))]					
				}
			);
			
			const rootDoc = vscode.window.activeTextEditor.document;						
			// panel.webview.html = getWebviewContent(rootDoc.fileName, rootDoc.languageId, rootDoc.uri.toString());
			fs.readFile(path.join(context.extensionPath,'views','graph_webview.html'),(err,data) => {
				if(err) {console.error(err);}				
				const res = panel.webview.asWebviewUri(vscode.Uri.file(path.join(context.extensionPath, webviewResources)));
				const uri = rootDoc.uri.toString();
				const filename = rootDoc.fileName;						
				panel.webview.html = eval("`" + data.toString() + "`");

				if(!panels.has(rootDoc.fileName)) panels.set(rootDoc.fileName, new Array<vscode.WebviewPanel>());
				panels.get(rootDoc.fileName).push(panel);
				
				// v1: use webview postMessage
				// getGraph(rootDoc.getText()).then(result => {
				// 	if(result != null) {
				// 		panel.webview.postMessage({cmd: "init", text: rootDoc.getText(), graph:result.graph});
				// 	}
				// });

				// v2: use socket.io
				// perform init inside .html

				// v3: use socket.io and init via postMessage(..)
				panel.webview.postMessage({ cmd: "init", text: rootDoc.getText() });
			});								
		})		
	);

	vscode.workspace.onDidChangeTextDocument(function(e) {
	
		// v1: use webview-postMessage(..)
		// const p = panels.get(e.document.fileName);
		// p.forEach(element => {
		// 	getGraph(e.document.getText()).then(result => {
		// 		if(result != null) {
		// 			element.webview.postMessage({cmd: "update", text: e.document.getText(), graph:result.graph});
		// 		}
		// 	});
		// });		
		
		// v2: use socket.io
		// trigger update from server.ts
	});
	
}

export function deactivate(): Thenable<void> | undefined {
	if (!client) {
		return undefined;
	}
	return client.stop();
}