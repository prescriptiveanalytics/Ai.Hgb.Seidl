// Generated from c:\dev\workspaces\spa\Sidl\src\Grammar\SidlParser.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class SidlParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		TYPE=1, ARRAY=2, STRING=3, INT=4, FLOAT=5, BOOL=6, STRUCT=7, MESSAGE=8, 
		NODETYPE=9, NODE=10, META=11, FUNCTION=12, IMPORT=13, INCLUDE=14, PROPERTY=15, 
		TOPIC=16, INPUT=17, OUTPUT=18, NULL=19, TRUE=20, FALSE=21, IF=22, ELSE=23, 
		ELSEIF=24, FOR=25, IN=26, WHILE=27, RETURN=28, DOT=29, STAR=30, COMMA=31, 
		COLON=32, SEMI_COLON=33, ASSIGN=34, ADD=35, MINUS=36, DIV=37, ARROW=38, 
		OPEN_PAREN=39, CLOSE_PAREN=40, OPEN_BRACE=41, CLOSE_BRACE=42, OPEN_BRACKET=43, 
		CLOSE_BRACKET=44, NAME=45, WORD=46, STRINGLITEARL=47, NORMALSTRING=48, 
		CHARSTRING=49, LONGSTRING=50, INTEGER=51, FLOATINGPOINTNUMBER=52, WHITESPACE=53, 
		STMEND=54, COMMENT=55, LINECOMMENT=56, SHEBANG=57;
	public static final int
		RULE_root = 0, RULE_set = 1, RULE_statement = 2, RULE_scope = 3, RULE_type = 4, 
		RULE_atomictype = 5, RULE_complextype = 6, RULE_graphtype = 7, RULE_variable = 8, 
		RULE_typename = 9, RULE_variablelist = 10, RULE_typedvariablelist = 11, 
		RULE_expressionlist = 12, RULE_expression = 13, RULE_arraydeclaration = 14, 
		RULE_arrayaccess = 15, RULE_fieldaccess = 16, RULE_lefthandside = 17, 
		RULE_importstatement = 18, RULE_typealiasingstatement = 19, RULE_functiondefinition = 20, 
		RULE_functionbody = 21, RULE_returnstatement = 22, RULE_functioncall = 23, 
		RULE_structdefinition = 24, RULE_messagetypename = 25, RULE_nodetypename = 26, 
		RULE_messagetypelist = 27, RULE_messagedefinition = 28, RULE_nodetypedefinition = 29, 
		RULE_nodetypesignature = 30, RULE_nodedefinition = 31, RULE_nodebody = 32, 
		RULE_metadefinition = 33, RULE_number = 34, RULE_string = 35, RULE_terminator = 36;
	private static String[] makeRuleNames() {
		return new String[] {
			"root", "set", "statement", "scope", "type", "atomictype", "complextype", 
			"graphtype", "variable", "typename", "variablelist", "typedvariablelist", 
			"expressionlist", "expression", "arraydeclaration", "arrayaccess", "fieldaccess", 
			"lefthandside", "importstatement", "typealiasingstatement", "functiondefinition", 
			"functionbody", "returnstatement", "functioncall", "structdefinition", 
			"messagetypename", "nodetypename", "messagetypelist", "messagedefinition", 
			"nodetypedefinition", "nodetypesignature", "nodedefinition", "nodebody", 
			"metadefinition", "number", "string", "terminator"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'type'", "'[]'", "'string'", "'int'", "'float'", "'bool'", "'struct'", 
			"'message'", "'nodetype'", "'node'", "'meta'", "'function'", "'import'", 
			"'include'", "'property'", "'topic'", "'input'", "'output'", "'null'", 
			"'true'", "'false'", "'if'", "'else'", "'else if'", "'for'", "'in'", 
			"'while'", "'return'", "'.'", "'*'", "','", "':'", "';'", "'='", "'+'", 
			"'-'", "'/'", "'-->'", "'('", "')'", "'{'", "'}'", "'['", "']'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "TYPE", "ARRAY", "STRING", "INT", "FLOAT", "BOOL", "STRUCT", "MESSAGE", 
			"NODETYPE", "NODE", "META", "FUNCTION", "IMPORT", "INCLUDE", "PROPERTY", 
			"TOPIC", "INPUT", "OUTPUT", "NULL", "TRUE", "FALSE", "IF", "ELSE", "ELSEIF", 
			"FOR", "IN", "WHILE", "RETURN", "DOT", "STAR", "COMMA", "COLON", "SEMI_COLON", 
			"ASSIGN", "ADD", "MINUS", "DIV", "ARROW", "OPEN_PAREN", "CLOSE_PAREN", 
			"OPEN_BRACE", "CLOSE_BRACE", "OPEN_BRACKET", "CLOSE_BRACKET", "NAME", 
			"WORD", "STRINGLITEARL", "NORMALSTRING", "CHARSTRING", "LONGSTRING", 
			"INTEGER", "FLOATINGPOINTNUMBER", "WHITESPACE", "STMEND", "COMMENT", 
			"LINECOMMENT", "SHEBANG"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "SidlParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public SidlParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class RootContext extends ParserRuleContext {
		public SetContext set() {
			return getRuleContext(SetContext.class,0);
		}
		public TerminalNode EOF() { return getToken(SidlParser.EOF, 0); }
		public RootContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_root; }
	}

	public final RootContext root() throws RecognitionException {
		RootContext _localctx = new RootContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_root);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(74);
			set();
			setState(75);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SetContext extends ParserRuleContext {
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public SetContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_set; }
	}

	public final SetContext set() throws RecognitionException {
		SetContext _localctx = new SetContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_set);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(80);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << TYPE) | (1L << STRING) | (1L << INT) | (1L << FLOAT) | (1L << BOOL) | (1L << STRUCT) | (1L << MESSAGE) | (1L << NODETYPE) | (1L << NODE) | (1L << META) | (1L << IMPORT) | (1L << OPEN_BRACKET) | (1L << NAME) | (1L << STMEND))) != 0)) {
				{
				{
				setState(77);
				statement();
				}
				}
				setState(82);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatementContext extends ParserRuleContext {
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
	 
		public StatementContext() { }
		public void copyFrom(StatementContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class DeclarationStatementContext extends StatementContext {
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public VariablelistContext variablelist() {
			return getRuleContext(VariablelistContext.class,0);
		}
		public TerminatorContext terminator() {
			return getRuleContext(TerminatorContext.class,0);
		}
		public DeclarationStatementContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class TerminatorStatementContext extends StatementContext {
		public TerminatorContext terminator() {
			return getRuleContext(TerminatorContext.class,0);
		}
		public TerminatorStatementContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class StructdefinitionStatementContext extends StatementContext {
		public StructdefinitionContext structdefinition() {
			return getRuleContext(StructdefinitionContext.class,0);
		}
		public StructdefinitionStatementContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class ImportStatementContext extends StatementContext {
		public ImportstatementContext importstatement() {
			return getRuleContext(ImportstatementContext.class,0);
		}
		public ImportStatementContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class AssignmentStatementContext extends StatementContext {
		public VariablelistContext variablelist() {
			return getRuleContext(VariablelistContext.class,0);
		}
		public TerminalNode ASSIGN() { return getToken(SidlParser.ASSIGN, 0); }
		public ExpressionlistContext expressionlist() {
			return getRuleContext(ExpressionlistContext.class,0);
		}
		public TerminatorContext terminator() {
			return getRuleContext(TerminatorContext.class,0);
		}
		public AssignmentStatementContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class DefinitionStatementContext extends StatementContext {
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public VariablelistContext variablelist() {
			return getRuleContext(VariablelistContext.class,0);
		}
		public TerminalNode ASSIGN() { return getToken(SidlParser.ASSIGN, 0); }
		public ExpressionlistContext expressionlist() {
			return getRuleContext(ExpressionlistContext.class,0);
		}
		public TerminatorContext terminator() {
			return getRuleContext(TerminatorContext.class,0);
		}
		public DefinitionStatementContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class MessagedefinitionStatementContext extends StatementContext {
		public MessagedefinitionContext messagedefinition() {
			return getRuleContext(MessagedefinitionContext.class,0);
		}
		public MessagedefinitionStatementContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class NodetypedefinitionStatementContext extends StatementContext {
		public NodetypedefinitionContext nodetypedefinition() {
			return getRuleContext(NodetypedefinitionContext.class,0);
		}
		public NodetypedefinitionStatementContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class NodedefinitionStatementContext extends StatementContext {
		public NodedefinitionContext nodedefinition() {
			return getRuleContext(NodedefinitionContext.class,0);
		}
		public NodedefinitionStatementContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class MetadefinitionStatementContext extends StatementContext {
		public MetadefinitionContext metadefinition() {
			return getRuleContext(MetadefinitionContext.class,0);
		}
		public MetadefinitionStatementContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class TypealiasingStatementContext extends StatementContext {
		public TypealiasingstatementContext typealiasingstatement() {
			return getRuleContext(TypealiasingstatementContext.class,0);
		}
		public TypealiasingStatementContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class ScopeStatementContext extends StatementContext {
		public ScopeContext scope() {
			return getRuleContext(ScopeContext.class,0);
		}
		public ScopeStatementContext(StatementContext ctx) { copyFrom(ctx); }
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_statement);
		try {
			setState(107);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				_localctx = new TerminatorStatementContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(83);
				terminator();
				}
				break;
			case 2:
				_localctx = new ScopeStatementContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(84);
				scope();
				}
				break;
			case 3:
				_localctx = new DeclarationStatementContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(85);
				type();
				setState(86);
				variablelist();
				setState(87);
				terminator();
				}
				break;
			case 4:
				_localctx = new AssignmentStatementContext(_localctx);
				enterOuterAlt(_localctx, 4);
				{
				setState(89);
				variablelist();
				setState(90);
				match(ASSIGN);
				setState(91);
				expressionlist();
				setState(92);
				terminator();
				}
				break;
			case 5:
				_localctx = new DefinitionStatementContext(_localctx);
				enterOuterAlt(_localctx, 5);
				{
				setState(94);
				type();
				setState(95);
				variablelist();
				setState(96);
				match(ASSIGN);
				setState(97);
				expressionlist();
				setState(98);
				terminator();
				}
				break;
			case 6:
				_localctx = new StructdefinitionStatementContext(_localctx);
				enterOuterAlt(_localctx, 6);
				{
				setState(100);
				structdefinition();
				}
				break;
			case 7:
				_localctx = new MessagedefinitionStatementContext(_localctx);
				enterOuterAlt(_localctx, 7);
				{
				setState(101);
				messagedefinition();
				}
				break;
			case 8:
				_localctx = new NodetypedefinitionStatementContext(_localctx);
				enterOuterAlt(_localctx, 8);
				{
				setState(102);
				nodetypedefinition();
				}
				break;
			case 9:
				_localctx = new NodedefinitionStatementContext(_localctx);
				enterOuterAlt(_localctx, 9);
				{
				setState(103);
				nodedefinition();
				}
				break;
			case 10:
				_localctx = new MetadefinitionStatementContext(_localctx);
				enterOuterAlt(_localctx, 10);
				{
				setState(104);
				metadefinition();
				}
				break;
			case 11:
				_localctx = new ImportStatementContext(_localctx);
				enterOuterAlt(_localctx, 11);
				{
				setState(105);
				importstatement();
				}
				break;
			case 12:
				_localctx = new TypealiasingStatementContext(_localctx);
				enterOuterAlt(_localctx, 12);
				{
				setState(106);
				typealiasingstatement();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ScopeContext extends ParserRuleContext {
		public TerminalNode OPEN_BRACKET() { return getToken(SidlParser.OPEN_BRACKET, 0); }
		public SetContext set() {
			return getRuleContext(SetContext.class,0);
		}
		public TerminalNode CLOSE_BRACKET() { return getToken(SidlParser.CLOSE_BRACKET, 0); }
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public ScopeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_scope; }
	}

	public final ScopeContext scope() throws RecognitionException {
		ScopeContext _localctx = new ScopeContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_scope);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(110);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NAME) {
				{
				setState(109);
				variable();
				}
			}

			setState(112);
			match(OPEN_BRACKET);
			setState(113);
			set();
			setState(114);
			match(CLOSE_BRACKET);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TypeContext extends ParserRuleContext {
		public AtomictypeContext atomictype() {
			return getRuleContext(AtomictypeContext.class,0);
		}
		public ComplextypeContext complextype() {
			return getRuleContext(ComplextypeContext.class,0);
		}
		public TerminalNode ARRAY() { return getToken(SidlParser.ARRAY, 0); }
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
	}

	public final TypeContext type() throws RecognitionException {
		TypeContext _localctx = new TypeContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_type);
		try {
			setState(124);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(116);
				atomictype();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(117);
				complextype();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(118);
				atomictype();
				setState(119);
				match(ARRAY);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(121);
				complextype();
				setState(122);
				match(ARRAY);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AtomictypeContext extends ParserRuleContext {
		public TerminalNode INT() { return getToken(SidlParser.INT, 0); }
		public TerminalNode FLOAT() { return getToken(SidlParser.FLOAT, 0); }
		public TerminalNode STRING() { return getToken(SidlParser.STRING, 0); }
		public TerminalNode BOOL() { return getToken(SidlParser.BOOL, 0); }
		public AtomictypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_atomictype; }
	}

	public final AtomictypeContext atomictype() throws RecognitionException {
		AtomictypeContext _localctx = new AtomictypeContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_atomictype);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(126);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STRING) | (1L << INT) | (1L << FLOAT) | (1L << BOOL))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ComplextypeContext extends ParserRuleContext {
		public TerminalNode STRUCT() { return getToken(SidlParser.STRUCT, 0); }
		public ComplextypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_complextype; }
	}

	public final ComplextypeContext complextype() throws RecognitionException {
		ComplextypeContext _localctx = new ComplextypeContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_complextype);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(128);
			match(STRUCT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class GraphtypeContext extends ParserRuleContext {
		public TerminalNode MESSAGE() { return getToken(SidlParser.MESSAGE, 0); }
		public TerminalNode NODETYPE() { return getToken(SidlParser.NODETYPE, 0); }
		public TerminalNode NODE() { return getToken(SidlParser.NODE, 0); }
		public TerminalNode META() { return getToken(SidlParser.META, 0); }
		public GraphtypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_graphtype; }
	}

	public final GraphtypeContext graphtype() throws RecognitionException {
		GraphtypeContext _localctx = new GraphtypeContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_graphtype);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(130);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << MESSAGE) | (1L << NODETYPE) | (1L << NODE) | (1L << META))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class VariableContext extends ParserRuleContext {
		public TerminalNode NAME() { return getToken(SidlParser.NAME, 0); }
		public VariableContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variable; }
	}

	public final VariableContext variable() throws RecognitionException {
		VariableContext _localctx = new VariableContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_variable);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(132);
			match(NAME);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TypenameContext extends ParserRuleContext {
		public TerminalNode NAME() { return getToken(SidlParser.NAME, 0); }
		public TypenameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typename; }
	}

	public final TypenameContext typename() throws RecognitionException {
		TypenameContext _localctx = new TypenameContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_typename);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(134);
			match(NAME);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class VariablelistContext extends ParserRuleContext {
		public List<VariableContext> variable() {
			return getRuleContexts(VariableContext.class);
		}
		public VariableContext variable(int i) {
			return getRuleContext(VariableContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SidlParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SidlParser.COMMA, i);
		}
		public VariablelistContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variablelist; }
	}

	public final VariablelistContext variablelist() throws RecognitionException {
		VariablelistContext _localctx = new VariablelistContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_variablelist);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(136);
			variable();
			setState(141);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(137);
				match(COMMA);
				setState(138);
				variable();
				}
				}
				setState(143);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TypedvariablelistContext extends ParserRuleContext {
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<VariableContext> variable() {
			return getRuleContexts(VariableContext.class);
		}
		public VariableContext variable(int i) {
			return getRuleContext(VariableContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SidlParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SidlParser.COMMA, i);
		}
		public TypedvariablelistContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typedvariablelist; }
	}

	public final TypedvariablelistContext typedvariablelist() throws RecognitionException {
		TypedvariablelistContext _localctx = new TypedvariablelistContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_typedvariablelist);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(144);
			type();
			setState(145);
			variable();
			setState(152);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(146);
				match(COMMA);
				setState(147);
				type();
				setState(148);
				variable();
				}
				}
				setState(154);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExpressionlistContext extends ParserRuleContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SidlParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SidlParser.COMMA, i);
		}
		public ExpressionlistContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expressionlist; }
	}

	public final ExpressionlistContext expressionlist() throws RecognitionException {
		ExpressionlistContext _localctx = new ExpressionlistContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_expressionlist);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(155);
			expression();
			setState(160);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,6,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(156);
					match(COMMA);
					setState(157);
					expression();
					}
					} 
				}
				setState(162);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,6,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExpressionContext extends ParserRuleContext {
		public TerminalNode NULL() { return getToken(SidlParser.NULL, 0); }
		public TerminalNode TRUE() { return getToken(SidlParser.TRUE, 0); }
		public TerminalNode FALSE() { return getToken(SidlParser.FALSE, 0); }
		public NumberContext number() {
			return getRuleContext(NumberContext.class,0);
		}
		public StringContext string() {
			return getRuleContext(StringContext.class,0);
		}
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public ScopeContext scope() {
			return getRuleContext(ScopeContext.class,0);
		}
		public FunctiondefinitionContext functiondefinition() {
			return getRuleContext(FunctiondefinitionContext.class,0);
		}
		public FunctioncallContext functioncall() {
			return getRuleContext(FunctioncallContext.class,0);
		}
		public ImportstatementContext importstatement() {
			return getRuleContext(ImportstatementContext.class,0);
		}
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	}

	public final ExpressionContext expression() throws RecognitionException {
		ExpressionContext _localctx = new ExpressionContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_expression);
		try {
			setState(173);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(163);
				match(NULL);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(164);
				match(TRUE);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(165);
				match(FALSE);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(166);
				number();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(167);
				string();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(168);
				variable();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(169);
				scope();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(170);
				functiondefinition();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(171);
				functioncall();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(172);
				importstatement();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ArraydeclarationContext extends ParserRuleContext {
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public TerminalNode ARRAY() { return getToken(SidlParser.ARRAY, 0); }
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public ArraydeclarationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_arraydeclaration; }
	}

	public final ArraydeclarationContext arraydeclaration() throws RecognitionException {
		ArraydeclarationContext _localctx = new ArraydeclarationContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_arraydeclaration);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(175);
			type();
			setState(176);
			match(ARRAY);
			setState(177);
			variable();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ArrayaccessContext extends ParserRuleContext {
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public TerminalNode OPEN_BRACKET() { return getToken(SidlParser.OPEN_BRACKET, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode CLOSE_BRACKET() { return getToken(SidlParser.CLOSE_BRACKET, 0); }
		public StringContext string() {
			return getRuleContext(StringContext.class,0);
		}
		public ArrayaccessContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_arrayaccess; }
	}

	public final ArrayaccessContext arrayaccess() throws RecognitionException {
		ArrayaccessContext _localctx = new ArrayaccessContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_arrayaccess);
		try {
			setState(189);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NAME:
				enterOuterAlt(_localctx, 1);
				{
				setState(179);
				variable();
				setState(180);
				match(OPEN_BRACKET);
				setState(181);
				expression();
				setState(182);
				match(CLOSE_BRACKET);
				}
				break;
			case STRINGLITEARL:
				enterOuterAlt(_localctx, 2);
				{
				setState(184);
				string();
				setState(185);
				match(OPEN_BRACKET);
				setState(186);
				expression();
				setState(187);
				match(CLOSE_BRACKET);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FieldaccessContext extends ParserRuleContext {
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SidlParser.DOT, 0); }
		public LefthandsideContext lefthandside() {
			return getRuleContext(LefthandsideContext.class,0);
		}
		public ArrayaccessContext arrayaccess() {
			return getRuleContext(ArrayaccessContext.class,0);
		}
		public FieldaccessContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_fieldaccess; }
	}

	public final FieldaccessContext fieldaccess() throws RecognitionException {
		FieldaccessContext _localctx = new FieldaccessContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_fieldaccess);
		try {
			setState(199);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(191);
				variable();
				setState(192);
				match(DOT);
				setState(193);
				lefthandside();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(195);
				arrayaccess();
				setState(196);
				match(DOT);
				setState(197);
				lefthandside();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LefthandsideContext extends ParserRuleContext {
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public FieldaccessContext fieldaccess() {
			return getRuleContext(FieldaccessContext.class,0);
		}
		public ArrayaccessContext arrayaccess() {
			return getRuleContext(ArrayaccessContext.class,0);
		}
		public LefthandsideContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_lefthandside; }
	}

	public final LefthandsideContext lefthandside() throws RecognitionException {
		LefthandsideContext _localctx = new LefthandsideContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_lefthandside);
		try {
			setState(204);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,10,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(201);
				variable();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(202);
				fieldaccess();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(203);
				arrayaccess();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ImportstatementContext extends ParserRuleContext {
		public TerminalNode IMPORT() { return getToken(SidlParser.IMPORT, 0); }
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public TerminalNode STRINGLITEARL() { return getToken(SidlParser.STRINGLITEARL, 0); }
		public ImportstatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_importstatement; }
	}

	public final ImportstatementContext importstatement() throws RecognitionException {
		ImportstatementContext _localctx = new ImportstatementContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_importstatement);
		try {
			setState(210);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,11,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(206);
				match(IMPORT);
				setState(207);
				variable();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(208);
				match(IMPORT);
				setState(209);
				match(STRINGLITEARL);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TypealiasingstatementContext extends ParserRuleContext {
		public TerminalNode TYPE() { return getToken(SidlParser.TYPE, 0); }
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public TerminalNode COLON() { return getToken(SidlParser.COLON, 0); }
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public TerminalNode COMMA() { return getToken(SidlParser.COMMA, 0); }
		public StringContext string() {
			return getRuleContext(StringContext.class,0);
		}
		public TypealiasingstatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typealiasingstatement; }
	}

	public final TypealiasingstatementContext typealiasingstatement() throws RecognitionException {
		TypealiasingstatementContext _localctx = new TypealiasingstatementContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_typealiasingstatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(212);
			match(TYPE);
			setState(213);
			variable();
			setState(214);
			match(COLON);
			setState(215);
			type();
			setState(218);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COMMA) {
				{
				setState(216);
				match(COMMA);
				setState(217);
				string();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctiondefinitionContext extends ParserRuleContext {
		public TerminalNode FUNCTION() { return getToken(SidlParser.FUNCTION, 0); }
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public TerminalNode ASSIGN() { return getToken(SidlParser.ASSIGN, 0); }
		public List<TerminalNode> OPEN_PAREN() { return getTokens(SidlParser.OPEN_PAREN); }
		public TerminalNode OPEN_PAREN(int i) {
			return getToken(SidlParser.OPEN_PAREN, i);
		}
		public List<TerminalNode> CLOSE_PAREN() { return getTokens(SidlParser.CLOSE_PAREN); }
		public TerminalNode CLOSE_PAREN(int i) {
			return getToken(SidlParser.CLOSE_PAREN, i);
		}
		public FunctionbodyContext functionbody() {
			return getRuleContext(FunctionbodyContext.class,0);
		}
		public List<TypedvariablelistContext> typedvariablelist() {
			return getRuleContexts(TypedvariablelistContext.class);
		}
		public TypedvariablelistContext typedvariablelist(int i) {
			return getRuleContext(TypedvariablelistContext.class,i);
		}
		public FunctiondefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functiondefinition; }
	}

	public final FunctiondefinitionContext functiondefinition() throws RecognitionException {
		FunctiondefinitionContext _localctx = new FunctiondefinitionContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_functiondefinition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(220);
			match(FUNCTION);
			setState(221);
			variable();
			setState(222);
			match(ASSIGN);
			setState(223);
			match(OPEN_PAREN);
			setState(225);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STRING) | (1L << INT) | (1L << FLOAT) | (1L << BOOL) | (1L << STRUCT))) != 0)) {
				{
				setState(224);
				typedvariablelist();
				}
			}

			setState(227);
			match(CLOSE_PAREN);
			setState(228);
			match(OPEN_PAREN);
			setState(230);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STRING) | (1L << INT) | (1L << FLOAT) | (1L << BOOL) | (1L << STRUCT))) != 0)) {
				{
				setState(229);
				typedvariablelist();
				}
			}

			setState(232);
			match(CLOSE_PAREN);
			setState(233);
			functionbody();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionbodyContext extends ParserRuleContext {
		public TerminalNode OPEN_BRACE() { return getToken(SidlParser.OPEN_BRACE, 0); }
		public TerminalNode CLOSE_BRACE() { return getToken(SidlParser.CLOSE_BRACE, 0); }
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public List<TerminalNode> IF() { return getTokens(SidlParser.IF); }
		public TerminalNode IF(int i) {
			return getToken(SidlParser.IF, i);
		}
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public List<ScopeContext> scope() {
			return getRuleContexts(ScopeContext.class);
		}
		public ScopeContext scope(int i) {
			return getRuleContext(ScopeContext.class,i);
		}
		public List<TerminalNode> WHILE() { return getTokens(SidlParser.WHILE); }
		public TerminalNode WHILE(int i) {
			return getToken(SidlParser.WHILE, i);
		}
		public List<TerminalNode> FOR() { return getTokens(SidlParser.FOR); }
		public TerminalNode FOR(int i) {
			return getToken(SidlParser.FOR, i);
		}
		public List<VariablelistContext> variablelist() {
			return getRuleContexts(VariablelistContext.class);
		}
		public VariablelistContext variablelist(int i) {
			return getRuleContext(VariablelistContext.class,i);
		}
		public List<TerminalNode> ASSIGN() { return getTokens(SidlParser.ASSIGN); }
		public TerminalNode ASSIGN(int i) {
			return getToken(SidlParser.ASSIGN, i);
		}
		public List<ExpressionlistContext> expressionlist() {
			return getRuleContexts(ExpressionlistContext.class);
		}
		public ExpressionlistContext expressionlist(int i) {
			return getRuleContext(ExpressionlistContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SidlParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SidlParser.COMMA, i);
		}
		public List<VariableContext> variable() {
			return getRuleContexts(VariableContext.class);
		}
		public VariableContext variable(int i) {
			return getRuleContext(VariableContext.class,i);
		}
		public List<TerminalNode> IN() { return getTokens(SidlParser.IN); }
		public TerminalNode IN(int i) {
			return getToken(SidlParser.IN, i);
		}
		public List<ReturnstatementContext> returnstatement() {
			return getRuleContexts(ReturnstatementContext.class);
		}
		public ReturnstatementContext returnstatement(int i) {
			return getRuleContext(ReturnstatementContext.class,i);
		}
		public List<TerminalNode> ELSEIF() { return getTokens(SidlParser.ELSEIF); }
		public TerminalNode ELSEIF(int i) {
			return getToken(SidlParser.ELSEIF, i);
		}
		public List<TerminalNode> ELSE() { return getTokens(SidlParser.ELSE); }
		public TerminalNode ELSE(int i) {
			return getToken(SidlParser.ELSE, i);
		}
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public FunctionbodyContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionbody; }
	}

	public final FunctionbodyContext functionbody() throws RecognitionException {
		FunctionbodyContext _localctx = new FunctionbodyContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_functionbody);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(235);
			match(OPEN_BRACE);
			setState(284);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << TYPE) | (1L << STRING) | (1L << INT) | (1L << FLOAT) | (1L << BOOL) | (1L << STRUCT) | (1L << MESSAGE) | (1L << NODETYPE) | (1L << NODE) | (1L << META) | (1L << IMPORT) | (1L << IF) | (1L << FOR) | (1L << WHILE) | (1L << RETURN) | (1L << OPEN_BRACKET) | (1L << NAME) | (1L << STMEND))) != 0)) {
				{
				setState(282);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,20,_ctx) ) {
				case 1:
					{
					setState(236);
					statement();
					}
					break;
				case 2:
					{
					setState(237);
					match(IF);
					setState(238);
					expression();
					setState(239);
					scope();
					setState(246);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==ELSEIF) {
						{
						{
						setState(240);
						match(ELSEIF);
						setState(241);
						expression();
						setState(242);
						scope();
						}
						}
						setState(248);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					setState(251);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==ELSE) {
						{
						setState(249);
						match(ELSE);
						setState(250);
						scope();
						}
					}

					}
					break;
				case 3:
					{
					setState(253);
					match(WHILE);
					setState(254);
					expression();
					setState(255);
					scope();
					}
					break;
				case 4:
					{
					setState(257);
					match(FOR);
					setState(259);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STRING) | (1L << INT) | (1L << FLOAT) | (1L << BOOL) | (1L << STRUCT))) != 0)) {
						{
						setState(258);
						type();
						}
					}

					setState(261);
					variablelist();
					setState(262);
					match(ASSIGN);
					setState(263);
					expressionlist();
					setState(264);
					match(COMMA);
					setState(265);
					expression();
					setState(268);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==COMMA) {
						{
						setState(266);
						match(COMMA);
						setState(267);
						expression();
						}
					}

					setState(270);
					scope();
					}
					break;
				case 5:
					{
					setState(272);
					match(FOR);
					setState(274);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STRING) | (1L << INT) | (1L << FLOAT) | (1L << BOOL) | (1L << STRUCT))) != 0)) {
						{
						setState(273);
						type();
						}
					}

					setState(276);
					variable();
					setState(277);
					match(IN);
					setState(278);
					variable();
					setState(279);
					scope();
					}
					break;
				case 6:
					{
					setState(281);
					returnstatement();
					}
					break;
				}
				}
				setState(286);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(287);
			match(CLOSE_BRACE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ReturnstatementContext extends ParserRuleContext {
		public TerminalNode RETURN() { return getToken(SidlParser.RETURN, 0); }
		public VariablelistContext variablelist() {
			return getRuleContext(VariablelistContext.class,0);
		}
		public ReturnstatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_returnstatement; }
	}

	public final ReturnstatementContext returnstatement() throws RecognitionException {
		ReturnstatementContext _localctx = new ReturnstatementContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_returnstatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(289);
			match(RETURN);
			setState(291);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,22,_ctx) ) {
			case 1:
				{
				setState(290);
				variablelist();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctioncallContext extends ParserRuleContext {
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public TerminalNode OPEN_PAREN() { return getToken(SidlParser.OPEN_PAREN, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(SidlParser.CLOSE_PAREN, 0); }
		public VariablelistContext variablelist() {
			return getRuleContext(VariablelistContext.class,0);
		}
		public FunctioncallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functioncall; }
	}

	public final FunctioncallContext functioncall() throws RecognitionException {
		FunctioncallContext _localctx = new FunctioncallContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_functioncall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(293);
			variable();
			setState(294);
			match(OPEN_PAREN);
			setState(296);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NAME) {
				{
				setState(295);
				variablelist();
				}
			}

			setState(298);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StructdefinitionContext extends ParserRuleContext {
		public TerminalNode STRUCT() { return getToken(SidlParser.STRUCT, 0); }
		public List<VariableContext> variable() {
			return getRuleContexts(VariableContext.class);
		}
		public VariableContext variable(int i) {
			return getRuleContext(VariableContext.class,i);
		}
		public TerminalNode OPEN_BRACE() { return getToken(SidlParser.OPEN_BRACE, 0); }
		public TerminalNode CLOSE_BRACE() { return getToken(SidlParser.CLOSE_BRACE, 0); }
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<TerminatorContext> terminator() {
			return getRuleContexts(TerminatorContext.class);
		}
		public TerminatorContext terminator(int i) {
			return getRuleContext(TerminatorContext.class,i);
		}
		public StructdefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_structdefinition; }
	}

	public final StructdefinitionContext structdefinition() throws RecognitionException {
		StructdefinitionContext _localctx = new StructdefinitionContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_structdefinition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(300);
			match(STRUCT);
			setState(301);
			variable();
			setState(302);
			match(OPEN_BRACE);
			setState(309);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STRING) | (1L << INT) | (1L << FLOAT) | (1L << BOOL) | (1L << STRUCT))) != 0)) {
				{
				{
				setState(303);
				type();
				setState(304);
				variable();
				setState(305);
				terminator();
				}
				}
				setState(311);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(312);
			match(CLOSE_BRACE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MessagetypenameContext extends ParserRuleContext {
		public TerminalNode NAME() { return getToken(SidlParser.NAME, 0); }
		public MessagetypenameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_messagetypename; }
	}

	public final MessagetypenameContext messagetypename() throws RecognitionException {
		MessagetypenameContext _localctx = new MessagetypenameContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_messagetypename);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(314);
			match(NAME);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NodetypenameContext extends ParserRuleContext {
		public TerminalNode NAME() { return getToken(SidlParser.NAME, 0); }
		public NodetypenameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_nodetypename; }
	}

	public final NodetypenameContext nodetypename() throws RecognitionException {
		NodetypenameContext _localctx = new NodetypenameContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_nodetypename);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(316);
			match(NAME);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MessagetypelistContext extends ParserRuleContext {
		public List<MessagetypenameContext> messagetypename() {
			return getRuleContexts(MessagetypenameContext.class);
		}
		public MessagetypenameContext messagetypename(int i) {
			return getRuleContext(MessagetypenameContext.class,i);
		}
		public List<VariableContext> variable() {
			return getRuleContexts(VariableContext.class);
		}
		public VariableContext variable(int i) {
			return getRuleContext(VariableContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SidlParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SidlParser.COMMA, i);
		}
		public MessagetypelistContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_messagetypelist; }
	}

	public final MessagetypelistContext messagetypelist() throws RecognitionException {
		MessagetypelistContext _localctx = new MessagetypelistContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_messagetypelist);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(318);
			messagetypename();
			setState(319);
			variable();
			setState(326);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(320);
				match(COMMA);
				setState(321);
				messagetypename();
				setState(322);
				variable();
				}
				}
				setState(328);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MessagedefinitionContext extends ParserRuleContext {
		public TerminalNode MESSAGE() { return getToken(SidlParser.MESSAGE, 0); }
		public MessagetypenameContext messagetypename() {
			return getRuleContext(MessagetypenameContext.class,0);
		}
		public TerminalNode OPEN_BRACE() { return getToken(SidlParser.OPEN_BRACE, 0); }
		public TerminalNode CLOSE_BRACE() { return getToken(SidlParser.CLOSE_BRACE, 0); }
		public List<VariableContext> variable() {
			return getRuleContexts(VariableContext.class);
		}
		public VariableContext variable(int i) {
			return getRuleContext(VariableContext.class,i);
		}
		public List<TypenameContext> typename() {
			return getRuleContexts(TypenameContext.class);
		}
		public TypenameContext typename(int i) {
			return getRuleContext(TypenameContext.class,i);
		}
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<TerminalNode> TOPIC() { return getTokens(SidlParser.TOPIC); }
		public TerminalNode TOPIC(int i) {
			return getToken(SidlParser.TOPIC, i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SidlParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SidlParser.COMMA, i);
		}
		public MessagedefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_messagedefinition; }
	}

	public final MessagedefinitionContext messagedefinition() throws RecognitionException {
		MessagedefinitionContext _localctx = new MessagedefinitionContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_messagedefinition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(329);
			match(MESSAGE);
			setState(330);
			messagetypename();
			setState(331);
			match(OPEN_BRACE);
			setState(355);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STRING) | (1L << INT) | (1L << FLOAT) | (1L << BOOL) | (1L << STRUCT) | (1L << TOPIC) | (1L << NAME))) != 0)) {
				{
				setState(333);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==TOPIC) {
					{
					setState(332);
					match(TOPIC);
					}
				}

				setState(337);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case NAME:
					{
					setState(335);
					typename();
					}
					break;
				case STRING:
				case INT:
				case FLOAT:
				case BOOL:
				case STRUCT:
					{
					setState(336);
					type();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(339);
				variable();
				setState(352);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(340);
					match(COMMA);
					setState(342);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==TOPIC) {
						{
						setState(341);
						match(TOPIC);
						}
					}

					setState(346);
					_errHandler.sync(this);
					switch (_input.LA(1)) {
					case NAME:
						{
						setState(344);
						typename();
						}
						break;
					case STRING:
					case INT:
					case FLOAT:
					case BOOL:
					case STRUCT:
						{
						setState(345);
						type();
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(348);
					variable();
					}
					}
					setState(354);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(357);
			match(CLOSE_BRACE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NodetypedefinitionContext extends ParserRuleContext {
		public TerminalNode NODETYPE() { return getToken(SidlParser.NODETYPE, 0); }
		public NodetypenameContext nodetypename() {
			return getRuleContext(NodetypenameContext.class,0);
		}
		public TerminalNode OPEN_BRACE() { return getToken(SidlParser.OPEN_BRACE, 0); }
		public NodebodyContext nodebody() {
			return getRuleContext(NodebodyContext.class,0);
		}
		public TerminalNode CLOSE_BRACE() { return getToken(SidlParser.CLOSE_BRACE, 0); }
		public NodetypesignatureContext nodetypesignature() {
			return getRuleContext(NodetypesignatureContext.class,0);
		}
		public NodetypedefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_nodetypedefinition; }
	}

	public final NodetypedefinitionContext nodetypedefinition() throws RecognitionException {
		NodetypedefinitionContext _localctx = new NodetypedefinitionContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_nodetypedefinition);
		int _la;
		try {
			setState(374);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,33,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(359);
				match(NODETYPE);
				setState(360);
				nodetypename();
				setState(361);
				match(OPEN_BRACE);
				setState(362);
				nodebody();
				setState(363);
				match(CLOSE_BRACE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(365);
				match(NODETYPE);
				setState(366);
				nodetypename();
				setState(367);
				nodetypesignature();
				setState(372);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==OPEN_BRACE) {
					{
					setState(368);
					match(OPEN_BRACE);
					setState(369);
					nodebody();
					setState(370);
					match(CLOSE_BRACE);
					}
				}

				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NodetypesignatureContext extends ParserRuleContext {
		public TerminalNode OPEN_PAREN() { return getToken(SidlParser.OPEN_PAREN, 0); }
		public TerminalNode ARROW() { return getToken(SidlParser.ARROW, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(SidlParser.CLOSE_PAREN, 0); }
		public List<MessagetypelistContext> messagetypelist() {
			return getRuleContexts(MessagetypelistContext.class);
		}
		public MessagetypelistContext messagetypelist(int i) {
			return getRuleContext(MessagetypelistContext.class,i);
		}
		public NodetypesignatureContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_nodetypesignature; }
	}

	public final NodetypesignatureContext nodetypesignature() throws RecognitionException {
		NodetypesignatureContext _localctx = new NodetypesignatureContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_nodetypesignature);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(376);
			match(OPEN_PAREN);
			setState(378);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NAME) {
				{
				setState(377);
				messagetypelist();
				}
			}

			setState(380);
			match(ARROW);
			setState(382);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NAME) {
				{
				setState(381);
				messagetypelist();
				}
			}

			setState(384);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NodedefinitionContext extends ParserRuleContext {
		public TerminalNode NODE() { return getToken(SidlParser.NODE, 0); }
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public TerminalNode OPEN_BRACE() { return getToken(SidlParser.OPEN_BRACE, 0); }
		public NodebodyContext nodebody() {
			return getRuleContext(NodebodyContext.class,0);
		}
		public TerminalNode CLOSE_BRACE() { return getToken(SidlParser.CLOSE_BRACE, 0); }
		public NodetypesignatureContext nodetypesignature() {
			return getRuleContext(NodetypesignatureContext.class,0);
		}
		public TypenameContext typename() {
			return getRuleContext(TypenameContext.class,0);
		}
		public NodedefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_nodedefinition; }
	}

	public final NodedefinitionContext nodedefinition() throws RecognitionException {
		NodedefinitionContext _localctx = new NodedefinitionContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_nodedefinition);
		int _la;
		try {
			setState(405);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,37,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(386);
				match(NODE);
				setState(387);
				variable();
				setState(388);
				match(OPEN_BRACE);
				setState(389);
				nodebody();
				setState(390);
				match(CLOSE_BRACE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(392);
				match(NODE);
				setState(393);
				variable();
				setState(394);
				nodetypesignature();
				setState(399);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==OPEN_BRACE) {
					{
					setState(395);
					match(OPEN_BRACE);
					setState(396);
					nodebody();
					setState(397);
					match(CLOSE_BRACE);
					}
				}

				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(401);
				match(NODE);
				setState(402);
				typename();
				setState(403);
				variable();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NodebodyContext extends ParserRuleContext {
		public List<TerminatorContext> terminator() {
			return getRuleContexts(TerminatorContext.class);
		}
		public TerminatorContext terminator(int i) {
			return getRuleContext(TerminatorContext.class,i);
		}
		public List<TerminalNode> INCLUDE() { return getTokens(SidlParser.INCLUDE); }
		public TerminalNode INCLUDE(int i) {
			return getToken(SidlParser.INCLUDE, i);
		}
		public List<VariableContext> variable() {
			return getRuleContexts(VariableContext.class);
		}
		public VariableContext variable(int i) {
			return getRuleContext(VariableContext.class,i);
		}
		public List<TerminalNode> PROPERTY() { return getTokens(SidlParser.PROPERTY); }
		public TerminalNode PROPERTY(int i) {
			return getToken(SidlParser.PROPERTY, i);
		}
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<VariablelistContext> variablelist() {
			return getRuleContexts(VariablelistContext.class);
		}
		public VariablelistContext variablelist(int i) {
			return getRuleContext(VariablelistContext.class,i);
		}
		public List<TerminalNode> INPUT() { return getTokens(SidlParser.INPUT); }
		public TerminalNode INPUT(int i) {
			return getToken(SidlParser.INPUT, i);
		}
		public List<TerminalNode> OUTPUT() { return getTokens(SidlParser.OUTPUT); }
		public TerminalNode OUTPUT(int i) {
			return getToken(SidlParser.OUTPUT, i);
		}
		public List<TypedvariablelistContext> typedvariablelist() {
			return getRuleContexts(TypedvariablelistContext.class);
		}
		public TypedvariablelistContext typedvariablelist(int i) {
			return getRuleContext(TypedvariablelistContext.class,i);
		}
		public NodebodyContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_nodebody; }
	}

	public final NodebodyContext nodebody() throws RecognitionException {
		NodebodyContext _localctx = new NodebodyContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_nodebody);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(423);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INCLUDE) | (1L << PROPERTY) | (1L << INPUT) | (1L << OUTPUT))) != 0)) {
				{
				setState(421);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case INPUT:
				case OUTPUT:
					{
					setState(407);
					_la = _input.LA(1);
					if ( !(_la==INPUT || _la==OUTPUT) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					setState(409);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STRING) | (1L << INT) | (1L << FLOAT) | (1L << BOOL) | (1L << STRUCT))) != 0)) {
						{
						setState(408);
						typedvariablelist();
						}
					}

					setState(411);
					terminator();
					}
					break;
				case INCLUDE:
					{
					setState(412);
					match(INCLUDE);
					setState(413);
					variable();
					setState(414);
					terminator();
					}
					break;
				case PROPERTY:
					{
					setState(416);
					match(PROPERTY);
					setState(417);
					type();
					setState(418);
					variablelist();
					setState(419);
					terminator();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(425);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MetadefinitionContext extends ParserRuleContext {
		public TerminalNode META() { return getToken(SidlParser.META, 0); }
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public TerminalNode OPEN_BRACE() { return getToken(SidlParser.OPEN_BRACE, 0); }
		public TerminalNode CLOSE_BRACE() { return getToken(SidlParser.CLOSE_BRACE, 0); }
		public List<TerminalNode> PROPERTY() { return getTokens(SidlParser.PROPERTY); }
		public TerminalNode PROPERTY(int i) {
			return getToken(SidlParser.PROPERTY, i);
		}
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<VariablelistContext> variablelist() {
			return getRuleContexts(VariablelistContext.class);
		}
		public VariablelistContext variablelist(int i) {
			return getRuleContext(VariablelistContext.class,i);
		}
		public List<TerminatorContext> terminator() {
			return getRuleContexts(TerminatorContext.class);
		}
		public TerminatorContext terminator(int i) {
			return getRuleContext(TerminatorContext.class,i);
		}
		public MetadefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_metadefinition; }
	}

	public final MetadefinitionContext metadefinition() throws RecognitionException {
		MetadefinitionContext _localctx = new MetadefinitionContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_metadefinition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(426);
			match(META);
			setState(427);
			variable();
			setState(428);
			match(OPEN_BRACE);
			setState(436);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==PROPERTY) {
				{
				{
				setState(429);
				match(PROPERTY);
				setState(430);
				type();
				setState(431);
				variablelist();
				setState(432);
				terminator();
				}
				}
				setState(438);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(439);
			match(CLOSE_BRACE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NumberContext extends ParserRuleContext {
		public TerminalNode INTEGER() { return getToken(SidlParser.INTEGER, 0); }
		public TerminalNode FLOATINGPOINTNUMBER() { return getToken(SidlParser.FLOATINGPOINTNUMBER, 0); }
		public NumberContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_number; }
	}

	public final NumberContext number() throws RecognitionException {
		NumberContext _localctx = new NumberContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_number);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(441);
			_la = _input.LA(1);
			if ( !(_la==INTEGER || _la==FLOATINGPOINTNUMBER) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StringContext extends ParserRuleContext {
		public TerminalNode STRINGLITEARL() { return getToken(SidlParser.STRINGLITEARL, 0); }
		public StringContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_string; }
	}

	public final StringContext string() throws RecognitionException {
		StringContext _localctx = new StringContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_string);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(443);
			match(STRINGLITEARL);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TerminatorContext extends ParserRuleContext {
		public TerminalNode STMEND() { return getToken(SidlParser.STMEND, 0); }
		public TerminatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_terminator; }
	}

	public final TerminatorContext terminator() throws RecognitionException {
		TerminatorContext _localctx = new TerminatorContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_terminator);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(445);
			match(STMEND);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3;\u01c2\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\3\2\3\2\3\2\3\3\7\3Q\n\3\f\3\16\3"+
		"T\13\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4"+
		"\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\5\4n\n\4\3\5\5\5q\n\5\3\5\3\5\3\5\3\5"+
		"\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\5\6\177\n\6\3\7\3\7\3\b\3\b\3\t\3\t\3"+
		"\n\3\n\3\13\3\13\3\f\3\f\3\f\7\f\u008e\n\f\f\f\16\f\u0091\13\f\3\r\3\r"+
		"\3\r\3\r\3\r\3\r\7\r\u0099\n\r\f\r\16\r\u009c\13\r\3\16\3\16\3\16\7\16"+
		"\u00a1\n\16\f\16\16\16\u00a4\13\16\3\17\3\17\3\17\3\17\3\17\3\17\3\17"+
		"\3\17\3\17\3\17\5\17\u00b0\n\17\3\20\3\20\3\20\3\20\3\21\3\21\3\21\3\21"+
		"\3\21\3\21\3\21\3\21\3\21\3\21\5\21\u00c0\n\21\3\22\3\22\3\22\3\22\3\22"+
		"\3\22\3\22\3\22\5\22\u00ca\n\22\3\23\3\23\3\23\5\23\u00cf\n\23\3\24\3"+
		"\24\3\24\3\24\5\24\u00d5\n\24\3\25\3\25\3\25\3\25\3\25\3\25\5\25\u00dd"+
		"\n\25\3\26\3\26\3\26\3\26\3\26\5\26\u00e4\n\26\3\26\3\26\3\26\5\26\u00e9"+
		"\n\26\3\26\3\26\3\26\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\7\27"+
		"\u00f7\n\27\f\27\16\27\u00fa\13\27\3\27\3\27\5\27\u00fe\n\27\3\27\3\27"+
		"\3\27\3\27\3\27\3\27\5\27\u0106\n\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27"+
		"\5\27\u010f\n\27\3\27\3\27\3\27\3\27\5\27\u0115\n\27\3\27\3\27\3\27\3"+
		"\27\3\27\3\27\7\27\u011d\n\27\f\27\16\27\u0120\13\27\3\27\3\27\3\30\3"+
		"\30\5\30\u0126\n\30\3\31\3\31\3\31\5\31\u012b\n\31\3\31\3\31\3\32\3\32"+
		"\3\32\3\32\3\32\3\32\3\32\7\32\u0136\n\32\f\32\16\32\u0139\13\32\3\32"+
		"\3\32\3\33\3\33\3\34\3\34\3\35\3\35\3\35\3\35\3\35\3\35\7\35\u0147\n\35"+
		"\f\35\16\35\u014a\13\35\3\36\3\36\3\36\3\36\5\36\u0150\n\36\3\36\3\36"+
		"\5\36\u0154\n\36\3\36\3\36\3\36\5\36\u0159\n\36\3\36\3\36\5\36\u015d\n"+
		"\36\3\36\3\36\7\36\u0161\n\36\f\36\16\36\u0164\13\36\5\36\u0166\n\36\3"+
		"\36\3\36\3\37\3\37\3\37\3\37\3\37\3\37\3\37\3\37\3\37\3\37\3\37\3\37\3"+
		"\37\5\37\u0177\n\37\5\37\u0179\n\37\3 \3 \5 \u017d\n \3 \3 \5 \u0181\n"+
		" \3 \3 \3!\3!\3!\3!\3!\3!\3!\3!\3!\3!\3!\3!\3!\5!\u0192\n!\3!\3!\3!\3"+
		"!\5!\u0198\n!\3\"\3\"\5\"\u019c\n\"\3\"\3\"\3\"\3\"\3\"\3\"\3\"\3\"\3"+
		"\"\3\"\7\"\u01a8\n\"\f\"\16\"\u01ab\13\"\3#\3#\3#\3#\3#\3#\3#\3#\7#\u01b5"+
		"\n#\f#\16#\u01b8\13#\3#\3#\3$\3$\3%\3%\3&\3&\3&\2\2\'\2\4\6\b\n\f\16\20"+
		"\22\24\26\30\32\34\36 \"$&(*,.\60\62\64\668:<>@BDFHJ\2\6\3\2\5\b\3\2\n"+
		"\r\3\2\23\24\3\2\65\66\2\u01e1\2L\3\2\2\2\4R\3\2\2\2\6m\3\2\2\2\bp\3\2"+
		"\2\2\n~\3\2\2\2\f\u0080\3\2\2\2\16\u0082\3\2\2\2\20\u0084\3\2\2\2\22\u0086"+
		"\3\2\2\2\24\u0088\3\2\2\2\26\u008a\3\2\2\2\30\u0092\3\2\2\2\32\u009d\3"+
		"\2\2\2\34\u00af\3\2\2\2\36\u00b1\3\2\2\2 \u00bf\3\2\2\2\"\u00c9\3\2\2"+
		"\2$\u00ce\3\2\2\2&\u00d4\3\2\2\2(\u00d6\3\2\2\2*\u00de\3\2\2\2,\u00ed"+
		"\3\2\2\2.\u0123\3\2\2\2\60\u0127\3\2\2\2\62\u012e\3\2\2\2\64\u013c\3\2"+
		"\2\2\66\u013e\3\2\2\28\u0140\3\2\2\2:\u014b\3\2\2\2<\u0178\3\2\2\2>\u017a"+
		"\3\2\2\2@\u0197\3\2\2\2B\u01a9\3\2\2\2D\u01ac\3\2\2\2F\u01bb\3\2\2\2H"+
		"\u01bd\3\2\2\2J\u01bf\3\2\2\2LM\5\4\3\2MN\7\2\2\3N\3\3\2\2\2OQ\5\6\4\2"+
		"PO\3\2\2\2QT\3\2\2\2RP\3\2\2\2RS\3\2\2\2S\5\3\2\2\2TR\3\2\2\2Un\5J&\2"+
		"Vn\5\b\5\2WX\5\n\6\2XY\5\26\f\2YZ\5J&\2Zn\3\2\2\2[\\\5\26\f\2\\]\7$\2"+
		"\2]^\5\32\16\2^_\5J&\2_n\3\2\2\2`a\5\n\6\2ab\5\26\f\2bc\7$\2\2cd\5\32"+
		"\16\2de\5J&\2en\3\2\2\2fn\5\62\32\2gn\5:\36\2hn\5<\37\2in\5@!\2jn\5D#"+
		"\2kn\5&\24\2ln\5(\25\2mU\3\2\2\2mV\3\2\2\2mW\3\2\2\2m[\3\2\2\2m`\3\2\2"+
		"\2mf\3\2\2\2mg\3\2\2\2mh\3\2\2\2mi\3\2\2\2mj\3\2\2\2mk\3\2\2\2ml\3\2\2"+
		"\2n\7\3\2\2\2oq\5\22\n\2po\3\2\2\2pq\3\2\2\2qr\3\2\2\2rs\7-\2\2st\5\4"+
		"\3\2tu\7.\2\2u\t\3\2\2\2v\177\5\f\7\2w\177\5\16\b\2xy\5\f\7\2yz\7\4\2"+
		"\2z\177\3\2\2\2{|\5\16\b\2|}\7\4\2\2}\177\3\2\2\2~v\3\2\2\2~w\3\2\2\2"+
		"~x\3\2\2\2~{\3\2\2\2\177\13\3\2\2\2\u0080\u0081\t\2\2\2\u0081\r\3\2\2"+
		"\2\u0082\u0083\7\t\2\2\u0083\17\3\2\2\2\u0084\u0085\t\3\2\2\u0085\21\3"+
		"\2\2\2\u0086\u0087\7/\2\2\u0087\23\3\2\2\2\u0088\u0089\7/\2\2\u0089\25"+
		"\3\2\2\2\u008a\u008f\5\22\n\2\u008b\u008c\7!\2\2\u008c\u008e\5\22\n\2"+
		"\u008d\u008b\3\2\2\2\u008e\u0091\3\2\2\2\u008f\u008d\3\2\2\2\u008f\u0090"+
		"\3\2\2\2\u0090\27\3\2\2\2\u0091\u008f\3\2\2\2\u0092\u0093\5\n\6\2\u0093"+
		"\u009a\5\22\n\2\u0094\u0095\7!\2\2\u0095\u0096\5\n\6\2\u0096\u0097\5\22"+
		"\n\2\u0097\u0099\3\2\2\2\u0098\u0094\3\2\2\2\u0099\u009c\3\2\2\2\u009a"+
		"\u0098\3\2\2\2\u009a\u009b\3\2\2\2\u009b\31\3\2\2\2\u009c\u009a\3\2\2"+
		"\2\u009d\u00a2\5\34\17\2\u009e\u009f\7!\2\2\u009f\u00a1\5\34\17\2\u00a0"+
		"\u009e\3\2\2\2\u00a1\u00a4\3\2\2\2\u00a2\u00a0\3\2\2\2\u00a2\u00a3\3\2"+
		"\2\2\u00a3\33\3\2\2\2\u00a4\u00a2\3\2\2\2\u00a5\u00b0\7\25\2\2\u00a6\u00b0"+
		"\7\26\2\2\u00a7\u00b0\7\27\2\2\u00a8\u00b0\5F$\2\u00a9\u00b0\5H%\2\u00aa"+
		"\u00b0\5\22\n\2\u00ab\u00b0\5\b\5\2\u00ac\u00b0\5*\26\2\u00ad\u00b0\5"+
		"\60\31\2\u00ae\u00b0\5&\24\2\u00af\u00a5\3\2\2\2\u00af\u00a6\3\2\2\2\u00af"+
		"\u00a7\3\2\2\2\u00af\u00a8\3\2\2\2\u00af\u00a9\3\2\2\2\u00af\u00aa\3\2"+
		"\2\2\u00af\u00ab\3\2\2\2\u00af\u00ac\3\2\2\2\u00af\u00ad\3\2\2\2\u00af"+
		"\u00ae\3\2\2\2\u00b0\35\3\2\2\2\u00b1\u00b2\5\n\6\2\u00b2\u00b3\7\4\2"+
		"\2\u00b3\u00b4\5\22\n\2\u00b4\37\3\2\2\2\u00b5\u00b6\5\22\n\2\u00b6\u00b7"+
		"\7-\2\2\u00b7\u00b8\5\34\17\2\u00b8\u00b9\7.\2\2\u00b9\u00c0\3\2\2\2\u00ba"+
		"\u00bb\5H%\2\u00bb\u00bc\7-\2\2\u00bc\u00bd\5\34\17\2\u00bd\u00be\7.\2"+
		"\2\u00be\u00c0\3\2\2\2\u00bf\u00b5\3\2\2\2\u00bf\u00ba\3\2\2\2\u00c0!"+
		"\3\2\2\2\u00c1\u00c2\5\22\n\2\u00c2\u00c3\7\37\2\2\u00c3\u00c4\5$\23\2"+
		"\u00c4\u00ca\3\2\2\2\u00c5\u00c6\5 \21\2\u00c6\u00c7\7\37\2\2\u00c7\u00c8"+
		"\5$\23\2\u00c8\u00ca\3\2\2\2\u00c9\u00c1\3\2\2\2\u00c9\u00c5\3\2\2\2\u00ca"+
		"#\3\2\2\2\u00cb\u00cf\5\22\n\2\u00cc\u00cf\5\"\22\2\u00cd\u00cf\5 \21"+
		"\2\u00ce\u00cb\3\2\2\2\u00ce\u00cc\3\2\2\2\u00ce\u00cd\3\2\2\2\u00cf%"+
		"\3\2\2\2\u00d0\u00d1\7\17\2\2\u00d1\u00d5\5\22\n\2\u00d2\u00d3\7\17\2"+
		"\2\u00d3\u00d5\7\61\2\2\u00d4\u00d0\3\2\2\2\u00d4\u00d2\3\2\2\2\u00d5"+
		"\'\3\2\2\2\u00d6\u00d7\7\3\2\2\u00d7\u00d8\5\22\n\2\u00d8\u00d9\7\"\2"+
		"\2\u00d9\u00dc\5\n\6\2\u00da\u00db\7!\2\2\u00db\u00dd\5H%\2\u00dc\u00da"+
		"\3\2\2\2\u00dc\u00dd\3\2\2\2\u00dd)\3\2\2\2\u00de\u00df\7\16\2\2\u00df"+
		"\u00e0\5\22\n\2\u00e0\u00e1\7$\2\2\u00e1\u00e3\7)\2\2\u00e2\u00e4\5\30"+
		"\r\2\u00e3\u00e2\3\2\2\2\u00e3\u00e4\3\2\2\2\u00e4\u00e5\3\2\2\2\u00e5"+
		"\u00e6\7*\2\2\u00e6\u00e8\7)\2\2\u00e7\u00e9\5\30\r\2\u00e8\u00e7\3\2"+
		"\2\2\u00e8\u00e9\3\2\2\2\u00e9\u00ea\3\2\2\2\u00ea\u00eb\7*\2\2\u00eb"+
		"\u00ec\5,\27\2\u00ec+\3\2\2\2\u00ed\u011e\7+\2\2\u00ee\u011d\5\6\4\2\u00ef"+
		"\u00f0\7\30\2\2\u00f0\u00f1\5\34\17\2\u00f1\u00f8\5\b\5\2\u00f2\u00f3"+
		"\7\32\2\2\u00f3\u00f4\5\34\17\2\u00f4\u00f5\5\b\5\2\u00f5\u00f7\3\2\2"+
		"\2\u00f6\u00f2\3\2\2\2\u00f7\u00fa\3\2\2\2\u00f8\u00f6\3\2\2\2\u00f8\u00f9"+
		"\3\2\2\2\u00f9\u00fd\3\2\2\2\u00fa\u00f8\3\2\2\2\u00fb\u00fc\7\31\2\2"+
		"\u00fc\u00fe\5\b\5\2\u00fd\u00fb\3\2\2\2\u00fd\u00fe\3\2\2\2\u00fe\u011d"+
		"\3\2\2\2\u00ff\u0100\7\35\2\2\u0100\u0101\5\34\17\2\u0101\u0102\5\b\5"+
		"\2\u0102\u011d\3\2\2\2\u0103\u0105\7\33\2\2\u0104\u0106\5\n\6\2\u0105"+
		"\u0104\3\2\2\2\u0105\u0106\3\2\2\2\u0106\u0107\3\2\2\2\u0107\u0108\5\26"+
		"\f\2\u0108\u0109\7$\2\2\u0109\u010a\5\32\16\2\u010a\u010b\7!\2\2\u010b"+
		"\u010e\5\34\17\2\u010c\u010d\7!\2\2\u010d\u010f\5\34\17\2\u010e\u010c"+
		"\3\2\2\2\u010e\u010f\3\2\2\2\u010f\u0110\3\2\2\2\u0110\u0111\5\b\5\2\u0111"+
		"\u011d\3\2\2\2\u0112\u0114\7\33\2\2\u0113\u0115\5\n\6\2\u0114\u0113\3"+
		"\2\2\2\u0114\u0115\3\2\2\2\u0115\u0116\3\2\2\2\u0116\u0117\5\22\n\2\u0117"+
		"\u0118\7\34\2\2\u0118\u0119\5\22\n\2\u0119\u011a\5\b\5\2\u011a\u011d\3"+
		"\2\2\2\u011b\u011d\5.\30\2\u011c\u00ee\3\2\2\2\u011c\u00ef\3\2\2\2\u011c"+
		"\u00ff\3\2\2\2\u011c\u0103\3\2\2\2\u011c\u0112\3\2\2\2\u011c\u011b\3\2"+
		"\2\2\u011d\u0120\3\2\2\2\u011e\u011c\3\2\2\2\u011e\u011f\3\2\2\2\u011f"+
		"\u0121\3\2\2\2\u0120\u011e\3\2\2\2\u0121\u0122\7,\2\2\u0122-\3\2\2\2\u0123"+
		"\u0125\7\36\2\2\u0124\u0126\5\26\f\2\u0125\u0124\3\2\2\2\u0125\u0126\3"+
		"\2\2\2\u0126/\3\2\2\2\u0127\u0128\5\22\n\2\u0128\u012a\7)\2\2\u0129\u012b"+
		"\5\26\f\2\u012a\u0129\3\2\2\2\u012a\u012b\3\2\2\2\u012b\u012c\3\2\2\2"+
		"\u012c\u012d\7*\2\2\u012d\61\3\2\2\2\u012e\u012f\7\t\2\2\u012f\u0130\5"+
		"\22\n\2\u0130\u0137\7+\2\2\u0131\u0132\5\n\6\2\u0132\u0133\5\22\n\2\u0133"+
		"\u0134\5J&\2\u0134\u0136\3\2\2\2\u0135\u0131\3\2\2\2\u0136\u0139\3\2\2"+
		"\2\u0137\u0135\3\2\2\2\u0137\u0138\3\2\2\2\u0138\u013a\3\2\2\2\u0139\u0137"+
		"\3\2\2\2\u013a\u013b\7,\2\2\u013b\63\3\2\2\2\u013c\u013d\7/\2\2\u013d"+
		"\65\3\2\2\2\u013e\u013f\7/\2\2\u013f\67\3\2\2\2\u0140\u0141\5\64\33\2"+
		"\u0141\u0148\5\22\n\2\u0142\u0143\7!\2\2\u0143\u0144\5\64\33\2\u0144\u0145"+
		"\5\22\n\2\u0145\u0147\3\2\2\2\u0146\u0142\3\2\2\2\u0147\u014a\3\2\2\2"+
		"\u0148\u0146\3\2\2\2\u0148\u0149\3\2\2\2\u01499\3\2\2\2\u014a\u0148\3"+
		"\2\2\2\u014b\u014c\7\n\2\2\u014c\u014d\5\64\33\2\u014d\u0165\7+\2\2\u014e"+
		"\u0150\7\22\2\2\u014f\u014e\3\2\2\2\u014f\u0150\3\2\2\2\u0150\u0153\3"+
		"\2\2\2\u0151\u0154\5\24\13\2\u0152\u0154\5\n\6\2\u0153\u0151\3\2\2\2\u0153"+
		"\u0152\3\2\2\2\u0154\u0155\3\2\2\2\u0155\u0162\5\22\n\2\u0156\u0158\7"+
		"!\2\2\u0157\u0159\7\22\2\2\u0158\u0157\3\2\2\2\u0158\u0159\3\2\2\2\u0159"+
		"\u015c\3\2\2\2\u015a\u015d\5\24\13\2\u015b\u015d\5\n\6\2\u015c\u015a\3"+
		"\2\2\2\u015c\u015b\3\2\2\2\u015d\u015e\3\2\2\2\u015e\u015f\5\22\n\2\u015f"+
		"\u0161\3\2\2\2\u0160\u0156\3\2\2\2\u0161\u0164\3\2\2\2\u0162\u0160\3\2"+
		"\2\2\u0162\u0163\3\2\2\2\u0163\u0166\3\2\2\2\u0164\u0162\3\2\2\2\u0165"+
		"\u014f\3\2\2\2\u0165\u0166\3\2\2\2\u0166\u0167\3\2\2\2\u0167\u0168\7,"+
		"\2\2\u0168;\3\2\2\2\u0169\u016a\7\13\2\2\u016a\u016b\5\66\34\2\u016b\u016c"+
		"\7+\2\2\u016c\u016d\5B\"\2\u016d\u016e\7,\2\2\u016e\u0179\3\2\2\2\u016f"+
		"\u0170\7\13\2\2\u0170\u0171\5\66\34\2\u0171\u0176\5> \2\u0172\u0173\7"+
		"+\2\2\u0173\u0174\5B\"\2\u0174\u0175\7,\2\2\u0175\u0177\3\2\2\2\u0176"+
		"\u0172\3\2\2\2\u0176\u0177\3\2\2\2\u0177\u0179\3\2\2\2\u0178\u0169\3\2"+
		"\2\2\u0178\u016f\3\2\2\2\u0179=\3\2\2\2\u017a\u017c\7)\2\2\u017b\u017d"+
		"\58\35\2\u017c\u017b\3\2\2\2\u017c\u017d\3\2\2\2\u017d\u017e\3\2\2\2\u017e"+
		"\u0180\7(\2\2\u017f\u0181\58\35\2\u0180\u017f\3\2\2\2\u0180\u0181\3\2"+
		"\2\2\u0181\u0182\3\2\2\2\u0182\u0183\7*\2\2\u0183?\3\2\2\2\u0184\u0185"+
		"\7\f\2\2\u0185\u0186\5\22\n\2\u0186\u0187\7+\2\2\u0187\u0188\5B\"\2\u0188"+
		"\u0189\7,\2\2\u0189\u0198\3\2\2\2\u018a\u018b\7\f\2\2\u018b\u018c\5\22"+
		"\n\2\u018c\u0191\5> \2\u018d\u018e\7+\2\2\u018e\u018f\5B\"\2\u018f\u0190"+
		"\7,\2\2\u0190\u0192\3\2\2\2\u0191\u018d\3\2\2\2\u0191\u0192\3\2\2\2\u0192"+
		"\u0198\3\2\2\2\u0193\u0194\7\f\2\2\u0194\u0195\5\24\13\2\u0195\u0196\5"+
		"\22\n\2\u0196\u0198\3\2\2\2\u0197\u0184\3\2\2\2\u0197\u018a\3\2\2\2\u0197"+
		"\u0193\3\2\2\2\u0198A\3\2\2\2\u0199\u019b\t\4\2\2\u019a\u019c\5\30\r\2"+
		"\u019b\u019a\3\2\2\2\u019b\u019c\3\2\2\2\u019c\u019d\3\2\2\2\u019d\u01a8"+
		"\5J&\2\u019e\u019f\7\20\2\2\u019f\u01a0\5\22\n\2\u01a0\u01a1\5J&\2\u01a1"+
		"\u01a8\3\2\2\2\u01a2\u01a3\7\21\2\2\u01a3\u01a4\5\n\6\2\u01a4\u01a5\5"+
		"\26\f\2\u01a5\u01a6\5J&\2\u01a6\u01a8\3\2\2\2\u01a7\u0199\3\2\2\2\u01a7"+
		"\u019e\3\2\2\2\u01a7\u01a2\3\2\2\2\u01a8\u01ab\3\2\2\2\u01a9\u01a7\3\2"+
		"\2\2\u01a9\u01aa\3\2\2\2\u01aaC\3\2\2\2\u01ab\u01a9\3\2\2\2\u01ac\u01ad"+
		"\7\r\2\2\u01ad\u01ae\5\22\n\2\u01ae\u01b6\7+\2\2\u01af\u01b0\7\21\2\2"+
		"\u01b0\u01b1\5\n\6\2\u01b1\u01b2\5\26\f\2\u01b2\u01b3\5J&\2\u01b3\u01b5"+
		"\3\2\2\2\u01b4\u01af\3\2\2\2\u01b5\u01b8\3\2\2\2\u01b6\u01b4\3\2\2\2\u01b6"+
		"\u01b7\3\2\2\2\u01b7\u01b9\3\2\2\2\u01b8\u01b6\3\2\2\2\u01b9\u01ba\7,"+
		"\2\2\u01baE\3\2\2\2\u01bb\u01bc\t\5\2\2\u01bcG\3\2\2\2\u01bd\u01be\7\61"+
		"\2\2\u01beI\3\2\2\2\u01bf\u01c0\78\2\2\u01c0K\3\2\2\2,Rmp~\u008f\u009a"+
		"\u00a2\u00af\u00bf\u00c9\u00ce\u00d4\u00dc\u00e3\u00e8\u00f8\u00fd\u0105"+
		"\u010e\u0114\u011c\u011e\u0125\u012a\u0137\u0148\u014f\u0153\u0158\u015c"+
		"\u0162\u0165\u0176\u0178\u017c\u0180\u0191\u0197\u019b\u01a7\u01a9\u01b6";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}