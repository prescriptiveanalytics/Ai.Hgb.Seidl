//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:/dev/workspaces/spa/Ai.Hgb.Seidl/src/Grammar/SeidlLexer.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Ai.Hgb.Seidl.Processor {
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class SeidlLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		ARRAY=1, STRING=2, INT=3, FLOAT=4, BOOL=5, STRUCT=6, MESSAGE=7, EDGETYPE=8, 
		NODETYPE=9, NODE=10, SURROGATE=11, META=12, FUNCTION=13, TYPEDEF=14, IMPORT=15, 
		INCLUDE=16, PROPERTY=17, TOPIC=18, INPUT=19, OUTPUT=20, CLIENT=21, SERVER=22, 
		PUBLISH=23, SUBSCRIBE=24, REQUEST=25, RESPONSE=26, PUB=27, SUB=28, REQ=29, 
		RES=30, AUX=31, NULL=32, TRUE=33, FALSE=34, IF=35, ELSE=36, ELSEIF=37, 
		FOR=38, IN=39, TO=40, WHILE=41, RETURN=42, AS=43, IMITATES=44, WITH=45, 
		LATEST=46, NAMEDEF=47, TAGDEF=48, PACKAGE=49, IMAGE=50, QUEUE=51, VAR=52, 
		COMMAND=53, DOT=54, STAR=55, COMMA=56, COLON=57, SEMI_COLON=58, ASSIGN=59, 
		ADD=60, MINUS=61, DIV=62, INTERPOLATION=63, ARROW=64, HEAVYARROW=65, QUERYARROW_BEGIN=66, 
		QUERYHARROW_BEGIN=67, QUERYARROW_END=68, QUERYHARROW_END=69, EQUAL=70, 
		UNEQUAL=71, GREATERTHAN=72, GREATEREQUALTHAN=73, LESSTHAN=74, LESSEQUALTHAN=75, 
		AND=76, OR=77, NOT=78, OPEN_PAREN=79, CLOSE_PAREN=80, OPEN_BRACE=81, CLOSE_BRACE=82, 
		OPEN_BRACKET=83, CLOSE_BRACKET=84, NAME=85, WORD=86, STRINGLITERAL=87, 
		NORMALSTRING=88, CHARSTRING=89, LONGSTRING=90, INTEGER=91, FLOATINGPOINTNUMBER=92, 
		WHITESPACE=93, STMEND=94, COMMENT=95, LINECOMMENT=96, SHEBANG=97;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"ARRAY", "STRING", "INT", "FLOAT", "BOOL", "STRUCT", "MESSAGE", "EDGETYPE", 
		"NODETYPE", "NODE", "SURROGATE", "META", "FUNCTION", "TYPEDEF", "IMPORT", 
		"INCLUDE", "PROPERTY", "TOPIC", "INPUT", "OUTPUT", "CLIENT", "SERVER", 
		"PUBLISH", "SUBSCRIBE", "REQUEST", "RESPONSE", "PUB", "SUB", "REQ", "RES", 
		"AUX", "NULL", "TRUE", "FALSE", "IF", "ELSE", "ELSEIF", "FOR", "IN", "TO", 
		"WHILE", "RETURN", "AS", "IMITATES", "WITH", "LATEST", "NAMEDEF", "TAGDEF", 
		"PACKAGE", "IMAGE", "QUEUE", "VAR", "COMMAND", "DOT", "STAR", "COMMA", 
		"COLON", "SEMI_COLON", "ASSIGN", "ADD", "MINUS", "DIV", "INTERPOLATION", 
		"ARROW", "HEAVYARROW", "QUERYARROW_BEGIN", "QUERYHARROW_BEGIN", "QUERYARROW_END", 
		"QUERYHARROW_END", "EQUAL", "UNEQUAL", "GREATERTHAN", "GREATEREQUALTHAN", 
		"LESSTHAN", "LESSEQUALTHAN", "AND", "OR", "NOT", "OPEN_PAREN", "CLOSE_PAREN", 
		"OPEN_BRACE", "CLOSE_BRACE", "OPEN_BRACKET", "CLOSE_BRACKET", "LOWERCASE", 
		"UPPERCASE", "DIGIT", "NESTEDSTRING", "ESCAPESEQUENCE", "SEMICOLON", "NEWLINE", 
		"NAME", "WORD", "STRINGLITERAL", "NORMALSTRING", "CHARSTRING", "LONGSTRING", 
		"INTEGER", "FLOATINGPOINTNUMBER", "WHITESPACE", "STMEND", "COMMENT", "LINECOMMENT", 
		"SHEBANG"
	};


	public SeidlLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public SeidlLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'[]'", "'string'", "'int'", "'float'", "'bool'", "'struct'", "'message'", 
		"'edgetype'", "'nodetype'", "'node'", "'surrogate'", "'meta'", "'function'", 
		"'typedef'", "'import'", "'include'", "'property'", "'topic'", "'input'", 
		"'output'", "'client'", "'server'", "'publish'", "'subscribe'", "'request'", 
		"'response'", "'pub'", "'sub'", "'req'", "'res'", "'aux'", "'null'", "'true'", 
		"'false'", "'if'", "'else'", "'else if'", "'for'", "'in'", "'to'", "'while'", 
		"'return'", "'as'", "'imitates'", "'with'", "'latest'", "'name'", "'tag'", 
		"'package'", "'image'", "'queue'", "'var'", "'command'", "'.'", "'*'", 
		"','", "':'", "';'", "'='", "'+'", "'-'", "'/'", "'$'", "'-->'", "'==>'", 
		"'-:'", "'=:'", "'->'", "'=>'", "'=='", "'!='", "'>'", "'>='", "'<'", 
		"'<='", "'and'", "'or'", "'not'", "'('", "')'", "'{'", "'}'", "'['", "']'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "ARRAY", "STRING", "INT", "FLOAT", "BOOL", "STRUCT", "MESSAGE", 
		"EDGETYPE", "NODETYPE", "NODE", "SURROGATE", "META", "FUNCTION", "TYPEDEF", 
		"IMPORT", "INCLUDE", "PROPERTY", "TOPIC", "INPUT", "OUTPUT", "CLIENT", 
		"SERVER", "PUBLISH", "SUBSCRIBE", "REQUEST", "RESPONSE", "PUB", "SUB", 
		"REQ", "RES", "AUX", "NULL", "TRUE", "FALSE", "IF", "ELSE", "ELSEIF", 
		"FOR", "IN", "TO", "WHILE", "RETURN", "AS", "IMITATES", "WITH", "LATEST", 
		"NAMEDEF", "TAGDEF", "PACKAGE", "IMAGE", "QUEUE", "VAR", "COMMAND", "DOT", 
		"STAR", "COMMA", "COLON", "SEMI_COLON", "ASSIGN", "ADD", "MINUS", "DIV", 
		"INTERPOLATION", "ARROW", "HEAVYARROW", "QUERYARROW_BEGIN", "QUERYHARROW_BEGIN", 
		"QUERYARROW_END", "QUERYHARROW_END", "EQUAL", "UNEQUAL", "GREATERTHAN", 
		"GREATEREQUALTHAN", "LESSTHAN", "LESSEQUALTHAN", "AND", "OR", "NOT", "OPEN_PAREN", 
		"CLOSE_PAREN", "OPEN_BRACE", "CLOSE_BRACE", "OPEN_BRACKET", "CLOSE_BRACKET", 
		"NAME", "WORD", "STRINGLITERAL", "NORMALSTRING", "CHARSTRING", "LONGSTRING", 
		"INTEGER", "FLOATINGPOINTNUMBER", "WHITESPACE", "STMEND", "COMMENT", "LINECOMMENT", 
		"SHEBANG"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "SeidlLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static SeidlLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,97,793,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,2,44,7,44,2,45,7,45,2,46,7,46,2,47,7,47,2,48,7,48,2,49,
		7,49,2,50,7,50,2,51,7,51,2,52,7,52,2,53,7,53,2,54,7,54,2,55,7,55,2,56,
		7,56,2,57,7,57,2,58,7,58,2,59,7,59,2,60,7,60,2,61,7,61,2,62,7,62,2,63,
		7,63,2,64,7,64,2,65,7,65,2,66,7,66,2,67,7,67,2,68,7,68,2,69,7,69,2,70,
		7,70,2,71,7,71,2,72,7,72,2,73,7,73,2,74,7,74,2,75,7,75,2,76,7,76,2,77,
		7,77,2,78,7,78,2,79,7,79,2,80,7,80,2,81,7,81,2,82,7,82,2,83,7,83,2,84,
		7,84,2,85,7,85,2,86,7,86,2,87,7,87,2,88,7,88,2,89,7,89,2,90,7,90,2,91,
		7,91,2,92,7,92,2,93,7,93,2,94,7,94,2,95,7,95,2,96,7,96,2,97,7,97,2,98,
		7,98,2,99,7,99,2,100,7,100,2,101,7,101,2,102,7,102,2,103,7,103,1,0,1,0,
		1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,
		3,1,4,1,4,1,4,1,4,1,4,1,5,1,5,1,5,1,5,1,5,1,5,1,5,1,6,1,6,1,6,1,6,1,6,
		1,6,1,6,1,6,1,7,1,7,1,7,1,7,1,7,1,7,1,7,1,7,1,7,1,8,1,8,1,8,1,8,1,8,1,
		8,1,8,1,8,1,8,1,9,1,9,1,9,1,9,1,9,1,10,1,10,1,10,1,10,1,10,1,10,1,10,1,
		10,1,10,1,10,1,11,1,11,1,11,1,11,1,11,1,12,1,12,1,12,1,12,1,12,1,12,1,
		12,1,12,1,12,1,13,1,13,1,13,1,13,1,13,1,13,1,13,1,13,1,14,1,14,1,14,1,
		14,1,14,1,14,1,14,1,15,1,15,1,15,1,15,1,15,1,15,1,15,1,15,1,16,1,16,1,
		16,1,16,1,16,1,16,1,16,1,16,1,16,1,17,1,17,1,17,1,17,1,17,1,17,1,18,1,
		18,1,18,1,18,1,18,1,18,1,19,1,19,1,19,1,19,1,19,1,19,1,19,1,20,1,20,1,
		20,1,20,1,20,1,20,1,20,1,21,1,21,1,21,1,21,1,21,1,21,1,21,1,22,1,22,1,
		22,1,22,1,22,1,22,1,22,1,22,1,23,1,23,1,23,1,23,1,23,1,23,1,23,1,23,1,
		23,1,23,1,24,1,24,1,24,1,24,1,24,1,24,1,24,1,24,1,25,1,25,1,25,1,25,1,
		25,1,25,1,25,1,25,1,25,1,26,1,26,1,26,1,26,1,27,1,27,1,27,1,27,1,28,1,
		28,1,28,1,28,1,29,1,29,1,29,1,29,1,30,1,30,1,30,1,30,1,31,1,31,1,31,1,
		31,1,31,1,32,1,32,1,32,1,32,1,32,1,33,1,33,1,33,1,33,1,33,1,33,1,34,1,
		34,1,34,1,35,1,35,1,35,1,35,1,35,1,36,1,36,1,36,1,36,1,36,1,36,1,36,1,
		36,1,37,1,37,1,37,1,37,1,38,1,38,1,38,1,39,1,39,1,39,1,40,1,40,1,40,1,
		40,1,40,1,40,1,41,1,41,1,41,1,41,1,41,1,41,1,41,1,42,1,42,1,42,1,43,1,
		43,1,43,1,43,1,43,1,43,1,43,1,43,1,43,1,44,1,44,1,44,1,44,1,44,1,45,1,
		45,1,45,1,45,1,45,1,45,1,45,1,46,1,46,1,46,1,46,1,46,1,47,1,47,1,47,1,
		47,1,48,1,48,1,48,1,48,1,48,1,48,1,48,1,48,1,49,1,49,1,49,1,49,1,49,1,
		49,1,50,1,50,1,50,1,50,1,50,1,50,1,51,1,51,1,51,1,51,1,52,1,52,1,52,1,
		52,1,52,1,52,1,52,1,52,1,53,1,53,1,54,1,54,1,55,1,55,1,56,1,56,1,57,1,
		57,1,58,1,58,1,59,1,59,1,60,1,60,1,61,1,61,1,62,1,62,1,63,1,63,1,63,1,
		63,1,64,1,64,1,64,1,64,1,65,1,65,1,65,1,66,1,66,1,66,1,67,1,67,1,67,1,
		68,1,68,1,68,1,69,1,69,1,69,1,70,1,70,1,70,1,71,1,71,1,72,1,72,1,72,1,
		73,1,73,1,74,1,74,1,74,1,75,1,75,1,75,1,75,1,76,1,76,1,76,1,77,1,77,1,
		77,1,77,1,78,1,78,1,79,1,79,1,80,1,80,1,81,1,81,1,82,1,82,1,83,1,83,1,
		84,1,84,1,85,1,85,1,86,1,86,1,87,1,87,1,87,1,87,1,87,1,87,5,87,628,8,87,
		10,87,12,87,631,9,87,1,87,3,87,634,8,87,1,88,1,88,1,88,1,88,3,88,640,8,
		88,1,88,3,88,643,8,88,1,89,1,89,1,90,1,90,1,90,3,90,650,8,90,1,91,1,91,
		5,91,654,8,91,10,91,12,91,657,9,91,1,92,1,92,4,92,661,8,92,11,92,12,92,
		662,1,93,1,93,5,93,667,8,93,10,93,12,93,670,9,93,1,93,1,93,1,94,1,94,1,
		94,5,94,677,8,94,10,94,12,94,680,9,94,1,94,1,94,1,95,1,95,1,95,5,95,687,
		8,95,10,95,12,95,690,9,95,1,95,1,95,1,96,1,96,1,96,1,96,1,97,4,97,699,
		8,97,11,97,12,97,700,1,98,4,98,704,8,98,11,98,12,98,705,1,98,1,98,4,98,
		710,8,98,11,98,12,98,711,3,98,714,8,98,1,99,4,99,717,8,99,11,99,12,99,
		718,1,99,1,99,1,100,1,100,5,100,725,8,100,10,100,12,100,728,9,100,1,100,
		4,100,731,8,100,11,100,12,100,732,3,100,735,8,100,1,101,1,101,1,101,1,
		101,1,101,1,101,1,101,1,101,1,102,1,102,1,102,1,102,5,102,749,8,102,10,
		102,12,102,752,9,102,1,102,1,102,5,102,756,8,102,10,102,12,102,759,9,102,
		1,102,1,102,5,102,763,8,102,10,102,12,102,766,9,102,1,102,1,102,5,102,
		770,8,102,10,102,12,102,773,9,102,3,102,775,8,102,1,102,1,102,1,102,3,
		102,780,8,102,1,102,1,102,1,103,1,103,1,103,5,103,787,8,103,10,103,12,
		103,790,9,103,1,103,1,103,2,629,668,0,104,1,1,3,2,5,3,7,4,9,5,11,6,13,
		7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,29,15,31,16,33,17,35,18,37,19,
		39,20,41,21,43,22,45,23,47,24,49,25,51,26,53,27,55,28,57,29,59,30,61,31,
		63,32,65,33,67,34,69,35,71,36,73,37,75,38,77,39,79,40,81,41,83,42,85,43,
		87,44,89,45,91,46,93,47,95,48,97,49,99,50,101,51,103,52,105,53,107,54,
		109,55,111,56,113,57,115,58,117,59,119,60,121,61,123,62,125,63,127,64,
		129,65,131,66,133,67,135,68,137,69,139,70,141,71,143,72,145,73,147,74,
		149,75,151,76,153,77,155,78,157,79,159,80,161,81,163,82,165,83,167,84,
		169,0,171,0,173,0,175,0,177,0,179,0,181,0,183,85,185,86,187,87,189,88,
		191,89,193,90,195,91,197,92,199,93,201,94,203,95,205,96,207,97,1,0,14,
		1,0,97,122,1,0,65,90,1,0,48,57,10,0,34,34,39,39,92,92,97,98,102,102,110,
		110,114,114,116,116,118,118,122,122,2,0,10,10,13,13,3,0,65,90,95,95,97,
		122,4,0,48,57,65,90,95,95,97,122,2,0,34,34,92,92,2,0,39,39,92,92,1,0,46,
		46,2,0,9,9,32,32,4,0,10,10,13,13,61,61,91,91,3,0,10,10,13,13,91,91,2,1,
		10,10,13,13,815,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,
		0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,
		0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,
		1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,
		0,0,43,1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,0,0,53,
		1,0,0,0,0,55,1,0,0,0,0,57,1,0,0,0,0,59,1,0,0,0,0,61,1,0,0,0,0,63,1,0,0,
		0,0,65,1,0,0,0,0,67,1,0,0,0,0,69,1,0,0,0,0,71,1,0,0,0,0,73,1,0,0,0,0,75,
		1,0,0,0,0,77,1,0,0,0,0,79,1,0,0,0,0,81,1,0,0,0,0,83,1,0,0,0,0,85,1,0,0,
		0,0,87,1,0,0,0,0,89,1,0,0,0,0,91,1,0,0,0,0,93,1,0,0,0,0,95,1,0,0,0,0,97,
		1,0,0,0,0,99,1,0,0,0,0,101,1,0,0,0,0,103,1,0,0,0,0,105,1,0,0,0,0,107,1,
		0,0,0,0,109,1,0,0,0,0,111,1,0,0,0,0,113,1,0,0,0,0,115,1,0,0,0,0,117,1,
		0,0,0,0,119,1,0,0,0,0,121,1,0,0,0,0,123,1,0,0,0,0,125,1,0,0,0,0,127,1,
		0,0,0,0,129,1,0,0,0,0,131,1,0,0,0,0,133,1,0,0,0,0,135,1,0,0,0,0,137,1,
		0,0,0,0,139,1,0,0,0,0,141,1,0,0,0,0,143,1,0,0,0,0,145,1,0,0,0,0,147,1,
		0,0,0,0,149,1,0,0,0,0,151,1,0,0,0,0,153,1,0,0,0,0,155,1,0,0,0,0,157,1,
		0,0,0,0,159,1,0,0,0,0,161,1,0,0,0,0,163,1,0,0,0,0,165,1,0,0,0,0,167,1,
		0,0,0,0,183,1,0,0,0,0,185,1,0,0,0,0,187,1,0,0,0,0,189,1,0,0,0,0,191,1,
		0,0,0,0,193,1,0,0,0,0,195,1,0,0,0,0,197,1,0,0,0,0,199,1,0,0,0,0,201,1,
		0,0,0,0,203,1,0,0,0,0,205,1,0,0,0,0,207,1,0,0,0,1,209,1,0,0,0,3,212,1,
		0,0,0,5,219,1,0,0,0,7,223,1,0,0,0,9,229,1,0,0,0,11,234,1,0,0,0,13,241,
		1,0,0,0,15,249,1,0,0,0,17,258,1,0,0,0,19,267,1,0,0,0,21,272,1,0,0,0,23,
		282,1,0,0,0,25,287,1,0,0,0,27,296,1,0,0,0,29,304,1,0,0,0,31,311,1,0,0,
		0,33,319,1,0,0,0,35,328,1,0,0,0,37,334,1,0,0,0,39,340,1,0,0,0,41,347,1,
		0,0,0,43,354,1,0,0,0,45,361,1,0,0,0,47,369,1,0,0,0,49,379,1,0,0,0,51,387,
		1,0,0,0,53,396,1,0,0,0,55,400,1,0,0,0,57,404,1,0,0,0,59,408,1,0,0,0,61,
		412,1,0,0,0,63,416,1,0,0,0,65,421,1,0,0,0,67,426,1,0,0,0,69,432,1,0,0,
		0,71,435,1,0,0,0,73,440,1,0,0,0,75,448,1,0,0,0,77,452,1,0,0,0,79,455,1,
		0,0,0,81,458,1,0,0,0,83,464,1,0,0,0,85,471,1,0,0,0,87,474,1,0,0,0,89,483,
		1,0,0,0,91,488,1,0,0,0,93,495,1,0,0,0,95,500,1,0,0,0,97,504,1,0,0,0,99,
		512,1,0,0,0,101,518,1,0,0,0,103,524,1,0,0,0,105,528,1,0,0,0,107,536,1,
		0,0,0,109,538,1,0,0,0,111,540,1,0,0,0,113,542,1,0,0,0,115,544,1,0,0,0,
		117,546,1,0,0,0,119,548,1,0,0,0,121,550,1,0,0,0,123,552,1,0,0,0,125,554,
		1,0,0,0,127,556,1,0,0,0,129,560,1,0,0,0,131,564,1,0,0,0,133,567,1,0,0,
		0,135,570,1,0,0,0,137,573,1,0,0,0,139,576,1,0,0,0,141,579,1,0,0,0,143,
		582,1,0,0,0,145,584,1,0,0,0,147,587,1,0,0,0,149,589,1,0,0,0,151,592,1,
		0,0,0,153,596,1,0,0,0,155,599,1,0,0,0,157,603,1,0,0,0,159,605,1,0,0,0,
		161,607,1,0,0,0,163,609,1,0,0,0,165,611,1,0,0,0,167,613,1,0,0,0,169,615,
		1,0,0,0,171,617,1,0,0,0,173,619,1,0,0,0,175,633,1,0,0,0,177,642,1,0,0,
		0,179,644,1,0,0,0,181,649,1,0,0,0,183,651,1,0,0,0,185,660,1,0,0,0,187,
		664,1,0,0,0,189,673,1,0,0,0,191,683,1,0,0,0,193,693,1,0,0,0,195,698,1,
		0,0,0,197,703,1,0,0,0,199,716,1,0,0,0,201,734,1,0,0,0,203,736,1,0,0,0,
		205,744,1,0,0,0,207,783,1,0,0,0,209,210,5,91,0,0,210,211,5,93,0,0,211,
		2,1,0,0,0,212,213,5,115,0,0,213,214,5,116,0,0,214,215,5,114,0,0,215,216,
		5,105,0,0,216,217,5,110,0,0,217,218,5,103,0,0,218,4,1,0,0,0,219,220,5,
		105,0,0,220,221,5,110,0,0,221,222,5,116,0,0,222,6,1,0,0,0,223,224,5,102,
		0,0,224,225,5,108,0,0,225,226,5,111,0,0,226,227,5,97,0,0,227,228,5,116,
		0,0,228,8,1,0,0,0,229,230,5,98,0,0,230,231,5,111,0,0,231,232,5,111,0,0,
		232,233,5,108,0,0,233,10,1,0,0,0,234,235,5,115,0,0,235,236,5,116,0,0,236,
		237,5,114,0,0,237,238,5,117,0,0,238,239,5,99,0,0,239,240,5,116,0,0,240,
		12,1,0,0,0,241,242,5,109,0,0,242,243,5,101,0,0,243,244,5,115,0,0,244,245,
		5,115,0,0,245,246,5,97,0,0,246,247,5,103,0,0,247,248,5,101,0,0,248,14,
		1,0,0,0,249,250,5,101,0,0,250,251,5,100,0,0,251,252,5,103,0,0,252,253,
		5,101,0,0,253,254,5,116,0,0,254,255,5,121,0,0,255,256,5,112,0,0,256,257,
		5,101,0,0,257,16,1,0,0,0,258,259,5,110,0,0,259,260,5,111,0,0,260,261,5,
		100,0,0,261,262,5,101,0,0,262,263,5,116,0,0,263,264,5,121,0,0,264,265,
		5,112,0,0,265,266,5,101,0,0,266,18,1,0,0,0,267,268,5,110,0,0,268,269,5,
		111,0,0,269,270,5,100,0,0,270,271,5,101,0,0,271,20,1,0,0,0,272,273,5,115,
		0,0,273,274,5,117,0,0,274,275,5,114,0,0,275,276,5,114,0,0,276,277,5,111,
		0,0,277,278,5,103,0,0,278,279,5,97,0,0,279,280,5,116,0,0,280,281,5,101,
		0,0,281,22,1,0,0,0,282,283,5,109,0,0,283,284,5,101,0,0,284,285,5,116,0,
		0,285,286,5,97,0,0,286,24,1,0,0,0,287,288,5,102,0,0,288,289,5,117,0,0,
		289,290,5,110,0,0,290,291,5,99,0,0,291,292,5,116,0,0,292,293,5,105,0,0,
		293,294,5,111,0,0,294,295,5,110,0,0,295,26,1,0,0,0,296,297,5,116,0,0,297,
		298,5,121,0,0,298,299,5,112,0,0,299,300,5,101,0,0,300,301,5,100,0,0,301,
		302,5,101,0,0,302,303,5,102,0,0,303,28,1,0,0,0,304,305,5,105,0,0,305,306,
		5,109,0,0,306,307,5,112,0,0,307,308,5,111,0,0,308,309,5,114,0,0,309,310,
		5,116,0,0,310,30,1,0,0,0,311,312,5,105,0,0,312,313,5,110,0,0,313,314,5,
		99,0,0,314,315,5,108,0,0,315,316,5,117,0,0,316,317,5,100,0,0,317,318,5,
		101,0,0,318,32,1,0,0,0,319,320,5,112,0,0,320,321,5,114,0,0,321,322,5,111,
		0,0,322,323,5,112,0,0,323,324,5,101,0,0,324,325,5,114,0,0,325,326,5,116,
		0,0,326,327,5,121,0,0,327,34,1,0,0,0,328,329,5,116,0,0,329,330,5,111,0,
		0,330,331,5,112,0,0,331,332,5,105,0,0,332,333,5,99,0,0,333,36,1,0,0,0,
		334,335,5,105,0,0,335,336,5,110,0,0,336,337,5,112,0,0,337,338,5,117,0,
		0,338,339,5,116,0,0,339,38,1,0,0,0,340,341,5,111,0,0,341,342,5,117,0,0,
		342,343,5,116,0,0,343,344,5,112,0,0,344,345,5,117,0,0,345,346,5,116,0,
		0,346,40,1,0,0,0,347,348,5,99,0,0,348,349,5,108,0,0,349,350,5,105,0,0,
		350,351,5,101,0,0,351,352,5,110,0,0,352,353,5,116,0,0,353,42,1,0,0,0,354,
		355,5,115,0,0,355,356,5,101,0,0,356,357,5,114,0,0,357,358,5,118,0,0,358,
		359,5,101,0,0,359,360,5,114,0,0,360,44,1,0,0,0,361,362,5,112,0,0,362,363,
		5,117,0,0,363,364,5,98,0,0,364,365,5,108,0,0,365,366,5,105,0,0,366,367,
		5,115,0,0,367,368,5,104,0,0,368,46,1,0,0,0,369,370,5,115,0,0,370,371,5,
		117,0,0,371,372,5,98,0,0,372,373,5,115,0,0,373,374,5,99,0,0,374,375,5,
		114,0,0,375,376,5,105,0,0,376,377,5,98,0,0,377,378,5,101,0,0,378,48,1,
		0,0,0,379,380,5,114,0,0,380,381,5,101,0,0,381,382,5,113,0,0,382,383,5,
		117,0,0,383,384,5,101,0,0,384,385,5,115,0,0,385,386,5,116,0,0,386,50,1,
		0,0,0,387,388,5,114,0,0,388,389,5,101,0,0,389,390,5,115,0,0,390,391,5,
		112,0,0,391,392,5,111,0,0,392,393,5,110,0,0,393,394,5,115,0,0,394,395,
		5,101,0,0,395,52,1,0,0,0,396,397,5,112,0,0,397,398,5,117,0,0,398,399,5,
		98,0,0,399,54,1,0,0,0,400,401,5,115,0,0,401,402,5,117,0,0,402,403,5,98,
		0,0,403,56,1,0,0,0,404,405,5,114,0,0,405,406,5,101,0,0,406,407,5,113,0,
		0,407,58,1,0,0,0,408,409,5,114,0,0,409,410,5,101,0,0,410,411,5,115,0,0,
		411,60,1,0,0,0,412,413,5,97,0,0,413,414,5,117,0,0,414,415,5,120,0,0,415,
		62,1,0,0,0,416,417,5,110,0,0,417,418,5,117,0,0,418,419,5,108,0,0,419,420,
		5,108,0,0,420,64,1,0,0,0,421,422,5,116,0,0,422,423,5,114,0,0,423,424,5,
		117,0,0,424,425,5,101,0,0,425,66,1,0,0,0,426,427,5,102,0,0,427,428,5,97,
		0,0,428,429,5,108,0,0,429,430,5,115,0,0,430,431,5,101,0,0,431,68,1,0,0,
		0,432,433,5,105,0,0,433,434,5,102,0,0,434,70,1,0,0,0,435,436,5,101,0,0,
		436,437,5,108,0,0,437,438,5,115,0,0,438,439,5,101,0,0,439,72,1,0,0,0,440,
		441,5,101,0,0,441,442,5,108,0,0,442,443,5,115,0,0,443,444,5,101,0,0,444,
		445,5,32,0,0,445,446,5,105,0,0,446,447,5,102,0,0,447,74,1,0,0,0,448,449,
		5,102,0,0,449,450,5,111,0,0,450,451,5,114,0,0,451,76,1,0,0,0,452,453,5,
		105,0,0,453,454,5,110,0,0,454,78,1,0,0,0,455,456,5,116,0,0,456,457,5,111,
		0,0,457,80,1,0,0,0,458,459,5,119,0,0,459,460,5,104,0,0,460,461,5,105,0,
		0,461,462,5,108,0,0,462,463,5,101,0,0,463,82,1,0,0,0,464,465,5,114,0,0,
		465,466,5,101,0,0,466,467,5,116,0,0,467,468,5,117,0,0,468,469,5,114,0,
		0,469,470,5,110,0,0,470,84,1,0,0,0,471,472,5,97,0,0,472,473,5,115,0,0,
		473,86,1,0,0,0,474,475,5,105,0,0,475,476,5,109,0,0,476,477,5,105,0,0,477,
		478,5,116,0,0,478,479,5,97,0,0,479,480,5,116,0,0,480,481,5,101,0,0,481,
		482,5,115,0,0,482,88,1,0,0,0,483,484,5,119,0,0,484,485,5,105,0,0,485,486,
		5,116,0,0,486,487,5,104,0,0,487,90,1,0,0,0,488,489,5,108,0,0,489,490,5,
		97,0,0,490,491,5,116,0,0,491,492,5,101,0,0,492,493,5,115,0,0,493,494,5,
		116,0,0,494,92,1,0,0,0,495,496,5,110,0,0,496,497,5,97,0,0,497,498,5,109,
		0,0,498,499,5,101,0,0,499,94,1,0,0,0,500,501,5,116,0,0,501,502,5,97,0,
		0,502,503,5,103,0,0,503,96,1,0,0,0,504,505,5,112,0,0,505,506,5,97,0,0,
		506,507,5,99,0,0,507,508,5,107,0,0,508,509,5,97,0,0,509,510,5,103,0,0,
		510,511,5,101,0,0,511,98,1,0,0,0,512,513,5,105,0,0,513,514,5,109,0,0,514,
		515,5,97,0,0,515,516,5,103,0,0,516,517,5,101,0,0,517,100,1,0,0,0,518,519,
		5,113,0,0,519,520,5,117,0,0,520,521,5,101,0,0,521,522,5,117,0,0,522,523,
		5,101,0,0,523,102,1,0,0,0,524,525,5,118,0,0,525,526,5,97,0,0,526,527,5,
		114,0,0,527,104,1,0,0,0,528,529,5,99,0,0,529,530,5,111,0,0,530,531,5,109,
		0,0,531,532,5,109,0,0,532,533,5,97,0,0,533,534,5,110,0,0,534,535,5,100,
		0,0,535,106,1,0,0,0,536,537,5,46,0,0,537,108,1,0,0,0,538,539,5,42,0,0,
		539,110,1,0,0,0,540,541,5,44,0,0,541,112,1,0,0,0,542,543,5,58,0,0,543,
		114,1,0,0,0,544,545,5,59,0,0,545,116,1,0,0,0,546,547,5,61,0,0,547,118,
		1,0,0,0,548,549,5,43,0,0,549,120,1,0,0,0,550,551,5,45,0,0,551,122,1,0,
		0,0,552,553,5,47,0,0,553,124,1,0,0,0,554,555,5,36,0,0,555,126,1,0,0,0,
		556,557,5,45,0,0,557,558,5,45,0,0,558,559,5,62,0,0,559,128,1,0,0,0,560,
		561,5,61,0,0,561,562,5,61,0,0,562,563,5,62,0,0,563,130,1,0,0,0,564,565,
		5,45,0,0,565,566,5,58,0,0,566,132,1,0,0,0,567,568,5,61,0,0,568,569,5,58,
		0,0,569,134,1,0,0,0,570,571,5,45,0,0,571,572,5,62,0,0,572,136,1,0,0,0,
		573,574,5,61,0,0,574,575,5,62,0,0,575,138,1,0,0,0,576,577,5,61,0,0,577,
		578,5,61,0,0,578,140,1,0,0,0,579,580,5,33,0,0,580,581,5,61,0,0,581,142,
		1,0,0,0,582,583,5,62,0,0,583,144,1,0,0,0,584,585,5,62,0,0,585,586,5,61,
		0,0,586,146,1,0,0,0,587,588,5,60,0,0,588,148,1,0,0,0,589,590,5,60,0,0,
		590,591,5,61,0,0,591,150,1,0,0,0,592,593,5,97,0,0,593,594,5,110,0,0,594,
		595,5,100,0,0,595,152,1,0,0,0,596,597,5,111,0,0,597,598,5,114,0,0,598,
		154,1,0,0,0,599,600,5,110,0,0,600,601,5,111,0,0,601,602,5,116,0,0,602,
		156,1,0,0,0,603,604,5,40,0,0,604,158,1,0,0,0,605,606,5,41,0,0,606,160,
		1,0,0,0,607,608,5,123,0,0,608,162,1,0,0,0,609,610,5,125,0,0,610,164,1,
		0,0,0,611,612,5,91,0,0,612,166,1,0,0,0,613,614,5,93,0,0,614,168,1,0,0,
		0,615,616,7,0,0,0,616,170,1,0,0,0,617,618,7,1,0,0,618,172,1,0,0,0,619,
		620,7,2,0,0,620,174,1,0,0,0,621,622,5,61,0,0,622,623,3,175,87,0,623,624,
		5,61,0,0,624,634,1,0,0,0,625,629,5,91,0,0,626,628,9,0,0,0,627,626,1,0,
		0,0,628,631,1,0,0,0,629,630,1,0,0,0,629,627,1,0,0,0,630,632,1,0,0,0,631,
		629,1,0,0,0,632,634,5,93,0,0,633,621,1,0,0,0,633,625,1,0,0,0,634,176,1,
		0,0,0,635,636,5,92,0,0,636,643,7,3,0,0,637,639,5,92,0,0,638,640,5,13,0,
		0,639,638,1,0,0,0,639,640,1,0,0,0,640,641,1,0,0,0,641,643,5,10,0,0,642,
		635,1,0,0,0,642,637,1,0,0,0,643,178,1,0,0,0,644,645,5,59,0,0,645,180,1,
		0,0,0,646,647,5,13,0,0,647,650,5,10,0,0,648,650,7,4,0,0,649,646,1,0,0,
		0,649,648,1,0,0,0,650,182,1,0,0,0,651,655,7,5,0,0,652,654,7,6,0,0,653,
		652,1,0,0,0,654,657,1,0,0,0,655,653,1,0,0,0,655,656,1,0,0,0,656,184,1,
		0,0,0,657,655,1,0,0,0,658,661,3,169,84,0,659,661,3,171,85,0,660,658,1,
		0,0,0,660,659,1,0,0,0,661,662,1,0,0,0,662,660,1,0,0,0,662,663,1,0,0,0,
		663,186,1,0,0,0,664,668,5,34,0,0,665,667,9,0,0,0,666,665,1,0,0,0,667,670,
		1,0,0,0,668,669,1,0,0,0,668,666,1,0,0,0,669,671,1,0,0,0,670,668,1,0,0,
		0,671,672,5,34,0,0,672,188,1,0,0,0,673,678,5,34,0,0,674,677,3,177,88,0,
		675,677,8,7,0,0,676,674,1,0,0,0,676,675,1,0,0,0,677,680,1,0,0,0,678,676,
		1,0,0,0,678,679,1,0,0,0,679,681,1,0,0,0,680,678,1,0,0,0,681,682,5,34,0,
		0,682,190,1,0,0,0,683,688,5,39,0,0,684,687,3,177,88,0,685,687,8,8,0,0,
		686,684,1,0,0,0,686,685,1,0,0,0,687,690,1,0,0,0,688,686,1,0,0,0,688,689,
		1,0,0,0,689,691,1,0,0,0,690,688,1,0,0,0,691,692,5,39,0,0,692,192,1,0,0,
		0,693,694,5,91,0,0,694,695,3,175,87,0,695,696,5,93,0,0,696,194,1,0,0,0,
		697,699,3,173,86,0,698,697,1,0,0,0,699,700,1,0,0,0,700,698,1,0,0,0,700,
		701,1,0,0,0,701,196,1,0,0,0,702,704,3,173,86,0,703,702,1,0,0,0,704,705,
		1,0,0,0,705,703,1,0,0,0,705,706,1,0,0,0,706,713,1,0,0,0,707,709,7,9,0,
		0,708,710,3,173,86,0,709,708,1,0,0,0,710,711,1,0,0,0,711,709,1,0,0,0,711,
		712,1,0,0,0,712,714,1,0,0,0,713,707,1,0,0,0,713,714,1,0,0,0,714,198,1,
		0,0,0,715,717,7,10,0,0,716,715,1,0,0,0,717,718,1,0,0,0,718,716,1,0,0,0,
		718,719,1,0,0,0,719,720,1,0,0,0,720,721,6,99,0,0,721,200,1,0,0,0,722,726,
		3,179,89,0,723,725,3,181,90,0,724,723,1,0,0,0,725,728,1,0,0,0,726,724,
		1,0,0,0,726,727,1,0,0,0,727,735,1,0,0,0,728,726,1,0,0,0,729,731,3,181,
		90,0,730,729,1,0,0,0,731,732,1,0,0,0,732,730,1,0,0,0,732,733,1,0,0,0,733,
		735,1,0,0,0,734,722,1,0,0,0,734,730,1,0,0,0,735,202,1,0,0,0,736,737,5,
		35,0,0,737,738,5,91,0,0,738,739,1,0,0,0,739,740,3,175,87,0,740,741,5,93,
		0,0,741,742,1,0,0,0,742,743,6,101,1,0,743,204,1,0,0,0,744,774,5,35,0,0,
		745,775,1,0,0,0,746,750,5,91,0,0,747,749,5,61,0,0,748,747,1,0,0,0,749,
		752,1,0,0,0,750,748,1,0,0,0,750,751,1,0,0,0,751,775,1,0,0,0,752,750,1,
		0,0,0,753,757,5,91,0,0,754,756,5,61,0,0,755,754,1,0,0,0,756,759,1,0,0,
		0,757,755,1,0,0,0,757,758,1,0,0,0,758,760,1,0,0,0,759,757,1,0,0,0,760,
		764,8,11,0,0,761,763,8,4,0,0,762,761,1,0,0,0,763,766,1,0,0,0,764,762,1,
		0,0,0,764,765,1,0,0,0,765,775,1,0,0,0,766,764,1,0,0,0,767,771,8,12,0,0,
		768,770,8,4,0,0,769,768,1,0,0,0,770,773,1,0,0,0,771,769,1,0,0,0,771,772,
		1,0,0,0,772,775,1,0,0,0,773,771,1,0,0,0,774,745,1,0,0,0,774,746,1,0,0,
		0,774,753,1,0,0,0,774,767,1,0,0,0,775,779,1,0,0,0,776,777,5,13,0,0,777,
		780,5,10,0,0,778,780,7,13,0,0,779,776,1,0,0,0,779,778,1,0,0,0,780,781,
		1,0,0,0,781,782,6,102,1,0,782,206,1,0,0,0,783,784,5,35,0,0,784,788,5,33,
		0,0,785,787,8,4,0,0,786,785,1,0,0,0,787,790,1,0,0,0,788,786,1,0,0,0,788,
		789,1,0,0,0,789,791,1,0,0,0,790,788,1,0,0,0,791,792,6,103,1,0,792,208,
		1,0,0,0,29,0,629,633,639,642,649,655,660,662,668,676,678,686,688,700,705,
		711,713,718,726,732,734,750,757,764,771,774,779,788,2,6,0,0,0,1,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace Ai.Hgb.Seidl.Processor
