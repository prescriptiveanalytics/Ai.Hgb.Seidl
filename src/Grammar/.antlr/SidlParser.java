// Generated from c:\dev\workspaces\spa\Sidl\src\Grammar\Sidl.g4 by ANTLR 4.9.2
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
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		T__24=25, T__25=26, T__26=27, T__27=28, T__28=29, T__29=30, TYPE=31, FUNCTION=32, 
		STRUCT=33, MESSAGE=34, NODETYPE=35, NODE=36, META=37, IMPORT=38, INCLUDE=39, 
		PROPERTY=40, TOPIC=41, NAME=42, WORD=43, STRING=44, NORMALSTRING=45, CHARSTRING=46, 
		LONGSTRING=47, INTEGER=48, FLOAT=49, WHITESPACE=50, STMEND=51, COMMENT=52, 
		LINECOMMENT=53, SHEBANG=54;
	public static final int
		RULE_root = 0, RULE_set = 1, RULE_statement = 2, RULE_scope = 3, RULE_type = 4, 
		RULE_atomictype = 5, RULE_complextype = 6, RULE_graphtype = 7, RULE_variable = 8, 
		RULE_variablelist = 9, RULE_typedvariablelist = 10, RULE_expressionlist = 11, 
		RULE_expression = 12, RULE_arraydeclaration = 13, RULE_arrayaccess = 14, 
		RULE_fieldaccess = 15, RULE_lefthandside = 16, RULE_importstatement = 17, 
		RULE_typealiasingstatement = 18, RULE_functiondefinition = 19, RULE_functionbody = 20, 
		RULE_returnstatement = 21, RULE_functioncall = 22, RULE_structdefinition = 23, 
		RULE_messagedefinition = 24, RULE_nodetypedefinition = 25, RULE_nodetypesignature = 26, 
		RULE_nodedefinition = 27, RULE_nodebody = 28, RULE_metadefinition = 29, 
		RULE_number = 30, RULE_string = 31, RULE_typetype = 32, RULE_functiontype = 33, 
		RULE_structtype = 34, RULE_messagetype = 35, RULE_nodetypetype = 36, RULE_nodetype = 37, 
		RULE_propertytype = 38, RULE_topictype = 39, RULE_metatype = 40, RULE_terminator = 41;
	private static String[] makeRuleNames() {
		return new String[] {
			"root", "set", "statement", "scope", "type", "atomictype", "complextype", 
			"graphtype", "variable", "variablelist", "typedvariablelist", "expressionlist", 
			"expression", "arraydeclaration", "arrayaccess", "fieldaccess", "lefthandside", 
			"importstatement", "typealiasingstatement", "functiondefinition", "functionbody", 
			"returnstatement", "functioncall", "structdefinition", "messagedefinition", 
			"nodetypedefinition", "nodetypesignature", "nodedefinition", "nodebody", 
			"metadefinition", "number", "string", "typetype", "functiontype", "structtype", 
			"messagetype", "nodetypetype", "nodetype", "propertytype", "topictype", 
			"metatype", "terminator"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'='", "'{'", "'}'", "'[]'", "'int'", "'float'", "'string'", "'bool'", 
			"','", "'null'", "'false'", "'true'", "'['", "']'", "'.'", "':'", "'('", 
			"')'", "'if'", "'else if'", "'else'", "'while'", "'for'", "'in'", "'return'", 
			"'=>'", "'name'", "'description'", "'input'", "'output'", "'type'", "'function'", 
			"'struct'", "'message'", "'nodetype'", "'node'", "'meta'", "'import'", 
			"'include'", "'property'", "'topic'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, "TYPE", "FUNCTION", "STRUCT", 
			"MESSAGE", "NODETYPE", "NODE", "META", "IMPORT", "INCLUDE", "PROPERTY", 
			"TOPIC", "NAME", "WORD", "STRING", "NORMALSTRING", "CHARSTRING", "LONGSTRING", 
			"INTEGER", "FLOAT", "WHITESPACE", "STMEND", "COMMENT", "LINECOMMENT", 
			"SHEBANG"
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
	public String getGrammarFileName() { return "Sidl.g4"; }

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
			setState(84);
			set();
			setState(85);
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
			setState(90);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__1) | (1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << TYPE) | (1L << STRUCT) | (1L << MESSAGE) | (1L << NODETYPE) | (1L << NODE) | (1L << META) | (1L << IMPORT) | (1L << NAME) | (1L << STMEND))) != 0)) {
				{
				{
				setState(87);
				statement();
				}
				}
				setState(92);
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
			setState(117);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				_localctx = new TerminatorStatementContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(93);
				terminator();
				}
				break;
			case 2:
				_localctx = new ScopeStatementContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(94);
				scope();
				}
				break;
			case 3:
				_localctx = new DeclarationStatementContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(95);
				type();
				setState(96);
				variablelist();
				setState(97);
				terminator();
				}
				break;
			case 4:
				_localctx = new AssignmentStatementContext(_localctx);
				enterOuterAlt(_localctx, 4);
				{
				setState(99);
				variablelist();
				setState(100);
				match(T__0);
				setState(101);
				expressionlist();
				setState(102);
				terminator();
				}
				break;
			case 5:
				_localctx = new DefinitionStatementContext(_localctx);
				enterOuterAlt(_localctx, 5);
				{
				setState(104);
				type();
				setState(105);
				variablelist();
				setState(106);
				match(T__0);
				setState(107);
				expressionlist();
				setState(108);
				terminator();
				}
				break;
			case 6:
				_localctx = new StructdefinitionStatementContext(_localctx);
				enterOuterAlt(_localctx, 6);
				{
				setState(110);
				structdefinition();
				}
				break;
			case 7:
				_localctx = new MessagedefinitionStatementContext(_localctx);
				enterOuterAlt(_localctx, 7);
				{
				setState(111);
				messagedefinition();
				}
				break;
			case 8:
				_localctx = new NodetypedefinitionStatementContext(_localctx);
				enterOuterAlt(_localctx, 8);
				{
				setState(112);
				nodetypedefinition();
				}
				break;
			case 9:
				_localctx = new NodedefinitionStatementContext(_localctx);
				enterOuterAlt(_localctx, 9);
				{
				setState(113);
				nodedefinition();
				}
				break;
			case 10:
				_localctx = new MetadefinitionStatementContext(_localctx);
				enterOuterAlt(_localctx, 10);
				{
				setState(114);
				metadefinition();
				}
				break;
			case 11:
				_localctx = new ImportStatementContext(_localctx);
				enterOuterAlt(_localctx, 11);
				{
				setState(115);
				importstatement();
				}
				break;
			case 12:
				_localctx = new TypealiasingStatementContext(_localctx);
				enterOuterAlt(_localctx, 12);
				{
				setState(116);
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
		public SetContext set() {
			return getRuleContext(SetContext.class,0);
		}
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
			setState(120);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NAME) {
				{
				setState(119);
				variable();
				}
			}

			setState(122);
			match(T__1);
			setState(123);
			set();
			setState(124);
			match(T__2);
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
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
	}

	public final TypeContext type() throws RecognitionException {
		TypeContext _localctx = new TypeContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_type);
		try {
			setState(134);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(126);
				atomictype();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(127);
				complextype();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(128);
				atomictype();
				setState(129);
				match(T__3);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(131);
				complextype();
				setState(132);
				match(T__3);
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
			setState(136);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7))) != 0)) ) {
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
		public StructtypeContext structtype() {
			return getRuleContext(StructtypeContext.class,0);
		}
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
			setState(138);
			structtype();
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
		public MessagetypeContext messagetype() {
			return getRuleContext(MessagetypeContext.class,0);
		}
		public NodetypetypeContext nodetypetype() {
			return getRuleContext(NodetypetypeContext.class,0);
		}
		public NodetypeContext nodetype() {
			return getRuleContext(NodetypeContext.class,0);
		}
		public MetatypeContext metatype() {
			return getRuleContext(MetatypeContext.class,0);
		}
		public GraphtypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_graphtype; }
	}

	public final GraphtypeContext graphtype() throws RecognitionException {
		GraphtypeContext _localctx = new GraphtypeContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_graphtype);
		try {
			setState(144);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case MESSAGE:
				enterOuterAlt(_localctx, 1);
				{
				setState(140);
				messagetype();
				}
				break;
			case NODETYPE:
				enterOuterAlt(_localctx, 2);
				{
				setState(141);
				nodetypetype();
				}
				break;
			case NODE:
				enterOuterAlt(_localctx, 3);
				{
				setState(142);
				nodetype();
				}
				break;
			case META:
				enterOuterAlt(_localctx, 4);
				{
				setState(143);
				metatype();
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
			setState(146);
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
		public VariablelistContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variablelist; }
	}

	public final VariablelistContext variablelist() throws RecognitionException {
		VariablelistContext _localctx = new VariablelistContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_variablelist);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(148);
			variable();
			setState(153);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__8) {
				{
				{
				setState(149);
				match(T__8);
				setState(150);
				variable();
				}
				}
				setState(155);
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
		public TypedvariablelistContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typedvariablelist; }
	}

	public final TypedvariablelistContext typedvariablelist() throws RecognitionException {
		TypedvariablelistContext _localctx = new TypedvariablelistContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_typedvariablelist);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(156);
			type();
			setState(157);
			variable();
			setState(164);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__8) {
				{
				{
				setState(158);
				match(T__8);
				setState(159);
				type();
				setState(160);
				variable();
				}
				}
				setState(166);
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
		public ExpressionlistContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expressionlist; }
	}

	public final ExpressionlistContext expressionlist() throws RecognitionException {
		ExpressionlistContext _localctx = new ExpressionlistContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_expressionlist);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(167);
			expression();
			setState(172);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(168);
					match(T__8);
					setState(169);
					expression();
					}
					} 
				}
				setState(174);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
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
		enterRule(_localctx, 24, RULE_expression);
		try {
			setState(185);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(175);
				match(T__9);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(176);
				match(T__10);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(177);
				match(T__11);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(178);
				number();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(179);
				string();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(180);
				variable();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(181);
				scope();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(182);
				functiondefinition();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(183);
				functioncall();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(184);
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
		enterRule(_localctx, 26, RULE_arraydeclaration);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(187);
			type();
			setState(188);
			match(T__3);
			setState(189);
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
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
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
		enterRule(_localctx, 28, RULE_arrayaccess);
		try {
			setState(201);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NAME:
				enterOuterAlt(_localctx, 1);
				{
				setState(191);
				variable();
				setState(192);
				match(T__12);
				setState(193);
				expression();
				setState(194);
				match(T__13);
				}
				break;
			case STRING:
				enterOuterAlt(_localctx, 2);
				{
				setState(196);
				string();
				setState(197);
				match(T__12);
				setState(198);
				expression();
				setState(199);
				match(T__13);
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
		enterRule(_localctx, 30, RULE_fieldaccess);
		try {
			setState(211);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,10,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(203);
				variable();
				setState(204);
				match(T__14);
				setState(205);
				lefthandside();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(207);
				arrayaccess();
				setState(208);
				match(T__14);
				setState(209);
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
		enterRule(_localctx, 32, RULE_lefthandside);
		try {
			setState(216);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,11,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(213);
				variable();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(214);
				fieldaccess();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(215);
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
		public StringContext string() {
			return getRuleContext(StringContext.class,0);
		}
		public ImportstatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_importstatement; }
	}

	public final ImportstatementContext importstatement() throws RecognitionException {
		ImportstatementContext _localctx = new ImportstatementContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_importstatement);
		try {
			setState(222);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(218);
				match(IMPORT);
				setState(219);
				variable();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(220);
				match(IMPORT);
				setState(221);
				string();
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
		public TypetypeContext typetype() {
			return getRuleContext(TypetypeContext.class,0);
		}
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
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
		enterRule(_localctx, 36, RULE_typealiasingstatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(224);
			typetype();
			setState(225);
			variable();
			setState(226);
			match(T__15);
			setState(227);
			type();
			setState(230);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__8) {
				{
				setState(228);
				match(T__8);
				setState(229);
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
		public FunctiontypeContext functiontype() {
			return getRuleContext(FunctiontypeContext.class,0);
		}
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
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
		enterRule(_localctx, 38, RULE_functiondefinition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(232);
			functiontype();
			setState(233);
			variable();
			setState(234);
			match(T__0);
			setState(235);
			match(T__16);
			setState(237);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << STRUCT))) != 0)) {
				{
				setState(236);
				typedvariablelist();
				}
			}

			setState(239);
			match(T__17);
			setState(240);
			match(T__16);
			setState(242);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << STRUCT))) != 0)) {
				{
				setState(241);
				typedvariablelist();
				}
			}

			setState(244);
			match(T__17);
			setState(245);
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
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
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
		public List<VariablelistContext> variablelist() {
			return getRuleContexts(VariablelistContext.class);
		}
		public VariablelistContext variablelist(int i) {
			return getRuleContext(VariablelistContext.class,i);
		}
		public List<ExpressionlistContext> expressionlist() {
			return getRuleContexts(ExpressionlistContext.class);
		}
		public ExpressionlistContext expressionlist(int i) {
			return getRuleContext(ExpressionlistContext.class,i);
		}
		public List<VariableContext> variable() {
			return getRuleContexts(VariableContext.class);
		}
		public VariableContext variable(int i) {
			return getRuleContext(VariableContext.class,i);
		}
		public List<ReturnstatementContext> returnstatement() {
			return getRuleContexts(ReturnstatementContext.class);
		}
		public ReturnstatementContext returnstatement(int i) {
			return getRuleContext(ReturnstatementContext.class,i);
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
		enterRule(_localctx, 40, RULE_functionbody);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(247);
			match(T__1);
			setState(296);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__1) | (1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << T__18) | (1L << T__21) | (1L << T__22) | (1L << T__24) | (1L << TYPE) | (1L << STRUCT) | (1L << MESSAGE) | (1L << NODETYPE) | (1L << NODE) | (1L << META) | (1L << IMPORT) | (1L << NAME) | (1L << STMEND))) != 0)) {
				{
				setState(294);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,21,_ctx) ) {
				case 1:
					{
					setState(248);
					statement();
					}
					break;
				case 2:
					{
					setState(249);
					match(T__18);
					setState(250);
					expression();
					setState(251);
					scope();
					setState(258);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==T__19) {
						{
						{
						setState(252);
						match(T__19);
						setState(253);
						expression();
						setState(254);
						scope();
						}
						}
						setState(260);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					setState(263);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==T__20) {
						{
						setState(261);
						match(T__20);
						setState(262);
						scope();
						}
					}

					}
					break;
				case 3:
					{
					setState(265);
					match(T__21);
					setState(266);
					expression();
					setState(267);
					scope();
					}
					break;
				case 4:
					{
					setState(269);
					match(T__22);
					setState(271);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << STRUCT))) != 0)) {
						{
						setState(270);
						type();
						}
					}

					setState(273);
					variablelist();
					setState(274);
					match(T__0);
					setState(275);
					expressionlist();
					setState(276);
					match(T__8);
					setState(277);
					expression();
					setState(280);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==T__8) {
						{
						setState(278);
						match(T__8);
						setState(279);
						expression();
						}
					}

					setState(282);
					scope();
					}
					break;
				case 5:
					{
					setState(284);
					match(T__22);
					setState(286);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << STRUCT))) != 0)) {
						{
						setState(285);
						type();
						}
					}

					setState(288);
					variable();
					setState(289);
					match(T__23);
					setState(290);
					variable();
					setState(291);
					scope();
					}
					break;
				case 6:
					{
					setState(293);
					returnstatement();
					}
					break;
				}
				}
				setState(298);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(299);
			match(T__2);
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
		enterRule(_localctx, 42, RULE_returnstatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(301);
			match(T__24);
			setState(303);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,23,_ctx) ) {
			case 1:
				{
				setState(302);
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
		enterRule(_localctx, 44, RULE_functioncall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(305);
			variable();
			setState(306);
			match(T__16);
			setState(308);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NAME) {
				{
				setState(307);
				variablelist();
				}
			}

			setState(310);
			match(T__17);
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
		public StructtypeContext structtype() {
			return getRuleContext(StructtypeContext.class,0);
		}
		public List<VariableContext> variable() {
			return getRuleContexts(VariableContext.class);
		}
		public VariableContext variable(int i) {
			return getRuleContext(VariableContext.class,i);
		}
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
		enterRule(_localctx, 46, RULE_structdefinition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(312);
			structtype();
			setState(313);
			variable();
			setState(314);
			match(T__0);
			setState(315);
			match(T__1);
			setState(322);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << STRUCT))) != 0)) {
				{
				{
				setState(316);
				type();
				setState(317);
				variable();
				setState(318);
				terminator();
				}
				}
				setState(324);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(325);
			match(T__2);
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
		public MessagetypeContext messagetype() {
			return getRuleContext(MessagetypeContext.class,0);
		}
		public List<VariableContext> variable() {
			return getRuleContexts(VariableContext.class);
		}
		public VariableContext variable(int i) {
			return getRuleContext(VariableContext.class,i);
		}
		public List<TopictypeContext> topictype() {
			return getRuleContexts(TopictypeContext.class);
		}
		public TopictypeContext topictype(int i) {
			return getRuleContext(TopictypeContext.class,i);
		}
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public MessagedefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_messagedefinition; }
	}

	public final MessagedefinitionContext messagedefinition() throws RecognitionException {
		MessagedefinitionContext _localctx = new MessagedefinitionContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_messagedefinition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(327);
			messagetype();
			setState(328);
			variable();
			setState(329);
			match(T__1);
			setState(350);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << STRUCT) | (1L << TOPIC) | (1L << NAME))) != 0)) {
				{
				setState(331);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==TOPIC) {
					{
					setState(330);
					topictype();
					}
				}

				setState(334);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << STRUCT))) != 0)) {
					{
					setState(333);
					type();
					}
				}

				setState(336);
				variable();
				setState(347);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==T__8) {
					{
					{
					setState(337);
					match(T__8);
					setState(339);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==TOPIC) {
						{
						setState(338);
						topictype();
						}
					}

					setState(342);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << STRUCT))) != 0)) {
						{
						setState(341);
						type();
						}
					}

					setState(344);
					variable();
					}
					}
					setState(349);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(352);
			match(T__2);
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
		public NodetypetypeContext nodetypetype() {
			return getRuleContext(NodetypetypeContext.class,0);
		}
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public NodebodyContext nodebody() {
			return getRuleContext(NodebodyContext.class,0);
		}
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
		enterRule(_localctx, 50, RULE_nodetypedefinition);
		try {
			setState(369);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,33,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(354);
				nodetypetype();
				setState(355);
				variable();
				setState(356);
				match(T__1);
				setState(357);
				nodebody();
				setState(358);
				match(T__2);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(360);
				nodetypetype();
				setState(361);
				variable();
				setState(362);
				nodetypesignature();
				setState(367);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,32,_ctx) ) {
				case 1:
					{
					setState(363);
					match(T__1);
					setState(364);
					nodebody();
					setState(365);
					match(T__2);
					}
					break;
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
		public VariablelistContext variablelist() {
			return getRuleContext(VariablelistContext.class,0);
		}
		public TypedvariablelistContext typedvariablelist() {
			return getRuleContext(TypedvariablelistContext.class,0);
		}
		public List<VariableContext> variable() {
			return getRuleContexts(VariableContext.class);
		}
		public VariableContext variable(int i) {
			return getRuleContext(VariableContext.class,i);
		}
		public List<TopictypeContext> topictype() {
			return getRuleContexts(TopictypeContext.class);
		}
		public TopictypeContext topictype(int i) {
			return getRuleContext(TopictypeContext.class,i);
		}
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public NodetypesignatureContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_nodetypesignature; }
	}

	public final NodetypesignatureContext nodetypesignature() throws RecognitionException {
		NodetypesignatureContext _localctx = new NodetypesignatureContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_nodetypesignature);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(371);
			match(T__16);
			setState(374);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NAME:
				{
				setState(372);
				variablelist();
				}
				break;
			case T__4:
			case T__5:
			case T__6:
			case T__7:
			case STRUCT:
				{
				setState(373);
				typedvariablelist();
				}
				break;
			case T__25:
				break;
			default:
				break;
			}
			setState(376);
			match(T__25);
			setState(397);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << STRUCT) | (1L << TOPIC) | (1L << NAME))) != 0)) {
				{
				setState(378);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==TOPIC) {
					{
					setState(377);
					topictype();
					}
				}

				setState(381);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << STRUCT))) != 0)) {
					{
					setState(380);
					type();
					}
				}

				setState(383);
				variable();
				setState(394);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==T__8) {
					{
					{
					setState(384);
					match(T__8);
					setState(386);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==TOPIC) {
						{
						setState(385);
						topictype();
						}
					}

					setState(389);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << STRUCT))) != 0)) {
						{
						setState(388);
						type();
						}
					}

					setState(391);
					variable();
					}
					}
					setState(396);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(399);
			match(T__17);
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
		public NodetypeContext nodetype() {
			return getRuleContext(NodetypeContext.class,0);
		}
		public List<VariableContext> variable() {
			return getRuleContexts(VariableContext.class);
		}
		public VariableContext variable(int i) {
			return getRuleContext(VariableContext.class,i);
		}
		public NodebodyContext nodebody() {
			return getRuleContext(NodebodyContext.class,0);
		}
		public NodetypesignatureContext nodetypesignature() {
			return getRuleContext(NodetypesignatureContext.class,0);
		}
		public NodedefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_nodedefinition; }
	}

	public final NodedefinitionContext nodedefinition() throws RecognitionException {
		NodedefinitionContext _localctx = new NodedefinitionContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_nodedefinition);
		try {
			setState(420);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,42,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(401);
				nodetype();
				setState(402);
				variable();
				setState(403);
				match(T__1);
				setState(404);
				nodebody();
				setState(405);
				match(T__2);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(407);
				nodetype();
				setState(408);
				variable();
				setState(409);
				nodetypesignature();
				setState(414);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,41,_ctx) ) {
				case 1:
					{
					setState(410);
					match(T__1);
					setState(411);
					nodebody();
					setState(412);
					match(T__2);
					}
					break;
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(416);
				nodetype();
				setState(417);
				variable();
				setState(418);
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
		public List<StringContext> string() {
			return getRuleContexts(StringContext.class);
		}
		public StringContext string(int i) {
			return getRuleContext(StringContext.class,i);
		}
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
		public List<PropertytypeContext> propertytype() {
			return getRuleContexts(PropertytypeContext.class);
		}
		public PropertytypeContext propertytype(int i) {
			return getRuleContext(PropertytypeContext.class,i);
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
		enterRule(_localctx, 56, RULE_nodebody);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(451);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__26) | (1L << T__27) | (1L << T__28) | (1L << T__29) | (1L << INCLUDE) | (1L << PROPERTY))) != 0)) {
				{
				setState(449);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case T__26:
					{
					setState(422);
					match(T__26);
					setState(423);
					string();
					setState(424);
					terminator();
					}
					break;
				case T__27:
					{
					setState(426);
					match(T__27);
					setState(427);
					string();
					setState(428);
					terminator();
					}
					break;
				case T__28:
					{
					setState(430);
					match(T__28);
					setState(432);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << STRUCT))) != 0)) {
						{
						setState(431);
						typedvariablelist();
						}
					}

					setState(434);
					terminator();
					}
					break;
				case T__29:
					{
					setState(435);
					match(T__29);
					setState(437);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << STRUCT))) != 0)) {
						{
						setState(436);
						typedvariablelist();
						}
					}

					setState(439);
					terminator();
					}
					break;
				case INCLUDE:
					{
					setState(440);
					match(INCLUDE);
					setState(441);
					variable();
					setState(442);
					terminator();
					}
					break;
				case PROPERTY:
					{
					setState(444);
					propertytype();
					setState(445);
					type();
					setState(446);
					variablelist();
					setState(447);
					terminator();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(453);
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
		public MetatypeContext metatype() {
			return getRuleContext(MetatypeContext.class,0);
		}
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public List<PropertytypeContext> propertytype() {
			return getRuleContexts(PropertytypeContext.class);
		}
		public PropertytypeContext propertytype(int i) {
			return getRuleContext(PropertytypeContext.class,i);
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
		enterRule(_localctx, 58, RULE_metadefinition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(454);
			metatype();
			setState(455);
			variable();
			setState(456);
			match(T__1);
			setState(464);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==PROPERTY) {
				{
				{
				setState(457);
				propertytype();
				setState(458);
				type();
				setState(459);
				variablelist();
				setState(460);
				terminator();
				}
				}
				setState(466);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(467);
			match(T__2);
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
		public TerminalNode FLOAT() { return getToken(SidlParser.FLOAT, 0); }
		public NumberContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_number; }
	}

	public final NumberContext number() throws RecognitionException {
		NumberContext _localctx = new NumberContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_number);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(469);
			_la = _input.LA(1);
			if ( !(_la==INTEGER || _la==FLOAT) ) {
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
		public TerminalNode STRING() { return getToken(SidlParser.STRING, 0); }
		public StringContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_string; }
	}

	public final StringContext string() throws RecognitionException {
		StringContext _localctx = new StringContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_string);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(471);
			match(STRING);
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

	public static class TypetypeContext extends ParserRuleContext {
		public TerminalNode TYPE() { return getToken(SidlParser.TYPE, 0); }
		public TypetypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typetype; }
	}

	public final TypetypeContext typetype() throws RecognitionException {
		TypetypeContext _localctx = new TypetypeContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_typetype);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(473);
			match(TYPE);
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

	public static class FunctiontypeContext extends ParserRuleContext {
		public TerminalNode FUNCTION() { return getToken(SidlParser.FUNCTION, 0); }
		public FunctiontypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functiontype; }
	}

	public final FunctiontypeContext functiontype() throws RecognitionException {
		FunctiontypeContext _localctx = new FunctiontypeContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_functiontype);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(475);
			match(FUNCTION);
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

	public static class StructtypeContext extends ParserRuleContext {
		public TerminalNode STRUCT() { return getToken(SidlParser.STRUCT, 0); }
		public StructtypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_structtype; }
	}

	public final StructtypeContext structtype() throws RecognitionException {
		StructtypeContext _localctx = new StructtypeContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_structtype);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(477);
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

	public static class MessagetypeContext extends ParserRuleContext {
		public TerminalNode MESSAGE() { return getToken(SidlParser.MESSAGE, 0); }
		public MessagetypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_messagetype; }
	}

	public final MessagetypeContext messagetype() throws RecognitionException {
		MessagetypeContext _localctx = new MessagetypeContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_messagetype);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(479);
			match(MESSAGE);
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

	public static class NodetypetypeContext extends ParserRuleContext {
		public TerminalNode NODETYPE() { return getToken(SidlParser.NODETYPE, 0); }
		public NodetypetypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_nodetypetype; }
	}

	public final NodetypetypeContext nodetypetype() throws RecognitionException {
		NodetypetypeContext _localctx = new NodetypetypeContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_nodetypetype);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(481);
			match(NODETYPE);
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

	public static class NodetypeContext extends ParserRuleContext {
		public TerminalNode NODE() { return getToken(SidlParser.NODE, 0); }
		public NodetypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_nodetype; }
	}

	public final NodetypeContext nodetype() throws RecognitionException {
		NodetypeContext _localctx = new NodetypeContext(_ctx, getState());
		enterRule(_localctx, 74, RULE_nodetype);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(483);
			match(NODE);
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

	public static class PropertytypeContext extends ParserRuleContext {
		public TerminalNode PROPERTY() { return getToken(SidlParser.PROPERTY, 0); }
		public PropertytypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_propertytype; }
	}

	public final PropertytypeContext propertytype() throws RecognitionException {
		PropertytypeContext _localctx = new PropertytypeContext(_ctx, getState());
		enterRule(_localctx, 76, RULE_propertytype);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(485);
			match(PROPERTY);
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

	public static class TopictypeContext extends ParserRuleContext {
		public TerminalNode TOPIC() { return getToken(SidlParser.TOPIC, 0); }
		public TopictypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_topictype; }
	}

	public final TopictypeContext topictype() throws RecognitionException {
		TopictypeContext _localctx = new TopictypeContext(_ctx, getState());
		enterRule(_localctx, 78, RULE_topictype);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(487);
			match(TOPIC);
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

	public static class MetatypeContext extends ParserRuleContext {
		public TerminalNode META() { return getToken(SidlParser.META, 0); }
		public MetatypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_metatype; }
	}

	public final MetatypeContext metatype() throws RecognitionException {
		MetatypeContext _localctx = new MetatypeContext(_ctx, getState());
		enterRule(_localctx, 80, RULE_metatype);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(489);
			match(META);
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
		enterRule(_localctx, 82, RULE_terminator);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(491);
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\38\u01f0\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\3"+
		"\2\3\2\3\2\3\3\7\3[\n\3\f\3\16\3^\13\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4"+
		"\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\5\4x"+
		"\n\4\3\5\5\5{\n\5\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\5\6"+
		"\u0089\n\6\3\7\3\7\3\b\3\b\3\t\3\t\3\t\3\t\5\t\u0093\n\t\3\n\3\n\3\13"+
		"\3\13\3\13\7\13\u009a\n\13\f\13\16\13\u009d\13\13\3\f\3\f\3\f\3\f\3\f"+
		"\3\f\7\f\u00a5\n\f\f\f\16\f\u00a8\13\f\3\r\3\r\3\r\7\r\u00ad\n\r\f\r\16"+
		"\r\u00b0\13\r\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\5\16\u00bc"+
		"\n\16\3\17\3\17\3\17\3\17\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20"+
		"\3\20\5\20\u00cc\n\20\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\5\21\u00d6"+
		"\n\21\3\22\3\22\3\22\5\22\u00db\n\22\3\23\3\23\3\23\3\23\5\23\u00e1\n"+
		"\23\3\24\3\24\3\24\3\24\3\24\3\24\5\24\u00e9\n\24\3\25\3\25\3\25\3\25"+
		"\3\25\5\25\u00f0\n\25\3\25\3\25\3\25\5\25\u00f5\n\25\3\25\3\25\3\25\3"+
		"\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\7\26\u0103\n\26\f\26\16\26"+
		"\u0106\13\26\3\26\3\26\5\26\u010a\n\26\3\26\3\26\3\26\3\26\3\26\3\26\5"+
		"\26\u0112\n\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\5\26\u011b\n\26\3\26"+
		"\3\26\3\26\3\26\5\26\u0121\n\26\3\26\3\26\3\26\3\26\3\26\3\26\7\26\u0129"+
		"\n\26\f\26\16\26\u012c\13\26\3\26\3\26\3\27\3\27\5\27\u0132\n\27\3\30"+
		"\3\30\3\30\5\30\u0137\n\30\3\30\3\30\3\31\3\31\3\31\3\31\3\31\3\31\3\31"+
		"\3\31\7\31\u0143\n\31\f\31\16\31\u0146\13\31\3\31\3\31\3\32\3\32\3\32"+
		"\3\32\5\32\u014e\n\32\3\32\5\32\u0151\n\32\3\32\3\32\3\32\5\32\u0156\n"+
		"\32\3\32\5\32\u0159\n\32\3\32\7\32\u015c\n\32\f\32\16\32\u015f\13\32\5"+
		"\32\u0161\n\32\3\32\3\32\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33"+
		"\3\33\3\33\3\33\3\33\5\33\u0172\n\33\5\33\u0174\n\33\3\34\3\34\3\34\5"+
		"\34\u0179\n\34\3\34\3\34\5\34\u017d\n\34\3\34\5\34\u0180\n\34\3\34\3\34"+
		"\3\34\5\34\u0185\n\34\3\34\5\34\u0188\n\34\3\34\7\34\u018b\n\34\f\34\16"+
		"\34\u018e\13\34\5\34\u0190\n\34\3\34\3\34\3\35\3\35\3\35\3\35\3\35\3\35"+
		"\3\35\3\35\3\35\3\35\3\35\3\35\3\35\5\35\u01a1\n\35\3\35\3\35\3\35\3\35"+
		"\5\35\u01a7\n\35\3\36\3\36\3\36\3\36\3\36\3\36\3\36\3\36\3\36\3\36\5\36"+
		"\u01b3\n\36\3\36\3\36\3\36\5\36\u01b8\n\36\3\36\3\36\3\36\3\36\3\36\3"+
		"\36\3\36\3\36\3\36\3\36\7\36\u01c4\n\36\f\36\16\36\u01c7\13\36\3\37\3"+
		"\37\3\37\3\37\3\37\3\37\3\37\3\37\7\37\u01d1\n\37\f\37\16\37\u01d4\13"+
		"\37\3\37\3\37\3 \3 \3!\3!\3\"\3\"\3#\3#\3$\3$\3%\3%\3&\3&\3\'\3\'\3(\3"+
		"(\3)\3)\3*\3*\3+\3+\3+\2\2,\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \""+
		"$&(*,.\60\62\64\668:<>@BDFHJLNPRT\2\4\3\2\7\n\3\2\62\63\2\u0216\2V\3\2"+
		"\2\2\4\\\3\2\2\2\6w\3\2\2\2\bz\3\2\2\2\n\u0088\3\2\2\2\f\u008a\3\2\2\2"+
		"\16\u008c\3\2\2\2\20\u0092\3\2\2\2\22\u0094\3\2\2\2\24\u0096\3\2\2\2\26"+
		"\u009e\3\2\2\2\30\u00a9\3\2\2\2\32\u00bb\3\2\2\2\34\u00bd\3\2\2\2\36\u00cb"+
		"\3\2\2\2 \u00d5\3\2\2\2\"\u00da\3\2\2\2$\u00e0\3\2\2\2&\u00e2\3\2\2\2"+
		"(\u00ea\3\2\2\2*\u00f9\3\2\2\2,\u012f\3\2\2\2.\u0133\3\2\2\2\60\u013a"+
		"\3\2\2\2\62\u0149\3\2\2\2\64\u0173\3\2\2\2\66\u0175\3\2\2\28\u01a6\3\2"+
		"\2\2:\u01c5\3\2\2\2<\u01c8\3\2\2\2>\u01d7\3\2\2\2@\u01d9\3\2\2\2B\u01db"+
		"\3\2\2\2D\u01dd\3\2\2\2F\u01df\3\2\2\2H\u01e1\3\2\2\2J\u01e3\3\2\2\2L"+
		"\u01e5\3\2\2\2N\u01e7\3\2\2\2P\u01e9\3\2\2\2R\u01eb\3\2\2\2T\u01ed\3\2"+
		"\2\2VW\5\4\3\2WX\7\2\2\3X\3\3\2\2\2Y[\5\6\4\2ZY\3\2\2\2[^\3\2\2\2\\Z\3"+
		"\2\2\2\\]\3\2\2\2]\5\3\2\2\2^\\\3\2\2\2_x\5T+\2`x\5\b\5\2ab\5\n\6\2bc"+
		"\5\24\13\2cd\5T+\2dx\3\2\2\2ef\5\24\13\2fg\7\3\2\2gh\5\30\r\2hi\5T+\2"+
		"ix\3\2\2\2jk\5\n\6\2kl\5\24\13\2lm\7\3\2\2mn\5\30\r\2no\5T+\2ox\3\2\2"+
		"\2px\5\60\31\2qx\5\62\32\2rx\5\64\33\2sx\58\35\2tx\5<\37\2ux\5$\23\2v"+
		"x\5&\24\2w_\3\2\2\2w`\3\2\2\2wa\3\2\2\2we\3\2\2\2wj\3\2\2\2wp\3\2\2\2"+
		"wq\3\2\2\2wr\3\2\2\2ws\3\2\2\2wt\3\2\2\2wu\3\2\2\2wv\3\2\2\2x\7\3\2\2"+
		"\2y{\5\22\n\2zy\3\2\2\2z{\3\2\2\2{|\3\2\2\2|}\7\4\2\2}~\5\4\3\2~\177\7"+
		"\5\2\2\177\t\3\2\2\2\u0080\u0089\5\f\7\2\u0081\u0089\5\16\b\2\u0082\u0083"+
		"\5\f\7\2\u0083\u0084\7\6\2\2\u0084\u0089\3\2\2\2\u0085\u0086\5\16\b\2"+
		"\u0086\u0087\7\6\2\2\u0087\u0089\3\2\2\2\u0088\u0080\3\2\2\2\u0088\u0081"+
		"\3\2\2\2\u0088\u0082\3\2\2\2\u0088\u0085\3\2\2\2\u0089\13\3\2\2\2\u008a"+
		"\u008b\t\2\2\2\u008b\r\3\2\2\2\u008c\u008d\5F$\2\u008d\17\3\2\2\2\u008e"+
		"\u0093\5H%\2\u008f\u0093\5J&\2\u0090\u0093\5L\'\2\u0091\u0093\5R*\2\u0092"+
		"\u008e\3\2\2\2\u0092\u008f\3\2\2\2\u0092\u0090\3\2\2\2\u0092\u0091\3\2"+
		"\2\2\u0093\21\3\2\2\2\u0094\u0095\7,\2\2\u0095\23\3\2\2\2\u0096\u009b"+
		"\5\22\n\2\u0097\u0098\7\13\2\2\u0098\u009a\5\22\n\2\u0099\u0097\3\2\2"+
		"\2\u009a\u009d\3\2\2\2\u009b\u0099\3\2\2\2\u009b\u009c\3\2\2\2\u009c\25"+
		"\3\2\2\2\u009d\u009b\3\2\2\2\u009e\u009f\5\n\6\2\u009f\u00a6\5\22\n\2"+
		"\u00a0\u00a1\7\13\2\2\u00a1\u00a2\5\n\6\2\u00a2\u00a3\5\22\n\2\u00a3\u00a5"+
		"\3\2\2\2\u00a4\u00a0\3\2\2\2\u00a5\u00a8\3\2\2\2\u00a6\u00a4\3\2\2\2\u00a6"+
		"\u00a7\3\2\2\2\u00a7\27\3\2\2\2\u00a8\u00a6\3\2\2\2\u00a9\u00ae\5\32\16"+
		"\2\u00aa\u00ab\7\13\2\2\u00ab\u00ad\5\32\16\2\u00ac\u00aa\3\2\2\2\u00ad"+
		"\u00b0\3\2\2\2\u00ae\u00ac\3\2\2\2\u00ae\u00af\3\2\2\2\u00af\31\3\2\2"+
		"\2\u00b0\u00ae\3\2\2\2\u00b1\u00bc\7\f\2\2\u00b2\u00bc\7\r\2\2\u00b3\u00bc"+
		"\7\16\2\2\u00b4\u00bc\5> \2\u00b5\u00bc\5@!\2\u00b6\u00bc\5\22\n\2\u00b7"+
		"\u00bc\5\b\5\2\u00b8\u00bc\5(\25\2\u00b9\u00bc\5.\30\2\u00ba\u00bc\5$"+
		"\23\2\u00bb\u00b1\3\2\2\2\u00bb\u00b2\3\2\2\2\u00bb\u00b3\3\2\2\2\u00bb"+
		"\u00b4\3\2\2\2\u00bb\u00b5\3\2\2\2\u00bb\u00b6\3\2\2\2\u00bb\u00b7\3\2"+
		"\2\2\u00bb\u00b8\3\2\2\2\u00bb\u00b9\3\2\2\2\u00bb\u00ba\3\2\2\2\u00bc"+
		"\33\3\2\2\2\u00bd\u00be\5\n\6\2\u00be\u00bf\7\6\2\2\u00bf\u00c0\5\22\n"+
		"\2\u00c0\35\3\2\2\2\u00c1\u00c2\5\22\n\2\u00c2\u00c3\7\17\2\2\u00c3\u00c4"+
		"\5\32\16\2\u00c4\u00c5\7\20\2\2\u00c5\u00cc\3\2\2\2\u00c6\u00c7\5@!\2"+
		"\u00c7\u00c8\7\17\2\2\u00c8\u00c9\5\32\16\2\u00c9\u00ca\7\20\2\2\u00ca"+
		"\u00cc\3\2\2\2\u00cb\u00c1\3\2\2\2\u00cb\u00c6\3\2\2\2\u00cc\37\3\2\2"+
		"\2\u00cd\u00ce\5\22\n\2\u00ce\u00cf\7\21\2\2\u00cf\u00d0\5\"\22\2\u00d0"+
		"\u00d6\3\2\2\2\u00d1\u00d2\5\36\20\2\u00d2\u00d3\7\21\2\2\u00d3\u00d4"+
		"\5\"\22\2\u00d4\u00d6\3\2\2\2\u00d5\u00cd\3\2\2\2\u00d5\u00d1\3\2\2\2"+
		"\u00d6!\3\2\2\2\u00d7\u00db\5\22\n\2\u00d8\u00db\5 \21\2\u00d9\u00db\5"+
		"\36\20\2\u00da\u00d7\3\2\2\2\u00da\u00d8\3\2\2\2\u00da\u00d9\3\2\2\2\u00db"+
		"#\3\2\2\2\u00dc\u00dd\7(\2\2\u00dd\u00e1\5\22\n\2\u00de\u00df\7(\2\2\u00df"+
		"\u00e1\5@!\2\u00e0\u00dc\3\2\2\2\u00e0\u00de\3\2\2\2\u00e1%\3\2\2\2\u00e2"+
		"\u00e3\5B\"\2\u00e3\u00e4\5\22\n\2\u00e4\u00e5\7\22\2\2\u00e5\u00e8\5"+
		"\n\6\2\u00e6\u00e7\7\13\2\2\u00e7\u00e9\5@!\2\u00e8\u00e6\3\2\2\2\u00e8"+
		"\u00e9\3\2\2\2\u00e9\'\3\2\2\2\u00ea\u00eb\5D#\2\u00eb\u00ec\5\22\n\2"+
		"\u00ec\u00ed\7\3\2\2\u00ed\u00ef\7\23\2\2\u00ee\u00f0\5\26\f\2\u00ef\u00ee"+
		"\3\2\2\2\u00ef\u00f0\3\2\2\2\u00f0\u00f1\3\2\2\2\u00f1\u00f2\7\24\2\2"+
		"\u00f2\u00f4\7\23\2\2\u00f3\u00f5\5\26\f\2\u00f4\u00f3\3\2\2\2\u00f4\u00f5"+
		"\3\2\2\2\u00f5\u00f6\3\2\2\2\u00f6\u00f7\7\24\2\2\u00f7\u00f8\5*\26\2"+
		"\u00f8)\3\2\2\2\u00f9\u012a\7\4\2\2\u00fa\u0129\5\6\4\2\u00fb\u00fc\7"+
		"\25\2\2\u00fc\u00fd\5\32\16\2\u00fd\u0104\5\b\5\2\u00fe\u00ff\7\26\2\2"+
		"\u00ff\u0100\5\32\16\2\u0100\u0101\5\b\5\2\u0101\u0103\3\2\2\2\u0102\u00fe"+
		"\3\2\2\2\u0103\u0106\3\2\2\2\u0104\u0102\3\2\2\2\u0104\u0105\3\2\2\2\u0105"+
		"\u0109\3\2\2\2\u0106\u0104\3\2\2\2\u0107\u0108\7\27\2\2\u0108\u010a\5"+
		"\b\5\2\u0109\u0107\3\2\2\2\u0109\u010a\3\2\2\2\u010a\u0129\3\2\2\2\u010b"+
		"\u010c\7\30\2\2\u010c\u010d\5\32\16\2\u010d\u010e\5\b\5\2\u010e\u0129"+
		"\3\2\2\2\u010f\u0111\7\31\2\2\u0110\u0112\5\n\6\2\u0111\u0110\3\2\2\2"+
		"\u0111\u0112\3\2\2\2\u0112\u0113\3\2\2\2\u0113\u0114\5\24\13\2\u0114\u0115"+
		"\7\3\2\2\u0115\u0116\5\30\r\2\u0116\u0117\7\13\2\2\u0117\u011a\5\32\16"+
		"\2\u0118\u0119\7\13\2\2\u0119\u011b\5\32\16\2\u011a\u0118\3\2\2\2\u011a"+
		"\u011b\3\2\2\2\u011b\u011c\3\2\2\2\u011c\u011d\5\b\5\2\u011d\u0129\3\2"+
		"\2\2\u011e\u0120\7\31\2\2\u011f\u0121\5\n\6\2\u0120\u011f\3\2\2\2\u0120"+
		"\u0121\3\2\2\2\u0121\u0122\3\2\2\2\u0122\u0123\5\22\n\2\u0123\u0124\7"+
		"\32\2\2\u0124\u0125\5\22\n\2\u0125\u0126\5\b\5\2\u0126\u0129\3\2\2\2\u0127"+
		"\u0129\5,\27\2\u0128\u00fa\3\2\2\2\u0128\u00fb\3\2\2\2\u0128\u010b\3\2"+
		"\2\2\u0128\u010f\3\2\2\2\u0128\u011e\3\2\2\2\u0128\u0127\3\2\2\2\u0129"+
		"\u012c\3\2\2\2\u012a\u0128\3\2\2\2\u012a\u012b\3\2\2\2\u012b\u012d\3\2"+
		"\2\2\u012c\u012a\3\2\2\2\u012d\u012e\7\5\2\2\u012e+\3\2\2\2\u012f\u0131"+
		"\7\33\2\2\u0130\u0132\5\24\13\2\u0131\u0130\3\2\2\2\u0131\u0132\3\2\2"+
		"\2\u0132-\3\2\2\2\u0133\u0134\5\22\n\2\u0134\u0136\7\23\2\2\u0135\u0137"+
		"\5\24\13\2\u0136\u0135\3\2\2\2\u0136\u0137\3\2\2\2\u0137\u0138\3\2\2\2"+
		"\u0138\u0139\7\24\2\2\u0139/\3\2\2\2\u013a\u013b\5F$\2\u013b\u013c\5\22"+
		"\n\2\u013c\u013d\7\3\2\2\u013d\u0144\7\4\2\2\u013e\u013f\5\n\6\2\u013f"+
		"\u0140\5\22\n\2\u0140\u0141\5T+\2\u0141\u0143\3\2\2\2\u0142\u013e\3\2"+
		"\2\2\u0143\u0146\3\2\2\2\u0144\u0142\3\2\2\2\u0144\u0145\3\2\2\2\u0145"+
		"\u0147\3\2\2\2\u0146\u0144\3\2\2\2\u0147\u0148\7\5\2\2\u0148\61\3\2\2"+
		"\2\u0149\u014a\5H%\2\u014a\u014b\5\22\n\2\u014b\u0160\7\4\2\2\u014c\u014e"+
		"\5P)\2\u014d\u014c\3\2\2\2\u014d\u014e\3\2\2\2\u014e\u0150\3\2\2\2\u014f"+
		"\u0151\5\n\6\2\u0150\u014f\3\2\2\2\u0150\u0151\3\2\2\2\u0151\u0152\3\2"+
		"\2\2\u0152\u015d\5\22\n\2\u0153\u0155\7\13\2\2\u0154\u0156\5P)\2\u0155"+
		"\u0154\3\2\2\2\u0155\u0156\3\2\2\2\u0156\u0158\3\2\2\2\u0157\u0159\5\n"+
		"\6\2\u0158\u0157\3\2\2\2\u0158\u0159\3\2\2\2\u0159\u015a\3\2\2\2\u015a"+
		"\u015c\5\22\n\2\u015b\u0153\3\2\2\2\u015c\u015f\3\2\2\2\u015d\u015b\3"+
		"\2\2\2\u015d\u015e\3\2\2\2\u015e\u0161\3\2\2\2\u015f\u015d\3\2\2\2\u0160"+
		"\u014d\3\2\2\2\u0160\u0161\3\2\2\2\u0161\u0162\3\2\2\2\u0162\u0163\7\5"+
		"\2\2\u0163\63\3\2\2\2\u0164\u0165\5J&\2\u0165\u0166\5\22\n\2\u0166\u0167"+
		"\7\4\2\2\u0167\u0168\5:\36\2\u0168\u0169\7\5\2\2\u0169\u0174\3\2\2\2\u016a"+
		"\u016b\5J&\2\u016b\u016c\5\22\n\2\u016c\u0171\5\66\34\2\u016d\u016e\7"+
		"\4\2\2\u016e\u016f\5:\36\2\u016f\u0170\7\5\2\2\u0170\u0172\3\2\2\2\u0171"+
		"\u016d\3\2\2\2\u0171\u0172\3\2\2\2\u0172\u0174\3\2\2\2\u0173\u0164\3\2"+
		"\2\2\u0173\u016a\3\2\2\2\u0174\65\3\2\2\2\u0175\u0178\7\23\2\2\u0176\u0179"+
		"\5\24\13\2\u0177\u0179\5\26\f\2\u0178\u0176\3\2\2\2\u0178\u0177\3\2\2"+
		"\2\u0178\u0179\3\2\2\2\u0179\u017a\3\2\2\2\u017a\u018f\7\34\2\2\u017b"+
		"\u017d\5P)\2\u017c\u017b\3\2\2\2\u017c\u017d\3\2\2\2\u017d\u017f\3\2\2"+
		"\2\u017e\u0180\5\n\6\2\u017f\u017e\3\2\2\2\u017f\u0180\3\2\2\2\u0180\u0181"+
		"\3\2\2\2\u0181\u018c\5\22\n\2\u0182\u0184\7\13\2\2\u0183\u0185\5P)\2\u0184"+
		"\u0183\3\2\2\2\u0184\u0185\3\2\2\2\u0185\u0187\3\2\2\2\u0186\u0188\5\n"+
		"\6\2\u0187\u0186\3\2\2\2\u0187\u0188\3\2\2\2\u0188\u0189\3\2\2\2\u0189"+
		"\u018b\5\22\n\2\u018a\u0182\3\2\2\2\u018b\u018e\3\2\2\2\u018c\u018a\3"+
		"\2\2\2\u018c\u018d\3\2\2\2\u018d\u0190\3\2\2\2\u018e\u018c\3\2\2\2\u018f"+
		"\u017c\3\2\2\2\u018f\u0190\3\2\2\2\u0190\u0191\3\2\2\2\u0191\u0192\7\24"+
		"\2\2\u0192\67\3\2\2\2\u0193\u0194\5L\'\2\u0194\u0195\5\22\n\2\u0195\u0196"+
		"\7\4\2\2\u0196\u0197\5:\36\2\u0197\u0198\7\5\2\2\u0198\u01a7\3\2\2\2\u0199"+
		"\u019a\5L\'\2\u019a\u019b\5\22\n\2\u019b\u01a0\5\66\34\2\u019c\u019d\7"+
		"\4\2\2\u019d\u019e\5:\36\2\u019e\u019f\7\5\2\2\u019f\u01a1\3\2\2\2\u01a0"+
		"\u019c\3\2\2\2\u01a0\u01a1\3\2\2\2\u01a1\u01a7\3\2\2\2\u01a2\u01a3\5L"+
		"\'\2\u01a3\u01a4\5\22\n\2\u01a4\u01a5\5\22\n\2\u01a5\u01a7\3\2\2\2\u01a6"+
		"\u0193\3\2\2\2\u01a6\u0199\3\2\2\2\u01a6\u01a2\3\2\2\2\u01a79\3\2\2\2"+
		"\u01a8\u01a9\7\35\2\2\u01a9\u01aa\5@!\2\u01aa\u01ab\5T+\2\u01ab\u01c4"+
		"\3\2\2\2\u01ac\u01ad\7\36\2\2\u01ad\u01ae\5@!\2\u01ae\u01af\5T+\2\u01af"+
		"\u01c4\3\2\2\2\u01b0\u01b2\7\37\2\2\u01b1\u01b3\5\26\f\2\u01b2\u01b1\3"+
		"\2\2\2\u01b2\u01b3\3\2\2\2\u01b3\u01b4\3\2\2\2\u01b4\u01c4\5T+\2\u01b5"+
		"\u01b7\7 \2\2\u01b6\u01b8\5\26\f\2\u01b7\u01b6\3\2\2\2\u01b7\u01b8\3\2"+
		"\2\2\u01b8\u01b9\3\2\2\2\u01b9\u01c4\5T+\2\u01ba\u01bb\7)\2\2\u01bb\u01bc"+
		"\5\22\n\2\u01bc\u01bd\5T+\2\u01bd\u01c4\3\2\2\2\u01be\u01bf\5N(\2\u01bf"+
		"\u01c0\5\n\6\2\u01c0\u01c1\5\24\13\2\u01c1\u01c2\5T+\2\u01c2\u01c4\3\2"+
		"\2\2\u01c3\u01a8\3\2\2\2\u01c3\u01ac\3\2\2\2\u01c3\u01b0\3\2\2\2\u01c3"+
		"\u01b5\3\2\2\2\u01c3\u01ba\3\2\2\2\u01c3\u01be\3\2\2\2\u01c4\u01c7\3\2"+
		"\2\2\u01c5\u01c3\3\2\2\2\u01c5\u01c6\3\2\2\2\u01c6;\3\2\2\2\u01c7\u01c5"+
		"\3\2\2\2\u01c8\u01c9\5R*\2\u01c9\u01ca\5\22\n\2\u01ca\u01d2\7\4\2\2\u01cb"+
		"\u01cc\5N(\2\u01cc\u01cd\5\n\6\2\u01cd\u01ce\5\24\13\2\u01ce\u01cf\5T"+
		"+\2\u01cf\u01d1\3\2\2\2\u01d0\u01cb\3\2\2\2\u01d1\u01d4\3\2\2\2\u01d2"+
		"\u01d0\3\2\2\2\u01d2\u01d3\3\2\2\2\u01d3\u01d5\3\2\2\2\u01d4\u01d2\3\2"+
		"\2\2\u01d5\u01d6\7\5\2\2\u01d6=\3\2\2\2\u01d7\u01d8\t\3\2\2\u01d8?\3\2"+
		"\2\2\u01d9\u01da\7.\2\2\u01daA\3\2\2\2\u01db\u01dc\7!\2\2\u01dcC\3\2\2"+
		"\2\u01dd\u01de\7\"\2\2\u01deE\3\2\2\2\u01df\u01e0\7#\2\2\u01e0G\3\2\2"+
		"\2\u01e1\u01e2\7$\2\2\u01e2I\3\2\2\2\u01e3\u01e4\7%\2\2\u01e4K\3\2\2\2"+
		"\u01e5\u01e6\7&\2\2\u01e6M\3\2\2\2\u01e7\u01e8\7*\2\2\u01e8O\3\2\2\2\u01e9"+
		"\u01ea\7+\2\2\u01eaQ\3\2\2\2\u01eb\u01ec\7\'\2\2\u01ecS\3\2\2\2\u01ed"+
		"\u01ee\7\65\2\2\u01eeU\3\2\2\2\62\\wz\u0088\u0092\u009b\u00a6\u00ae\u00bb"+
		"\u00cb\u00d5\u00da\u00e0\u00e8\u00ef\u00f4\u0104\u0109\u0111\u011a\u0120"+
		"\u0128\u012a\u0131\u0136\u0144\u014d\u0150\u0155\u0158\u015d\u0160\u0171"+
		"\u0173\u0178\u017c\u017f\u0184\u0187\u018c\u018f\u01a0\u01a6\u01b2\u01b7"+
		"\u01c3\u01c5\u01d2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}