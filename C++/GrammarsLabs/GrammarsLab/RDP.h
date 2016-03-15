/***********************************************************
* Author:					James Shaver
* Date Created:				2/7/2016
* Last Modification Date:	2/22/2016
* Lab Number:				CST 320 Lab 2b
* Filename:					RDP.h
*
* Overview:
*	This file contains the class definition for the RDP class. The purpose of RDP class
*	is to act as Recursive Descent Parser for a custom language. It reads in tokens
*	for a program written in the language and idenifies what tokens are usuable statements.
*	Currently the grammar for the language is as follows:
*
comp_operators are:
==
!=
<=
>=
>
<

mulops are:
/
*
%

asops are:
+
-


PROGRAM -> STATE_LIST | lambda

STATE_LIST -> lamda
-> STATEMENT  STATE_LIST   //left recursion

STATEMENT -> KEYWORD
-> DECL
-> ASSIGN
-> FUN_DEF
-> FUN_CALL
-> IO
-> lambda

KEYWORD   -> if ( CONDITIONAL ) { STATE_LIST } OPTIONAL_STAT
-> for ( ASSIGNMENT ; CONDITIONAL; TERM) { STATE_LIST }
-> while ( CONDITIONAL ) { STATE_LIST }
-> main { STATE_LIST } STATEMENT
-> return TERM ;

DECL -> TYPE id DECL2

DECL2 -> = TERM ;

ASSIGN -> id ;
-> id = TERM ;
-> id = ID_SUB ;
-> Map = EXPRESSION ;
-> Music = EXPRESSION ;


FUN_DEF	->OPTIONAL_TYPE id(FUN_ID_LIST) { STATE_LIST } FUN_DEF
->lambda

FUN_CALL-> id (ID_LIST) ;

IO -> read id ;
-> write OUTPUT_LIST ;

OUTPUT_LIST -> " id " + OUTPUT_LST
-> TERM
-> id
-> ID_SUB

ID_LIST -> id , ID_LIST
-> id
-> num
-> ID_SUB  //unit production
-> lambda

ID_SUB -> id (ID_LIST)
-> id

OPTIONAL_STAT -> else { STATE_LIST } |
-> else if ( CONDITIONAL ) { STATE_LIST }
-> lambda

OPTIONAL_TYPE -> int
-> float
-> string
-> Camera
-> Actor
-> void
-> bool
-> lambda

TYPE -> int
-> float
-> bool
-> string
-> Camera
-> Actor
-> void

CONDITIONAL-> EXPRESSION comp_operator EXPRESSION |
-> EXPRESSION comp_operator EXPRESSION || CONDITIONAL |
-> EXPRESSION comp_operator EXPRESSION && CONDITIONAL

EXPRESSION -> TERM

TERM -> num
-> id
-> FUN_CALL
-> ID_SUB
-> ( TERM )
-> PRODUCT
-> VALUE

PRODUCT -> mulop TERM PRODUCT
-> lambda
-> num
-> id
-> ID_SUB

VALUE -> asop TERM VALUE
-> lamda
-> num
-> id
-> ID_SUB

FUN_ID_LIST -> TYPE id
-> TYPE id, FUN_ID_LIST
-> lambda
***********************************************************/
#ifndef  RDP_H
#define  RDP_H

#include <string>
#include <vector>
#include "SymbolTable.h"

using namespace std;

class RDP
{
	
public:

	//Constructors
	RDP(vector<string> values, vector<string> types, SymbolTable table);
	RDP();

	//Destructor
	~RDP();


	//Grammar rule mutators
	bool Program();
	bool StateList();
	bool Statement();
	bool OutputList();
	bool Idlist();
	bool Id_Sub();
	bool Optional_Stat();
	bool Optional_Type();
	bool Type();
	bool Conditional();
	bool Expression();
	bool Term();
	bool Product();
	bool Value();
	bool Keyword();
	bool Decl();
	bool Decl2();
	bool Assign();
	bool Fun_Def();
	bool Fun_Call();
	bool IO();
	bool Fun_Id_List();
	
	//Execution Mutator
	int Parse();

	//Helper functions
	void Error(string message) const;
	int GetSymbolCount() const;
private:

	//member struct
	struct Token
	{
		string value;
		string type;
	};

	//member variables
	vector<Token> mTokens;  //a list of token usually populated from a Lexical Analyzer
	vector<Token>::iterator  mCurrent; //the current position in the mTokens vector..
	vector<vector<Token>::iterator> mTempStack;
	int mCount;  //Number of blocks found.
	SymbolTable mSymbols;

};
#endif