/***********************************************************
* Author:					James Shaver
* Date Created:				12/3/2015
* Last Modification Date:	2/22/2016
* Lab Number:				CST 320 Lab 2b
* Filename:					LexicalAnalyzer.h
*
* Overview:
*	This file contains the class definition for the LexicalAnalyzer class. The purpose of this class is to read files and recognize their tokens.
*	A person who uses this class would first load a language defition via LoadLanguageDefinition then they would call LoadInputFile to open a 
*	specific file using that language. Tokenize is then called to split the files lines into their individual tokens. IdenitfyTokens would then be ran to
*	to identify tokens. Last the user would run PrintTokens, to see which each token is identified as.
*
* Language restrictions:
*	1. Currently identifiers cannot begin or end with operators and symbols, this is more an issue with whitespace.
*	2. Tabs and spaces cannot be part of a language definition
*	3. All numbers are considered unsigned.
*   4. Comments are always assumed to start with // and are never tokenized
*	5. Preprocessed lines currently are recognized as just pre processed lines and are not split up.
*   6. #define will be processed as preprocessor
***********************************************************/


#ifndef  LexicalAnalyzer_H
#define  LexicalAnalyzer_H

#include <string>
#include <vector>
#include "SymbolTable.h"
#include "RDP.h"

using namespace std;

/************************************************************************
* Class: LexicalAnalyzer
* 
* Constructor:
*	LexicalAnalyzer();
* 
* Destructor:
*	~LexicalAnalyzer();
* 
* Mutators:
*	void AddLanguageItem( string line );
*	void Tokenize();
*	void LoadInputFile( string fileName );
*	void LoadLanguageDefinition( string fileName );
*	void IdentifyTokens();
*
* Methods:
*	int CheckInteger( string section ) const;
*	int CheckFloat( string section ) const;
*	int CheckLong( string section ) const;
*	bool CheckSymbol( string section ) const;
*	bool CheckOperator( string section ) const;
*	bool CheckKeyword( string section ) const;
*	bool CheckConditional( string section ) const;
*	void void PrintTokens() const;
*
************************************************************************/
class LexicalAnalyzer
{
public:
	//Constructor
	LexicalAnalyzer();

	//Destructor
	~LexicalAnalyzer();
	
	//Mutators
	void AddLanguageItem( string line );
	void Tokenize();
	void LoadInputFile( string fileName );
	void LoadLanguageDefinition( string fileName );
	void IdentifyTokens();

	//Methods
	string GetType(string section) const;
	bool CheckSymbol( string section ) const;
	bool CheckOperator( string section ) const;
	bool CheckKeyword( string section) const;
	bool CheckConditional( string section ) const;
	bool CheckPreprocessor( string line ) const;
	void PrintTokens();
	void RDP_Parse();

private:

	//Member structs
	struct TokenItem 
	{
		string value;
		string type;
	};

	//Member variables
	SymbolTable mSymbolTable;
	vector<string> mFileLines;			//a list of loaded lines from a file
	vector<string> mOperators;			//a list of loaded operators loaded from a language definition
	vector<string> mPreProcessors;		//a list of preprocessors loaded from a language definition
	vector<string> mSymbols;			//a list of symbols loaded from a language defintion
	vector<string> mConditionals; 		//a list of conditional statements loaded from a language definition
	vector<string> mKeywords;			//a list of keywords loaded from a language definition
	vector<TokenItem> mTokens;			//a list of tokens that are created from lines of file
	bool mValueTypes[3];				//a group of boolean flags that identify the allowed primitive types
	RDP* mRecursiveDescentParser;
};

#endif	