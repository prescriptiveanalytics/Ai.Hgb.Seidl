grammar Sidl;

// TODO
// arrays + index operator
// records/structs
// newline issue
// mathematic operators, string concat
// pre-defined aggregation operators = function lib
// split parser, lexer etc.
// dot-operator

/*
 *  Parser Rules
 */

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
    : variable? '{' set '}'    
    ;

type
    : atomictype | complextype
    | atomictype '[]' | complextype '[]'
    ;

atomictype
    : 'int' | 'float' | 'string' | 'bool'
    ;

complextype
    : structtype
    // : 'struct' | 'node' | 'message' | 'function'
    ;

graphtype
    : messagetype | nodetypetype | nodetype | metatype
    ;

variable
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
    : 'null' | 'false' | 'true'
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
    : 'import' variable
    | 'import' string
    ;

typealiasingstatement
    : typetype variable ':' type (',' string)?
    ;

functiondefinition
    : functiontype variable '=' '(' typedvariablelist? ')' '(' typedvariablelist? ')' functionbody
    ;

functionbody
    : '{' (
        statement
        | 'if' expression scope ('else if' expression scope)* ('else' scope)?
        | 'while' expression scope
        | 'for' type? variablelist '=' expressionlist ',' expression (',' expression)? scope
        | 'for' type? variable 'in' variable scope
        | returnstatement
        )*
    '}'
    ;

returnstatement
    : 'return' variablelist?
    ;

functioncall
    : variable '(' variablelist? ')'
    ;

structdefinition
    : structtype variable '=' '{'
        (type variable terminator)*
    '}'
    ;

messagedefinition
    : messagetype variable '{' (topictype? type? variable (',' topictype? type? variable)*)? '}'
    ;

nodetypedefinition
    : nodetypetype variable '{' nodebody '}' // parameter based definition
    | nodetypetype variable nodetypesignature ('{' nodebody '}')? // signature based definition
    ;

nodetypesignature
    : '(' (variablelist | typedvariablelist)? '=>' (topictype? type? variable (',' topictype? type? variable)*)? ')'
    ;

nodedefinition
    : nodetype variable '{' nodebody '}' // using implicit nodetype
    | nodetype variable nodetypesignature ('{' nodebody '}')? // using implicit nodetype
    | nodetype variable variable // using explicit nodetype
    ;

nodebody
    : ( 'name' string terminator
        | 'description' string terminator
        | 'input' typedvariablelist? terminator
        | 'output' typedvariablelist? terminator 
        | 'include' variable terminator // include pre-defined meta properties
        | propertytype type variablelist terminator
    )*
    ;

metadefinition
    : metatype variable '{'
        (
            propertytype type variablelist terminator
        )*
    '}'
    ;

// edgedefinition
//     : edgetype variable '=' variablelist? '-[' typedvariablelist ']->' variablelist?
//     | edgetype variable '=' '{'
//         (
//             'name' '=' NAME terminator
//             | 'from' '=' '[' variablelist? ']' terminator
//             | 'to' '=' '[' variablelist? ']' terminator
//             | 'arguments' '=' '[' typedvariablelist ']' terminator
//         )*
//     '}'
//     ;

number
    : INTEGER | FLOAT
    ;

string
    : STRING //NORMALSTRING | CHARSTRING | LONGSTRING
    ;

typetype
    : 'type'
    ;

functiontype
    : 'function'
    ;

structtype
    : 'struct'
    ;

messagetype
    : 'message'
    ;

nodetypetype
    : 'nodetype'
    ;

nodetype
    : 'node'
    ;

propertytype
    : 'property'
    ;

topictype
    : 'topic'
    ;

metatype
    : 'meta'
    ;

terminator
    : STMEND
    // | EOF
    ;



/*
*  Lexer Rules
*/

// Types

TYPE        : 'type';
FUNCTION    : 'function';
STRUCT      : 'struct';
MESSAGE     : 'message';
NODETYPE    : 'nodetype';
NODE        : 'node';
META        : 'meta';


// Keywords

IMPORT      : 'import';
INCLUDE     : 'include';
PROPERTY    : 'property';
TOPIC       : 'topic';


// Fragments

fragment LOWERCASE    : [a-z] ;
fragment UPPERCASE    : [A-Z] ;
fragment DIGIT        : [0-9] ;
fragment NESTEDSTRING
    : '=' NESTEDSTRING '='
    | '[' .*? ']'
    ;
fragment ESCAPESEQUENCE    
    : '\\' [abfnrtvz"'\\] // https://stackoverflow.com/questions/30283122/lua-ignore-escape-sequence
    | '\\' '\r'? '\n'
    ;

fragment SEMICOLON : ';';

fragment NEWLINE
    : '\r' '\n'
    | '\n'
    | '\r'
    ;


// Literals

NAME                  : [a-zA-Z_][a-zA-Z_0-9]* ;
WORD                  : (LOWERCASE | UPPERCASE)+ ;
STRING                : '"'.*? '"' ;
NORMALSTRING          : '"' ( ESCAPESEQUENCE | ~('\\'|'"') )* '"' ;
CHARSTRING            : '\'' ( ESCAPESEQUENCE | ~('\''|'\\') )* '\'' ;
LONGSTRING            : '[' NESTEDSTRING ']' ;
INTEGER               : DIGIT+ ;
FLOAT                 : DIGIT+ ([.,] DIGIT+)? ;
WHITESPACE            : (' '|'\t')+ -> skip ;
// STMEND                : SEMICOLON ;
// STMEND                : NEWLINE+ ;
STMEND                : SEMICOLON NEWLINE* | NEWLINE+ ;
// NEWLINE               : ('\r'? '\n' | 'r')+ ;

COMMENT
    : '#[' NESTEDSTRING ']' -> channel(HIDDEN)
    ;

LINECOMMENT
    : '#'
    (                                               // #
    | '[' '='*                                      // #[==
    | '[' '='* ~('='|'['|'\r'|'\n') ~('\r'|'\n')*   // #[==AA
    | ~('['|'\r'|'\n') ~('\r'|'\n')*                // #AAA
    ) ('\r\n'|'\r'|'\n'|EOF)
    -> channel(HIDDEN)
    ;

SHEBANG
    : '#' '!' ~('\n'|'\r')* -> channel(HIDDEN)
    ;    