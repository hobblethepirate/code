
/***********************************************************
* Author:					James Shaver
* Date Created:				2/7/2016
* Last Modification Date:	2/22/2016
* Lab Number:				CST 320 Lab 2b
* Filename:					RDP.cpp
*
* Overview:
*	This file contains the methods and mutators for the
*	RDP class.
*
***********************************************************/

#include "RDP.h"
#include <iostream>

using namespace std;

/**************************************************************
* RDP constructor -
*
* Purpose:
*	Initializes a RDP object.
**************************************************************/
RDP::RDP() 
{

}

/**************************************************************
* RDP(vector<string> values, vector<string> types) constructor -
*
* Purpose:
*	Initializes a SymbolTable object with a group of values and
*	their matching types.
**************************************************************/
RDP::RDP(vector<string> values, vector<string> types, SymbolTable table)
{
	Token temp;
	for (int count = 0; count < values.size(); count++)
	{
		//Taking all the given values and types and adding them to 
		//mTokens
		temp.value = values[count];
		temp.type = types[count];
		mTokens.push_back(temp);
		
		//resetting values
		temp.value = "";
		temp.type = "";
	}
	mSymbols = table;
}


/**************************************************************
* RDP destructor -
*
* Purpose:
*	De-allocates the RDP in memory.
**************************************************************/
RDP::~RDP()
{

}

/**************************************************************
* bool Parse -
*
* Input:
*	A list of preprocessed tokens. 
*
* Output:
*	Statements regarding which grammar blocks were matched. The
*	function returns true if all the statements were correct or
*	false if one or more statements are incorrect.
*
* Purpose:
*	Starts at the beginning of a list of tokens. 
*	Goes through a list of tokens and matches it to a respective
*	grammar. If a statement is matched a message is displayed.
*	in the console.
**************************************************************/
 int RDP::Parse()
{
	mCurrent = mTokens.begin();
	Program();
	return mCount;
}

/**************************************************************
* bool Program -
*
* Output:
*	True if the tokens match the description of the program grammar.
*
* Purpose:
*	Checks to see if the current token fits the grammar 
*	description of:
*	
*	PROGRAM -> STATE_LIST | lambda
**************************************************************/
bool RDP::Program() 
{	
	if (mCurrent == mTokens.end())
	{
		return true;
	}
	return StateList();
}


/**************************************************************
* bool State_List -
*
* Output:
*	True if the tokens match the description of State_List grammar.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	STATE_LIST-> STATEMENT | STATEMENT } | STATEMENT  STATE_LIST | STATEMENT lambda
**************************************************************/
bool RDP::StateList() 
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;
	
	if (mCurrent == mTokens.end() || mCurrent->type.compare("}") == 0)
	{
		return true;
	}

	if (Statement())
	{

		if (mCurrent == mTokens.end())
		{
			return true;
		}
		else if (mCurrent->type.compare("}") == 0)
		{
			return true;
		}
		else if (StateList())
		{
			return true;
		}
		
	}		
	return false;
}


/**************************************************************
* bool Statement -
*
* Output:
*	True if the tokens match the description of Statement_List grammar.
*   True if lambda.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	STATEMENT-> KEYWORD | DECL | ASSIGN | FUN_DEF | FUN_CALL | IO | lambda
**************************************************************/
bool RDP::Statement()
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;

	if (mCurrent == mTokens.end())
	{
		return true;
	}

	if (Keyword())
	{
		return true;
	}
	else if (Decl())
	{
		return true;
	}
	else if (Assign())
	{
		return true;
	}
	else if (Fun_Def())
	{
		return true;
	}
	else if (Fun_Call())
	{
		return true;
	}
	//because of lambda
	return true;
}

/**************************************************************
* bool Keyword -
*
* Output:
*	True if the tokens match the description of Keyword.
*   False if the tokens do not.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	KEYWORD-> if (CONDITIONAL) { STATE_LIST } OPTIONAL_STAT |
*			  for (ASSIGNMENT; CONDITIONAL; EQUATION) { STATE_LIST }
*			  while (CONDITIONAL) { STATE_LIST }  |
*			  main { STATE_LIST } FUN_DEF
**************************************************************/
bool RDP::Keyword()
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;
	
	if (mCurrent->type.compare("if") == 0)
	{
		mCurrent++;
		if (mCurrent->type.compare("(") == 0)
		{
			mCurrent++;
			if (Conditional())
			{
				mCurrent++;
				if (mCurrent->type.compare(")") == 0)
				{
					mCurrent++;
					if (mCurrent->type.compare("{") == 0)
					{
						mCurrent++;
						if (StateList())
						{
							if (mCurrent->type.compare("}") == 0)
							{
								mCurrent++;
								if (Optional_Stat())
								{
									cout << "[IF] block found." << endl;
									mCount++;
									return true;
								}
							}
							else
							{
								Error("Incomplete If block, missing a } at the end of the If's statement(s).");
								return false;
							}
						}
					}
					else
					{
						Error("Incomplete If block, missing a { after the conditional part of the If statement.");
						return false;
					}
				}
			}
		}
	}
	else if(mCurrent->type.compare("for") == 0)
	{
		//-> for (ASSIGNMENT; CONDITIONAL; TERM) { STATE_LIST }
		mCurrent++;
		if (mCurrent->type.compare("(") == 0)
		{
			mCurrent++;
			if (Assign())
			{
				mCurrent++;
				if (mCurrent->type.compare(";") == 0)
				{
					mCurrent++;
					if (Conditional())
					{
						mCurrent++;
						if (mCurrent->type.compare(";") == 0)
						{
							mCurrent++;
							if (Term())
							{
								mCurrent++;
								if (mCurrent->type.compare(")") == 0)
								{
									mCurrent++;
									if (mCurrent->type.compare("{") == 0)
									{
										mCurrent++;
										if (StateList())
										{
											mCurrent++;
											if (mCurrent->type.compare("}") == 0)
											{
												cout << "[FOR] Block found" << endl;
												mCount++;
												return true;
											}
											else
											{
												Error("Incomplete For block, missing a } at the end of the For's statement(s).");
												return false;
											}
										}
									}
									else
									{
										Error("Incomplete For block, missing a { after the For loop conditions statement.");
										return false;
									}
								}
								else
								{
									Error("Incomplete For block, missing a ) after the for loop description.");
									return false;
								}
							}
						}
					}

				}
			}
			else
			{
				Error("Incomplete For block, missing an assignment statement.");
				return false;
			}
		
		}
		else
		{
			Error("Incomplete For block, missing a ( after the for keyword");
			return false;
		}
	}
	else if (mCurrent->type.compare("while") == 0)
	{
		//-> while (CONDITIONAL) { STATE_LIST }
		mCurrent++;
		if (mCurrent->type.compare("(") == 0)
		{
			mCurrent++;
			if (Conditional())
			{
				mCurrent++;
				if (mCurrent->type.compare(")") == 0)
				{
					mCurrent++;
					if (mCurrent->type.compare("{") == 0)
					{
						mCurrent++;
						if (StateList())
						{
							if (mCurrent->type.compare("}") == 0)
							{
								cout << "[While] block found" << endl;
								mCount++;
								return true;

							}
							else
							{
								Error("Incomplete While block, missing a } at the end of the While's statement(s).");
								return false;
							}
						}
					}
					else
					{
						Error("Incomplete While block, missing a { after the conditional part of the While statement.");
						return false;
					}
				}
				else
				{
					Error("Incomplete While block, missing a ) after the conditional part of the While statement.");
					return false;
				}
			}
		}
		else
		{
			Error("Incomplete While block, missing a ( after the While keyword.");
			return false;
		}

	}
	else if (mCurrent->type.compare("main") == 0)
	{

		//main{ STATE_LIST } FUN_DEF
		mCurrent++;
		if (mCurrent->type.compare("{") == 0)
		{
			mCurrent++;
			if (StateList())
			{
				if (mCurrent->type.compare("}") == 0)
				{
					mCurrent++;
					if (mCurrent == mTokens.end())
					{
						cout << "[Main] block found, with no functions found." << endl;
						mCount++;
						mSymbols.Insert("main", "main", "", "void", 1);
						return true;
					}
					else if (Fun_Def())
					{
						cout << "[Main] block with functions found." << endl;
						mSymbols.Insert("main", "main", "", "void", 1);
						mCount++;
						return true;
					}

				}
				else
				{
					Error("Incomplete Main block, missing a } at the end of the main statement(s).");
					return false;
				}
			}
		}
		else
		{
			Error("Incomplete Main block, missing a { after the main keyword.");
			return false;
		}

	}
	else if (mCurrent->type.compare("return") == 0)
	{
		mCurrent++;
		if (Term())
		{
			cout << "[Return] block found." << endl;
			mCount++;
			return true;
		}
		else
		{
			Error("Incomplete Return block, missing a ; at the end of statement");
			return false;
		}
	}
	return false;
}


/**************************************************************
* bool Decl -
*
* Output:
*	True if the tokens match the description of Decl grammar.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	DECL -> TYPE id DECL2 
**************************************************************/
bool RDP::Decl()
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;

	if (Type())
	{
		mTempStack.push_back(mCurrent);
		mCurrent++;
		if (mCurrent->type.compare("id")==0)
		{
			mTempStack.push_back(mCurrent);
			mCurrent++;
			if (Decl2())
			{
				
				if (mSymbols.Search(mTempStack[1]->value) == false)
				{
					mSymbols.Insert(mTempStack[1]->value, mTempStack[0]->value, "variable", "", 1);
					mCurrent++;
					cout << "[Declaration] block found." << endl;

					mTempStack.clear();

					mCount++;
					return true;
				}
				else
				{
					cout << "Unable to insert the " << mTempStack[1]->value << ". Duplicate Declaration" << endl;
					mTempStack.clear();
				}
			}
			else
			{
				mTempStack.clear();

			}
		}
	}
	return false;
}


/**************************************************************
* bool Decl2 -
*
* Output:
*	True if the tokens match the description of Decl2 grammar.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	DECL2 -> = TERM ;
**************************************************************/
bool RDP::Decl2()
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;

	if (mCurrent->type.compare("=") == 0)
	{
		mCurrent++;

		if (Term())
		{
			if (mCurrent->type.compare(";") != 0)
			{
				mCurrent++;
			}
			if (mCurrent->type.compare(";") == 0)
			{
				return true;
			}
			else
			{
				Error("Incomplete declaration, missing a ; at the end of statement");
				return false;
			}
		}
	}
	else
	{
		Error("Incomplete declaration, missing a = in the middle of the statement");
		return false;
	}
}



/**************************************************************
* bool Assign -
*
* Output:
*	True if the tokens match the description of Assign grammar.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	ASSIGN -> id = TERM; | id = ID_SUB; | ID_SUB; | Map = EXPRESSION; | Music = EXPRESSION; 
**************************************************************/
bool RDP::Assign()
{
	vector<Token>::iterator temp, i;
	vector<Token>::iterator tempTwo, j;
	temp = mCurrent;
	
	if (Id_Sub())
	{
		mCurrent++;
		if (mCurrent->type.compare(";") == 0)
		{
			cout << "[Assignment-id_sub] block found." << endl;
			mCount++;
			mCurrent++;
			return true;
		}
		else
		{
			Error("Assignment -id_sub block, missing a ; at the end of statement");
			return false;
		}
	}
	if (mCurrent->type.compare("id") == 0)
	{
		tempTwo = mCurrent;
		mCurrent++;
		if (mCurrent->type.compare("=") == 0)
		{
			mCurrent++;
			if (Term())
			{
				if (mCurrent->type.compare(";") != 0)
				{
					mCurrent++;
				}
				if (mCurrent->type.compare(";") == 0)
				{

					if (mSymbols.Search(tempTwo->value) == false)
					{
						cout << "Unable to use " << tempTwo->value << ", it hasn't been declared." << endl;
						return false;
					}
					else
					{
						mCurrent++;
						cout << "[Assignment] block found." << endl;
						mCount++;
						return true;
					}
				}
				else
				{
					Error("Incomplete Assignment block, missing a ; at the end of statement");
					return false;
				}
			}
			else if (Expression())
			{
				mCurrent++;
				if (mCurrent->type.compare(";") == 0)
				{
					cout << "[Assignment] block found with expression" << endl;
					mCount++;
					return true;
				}
				else
				{
					Error("Incomplete Assignment block, missing a ; at the end of statement");
					return false;
				}
				
			}
		}

			
	}
	else if (mCurrent->type.compare("Map") == 0)
	{
		mCurrent++;
		if (mCurrent->type.compare("=") == 0)
		{
			mCurrent++;
			if (Expression())
			{
				mCurrent++;
				
				if (mCurrent->type.compare(";") == 0)
				{
					if (mSymbols.Search("Map") != true){
						mSymbols.Insert("Map", "id", "mapdef", "", 1);
						mCurrent++;
						cout << "[Map Assignment] block found" << endl;
						mCount++;
						return true;
					}
					else
					{
						Error("Duplicate Map assignment block, only one Map assignment per program.");
						return false;
					}
				}
				else
				{
					
					Error("Incomplete Map Assignment block, missing a ; at the end of statement");
					return false;
				}
			}
		}
		else
		{
			Error("Incomplete Map Assignment block, missing a = in the statement.");
			return false;
		}
	}
	else if (mCurrent->type.compare("Music") == 0)
	{
		mCurrent++;
		if (mCurrent->type.compare("=") == 0)
		{
			mCurrent++;
			if (Expression())
			{
				mCurrent++;
				if (mCurrent->type.compare(";") == 0)
				{
					if (mSymbols.Search("Music") != true){
						mCurrent++;
						mSymbols.Insert("Music", "id", "musicdef", "", 1);

						cout << "[Music Assignment] block found." << endl;
						mCount++;
						return true;
					}
					else
					{
						Error("Duplicate Music assignment block, only one Muisc assignment per program.");
						return false;
					}
				}
				else
				{
					Error("Incomplete Music Assignment block, missing a ; at the end of statement");
					return false;
				}
			}
		}
		else
		{
			Error("Incomplete Music Assignment block, missing a = in the statement.");
			return false;
		}
	}
	return false;
}


/**************************************************************
* bool Fun_Def -
*
* Output:
*	True if the tokens match the description of Fun_Def grammar.
*   True if it is lambda.
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*   FUN_DEF->	OPTIONAL_TYPE id(FUN_ID_LIST) { STATE_LIST  } FUN_DEF |
*				lambda
**************************************************************/
bool RDP::Fun_Def()
{
	
	vector<Token>::iterator temp, i;
	temp = mCurrent;

	if (mCurrent == mTokens.end())
	{
		return true;
	}

	if (Optional_Type())
	{
		mCurrent++;
		if (mCurrent == mTokens.end())
		{
			mCurrent = temp;
			return false;
		}
		if (mCurrent->type.compare("id") == 0)
		{
			mTempStack.push_back(mCurrent);
			mCurrent++;
			if (mCurrent->type.compare("(") == 0)
			{
				mCurrent++;
				if (Fun_Id_List())
				{
					if (mCurrent->type.compare(")") == 0)
					{
						mCurrent++;
						if (mCurrent->type.compare("{") == 0)
						{
							mCurrent++;
							if (StateList())
							{
								if (mCurrent->type.compare("}") == 0)
								{
									mCurrent++;
									if (Fun_Def())
									{
										bool failed = false;
										for (auto iter : mTempStack)
										{
											if (mSymbols.Search(iter->value) == true)
											{
												failed = true;
											}
										}
										if (failed != true)
										{
											for (int a=0; a < mTempStack.size() - 1; a++)
											{
												mSymbols.Insert(mTempStack[a]->value, mTempStack[a]->type, "variable", "", 2);
											}
											mSymbols.Insert(mTempStack[mTempStack.size() - 1]->value, mTempStack[mTempStack.size() - 1]->type, "function", "", 2);
											mTempStack.clear();
											cout << "[Function Defintion] block found." << endl;
											mCount++;
											return true;
										}
										else
										{
											mTempStack.clear();
											return false;
										}
									}
								}
								else
								{
									Error("Incomplete Function Defintion block missing a } at the end of statements.");
									return false;
								}

							}
						}
					}
				}
			}
		}
	}
	return true;
}



/**************************************************************
* bool Fun_Call -
*
* Output:
*	True if the tokens match the description of Fun_Call grammar.
*   
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*   FUN_CALL -> id (ID_LIST) ;
**************************************************************/
bool RDP::Fun_Call()
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;

	if (mCurrent->type.compare("id") == 0)
	{
		mCurrent++;
		if (mCurrent->type.compare("(") == 0)
		{
			mCurrent++;
			if (Idlist())
			{
				if (mCurrent->type.compare(")") == 0)
				{
					mCurrent++;
					if (mCurrent->type.compare(";") == 0)
					{
						cout << "[Function Call] block found." << endl;
						mCount++;
						return true;
					}
					else
					{
						Error("Incomplete Function Call block missing ; at the end of statement");
						return false;
					}
						
				}
			}
		}
	}
	return false;
}


/**************************************************************
* bool IO -
*
* Output:
*	True if the tokens match the description of IO grammar.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*   IO-> read id; | write OUTPUT_LIST;
**************************************************************/
bool RDP::IO()
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;

	if (mCurrent->type.compare("read") == 0)
	{
		mCurrent++;
		if (mCurrent->type.compare("id") == 0)
		{
			mCurrent++;
			if (mCurrent->type.compare(";") == 0)
			{
				return true;
			}
			else
			{
				Error("Incomplete read block missing a ; at the end of the statement.");
				return false;
			}
		}
		else
		{
			Error("Incomplete read block missing an id");
			return false;
		}
	}
	else if (mCurrent->type.compare("write") == 0)
	{
		mCurrent++;
		if (OutputList())
		{
			mCurrent++;
			if (mCurrent->type.compare(";") == 0)
			{
				return true;
			}
			else
			{
				Error("Incomplete write block missing a ; at the end of statement.");
				return false;
			}
		}
	}
}



/**************************************************************
* bool OutputList -
*
* Output:
*	True if the tokens match the description of OutputList grammar.
*   True if it's lambda.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	OUTPUT_LIST -> " id " + OUTPUT_LIST | TERM | id | ID_SUB | lambda
**************************************************************/
bool RDP::OutputList() 
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;

	if (mCurrent->type.compare("\"") == 0)
	{
		mCurrent++;
		if (mCurrent->type.compare("id") == 0)
		{
			mCurrent++;
			if (mCurrent->type.compare("\"") == 0)
			{
				mCurrent++;
				if (mCurrent->type.compare("+") == 0)
				{
					mCurrent++;
					if (OutputList())
					{
						return true;
					}
				}
			}
		}
	} 
	else if (Term())
	{
		return true;
	}
	else if (Id_Sub())
	{
		return true;
	}
	return true;
}



/**************************************************************
* bool IdList -
*
* Output:
*	True if the tokens match the description of IdList grammar.
*   True if it's lambda.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	ID_LIST -> id, ID_LIST | num, ID_LIST | id | num | ID_SUB |lambda
**************************************************************/
bool RDP::Idlist() 
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;


	if (mCurrent->type.compare("id") == 0 || mCurrent->type.compare("num") == 0)
	{
		mCurrent++;
		if (mCurrent->type.compare(",") == 0)
		{
			mCurrent++;
			if (Idlist())
			{
				return true;
			}
		}
		else
		{
			return true;
		}
	}
	else if (Id_Sub())
	{
		return true;
	}
	return true;
}



/**************************************************************
* bool IdList -
*
* Output:
*	True if the tokens match the description of IdList grammar.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	 ID_SUB-> (ID_LIST) | num | id
**************************************************************/
bool RDP::Id_Sub() 
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;

	if (mCurrent->type.compare("id") == 0)
	{
		mCurrent++;
		if (mCurrent->type.compare("(") == 0)
		{
			mCurrent++;
			if (Idlist())
			{
				if (mCurrent->type.compare(")") == 0)
				{
					return true;
				}
			}

		}
		else
		{
			mCurrent = temp;
			return false;
		}
	}
	else if (mCurrent->type.compare("num") == 0)
	{
		return true;
	}
	return false;
}


/**************************************************************
* bool Optional_Stat -
*
* Output:
*	True if the tokens match the description of Optional_Stat grammar.
*	True if lambda.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	OPTIONAL_STAT -> else { STATE_LIST } | else if (CONDITIONAL) { STATE_LIST } | lambda
**************************************************************/
bool RDP::Optional_Stat()
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;

	if (mCurrent->type.compare("else") == 0)
	{
		mCurrent++;
		if (mCurrent->type.compare("{") == 0)
		{
			mCurrent++;
			if (StateList())
			{
				
				if (mCurrent->type.compare("}") == 0)
				{
					mCurrent++;
					cout << "[Else] block found. " << endl;
					mCount++;
					return true;
				}
				else
				{
					Error("Incomplete else block missing } at the end of statements.");
				}
			}
		}
		else if (mCurrent->type.compare("if") == 0)
		{
			mCurrent++;
			if (mCurrent->type.compare("(") == 0)
			{
				mCurrent++;
				if (Conditional())
				{
					mCurrent++;
					if (mCurrent->type.compare(")") == 0)
					{
						mCurrent++;
						if (mCurrent->type.compare("{") == 0)
						{
							mCurrent++;
							if (StateList())
							{
								if (mCurrent->type.compare("}") == 0)
								{
									cout << "[Else if] block found." << endl;
									mCount++;
									return true;
								}
								else
								{
									Error("Incomplete else if block missing } at the end of statements.");
								}
							}
						}
					}
				}
			}
		}
	}
	return true;
}
	


/**************************************************************
* bool Optional_Type -
*
* Output:
*	True if the tokens match the description of Optional_Type grammar.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	OPTIONAL_TYPE -> int | float | string | Camera | Actor | void | bool | lambda
**************************************************************/
bool RDP::Optional_Type()
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;

	if (mCurrent->type.compare("int") == 0)
	{
		return true;
	}
	else if (mCurrent->type.compare("float") == 0)
	{
		return true;
	}
	else if (mCurrent->type.compare("string") == 0)
	{
		return true;
	}
	else if (mCurrent->type.compare("Camera") == 0)
	{
		return true;
	}
	else if (mCurrent->type.compare("Actor") == 0)
	{
		return true;
	}
	else if (mCurrent->type.compare("void") == 0)
	{
		return true;
	}
	else if (mCurrent->type.compare("bool") == 0)
	{
		return true;
	}
	return true;
}


/**************************************************************
* bool Type -
*
* Output:
*	True if the tokens match the description of Type grammar.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	TYPE -> int | float | bool | string | Camera | Actor | void
**************************************************************/
bool RDP::Type() 
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;

	if (mCurrent->type.compare("int") == 0)
	{
		return true;
	}
	else if (mCurrent->type.compare("float") == 0)
	{
		return true;
	}
	else if (mCurrent->type.compare("string") == 0)
	{
		return true;
	}
	else if (mCurrent->type.compare("Camera") == 0)
	{
		return true;
	}
	else if (mCurrent->type.compare("Actor") == 0)
	{
		return true;
	}
	else if (mCurrent->type.compare("void") == 0)
	{
		return true;
	}
	else if (mCurrent->type.compare("bool") == 0)
	{
		return true;
	}
	return false;
}



/**************************************************************
* bool Conditional -
*
* Output:
*	True if the tokens match the description of Conditional grammar.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	  CONDITIONAL-> EXPRESSION comp_operator EXPRESSION | 
*					EXPRESSION comp_operator EXPRESSION || CONDITIONAL |
*					EXPRESSION comp_operator EXPRESSION && CONDITIONAL
**************************************************************/
bool RDP::Conditional()
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;

	if (Expression())
	{
		mCurrent++;
		if (mCurrent->type.compare("conditional") == 0)
		{
			mCurrent++;
			if (Expression())
			{
				temp = mCurrent;
				mCurrent++;
				if (mCurrent->value.compare("||") == 0)
				{
					mCurrent++;
					if (Conditional())
					{
						return true;
					}
				}
				else if (mCurrent->value.compare("&&") == 0)
				{
					mCurrent++;
					if (Conditional())
					{
						return true;
					}

				}
				else
				{
					mCurrent = temp;
					return true;
				}
			}
		}

	}
	return false;
}


/**************************************************************
* bool Expression -
*
* Output:
*	True if the tokens match the description of Expression grammar.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	  EXPRESSION -> TERM 
**************************************************************/
bool RDP::Expression() 
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;

	if (Term())
	{
		mCurrent = temp;
		return true;
	}

	return false;
}


/**************************************************************
* bool Term -
*
* Output:
*	True if the tokens match the description of Term grammar.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	  TERM-> num | id | FUN_CALL| ID_SUB | (TERM) | PRODUCT | VALUE
**************************************************************/
bool RDP::Term() 
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;
	
	if (mCurrent->type.compare("num") == 0)
	{
		return true;
	}
	else if (mCurrent->type.compare("id") == 0)
	{
		if (Fun_Call())
		{
			return true;
		}
		else if (Id_Sub())
		{
			return true;
		}
		else
		{
			mCurrent = temp;
			if (Product())
			{
				return true;
			}
			else if (Value())
			{
				return true;
			}
		}

	}
	else if (mCurrent->type.compare("(") == 0)
	{
		mCurrent++;
		if (Term())
		{
			mCurrent++;
			if (mCurrent->type.compare(")") == 0)
			{
				return true;
			}
		}
	}
	else if (mCurrent->type.compare("-") == 0 || mCurrent->type.compare("+") == 0)
	{
		if (Value())
		{
			return true;
		}
	}
	else if (Product())
	{
		return true;
	}
	else if (Value())
	{
		return true;
	}
	return false;
}


/**************************************************************
* bool Product -
*
* Output:
*	True if the tokens match the description of Product grammar.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
*	PRODUCT->mulop TERM PRODUCT | lambda | num | id | ID_SUB
**************************************************************/
bool RDP::Product() 
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;

	if (mCurrent->type.compare("/") == 0 || mCurrent->type.compare("*") == 0 || mCurrent->type.compare("%") == 0)
	{
		mCurrent++;
		if (Term())
		{
			mCurrent++;
			if (Product())
			{
				return true;
			}
		}
	}
	else if (mCurrent->type.compare("num") == 0)
	{
		temp = mCurrent;
		mCurrent++;
		if (mCurrent->type.compare("-") == 0 || mCurrent->type.compare("+") == 0) 
		{
			mCurrent = temp;
			return false;
		}
		return true;
	}
	else if (mCurrent->type.compare("id") == 0)
	{
		temp = mCurrent;
		mCurrent++;
		if (mCurrent->type.compare("-") == 0 || mCurrent->type.compare("+") == 0)
		{
			mCurrent = temp;
			return false;
		}
		return true;
	}
	else if (Id_Sub())
	{
		return true;
	}
	return true;
}

/**************************************************************
* bool Value -
*
* Output:
*	True if the tokens match the description of Value grammar.
*	True if lambda.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
* VALUE-> asop TERM VALUE | num | id | ID_SUB | lambda
**************************************************************/
bool RDP::Value() 
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;
	if (mCurrent->type.compare("+") == 0 || mCurrent->type.compare("-") == 0)
	{
		mCurrent++;
		if (Term())
		{
			mCurrent++;
			if (Value())
			{
				return true;
			}
		}
	}
	else if (mCurrent->type.compare("num") == 0)
	{
		mCurrent++;
		if (Value())
		{
			return true;
		}
		return true;
	}
	else if (mCurrent->type.compare("id") == 0)
	{
		mCurrent++;
		if (Value())
		{
			return true;
		}
		return true;
	}
	else if (Id_Sub())
	{
		return true;
	}
	return true;
}


/**************************************************************
* bool Fun_Id_List() -
*
* Output:
*	True if the tokens match the description of FUN_ID_LIST grammar.
*	True if lambda.
*
* Purpose:
*	Checks to see if the current token fits the grammar
*	description of:
*
* //FUN_ID_LIST->TYPE id | TYPE id, FUN_ID_LIST | lambda
**************************************************************/
bool RDP::Fun_Id_List()
{
	vector<Token>::iterator temp, i;
	temp = mCurrent;
	
	if (Type())
	{
		mCurrent++;
		if (mCurrent->type.compare("id") == 0)
		{
			mTempStack.push_back(mCurrent);
			mCurrent++;
			if (mCurrent->type.compare(",") == 0)
			{
				mCurrent++; 
				if (Fun_Id_List())
				{
					return true;
				}
			}
			else
			{
				return true;
			}
		}
	}
	return true;
}

/**************************************************************
* Error(string message)
*
* Input:
*	A string representing an error message.
*
* Output:
*	A cout error message is displayed to console.
*
* Purpose:
*	Outputs an error message in a specific format.
*
**************************************************************/
void RDP::Error( string message ) const
{
	cout <<"Error: "<< message << endl;
}

/**************************************************************
* int RDP::GetSymbolCount() const
*
*
* Output:
*	Returns the number of entries in the mSymbols
*
* Purpose:
*	Gets the number of entries in the mSymbols.
*
**************************************************************/
int RDP::GetSymbolCount() const
{
	return mSymbols.GetCount();
}