//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:/dev/workspaces/spa/Ai.Hgb.Seidl/src/Grammar/SeidlParser.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Ai.Hgb.Seidl.Processor {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="SeidlParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface ISeidlParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.root"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRoot([NotNull] SeidlParser.RootContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.set"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSet([NotNull] SeidlParser.SetContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>terminatorStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTerminatorStatement([NotNull] SeidlParser.TerminatorStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>scopeStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScopeStatement([NotNull] SeidlParser.ScopeStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>declarationStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclarationStatement([NotNull] SeidlParser.DeclarationStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>assignmentStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentStatement([NotNull] SeidlParser.AssignmentStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>definitionStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefinitionStatement([NotNull] SeidlParser.DefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>arrayDefinitionStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayDefinitionStatement([NotNull] SeidlParser.ArrayDefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>structDefinitionStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructDefinitionStatement([NotNull] SeidlParser.StructDefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>messageDefinitionStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMessageDefinitionStatement([NotNull] SeidlParser.MessageDefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>edgetypeDefinitionStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEdgetypeDefinitionStatement([NotNull] SeidlParser.EdgetypeDefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>nodetypeDefinitionStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNodetypeDefinitionStatement([NotNull] SeidlParser.NodetypeDefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>nodeDefinitionStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNodeDefinitionStatement([NotNull] SeidlParser.NodeDefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>metaDefinitionStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMetaDefinitionStatement([NotNull] SeidlParser.MetaDefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>importStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitImportStatement([NotNull] SeidlParser.ImportStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>typedefStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypedefStatement([NotNull] SeidlParser.TypedefStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>nodeConnectionStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNodeConnectionStatement([NotNull] SeidlParser.NodeConnectionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>surrogateDefinitionStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSurrogateDefinitionStatement([NotNull] SeidlParser.SurrogateDefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>nameDefinitionStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNameDefinitionStatement([NotNull] SeidlParser.NameDefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>tagDefinitionStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTagDefinitionStatement([NotNull] SeidlParser.TagDefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>nametagDefinitionStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNametagDefinitionStatement([NotNull] SeidlParser.NametagDefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>packageDefinitionStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPackageDefinitionStatement([NotNull] SeidlParser.PackageDefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>loopStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLoopStatement([NotNull] SeidlParser.LoopStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>conditionalStatement</c>
	/// labeled alternative in <see cref="SeidlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConditionalStatement([NotNull] SeidlParser.ConditionalStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.scope"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScope([NotNull] SeidlParser.ScopeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] SeidlParser.TypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.atomictype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAtomictype([NotNull] SeidlParser.AtomictypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.complextype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComplextype([NotNull] SeidlParser.ComplextypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.atomictypeortypename"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAtomictypeortypename([NotNull] SeidlParser.AtomictypeortypenameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.graphtype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGraphtype([NotNull] SeidlParser.GraphtypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.variable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariable([NotNull] SeidlParser.VariableContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.typename"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypename([NotNull] SeidlParser.TypenameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitField([NotNull] SeidlParser.FieldContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.fieldlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFieldlist([NotNull] SeidlParser.FieldlistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.variablelist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariablelist([NotNull] SeidlParser.VariablelistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.typedvariablelist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypedvariablelist([NotNull] SeidlParser.TypedvariablelistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.customtypedvariablelist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCustomtypedvariablelist([NotNull] SeidlParser.CustomtypedvariablelistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.messageparameterlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMessageparameterlist([NotNull] SeidlParser.MessageparameterlistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.messageparametersignature"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMessageparametersignature([NotNull] SeidlParser.MessageparametersignatureContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.expressionlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionlist([NotNull] SeidlParser.ExpressionlistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] SeidlParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.binop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinop([NotNull] SeidlParser.BinopContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.unop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnop([NotNull] SeidlParser.UnopContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.assignmentlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentlist([NotNull] SeidlParser.AssignmentlistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] SeidlParser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.query"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitQuery([NotNull] SeidlParser.QueryContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.comparator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComparator([NotNull] SeidlParser.ComparatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.arraydeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArraydeclaration([NotNull] SeidlParser.ArraydeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.arraydefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArraydefinition([NotNull] SeidlParser.ArraydefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.arrayaccess"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayaccess([NotNull] SeidlParser.ArrayaccessContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.fieldaccess"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFieldaccess([NotNull] SeidlParser.FieldaccessContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.lefthandside"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLefthandside([NotNull] SeidlParser.LefthandsideContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.nametagdefstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNametagdefstatement([NotNull] SeidlParser.NametagdefstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.nametaglistdefstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNametaglistdefstatement([NotNull] SeidlParser.NametaglistdefstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.namedefstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNamedefstatement([NotNull] SeidlParser.NamedefstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.tagdefstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTagdefstatement([NotNull] SeidlParser.TagdefstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.tag"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTag([NotNull] SeidlParser.TagContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.versionnumber"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVersionnumber([NotNull] SeidlParser.VersionnumberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.packagedefstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPackagedefstatement([NotNull] SeidlParser.PackagedefstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.importstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitImportstatement([NotNull] SeidlParser.ImportstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.typedefstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypedefstatement([NotNull] SeidlParser.TypedefstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.nodeconnectionstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNodeconnectionstatement([NotNull] SeidlParser.NodeconnectionstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.surrogatedefinitionstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSurrogatedefinitionstatement([NotNull] SeidlParser.SurrogatedefinitionstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.surrogatebody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSurrogatebody([NotNull] SeidlParser.SurrogatebodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.functiondefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctiondefinition([NotNull] SeidlParser.FunctiondefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.functionbody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionbody([NotNull] SeidlParser.FunctionbodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.returnstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnstatement([NotNull] SeidlParser.ReturnstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.functioncall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctioncall([NotNull] SeidlParser.FunctioncallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.structpropertylist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructpropertylist([NotNull] SeidlParser.StructpropertylistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.structdefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructdefinition([NotNull] SeidlParser.StructdefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.messagetypename"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMessagetypename([NotNull] SeidlParser.MessagetypenameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.nodetypename"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNodetypename([NotNull] SeidlParser.NodetypenameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.edgetypename"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEdgetypename([NotNull] SeidlParser.EdgetypenameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.messagetypelist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMessagetypelist([NotNull] SeidlParser.MessagetypelistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.messagedefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMessagedefinition([NotNull] SeidlParser.MessagedefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.edgetypedefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEdgetypedefinition([NotNull] SeidlParser.EdgetypedefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.edgetypebody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEdgetypebody([NotNull] SeidlParser.EdgetypebodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.nodetypedefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNodetypedefinition([NotNull] SeidlParser.NodetypedefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.nodedefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNodedefinition([NotNull] SeidlParser.NodedefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.nodebody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNodebody([NotNull] SeidlParser.NodebodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.nodebodyinout"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNodebodyinout([NotNull] SeidlParser.NodebodyinoutContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.inoutoption"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInoutoption([NotNull] SeidlParser.InoutoptionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.nodebodyproperty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNodebodyproperty([NotNull] SeidlParser.NodebodypropertyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.nodebodyimage"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNodebodyimage([NotNull] SeidlParser.NodebodyimageContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.nodebodycommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNodebodycommand([NotNull] SeidlParser.NodebodycommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.nodebodyclientserver"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNodebodyclientserver([NotNull] SeidlParser.NodebodyclientserverContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.nodeconstructor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNodeconstructor([NotNull] SeidlParser.NodeconstructorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.metadefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMetadefinition([NotNull] SeidlParser.MetadefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.loopstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLoopstatement([NotNull] SeidlParser.LoopstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.loopsignature"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLoopsignature([NotNull] SeidlParser.LoopsignatureContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.loopbody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLoopbody([NotNull] SeidlParser.LoopbodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.conditionalstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConditionalstatement([NotNull] SeidlParser.ConditionalstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.conditionalelseif"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConditionalelseif([NotNull] SeidlParser.ConditionalelseifContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.conditionalelse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConditionalelse([NotNull] SeidlParser.ConditionalelseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.integerrange"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntegerrange([NotNull] SeidlParser.IntegerrangeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.generatename"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGeneratename([NotNull] SeidlParser.GeneratenameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.interpolationlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInterpolationlist([NotNull] SeidlParser.InterpolationlistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.concatelement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConcatelement([NotNull] SeidlParser.ConcatelementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumber([NotNull] SeidlParser.NumberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitString([NotNull] SeidlParser.StringContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.boolean"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolean([NotNull] SeidlParser.BooleanContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeidlParser.terminator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTerminator([NotNull] SeidlParser.TerminatorContext context);
}
} // namespace Ai.Hgb.Seidl.Processor
