lexer grammar SeidlLexer;


/*
 * Note: all terminals must be defined here
 */

// Types

ARRAY               : '[]';
STRING              : 'string';
INT                 : 'int';
FLOAT               : 'float';
BOOL                : 'bool';
STRUCT              : 'struct';

MESSAGE             : 'message';
EDGETYPE            : 'edgetype';
NODETYPE            : 'nodetype';
NODE                : 'node';
SURROGATE           : 'surrogate';
META                : 'meta';
FUNCTION            : 'function';


// Keywords

TYPEDEF             : 'typedef';
IMPORT              : 'import';
INCLUDE             : 'include';
PROPERTY            : 'property';
TOPIC               : 'topic';
INPUT               : 'input';
OUTPUT              : 'output';
CLIENT              : 'client';
SERVER              : 'server';
PUBLISH             : 'publish';
SUBSCRIBE           : 'subscribe';
REQUEST             : 'request';
RESPOND             : 'respond';
PUB                 : 'pub';
SUB                 : 'sub';
REQ                 : 'req';
RES                 : 'res';
AUX                 : 'aux';
NULL                : 'null';
TRUE                : 'true';
FALSE               : 'false';
IF                  : 'if';
ELSE                : 'else';
ELSEIF              : 'else if';
FOR                 : 'for';
IN                  : 'in';
TO                  : 'to';
WHILE               : 'while';
RETURN              : 'return';
AS                  : 'as';
IMITATES            : 'imitates';
WITH                : 'with';
LATEST              : 'latest';
AUTO                : 'auto';
LABEL               : 'label';
NAMEDEF             : 'name';
TAGDEF              : 'tag';
PACKAGE             : 'package';
IMAGE               : 'image';
QUEUE               : 'queue';
VAR                 : 'var';
COMMAND             : 'command';
SEQUENTIAL          : 'sequential';
PARALLEL            : 'parallel';

// Operators

DOT                 : '.';
STAR                : '*';
COMMA               : ',';
COLON               : ':';
SEMI_COLON          : ';';
ASSIGN              : '=';
ADD                 : '+';
MINUS               : '-';
DIV                 : '/';
INTERPOLATION       : '$';
ARROW               : '-->';
HEAVYARROW          : '==>';
QUERYARROW_BEGIN    : '-:';
QUERYHARROW_BEGIN   : '=:';
QUERYARROW_END      : '->';
QUERYHARROW_END     : '=>';

EQUAL               : '==';
UNEQUAL             : '!=';
GREATERTHAN         : '>';
GREATEREQUALTHAN    : '>=';
LESSTHAN            : '<';
LESSEQUALTHAN       : '<=';
AND                 : 'and';
OR                  : 'or';
NOT                 : 'not';

OPEN_PAREN          : '(';
CLOSE_PAREN         : ')';
OPEN_BRACE          : '{';
CLOSE_BRACE         : '}';
OPEN_BRACKET        : '[';
CLOSE_BRACKET       : ']';



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

fragment SEMICOLON : ';' ;

fragment NEWLINE
    : '\r' '\n'
    | '\n'
    | '\r'
    ;


// Literals, Misc

NAME                  : [a-zA-Z_][a-zA-Z_0-9]*;
WORD                  : (LOWERCASE | UPPERCASE)+;
STRINGLITERAL         : '"'.*? '"'; // note: LITERAL postfix necessary due to already used keyword
NORMALSTRING          : '"' ( ESCAPESEQUENCE | ~('\\'|'"') )* '"';
CHARSTRING            : '\'' ( ESCAPESEQUENCE | ~('\''|'\\') )* '\'';
LONGSTRING            : '[' NESTEDSTRING ']';
INTEGER               : DIGIT+;
// FLOATINGPOINTNUMBER                 : DIGIT+ ([.,] DIGIT+)?;
FLOATINGPOINTNUMBER   : DIGIT+ ([.] DIGIT+)?; // note: _LIT postfix necessary due to already used keyword
WHITESPACE            : (' '|'\t')+ -> skip;
// STMEND                : SEMICOLON;
// STMEND                : NEWLINE+;
STMEND                : SEMICOLON NEWLINE* | NEWLINE+;
// NEWLINE               : ('\r'? '\n' | 'r')+;

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