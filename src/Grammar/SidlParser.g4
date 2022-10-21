parser grammar SidlParser;

options { tokenVocab=SidlLexer; }

// TODO
// arrays + index operator
// records/structs
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
    : terminator                                        #terminatorStatement         
    | scope                                             #scopeStatement
    | type variablelist terminator                      #declarationStatement
    | variablelist '=' expressionlist terminator        #assignmentStatement
    | type variablelist '=' expressionlist terminator   #definitionStatement    
    | structdefinition                                  #structdefinitionStatement
    | messagedefinition                                 #messagedefinitionStatement
    | nodetypedefinition                                #nodetypedefinitionStatement
    | nodedefinition                                    #nodedefinitionStatement
    | metadefinition                                    #metadefinitionStatement
    | importstatement                                   #importStatement
    | typealiasingstatement                             #typealiasingStatement

    // not yet in use
    // | functiondefinition
    // | functioncall   

    // deprecated:
    //| variablelist ('=' expressionlist)+ // enables: a, b = c, d = e, f which evaluates to: a, b = e, f   
    //| 'int' variablelist '=' INTEGER // type safe by syntax (uncommon for most EBNFs)
    ;

scope // = block scope
    : variable? '[' set ']'
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

variablelist
    : variable (',' variable)*
    ;

typedvariablelist
    : type variable (',' type variable)*
    ;

expressionlist
    : expression (',' expression)*
    ;

expression
    : NULL | TRUE | FALSE
    | number
    | string
    | variable
    | scope
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

typealiasingstatement
    : TYPE variable ':' type (',' string)?
    ;

functiondefinition
    : FUNCTION variable '=' '(' typedvariablelist? ')' '(' typedvariablelist? ')' functionbody
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

structdefinition
    : STRUCT variable '{'
        (type variable terminator)*
    '}'
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
    : MESSAGE messagetypename '{' (TOPIC? (typename | type) variable (',' TOPIC? (typename | type) variable)*)? '}'
    ;

nodetypedefinition
    : NODETYPE nodetypename '{' nodebody '}' // parameter based definition
    | NODETYPE nodetypename nodetypesignature ('{' nodebody '}')? // signature based definition
    ;

nodetypesignature
    : '(' messagetypelist? '-->' messagetypelist? ')'
    ;

nodedefinition
    : NODE variable '{' nodebody '}' // using implicit nodetype
    | NODE variable nodetypesignature ('{' nodebody '}')? // using implicit nodetype
    | NODE typename variable // using explicit nodetype
    ;

nodebody
    : (
        (INPUT | OUTPUT) typedvariablelist? terminator
        | INCLUDE variable terminator // include pre-defined meta properties
        | PROPERTY type variablelist terminator
    )*
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

terminator
    : STMEND
    // | EOF
    ;
