/* --------------------------------------------------------------------------------------------
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 * ------------------------------------------------------------------------------------------ */
import * as fs from 'fs';
import * as path from 'path';
import * as https from 'https';
import * as http from 'http';
// import { Server } from "socket.io";
import { Server } from "socket.io";

import {
	createConnection,
	TextDocuments,
	Diagnostic,
	DiagnosticSeverity,
	ProposedFeatures,
	InitializeParams,
	DidChangeConfigurationNotification,
	CompletionItem,
	CompletionItemKind,
	TextDocumentPositionParams,
	TextDocumentSyncKind,
	InitializeResult,
	integer,
	Position
} from 'vscode-languageserver/node';

import {
	TextDocument
} from 'vscode-languageserver-textdocument';

import axios from 'axios';
// DO NOT DO THIS IF SHARING PRIVATE DATA WITH SERVICE
const httpsAgent = new https.Agent({ rejectUnauthorized: false });

// socket.io

// const httpsServer = https.createServer({
// 	key: fs.readFileSync(path.join(__dirname, '..', '..', 'resources', 'cert', 'server.key')),
// 	cert:  fs.readFileSync(path.join(__dirname, '..', '..', 'resources', 'cert', 'server.cert'))
//  });

const httpServer = http.createServer();
const io = new  Server(httpServer, {
	cors: {
		origin: '*'
	}
});	
httpServer.listen(3000);

io.on("connection", (socket) => {	
	console.log("client ", socket.id, " is connected");
	
	const query = socket.handshake.query;
	const roomName = query.roomName;
	if(!roomName) {
		// handle this
	} else {
		socket.join(roomName.toString());
		console.log("client ", socket.id, "joind room: ", roomName.toString());		

		socket.on("initGraph", (data) => {			
			getGraph(data.rootdoctext).then(result => {				
				if(result != null) {
					// panel.webview.postMessage({cmd: "init", text: rootDoc.getText(), graph:result.graph}); // comm v1
					io.to(roomName).emit("msg", {cmd: "init", graph:result.graph});
				}
			});
		});
	}
});



// Create a connection for the server, using Node's IPC as a transport.
// Also include all preview / proposed LSP features.
const connection = createConnection(ProposedFeatures.all);

// Create a simple text document manager.
const documents: TextDocuments<TextDocument> = new TextDocuments(TextDocument);

let hasConfigurationCapability = false;
let hasWorkspaceFolderCapability = false;
let hasDiagnosticRelatedInformationCapability = false;

// holds a list of basetypes for the completion provider
let basetypes: Array<string>;

connection.onInitialize((params: InitializeParams) => {
	const capabilities = params.capabilities;

	basetypes = new Array<string>();

	// Does the client support the `workspace/configuration` request?
	// If not, we fall back using global settings.
	hasConfigurationCapability = !!(
		capabilities.workspace && !!capabilities.workspace.configuration
	);
	hasWorkspaceFolderCapability = !!(
		capabilities.workspace && !!capabilities.workspace.workspaceFolders
	);
	hasDiagnosticRelatedInformationCapability = !!(
		capabilities.textDocument &&
		capabilities.textDocument.publishDiagnostics &&
		capabilities.textDocument.publishDiagnostics.relatedInformation
	);

	const result: InitializeResult = {
		capabilities: {
			textDocumentSync: TextDocumentSyncKind.Incremental,
			// Tell the client that this server supports code completion.
			completionProvider: {
				resolveProvider: true
			}
		}
	};
	if (hasWorkspaceFolderCapability) {
		result.capabilities.workspace = {
			workspaceFolders: {
				supported: true
			}
		};
	}
	return result;
});

connection.onInitialized(() => {
	if (hasConfigurationCapability) {
		// Register for all configuration changes.
		connection.client.register(DidChangeConfigurationNotification.type, undefined);
	}
	if (hasWorkspaceFolderCapability) {
		connection.workspace.onDidChangeWorkspaceFolders(_event => {
			connection.console.log('Workspace folder change event received.');
		});
	}

	// custom:
	if (basetypes.length == 0) {
		loadBasetypeKeywordsAsync().then(bt => {
			basetypes = basetypes.concat(bt);
		});
	}
});

// The example settings
interface SidlLspServerSettings {
	maxNumberOfProblems: number;
}

// The global settings, used when the `workspace/configuration` request is not supported by the client.
// Please note that this is not the case when using this server with the client provided in this example
// but could happen with other clients.
const defaultSettings: SidlLspServerSettings = { maxNumberOfProblems: 1000 };
let globalSettings: SidlLspServerSettings = defaultSettings;

// Cache the settings of all open documents
const documentSettings: Map<string, Thenable<SidlLspServerSettings>> = new Map();

connection.onDidChangeConfiguration(change => {
	if (hasConfigurationCapability) {
		// Reset all cached document settings
		documentSettings.clear();
	} else {
		globalSettings = <SidlLspServerSettings>(
			(change.settings.languageServerExample || defaultSettings)
		);
	}

	// Revalidate all open text documents
	documents.all().forEach(validateTextDocument);
});

function getDocumentSettings(resource: string): Thenable<SidlLspServerSettings> {
	if (!hasConfigurationCapability) {
		return Promise.resolve(globalSettings);
	}
	let result = documentSettings.get(resource);
	if (!result) {
		result = connection.workspace.getConfiguration({
			scopeUri: resource,
			section: 'sidlLanguageServer'
		});
		documentSettings.set(resource, result);
	}
	return result;
}

// Only keep settings for open documents
documents.onDidClose(e => {
	documentSettings.delete(e.document.uri);
});

// The content of a text document has changed. This event is emitted
// when the text document first opened or when its content has changed.
documents.onDidChangeContent(change => {
	validateTextDocument(change.document);
	const room = change.document.uri;
	
	// commu v2
	getGraph(change.document.getText()).then(result => {		
		if(result != null) {
			// panel.webview.postMessage({cmd: "init", text: rootDoc.getText(), graph:result.graph}); // comm v1
			io.to(room).emit("msg", {cmd: "egaaaal", graph:result.graph});
		}
	});
});

async function validateTextDocument(textDocument: TextDocument): Promise<void> {
	// In this simple example we get the settings for every validate run.
	const settings = await getDocumentSettings(textDocument.uri);

	// The validator creates diagnostics for all uppercase words length 2 and more
	const text = textDocument.getText();
	const pattern = /\b[A-Z]{2,}\b/g;
	let m: RegExpExecArray | null;

	const problems = 0;	
	const diagnostics: Diagnostic[] = [];

	// new:
	validateProgramText(text).then(result => {
		if (result != null) {
			if(result.data == "ok") {
				const diagnostic: Diagnostic = {
					severity: DiagnosticSeverity.Information,					
					range: {
						start: textDocument.positionAt(text.length),
						end: textDocument.positionAt(text.length)
					},
					message: "All good!",
					source: 'Sidl-Linter'
				};
				diagnostics.push(diagnostic);
			} else if(result.status >= 200 && result.status < 300) {
				const diagnostic: Diagnostic = {
					severity: DiagnosticSeverity.Error,
					range: {
						start: textDocument.positionAt(text.length),
						end: textDocument.positionAt(text.length)
					},
					message: `${result.data}`,
					source: 'Sidl-Linter'
				};
				diagnostics.push(diagnostic);
			} else if(result.status > 200) {
				const diagnostic: Diagnostic = {
					severity: DiagnosticSeverity.Warning,
					range: {
						start: textDocument.positionAt(text.length),
						end: textDocument.positionAt(text.length)
					},
					message: `${result.data}`,
					source: 'Sidl-Linter'
				};
				diagnostics.push(diagnostic);
			} 			
			connection.sendDiagnostics({ uri: textDocument.uri, diagnostics });
		}
	});

	// old
	/*
	while ((m = pattern.exec(text)) && problems < settings.maxNumberOfProblems) {
		problems++;
		const diagnostic: Diagnostic = {
			severity: DiagnosticSeverity.Warning,
			range: {
				start: textDocument.positionAt(m.index),
				end: textDocument.positionAt(m.index + m[0].length)
			},
			message: `${m[0]} is all uppercase.`,
			source: 'ex'
		};
		if (hasDiagnosticRelatedInformationCapability) {
			diagnostic.relatedInformation = [
				{
					location: {
						uri: textDocument.uri,
						range: Object.assign({}, diagnostic.range)
					},
					message: 'Spelling matters'
				},
				{
					location: {
						uri: textDocument.uri,
						range: Object.assign({}, diagnostic.range)
					},
					message: 'Particularly for names'
				}
			];
		}
		diagnostics.push(diagnostic);
	}

	// Send the computed diagnostics to VSCode.
	connection.sendDiagnostics({ uri: textDocument.uri, diagnostics });
	*/
}

connection.onDidChangeWatchedFiles(_change => {
	// Monitored files have change in VSCode
	connection.console.log('We received an file change event');
});


connection.onCompletion(async (params: TextDocumentPositionParams): (Promise<CompletionItem[]>) => {
	const docu = documents.get(params.textDocument.uri);
	const text = docu != null ? docu.getText() : "";	
	const lines = text.split(/\r?\n/g);
	const position = params.position;

	const results = new Array<CompletionItem>();
	let nodetypes = new Array<string>();

	// loadNodetypesForContextAsync(text, position.line, position.character).then(nt => {
	// 	nodetypes = nodetypes.concat(nt);
		
	// 	return results;
	// });
	const currentLine = lines[position.line];
	const nodeKeywordPos = currentLine.indexOf("node");

	// if word before is "node" do...
	console.log("pos: " + nodeKeywordPos + " / :" + currentLine.substring(nodeKeywordPos+4, position.character).trim());
	if(nodeKeywordPos >= 0 && currentLine.substring(nodeKeywordPos+4, position.character).trim() == "") {
		const nt = await loadNodetypesForContextAsync(text, position.line, position.character);
		nodetypes = nodetypes.concat(nt);	
		for (let a = 0; a < nodetypes.length; a++) {
			results.push({
				label: nodetypes[a],
				kind: CompletionItemKind.TypeParameter,
				data: 'type-' + a
			});
		}

		console.log(nodetypes);
	} else {		
		for (let a = 0; a < basetypes.length; a++) {
			results.push({
				label: basetypes[a],
				kind: CompletionItemKind.TypeParameter,
				data: 'type-' + a
			});
		}
	}
	return results;
});


/*
// This handler provides the initial list of the completion items.
connection.onCompletion((_textDocumentPosition: TextDocumentPositionParams): CompletionItem[] => {
		// The pass parameter contains the position of the text document in
		// which code complete got requested. For the example we ignore this
		// info and always provide the same completion items.
		// return [
		// 	{
		// 		label: 'TypeScript',
		// 		kind: CompletionItemKind.Text,
		// 		data: 1
		// 	},
		// 	{
		// 		label: 'JavaScript',
		// 		kind: CompletionItemKind.Text,
		// 		data: 2
		// 	}
		// ];

		
		const docu = documents.get(_textDocumentPosition.textDocument.uri);
		const text = docu != null ? docu.getText() : "";

		const lines = text.split(/\r?\n/g);
		const position = _textDocumentPosition.position;



		let start = 0;

		for (let i = position.character; i >= 0; i--) {
			if (lines != null && lines[position.line][i] == '=') {
				start = i;
				i = 0;
			}
		}

		const results = new Array<CompletionItem>();



		// TODO check if word before is "node", if no:
		for (let a = 0; a < basetypes.length; a++) {
			results.push({
				label: basetypes[a],
				kind: CompletionItemKind.TypeParameter,
				data: 'type-' + a
			});
		}

		// if yes:
		let nodetypes = new Array<string>();
		loadNodetypesForContextAsync(text, position.line, position.character).then(nt => {
			nodetypes = nodetypes.concat(nt);
			
			return results;
		});



		// if(start >= 5
		//     && lines[position.line].substr(start-5,5) == "color")
		//      {

		//         for(let a = 0; a < basetypes.length; a++)
		//         {
		//             results.push({ 
		//                 label: basetypes[a],
		//                 kind: CompletionItemKind.TypeParameter,
		//                 data: 'type-' + a
		//             });
		//         }

		//         // return results;
		//     }        

		// if(start >= 5
		// && lines[position.line].substr(start-5,5) == "shape")
		//  {
		//     let results = new Array<CompletionItem>();
		//     for(var a = 0; a < shapes.length; a++)
		//     {
		//         results.push({ 
		//             label: shapes[a],
		//             kind: CompletionItemKind.Text,
		//             data: 'shape-' + a
		//         })
		//     }

		//     return results;
		// }
		return results;
	}
);
*/

// This handler resolves additional information for the item selected in
// the completion list.
connection.onCompletionResolve(
	(item: CompletionItem): CompletionItem => {
		if (item.data === 1) {
			item.detail = 'TypeScript details';
			item.documentation = 'TypeScript documentation';
		} else if (item.data === 2) {
			item.detail = 'JavaScript details';
			item.documentation = 'JavaScript documentation';
		}
		return item;
	}
);

// Make the text document manager listen on the connection
// for open, change and close text document events
documents.listen(connection);

// Listen on the connection
connection.listen();






// helper methods

async function loadBasetypeKeywordsAsync() {
	// const btkeysText = fs.readFileSync(path.join(__dirname, '..', '..', 'data', 'basetypes')).toString();
	// const btkeys = btkeysText.split(/\r?\n/g);			
	// return btkeys;
	try {
		const { data, status } = await axios.get<Array<string>>(
			'https://localhost:7059/sidl/lsp/basetypes',
			{
				httpsAgent,
				headers: {
					Accept: 'application/json',
				},
			},
		);
		//console.log(JSON.stringify(data, null, 4));
		return data;
	} catch (error) {
		if (axios.isAxiosError(error)) {
			console.log('error message: ', error.message);
			return error.message;
		} else {
			console.log('unexpected error: ', error);
			return 'An unexpected error occurred';
		}

	}
}

async function loadNodetypesForContextAsync(text: string, line: integer, character: integer) {
	try {		
		const { data, status } = await axios.post<Array<string>>(
			'https://localhost:7059/sidl/lsp/nodetypes',
			{ programText: text, line: line, character: character },
			{
				httpsAgent,
				headers: {
					'Content-Type': 'application/json',
					Accept: 'application/json',
				},
			},
		);
		console.log("load nodetypes: " + status + " / " + JSON.stringify(data, null, 4));		
		return data;
	} catch (error) {
		if (axios.isAxiosError(error)) {
			console.log('error message: ', error.message);
			return error.message;
		} else {
			console.log('unexpected error: ', error);
			return 'An unexpected error occurred';
		}
	}
}

// https://dev.to/tuasegun/cleaner-and-better-way-for-calling-apis-with-axios-in-your-react-typescript-applications-3d3k
async function validateProgramText(text: string) : Promise<{status:integer, data:string}> {

	try {
		const { data, status } = await axios.post<string>(
			'https://localhost:7059/sidl/lsp/validate',
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
		return {status, data};
	} catch (error) {
		if (axios.isAxiosError(error)) {
			console.log('error message: ', error.message);					
			return { status:500, data:error.message };
		} else {
			console.log('unexpected error: ', error);
			return { status:500, data:'An unexpected error occurred' };
		}
	}
}

// const loadBasetypeKeywords = async() : Promise<Array<string>> => {
// 	// const btkeysText = fs.readFileSync(path.join(__dirname, '..', '..', 'data', 'basetypes')).toString();
// 	// const btkeys = btkeysText.split(/\r?\n/g);
// 	// return btkeys;

// 	const response = fetch('https://localhost:7059/atomictypes');
// 	return response.then(res => res.json()).then(json => { return json as Array<string>;});

// };

// const validateText = async() : Promise<Array<string>> => {
// 	const response = await fetch('https://localhost:7059/validate', {method: 'POST', body: 'a=1'});
// 	const data = await response.json();
// 	return data as Array<string>;
// };







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
			return { status:500, graph:{nodes:[], edges:[]} };
		} else {
			console.log('unexpected error: ', error);
			return { status:500, graph:{nodes:[], edges:[]} };
		}
	}
}