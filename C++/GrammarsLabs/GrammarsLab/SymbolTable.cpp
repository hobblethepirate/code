/***********************************************************
* Author:					James Shaver
* Date Created:				1/10/2016
* Last Modification Date:	2/22/2016
* Lab Number:				CST 320 Lab 2b
* Filename:					SymbolTable.cpp
*
* Overview:
*	This file contains the methods and mutators for the 
*	SymbolTable class.
*
***********************************************************/

#include "SymbolTable.h"
#include <string>
#include <map>

/**************************************************************
* SymbolTable constructor -
*
* Purpose:
*	Initializes a SymbolTable object.
**************************************************************/
SymbolTable::SymbolTable()
{

}

/**************************************************************
* SymbolTable destructor -
*
* Purpose:
*	Deallocates the needed memory for a SymbolTable object.
*
**************************************************************/
SymbolTable::~SymbolTable()
{

}

/**************************************************************
* Insert(string name, string type, string use, string value, int scope)
*
* Input:
*	name - the token given eg "1.5", "int", "for";
*	type - the identified type of token eg 1.5 is a float and for is a keyword
*	use - eg variable name, constant name, type name, function name
*	value - eg value of a constant
*	scope - level of use eg a variable at scope 0 can be visible by it's lower levels 1,2,3. 
*
* Output:
*	A boolean value that will be true if the insert succeeded and false if the insert failed.
*
* Purpose:
*	Adds values to symbol tables and returns if it occurs successfully it returns true or 
*	it returns false if it fails to insert.
*
**************************************************************/
bool SymbolTable::Insert(string name, string type, string use, string value, int scope)
{
	//For debugging purposes, the line below can be uncommented.
	//std::cout << mCount << ". adding " << name << " to the symbol table." << endl;
	//checking for a duplicate value
	if (Search(name) == true)
	{
		//a redefinition should occur here
		mSymbolData.at(name).type = type;
		mSymbolData.at(name).use = use;
		mSymbolData.at(name).value = value;
		mSymbolData.at(name).scope = scope;
		return true;
	}
	SymbolEntry temp;

	temp.type = type;
	temp.use = use;
	temp.value = value;
	temp.scope = scope;

	mSymbolData[name] = temp;
	mCount++;
	return true;
}

/**************************************************************
* Delete(string name)
*
* Input:
*	A name of symbol to be deleted.
*
* Purpose:
*	Deletes a value from the symbol table.
*
**************************************************************/
void SymbolTable::Delete(string name)
{
	mSymbolData.erase(name);
}

/**************************************************************
* Search(string name)
*
* Input:
*	A name of symbol to be searched.
*
* Purpose:
*	Searches for a value in the symbol table, returns false if not found.
*	Returns true if found.
*
**************************************************************/
bool SymbolTable::Search(string name) const
{
	if (mSymbolData.find(name) == mSymbolData.end())
	{
		return false;
	}
	return true;
}

/**************************************************************
* string GetValue(string name)
*
* Input:
*	A name of symbol to be looked up.
*
* Output:
*	A string value for the specified symbol name
*
* Purpose:
*	Gets the value of specific named key. 
*
**************************************************************/
string SymbolTable::GetValue(string name) const
{
	SymbolEntry temp = mSymbolData.at(name);
	return temp.value;
}

/**************************************************************
* string GetType(string name)
*
* Input:
*	A name of symbol to be looked up.
*
* Output:
*	The type of symbol that was searched.
*
* Purpose:
*	Gets the type of specific named key.
*
**************************************************************/
string SymbolTable::GetType(string name) const
{
	SymbolEntry temp = mSymbolData.at(name);
	return temp.type;
}

/**************************************************************
* string GetCount() const
*
*
* Output:
*	returns the number of symbol entries in the symbol table;
*
* Purpose:
*	Used to find out how many table entries exist in the current
*	symbol Table.
*
**************************************************************/
int SymbolTable::GetCount() const
{
	return mCount;
}