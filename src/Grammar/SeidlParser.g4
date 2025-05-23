parser grammar SeidlParser;

options { tokenVocab=SeidlLexer; }

// TODO

// meta and property definition actually not necessary?!
// input/output messages (main dependency) vs input/output properties (ctr-channel) ... two-way comm. design feels superfluous
// topic / filter keywords and functionality unclear

// arrays + index operator
// newline issue
// mathematic operators, string concat
// pre-defined aggregation operators = function lib
// split parser, lexer etc.
// dot-operator

root
    : set EOF
    ;

set // = global scope
    : statement*
    ;

statement
    : terminator                                                            #terminatorStatement         
    | scope                                                                 #scopeStatement     
    | (atomictype | typename) variablelist terminator                       #declarationStatement
    | variablelist '=' expressionlist terminator                            #assignmentStatement
    | (atomictype | typename) variablelist '=' expressionlist               #definitionStatement    
    | arraydefinition                                                       #arrayDefinitionStatement
    | structdefinition                                                      #structDefinitionStatement
    // | structinstantiation                                                   #structInstantiationStatement // not necessary: handled by expression-rule
    | messagedefinition                                                     #messageDefinitionStatement
    | edgetypedefinition                                                    #edgetypeDefinitionStatement
    | nodetypedefinition                                                    #nodetypeDefinitionStatement
    | nodedefinition                                                        #nodeDefinitionStatement
    | metadefinition                                                        #metaDefinitionStatement
    | importstatement                                                       #importStatement    
    | typedefstatement terminator                                           #typedefStatement
    | nodeconnectionstatement terminator                                    #nodeConnectionStatement
    | surrogatedefinitionstatement terminator                               #surrogateDefinitionStatement
    | namedefstatement                                                      #nameDefinitionStatement
    | tagdefstatement                                                       #tagDefinitionStatement
    | nametagdefstatement                                                   #nametagDefinitionStatement
    | packagedefstatement                                                   #packageDefinitionStatement
    | loopstatement                                                         #loopStatement
    | conditionalstatement                                                  #conditionalStatement

    // not yet in use
    // | functiondefinition
    // | functioncall   

    // deprecated:
    //| variablelist ('=' expressionlist)+ // enables: a, b = c, d = e, f which evaluates to: a, b = e, f   
    //| 'int' variablelist '=' INTEGER // type safe by syntax (uncommon for most EBNFs)
    ;

scope // = block scope
    : variable? '{' set '}'
    ;

type
    : atomictype | complextype | typename
    | atomictype '[]' | complextype '[]' | typename '[]'
    ;

atomictype
    : INT | FLOAT | STRING | BOOL
    ;

complextype
    : STRUCT    
    ;

atomictypeortypename
    : atomictype | typename
    ;

graphtype
    : MESSAGE | NODETYPE | NODE | META
    ;

variable
    : generatename
    | NAME
    ;

typename
    : NAME
    ;

field
    : variable ('.' variable)*
    ;

fieldlist
    : field (',' field)*
    ;

variablelist
    : variable (',' variable)*
    ;

typedvariablelist
    : atomictype variable (',' atomictype variable)*
    ;

customtypedvariablelist
    : (typename | atomictype) variable (',' (typename | atomictype) variable)*
    ;

messageparameterlist
    : messageparametersignature variable (',' messageparametersignature variable)*
    ;

messageparametersignature
    : TOPIC? (typename | atomictype)
    ;    

expressionlist
    : expression (',' expression)*
    ;

value
    : boolean | number | string
    ;

valuelist
    : value (',' value)*
    ;

expression
    : NULL
    | boolean
    | number
    | string
    | variable
    | field      
    | functiondefinition | functioncall
    | importstatement
    | assignmentlist
    | '{' assignmentlist? '}'
    | '[' variablelist?  ']'
    | '[' valuelist?  ']'
    ;

binop : '+' | '-' | '*' | '/' 
	    | '<' | '<=' | '>' | '>=' | '==' 
	    | 'and' | 'or';

unop : '-' | 'not';

assignmentlist
    : assignment (',' assignment)*
    ;

assignment
    : variable '=' expression
    | field '=' expression
    ;

query
    : field comparator expression
    | QUEUE
    ;

comparator
    : EQUAL | UNEQUAL | GREATERTHAN | GREATEREQUALTHAN | LESSTHAN | LESSEQUALTHAN
    ;

arraydeclaration
    : type '[]' variable
    ;

arraydefinition
    : atomictype '[]' variablelist '=' expressionlist
    ;

arrayaccess
    : variable '[' expression ']'
    | string '[' expression ']'
    ;

fieldaccess   
    : variable '.' lefthandside
    | arrayaccess '.' lefthandside
    ;

lefthandside
	:	variable
	|	fieldaccess
	|	arrayaccess
	;

nametagdefstatement
    : LABEL nametagstatement
    ;

nametagstatement
    : field COLON tag
    | field
    ;

nametagliststatement
    : (
        nametagstatement
        | terminator
    )*
    ;


namedefstatement
    : NAMEDEF '=' field    
    ;

tagdefstatement
    : TAGDEF '=' tag
    ;

tag
    : LATEST
    | AUTO
    | string
    | versionnumber
    ;

versionnumber
    : number ('.' number)*
    ;

packagedefstatement
    : PACKAGE packageidentifier=nametagstatement '{' packagecontent=nametagliststatement '}'
    ;

importstatement
    : IMPORT string
    | IMPORT field
    | IMPORT field COLON tag
    // | IMPORT from=field AS to=field
    // | IMPORT string AS field
    // | IMPORT from=field COLON tag AS to=field
    ;



typedefstatement
    : TYPEDEF (atomictype | typename) variable
    ;

nodeconnectionstatement
    : sources=fieldlist '-->' sinks=fieldlist    
    | sources=fieldlist '==>' sinks=fieldlist    
    | sources=fieldlist '-:' query '->' sinks=fieldlist    
    | sources=fieldlist '=:' query '=>' sinks=fieldlist       
    ;

surrogatedefinitionstatement
    : SURROGATE variable surrogatebody
    ;

surrogatebody
    : '{' (
        FOR field
        | WITH field
        )*
    '}'
    ;

functiondefinition
    : FUNCTION variable '=' '(' customtypedvariablelist? ')' '(' customtypedvariablelist? ')' functionbody
    ;

functionbody
    : '{' (
        statement
        | IF expression scope (ELSEIF expression scope)* (ELSE scope)?
        | WHILE expression scope
        | FOR type? variablelist '=' expressionlist ',' expression (',' expression)? scope
        | FOR type? variable IN variable scope
        | returnstatement
        )*
    '}'
    ;

returnstatement
    : RETURN variablelist?
    ;

functioncall
    : variable '(' variablelist? ')'
    ;

structpropertylist
    : (
        atomictypeortypename variable (terminator* ',' terminator* atomictypeortypename variable)*    
        | terminator
    )*
    ;

structdefinition
    : STRUCT variable '{' structpropertylist '}'
    ;

// not necessary: handled by expression-rule
// structinstantiation
//     : typename variable '=' '{' assignmentlist? '}'
//     ;

// move up/down
messagetypename
    : NAME
    ;  

nodetypename
    : NAME
    ;

edgetypename
    : NAME
    ;

messagetypelist    
    : messagetypename variable (',' messagetypename variable)*
    ;

messagedefinition    
    : MESSAGE messagetypename '{' messageparameterlist? '}'
    ;

edgetypedefinition
    : EDGETYPE edgetypename '{' edgetypebody '}'
    ;

edgetypebody
    : (
        REQUEST messagetypename
        | RESPOND messagetypename
        | terminator
        )*
    ;

nodetypedefinition
    : NODETYPE nodetypename '{' nodebody '}' // parameter based definition    
    ;

nodedefinition
    : NODE typename variable // using explicit nodetype
    | NODE typename variable nodeconstructor // using explicit nodetype and constructor
    | NODE typename (SEQUENTIAL | PARALLEL) variable nodeconstructor
    // | NODE variable '{' nodebody '}' // using implicit nodetype     
    ;

nodebody
    : (
        inout=nodebodyinout 
        | clientserver=nodebodyclientserver
        | property=nodebodyproperty
        // | IMAGE field COLON tag
        | image=nodebodyimage
        | command=nodebodycommand        
        | terminator
    )*
    ;

nodebodyinout
    : INPUT messagetypelist
    | OUTPUT messagetypelist
    | PUBLISH messagetypelist
    | SUBSCRIBE messagetypelist
    | REQUEST messagetypename messagetypename variable
    | RESPOND messagetypename messagetypename variable
    ;

nodebodyproperty
    : PROPERTY (type | typename) variablelist
    ;

nodebodyimage
    : IMAGE nametagstatement
    ;

nodebodycommand
    : COMMAND command=NAME workingdirectory=STRINGLITERAL arguments=STRINGLITERAL
    ;

nodebodyclientserver
    : (CLIENT | SERVER) edgetypename NAME
    ;

nodeconstructor
    : '(' assignmentlist? ')'
    ;


metadefinition
    : META variable '{'
        (
            PROPERTY type variablelist terminator
        )*
    '}'
    ;

loopstatement
    : loopsignature '{' loopbody '}'
    ;

loopsignature
    : FOR iterator=variable IN field
    | FOR iterator=variable IN integerrange
    // | FOR iterator=variable IN collection=integerrange
    ;

loopbody
    : statement*
    ;

conditionalstatement
    : IF expression '{' statement* '}' conditionalelseif* conditionalelse?
    ;

conditionalelseif
    : ELSEIF expression '{' statement* '}'
    ;
conditionalelse
    : ELSE '{' statement* '}'
    ;

integerrange
    : from=INTEGER TO to=INTEGER    
    ;

generatename
    : VAR '(' concatelement (',' concatelement)*  ')'
    // | baseinterpolation=INTERPOLATION? baseelement=concatelement interpolationelements=interpolationlist
    | baseelement=NAME bracketinterpolationelements=bracketinterpolationelement+ 
    ;

interpolationlist
    : (INTERPOLATION concatelement)+
    ;

bracketinterpolationelement
    : (
        interpolation='{' NAME '}'
        | element=NAME
     )
    ;

concatelement
    : NAME | STRINGLITERAL
    ;

number
    : INTEGER | FLOATINGPOINTNUMBER
    ;

string
    : STRINGLITERAL //NORMALSTRING | CHARSTRING | LONGSTRING
    ;

boolean
    : TRUE | FALSE
    ;

terminator
    : STMEND
    // | EOF
    ;
