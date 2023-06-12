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
    : terminator                                                            #terminatorStatement         
    | scope                                                                 #scopeStatement
    | (atomictype | typename) variablelist terminator                       #declarationStatement
    | variablelist '=' expressionlist terminator                            #assignmentStatement
    | (atomictype | typename) variablelist '=' expressionlist               #definitionStatement    
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
    | typename '[]'
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

nestedtypename // TODO: update that
    : NAME '.' NAME ('.' NAME)*
    ;

propertyname
    : NAME ('.' NAME)*
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
    | nestedtypename
    | functiondefinition | functioncall
    | importstatement
    | assignmentlist
    | '{' assignmentlist? '}'
    | '[' variablelist?  ']'
    ;

assignmentlist
    : assignment (',' assignment)*
    ;

assignment
    : variable '=' expression
    | nestedtypename '=' expression
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
    | IMPORT string
    | IMPORT from=variable AS to=variable
    | IMPORT string AS variable
    ;

typedefstatement
    : TYPEDEF (atomictype | typename) variable
    ;

nodeconnectionstatement
    : source=typename '-->' sink=typename
    | sources=variablelist '-->' sinks=variablelist
    | source=typename '==>' sink=typename
    | sources=variablelist '==>' sinks=variablelist
    ;

surrogatedefinitionstatement
    : propertyname typename IMITATES variable
    | propertyname typename IMITATES variable '{' assignmentlist? '}'
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
        | RESPONSE messagetypename
        | terminator
        )*
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
    | NODE typename variable nodeconstructor // using explicit nodetype and constructor
    ;

nodebody
    : (
        inout=nodebodyinout 
        | clientserver=nodebodyclientserver
        | include=nodebodyinclude
        | property=nodebodyproperty
        | terminator
    )*
    ;

nodebodyinout
    : INPUT messagetypelist
    | OUTPUT messagetypelist
    | INPUT '[' inoutoption ']' messagetypelist
    | OUTPUT '[' inoutoption ']' messagetypelist
    ;

inoutoption
    : (AUX | REQ | RES | REQUEST | RESPONSE | PUB | SUB | PUBLISH | SUBSCRIBE) ':' NAME
    ;

nodebodyinclude
    : INCLUDE variable
    ;
nodebodyproperty
    : PROPERTY (type | typename) variablelist    
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
