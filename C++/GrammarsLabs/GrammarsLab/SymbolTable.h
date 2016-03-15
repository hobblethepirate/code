/***********************************************************
* Author:					James Shaver
* Date Created:				1/10/2016
* Last Modification Date:	2/22/2016
* Lab Number:				CST 320 Lab 2b
* Filename:					SymbolTable.h
*
* Overview:
*	This file contains the class definition for the SymbolTbale class. The purpose of this class is a data structure to contain symbols.
*	Each symbol can have a name, type, use, value, and scope. Name is the value from the token (split portions of text). Scope is the level of 
*	visibility for symbol, eg. 0 being the top level and 1 being a sub level to it. 
*
***********************************************************/
#ifndef  SymbolTable_H
#define  SymbolTable_H

#include <string>
#include <map>
#include <vector>

using namespace std;

class SymbolTable
{

public:

	//Constructor
	SymbolTable();
	
	//Destructor
	~SymbolTable();

	//Mutators
	bool Insert( string name, string type, string use, string value, int scope );
	bool SetValue(string name, string value);
	void Delete( string name );

	//Methods
	bool Search( string name ) const;
	string GetValue( string name ) const;
	string GetType( string name ) const;
	int GetCount() const;

private:

	//Member struct
	struct SymbolEntry
	{
		string type;
		string use; 
		string value;
		int scope;
	};

	//Member variables
	map <string, SymbolEntry> mSymbolData;
	int mCount;

};
#endif