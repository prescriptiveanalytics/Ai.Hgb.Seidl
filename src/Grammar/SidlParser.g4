parser grammar SidlParser;

options { tokenVocab=SidlLexer; }

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
    : terminator                                                #terminatorStatement         
    | scope                                                     #scopeStatement
    | (atomictype | typename) variablelist terminator           #declarationStatement
    | variablelist '=' expressionlist terminator                #assignmentStatement
    | (atomictype | typename) variablelist '=' expressionlist   terminator #definitionStatement    
    | structdefinition                                          #structDefinitionStatement
    | messagedefinition                                         #messageDefinitionStatement
    | nodetypedefinition                                        #nodetypeDefinitionStatement
    | nodedefinition                                            #nodeDefinitionStatement
    | metadefinition                                            #metaDefinitionStatement
    | importstatement terminator                                #importStatement
    | typedefstatement terminator                               #typedefStatement

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
    : atomictype | complextype
    | atomictype '[]' | complextype '[]'
    ;

atomictype
    : INT | FLOAT | STRING | BOOL
    ;

complextype
    : STRUCT    
    ;

graphtype
    : MESSAGE | NODETYPE | NODE | META
    ;

variable
    : NAME    
    ;

typename
    : NAME
    ;

atomictypeortypename
    : atomictype | typename
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

expression
    : NULL
    | boolean
    | number
    | string
    | variable    
    | functiondefinition | functioncall
    | importstatement
    ;

arraydeclaration
    : type '[]' variable
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

importstatement
    : IMPORT variable
    | IMPORT STRINGLITEARL
    ;

typedefstatement
    : TYPEDEF (atomictype | typename) variable
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

// move up/down
messagetypename
    : NAME
    ;  

nodetypename
    : NAME
    ;

messagetypelist    
    : messagetypename variable (',' messagetypename variable)*
    ;

messagedefinition    
    : MESSAGE messagetypename '{' messageparameterlist? '}'
    ;

nodetypedefinition
    : NODETYPE nodetypename '{' nodebody '}' // parameter based definition
    | NODETYPE nodetypename nodetypesignature '{' nodebody '}' // signature based definition
    ;

nodetypesignature
    : '(' inputs=messagetypelist? '-->' outputs=messagetypelist? ')'
    ;

nodedefinition
    : NODE variable '{' nodebody '}' // using implicit nodetype
    | NODE variable nodetypesignature ('{' nodebody '}')? // using implicit nodetype
    | NODE typename variable // using explicit nodetype
    ;

nodebody
    : (
        inout=nodebodyinout 
        | include=nodebodyinclude
        | property=nodebodyproperty
        | terminator
    )*
    ;

nodebodyinout
    : (INPUT | OUTPUT) messagetypelist
    ;
nodebodyinclude
    : INCLUDE variable
    ;
nodebodyproperty
    : PROPERTY (type | typename) variablelist
    ;


metadefinition
    : META variable '{'
        (
            PROPERTY type variablelist terminator
        )*
    '}'
    ;


number
    : INTEGER | FLOATINGPOINTNUMBER
    ;

string
    : STRINGLITEARL //NORMALSTRING | CHARSTRING | LONGSTRING
    ;

boolean
    : TRUE | FALSE
    ;

terminator
    : STMEND
    // | EOF
    ;
