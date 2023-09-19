
// graph visualization (vis.js)
var graph, nodes, edges, data, container, options;
var nodesDict, nodesArr, edgesDict, edgesArr, nodeNamesDict;
var nodeEdgeCounter;
var graphInitialized = false;


const text = document.getElementById('doctext');
const graphobj = document.getElementById('graphobj');

// comm v1: event listener (vsc client extension)
// window.addEventListener('message', event => {
// 	const cmd = event.data.cmd;
// 	const graphdata = event.data.graph;

// 	if(cmd == "init") {
// 		initGraph(graphdata);
// 		graphInitialized = true;
// 	} else if(cmd == "update") {
// 		processGraph(graphdata);
// 	}				
// });


// comm v2: socket.io (lsp server)																				
var socket = io(websocketaddress, {
	query: { roomName: roomname },
	rejectUnauthorized: false
});

socket.on("connect", () => {
	// text.innerHTML = "client: " + socket.id;
});

socket.on("msg", (payload) => {
	const cmd = payload.cmd;
	const graph = payload.graph;

	if (graphInitialized) {
		processGraph(graph);
		console.log(graph);
	} else {
		initGraph(graph);
		graphInitialized = true;
	}
});

// comm init
window.addEventListener('message', event => {
	const cmd = event.data.cmd;
	const rootdoctext = event.data.text;

	socket.emit("initGraph", { rootdoctext: rootdoctext });
});



// vis node styles				
var changeChosenNodeLabel = function (values, id, selected, hovering) {
	values.color = '#339933'; //#000000
	//values.mod = 'bold';
};

var changeChosenNode = function (values, id, selected, hovering) {
	values.borderColor = '#339933'; //#000000
};

var nc0 = {
	margin: 12, shape: 'circle', borderWidth: 2, borderWidthSelected: 2, chosen: { label: changeChosenNodeLabel, node: changeChosenNode },
	color: { background: '#ffffff', border: '#666666' },
	font: { multi: 'html', color: '#666666', face: 'Open Sans, Helvetica, Arial' }
};

// vis edgle styles
// var ec0 = { length: 400, width: 1, color: { color: '#333333' }, dashes: true, arrows: { to: { enabled: true, scaleFactor: 0.5 } }, chosen: { label: ccelOnClicked, edge: cceOnClicked } }; // default
// var ec1 = { width: 1, color: { color: '#993333' }, dashes: false, arrows: { from: {enabled:true, scaleFactor: 0.5}, to: { enabled: true, scaleFactor: 0.5 } }, chosen: { label: ccelOnClicked, edge: cceOnClicked } }; // default
var ec0 = { width: 1, color: { color: '#333333' }, dashes: true, arrows: { to: { enabled: true, scaleFactor: 0.5 } }, chosen: { label: ccelOnClicked, edge: cceOnClicked } }; // default
var ec1 = { width: 1, color: { color: '333333' }, dashes: false, arrows: { from: {enabled:true, scaleFactor: 0.5}, to: { enabled: true, scaleFactor: 0.5 } }, smooth: {type: "curvedCCW", roundness: 0.4}, chosen: { label: ccelOnClicked, edge: cceOnClicked } }; // default

var cceOnClicked = function (values, id, selected, hovering) {
	values.width = 2;
	values.color = '#339933';
};

var ccelOnClicked = function (values, id, selected, hovering) {
	values.mod = 'bold';
};

var cceOnFromNodeClicked = function (values, id, selected, hovering) {
	values.width = 2;
	values.color = '#f95f6f';
};

var cceOnToNodeClicked = function (values, id, selected, hovering) {
	values.width = 2;
	values.color = '#00e5d4';
};

var echfrom = { chosen: { label: ccelOnClicked, edge: cceOnFromNodeClicked } };
var echto = { chosen: { label: ccelOnClicked, edge: cceOnToNodeClicked } };


function initGraph(graphrec) {
	nodesDict = {};
	nodesArr = [];
	edgesDict = {};
	edgesArr = [];
	nodeEdgeCounter = [];

	var count = 1;
	for (let n of graphrec.nodes) {
		let obj = {};
		Object.assign(obj, nc0);
		obj.id = n.name;
		obj.label = n.name;
		nodesArr.push(obj);
		count++;
	}

	for (let e of graphrec.edges) {
		let obj = {};
		if (e.type == "-->") Object.assign(obj, ec0);
		else Object.assign(obj, ec1);		
		// obj.id = e.from + "-->" + e.to;
		obj.id = e.id;
		obj.label = e.payload;
		obj.from = e.from;
		obj.to = e.to;
		obj.type = e.type;
		edgesArr.push(obj);
	}

	container = document.getElementById("graph");

	nodes = new vis.DataSet(nodesArr);
	edges = new vis.DataSet(edgesArr);

	data = {
		nodes: nodes,
		edges: edges
	};
	options = {
		layout: {
			hierarchical: {
				direction: "DU", // DU, LR, 
				sortMethod: "directed",
				parentCentralization: true,
				levelSeparation: 100
			}
		},
		edges: {
			smooth: true
		},
		physics: {
			enabled: false
		}
	};

	graph = new vis.Network(container, data, options);

}

function processGraph(graphrec) {
	if (!graphrec) return;

	var newNodesArr = [];
	var newEdgesArr = [];
	var newNodesDict = {};
	var newEdgesDict = {};

	// collect new graph data
	for (let n of graphrec.nodes) {
		newNodesDict[n.name] = {
			id: n.name,
			label: n.name
		};

		var obj = {};
		Object.assign(obj, nc0);
		obj.id = n.name;
		obj.label = n.name;
		newNodesArr.push(obj);
	}

	for (let e of graphrec.edges) {
		newEdgesDict[e.name] = {
			id: e.id,
			label: e.payload,
			from: e.from,
			to: e.to
		};

		let obj = {};
		if (e.type == "-->") Object.assign(obj, ec0);
		else Object.assign(obj, ec1);		
		// obj.id = e.from + "-->" + e.to;
		obj.id = e.id;
		obj.label = e.payload;
		obj.from = e.from;
		obj.to = e.to;
		obj.type = e.type;
		newEdgesArr.push(obj);
	}

	// remove old graph data
	for (let n of nodesArr) {
		var node = newNodesDict[n.name];
		if (!node) {
			data.nodes.remove([n.name]);
			// console.log("removing: " + n.name);
		}
	}
	for (let e of edgesArr) {
		var id = e.from + "-->" + e.to;
		var edge = newEdgesArr[id];
		if (!edge) {
			// console.log("removing: " + id);
			data.edges.remove([id]);
		}
	}

	edgesArr = newEdgesArr;
	nodesArr = newNodesArr;
	data.edges.update(edgesArr);
	data.nodes.update(nodesArr);
}
