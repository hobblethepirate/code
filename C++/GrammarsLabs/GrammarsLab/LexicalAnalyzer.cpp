
/***********************************************************
* Author:					James Shaver
* Date Created:				12/3/2015
* Last Modification Date:	2/22/2016
* Lab Number:				CST 320 Lab 2b
* Filename:					LexicalAnalyzer.cpp
*
* Overview:
*	This file contains the methods and mutators for the 
*	the LexicalAnalyzer class.
*
***********************************************************/
#include "LexicalAnalyzer.h"
#include <string>
#include <iostream>
#include <fstream>
#include <algorithm> 

/**************************************************************
* LexicalAnalyzer constructor - 
*
* Purpose:	
*	Sets all the flags for all primitive values to false and
*	allocates the needed memory for a LexicalAnalyzer object.
*
**************************************************************/
LexicalAnalyzer::LexicalAnalyzer()
{
	mValueTypes[0] = false;
	mValueTypes[1] = false;
	mValueTypes[2] = false;
	mValueTypes[3] = false;
	mRecursiveDescentParser = new RDP();
}

/**************************************************************
* LexicalAnalyzer destructor -
*
* Purpose:
*	Deallocates the needed memory for a LexicalAnalyzer object.
*
**************************************************************/
LexicalAnalyzer::~LexicalAnalyzer()
{
	delete mRecursiveDescentParser;
}

	/**************************************************************
	* LoadLanguageDefinition( string fileName )
	*
	* Input:
	*	A filename to open.
	*
	* Output:
	*	Nothing is output, but running the AddLanguageItem does change 
	*	all member variables except mTokens.
	*
	* Purpose:
	*	Opens up a given file and runs the AddLanguageItem mutator on it.
	*	
	**************************************************************/
void LexicalAnalyzer::LoadLanguageDefinition( string fileName )
{
	ifstream file;	//file variable to open
	string line;	// a temporary variable for hold each line read from the file
	file.open( fileName );
	
	if ( file.is_open() )
	{
		while ( getline( file , line ) )
		{
			AddLanguageItem( line );
		}
		file.close();
		//sort all the keywords
		sort(mKeywords.begin(), mKeywords.end());
	}
	else
	{
		cout << "Unable to locate file: " << fileName << endl;
	}
}

/**************************************************************
* AddLanguageItem( string line)
*
* Input:
*	Line is any string of characters that represents a definition
*	of language.
*
*	eg.
*	operator %     //loads in % as an operator
*	operator *     //loads in * as an operator
*	float		   //enables the float primitive
*	integer		   //enables the integer primitive
*	
* Output:
*	No output is given but any member variable can change except
*	mTokens.
*
* Purpose:
*	Reads through a given line and adds it to the respective
*	defintion for a language. This mutator assumes every line
*	contains one definition, anything more will cause it to throw
*	out the line.
* 
**************************************************************/
void LexicalAnalyzer::AddLanguageItem( string line )
{
	int result = -1;
	string temp = "";
	

	//looking for a space in the line
	result = line.find_first_of( ' ' );
	
	//if there is no space in the line, it may be a primitive enable
	if ( result == -1 )
	{

		if ( line.compare( "long" ) == 0 )
		{
			//enabling longs
			mValueTypes[0] = true;
		} 
		else if ( line.compare( "float" ) == 0 )
		{
			//enabling floats
			mValueTypes[1] = true;
		}
		else if ( line.compare( "integer" ) == 0 )
		{
			//enabling integers
			mValueTypes[2] = true;
		}
		else if ( line.compare( "string" ) == 0 )
		{
			//enabling strings
			mValueTypes[3] = true;
		}
		else
		{
			cout << "Unable to read " << line << ", throwing out of language definition." << endl;
		}
	}
	else
	{
		// the line does contain a space

		//it may be an operator
		if ( line.substr( 0 , result ).compare( "operator" ) == 0 )
		{
			mOperators.push_back( line.substr( result + 1 , line.length() ) );
		}
		//it could be a keyword
		else if (line.substr( 0 , result ).compare("keyword") == 0)
		{
			mKeywords.push_back( line.substr( result + 1, line.length() ) );
		}
		//it could be a preprocessor
		else if (line.substr( 0 , result ).compare("pp") == 0)
		{
			mPreProcessors.push_back( line.substr( result + 1, line.length() ) );
		}
		//it could be a symbol
		else if ( line.substr( 0 , result ).compare("symbol") == 0)
		{
			mSymbols.push_back( line.substr( result + 1 , line.length() ) );
		}
		//it could be a conditional
		else if ( line.substr( 0, result ).compare( "cond" ) == 0 )
		{
			mConditionals.push_back( line.substr( result + 1, line.length() ) );
		}
		else
		{
			//it's not recognizable
			cout << "Unable to read " << line << ", throwing out from language definition." << endl;
		}

	}

}

/**************************************************************
* PrintResults
*
* Input:
*	No direct inputs are given, however this is the last step
*	of four phase process.  It's assumed that LoadLanguageDefinition
*	LoadInputFile, and Tokenize have been run so their altered 
*	member variables should contain data.
*
* Output:
*	Outputs each token along with it's matched type.
*	eg + : Operator
*
* Purpose:
*	This method outputs each token along with it is matched type.
*	If no matched type is found then illegal token is output as 
*	it's type.
*
**************************************************************/
void LexicalAnalyzer::IdentifyTokens()
{
	//At this point we should have a stack of tokens that need describing

	for (int a = 0; a < mTokens.size(); a++)
	{
		if (mTokens[a].type.compare("") == 0)
		{

			//currently we are skipping tabs and spaces as part of the print out 
			if (mTokens[a].value.compare(" ") != 0 && mTokens[a].value.compare("\t") != 0)
			{

				//check and see if it's an operator
				if (CheckOperator(mTokens[a].value) == true)
				{
					mTokens[a].type = mTokens[a].value;
				}
				//if it's not an operator it maybe a conditional
				else if (CheckConditional(mTokens[a].value) == true)
				{
					mTokens[a].type = "conditional";
				}
				//if it's not a conditional, or operator, it maybe a symbol
				else if (CheckSymbol(mTokens[a].value) == true)
				{
					mTokens[a].type = mTokens[a].value;
				}
				//if it's not a symbol, conditional, or operator maybe it's a keyword
				else if (CheckKeyword(mTokens[a].value) == true)
				{
					mTokens[a].type = mTokens[a].value;
				}
				else
				{
					//it's a number, identifier, or unknown

					if (isdigit(mTokens[a].value[0]) != false)
					{
						//the first character is a number, assuming C rules if the rest is not a number than it is an invalid identifier.

						//check for decimal point
						int result = -1;
						result = mTokens[a].value.find('.');
						if (result != -1)
						{
							//possibly a float
							try{
								float tempResult = stof(mTokens[a].value);
								mTokens[a].type = "num";
							}
							catch (exception e)
							{
								cout << mTokens[a].value << " : Illegal token" << endl;
							}
						}
						else
						{
							//possibly an int, long, or unknown
							//max int value = 2147483647 unfortunately long has the same max value 

							try
							{
								long tempResult = stoi(mTokens[a].value);
								mTokens[a].type = "num";
							}
							catch (exception e)
							{
								cout << mTokens[a].value << " : Illegal token" << endl;
							}

						}
					}
					else
					{
						//an identifier or unknown

						if (mTokens[a].value[0] == '>' || mTokens[a].value[0] == '<')
						{
							cout << mTokens[a].value << " : Illegal token" << endl;;

						}
						else
						{
							//check symbol table to see if it is a constant that has already been defined
							if (mSymbolTable.Search(mTokens[a].value) == false){
								mTokens[a].type = "id";
							}
							else
							{
								//Currently this could replace any identifier with #define constant
								mTokens[a].type = mSymbolTable.GetType(mTokens[a].value);
								mTokens[a].value = mSymbolTable.GetValue(mTokens[a].value);
								
							}
						}

					}

				}

			}
			else
			{
				//whitespace is pushed to the token stack
				mTokens[a].type = "whitespace";
			}

		}
	}


}

/**************************************************************
* Tokenize
*
* Input:
*	No direct input is given, however for this mutator to run,
*	LoadLanguageDefinition and LoadInputFile should have 
*	successfully loaded data into their respective vectors.
*
* Output:
*	No direct output is given, however this mutator populates
*	the mtokens vector.
*
* Purpose:
*	Takes a vector lines and splits into individual tokens. The
*	tokens are then loaded into a vector of tokens.
*
**************************************************************/
void LexicalAnalyzer::Tokenize()
{
	
	int leftIndex, rightIndex;  //positions representing the left and right postion of the current line	
	
	bool found = false;		//found is flag that represents whether the current substring was matched with some language item
	bool finished = false;	//finished is flag that represents whether the current line has been completely tokenized
	TokenItem temp, temp1;

	//split each statement by spaces, symbols, and conditionals
	for ( auto line: mFileLines )
	{
		temp.value = "";
		temp.type = "";
		temp1.type = "";
		temp1.value = "";
		//starting with the first character
		leftIndex = 0;
		rightIndex = 1;

		//setting the needed flags
		finished = false;
		found = false;
		
		//check to see if the line is a preprocessor
		if (CheckPreprocessor(line))
		{

			//split the line and add it to the symbol table
			if (line.substr(0, 8).compare("#define ") == 0)
			{
				//#define
				//#define PI 3.145
				//everything after #define needs to be split and added to the symbol table
				
				int space = line.substr(8, line.size() - 8).find(' ');
				string name = line.substr(8, space);
				//may fail
				if (name.compare("") == 0 || name.compare(" ") == 0)
				{
					cout << "Unreadable #define throwing out: " << line << endl;
				}
				else
				{
					if (space == -1)
					{
						//symbol without a value
						mSymbolTable.Insert(name, "", "constant", "", 0);
					}
					else
					{
						//symbol with a value
						string value = line.substr(9 + space, line.size());
						string type = "num";
						mSymbolTable.Insert(name, type, "constant", value, 0);
					}
				}
			}
			else
			{
				temp.value = line;
				temp.type = "preprocessor";
				mTokens.push_back(temp);
			}
			finished = true;
		}

		// keep looping until the line has been consumed.
		while ( finished == false )
		{
			temp.value = "";
			temp.type = "";
			temp1.type = "";
			temp1.value = "";

			//tabs and spaces should be treated the same for the most part
			if ( line.substr( rightIndex - 1 , 1 ).compare( " " ) == 0 || line.substr( rightIndex - 1, 1).compare( "\t" ) == 0)
			{
				//Check to see if there is still some part of a line left and push it
				if (rightIndex - leftIndex > 1)
				{
					//whatever is next to the space is either an identifier or a number
					temp.value = line.substr(leftIndex, rightIndex - leftIndex - 1);
					mTokens.push_back( temp );
					temp1.value = line.substr(rightIndex - 1, rightIndex - (rightIndex - 1));
					mTokens.push_back(temp1);
					leftIndex = rightIndex;
					found = true;
				}
				else
				{
					//A space is found, push it to the tokens
					temp.value = line.substr(leftIndex, rightIndex - leftIndex);
					mTokens.push_back( temp );
					leftIndex = rightIndex;
					found = true;
				}
			}
			else
			{

				if (rightIndex - leftIndex == 1)
				{
					//A one character conditional
					found = CheckConditional( line.substr( leftIndex , rightIndex - leftIndex ) );
					if ( found == false )
					{
						//A two character conditional
						found = CheckConditional( line.substr( leftIndex , rightIndex + 1 - leftIndex ) );
						if ( found == true )
						{
							temp.value = line.substr( leftIndex, rightIndex + 1 - leftIndex );
							mTokens.push_back( temp );
							leftIndex = rightIndex+ 1;
							rightIndex = rightIndex + 1;
						}
					}
					else
					{
						//a one character conditional has been found, add it to the vector of tokens
						temp.value = line.substr(leftIndex, rightIndex - leftIndex);
						temp.type = "conditional";
						mTokens.push_back(temp);
						leftIndex = rightIndex;
					}

				}
				else
				{
					//dealing with a longer than two character string
					//take the last character and see if it's a conditional
					found = CheckConditional( line.substr( rightIndex, 1 ) );
					if ( found == false )
					{
						found = CheckConditional( line.substr( rightIndex, 2 ) );
						if (found == true)
						{
							//a two character conditional is found with additional data to left of it, pushing back into the list of tokens
							temp.value = line.substr(leftIndex, rightIndex - leftIndex);
							mTokens.push_back(temp);
							temp1.value = line.substr(rightIndex, 2);
							mTokens.push_back(temp1);
							
							leftIndex = rightIndex + 2;
							rightIndex = rightIndex + 2;
						}
					}
					else
					{
						//Just a one character conditional is found pushing into the vector of tokens
						temp.value = line.substr(leftIndex, rightIndex - leftIndex);
						mTokens.push_back(temp);
						temp1.value = line.substr(rightIndex, 1);
						mTokens.push_back(temp1);
						leftIndex = rightIndex+1;				
					}
				}

				if ( found == false )
				{
					found = CheckOperator( line.substr( rightIndex - 1 , rightIndex - ( rightIndex - 1 ) ) );
					if ( found == false )
					{
						found = CheckSymbol( line.substr( rightIndex - 1 , rightIndex - ( rightIndex - 1) ) );
						if ( found != false )
						{
							//A symbol is found, push it to the tokens
							if ( rightIndex - leftIndex > 1 )
							{
								//whatever is next to the space is either an identifier or a number
								temp.value = line.substr(leftIndex, rightIndex - leftIndex - 1);
								mTokens.push_back(temp);
								temp1.value = line.substr(rightIndex - 1, 1);
								mTokens.push_back(temp1);
								leftIndex = rightIndex;
							}
							else
							{
								//just a symbol is found pushing it back to the list tokens
								temp.value = line.substr(leftIndex, rightIndex - leftIndex);
								temp.type = line.substr(leftIndex, rightIndex - leftIndex);
								mTokens.push_back( temp);
								leftIndex = rightIndex;
							}
						}
					}
					else
					{
						if ( rightIndex - leftIndex > 1 )
						{
							//whatever is next to the operator is either an identifier or a number
							temp.value = line.substr(leftIndex, rightIndex - leftIndex - 1);
							mTokens.push_back(temp);
							temp1.value = line.substr(rightIndex - 1, 1);
							mTokens.push_back(temp1);
							leftIndex = rightIndex;
						}
						else
						{
							//A operator is found, push it to the tokens
							temp.value = line.substr(leftIndex, rightIndex - leftIndex);
							temp.type = line.substr(leftIndex, rightIndex - leftIndex);
							mTokens.push_back(temp);
							leftIndex = rightIndex;
						}
					}
				}
			}

			if ( rightIndex == line.length() )
			{
				//we have reached the end of the line, we will assume each line is symbol terminated
				//with the exception of a main or function block
				if (line.substr(leftIndex, rightIndex).compare("main") == 0)
				{
					temp.value = line.substr(leftIndex, rightIndex );
					temp.type = line.substr(leftIndex, rightIndex );
					mTokens.push_back(temp);
				}
				finished = true;
			}
			else
			{
				//resetting the found flag and increasing the right index by 1
				found = false;
				rightIndex++;
			}
			
		}
	}
 }

/**************************************************************
* CheckConditional( string section ) const
*
* Input:
*	A section of text that may have a conditional
*
* Output:
*	True - if the section is a conditional
*	False - if the section is not a conditional
*
* Purpose:
*	Checks to see if a section is a conditional or not.
*
**************************************************************/
bool LexicalAnalyzer::CheckConditional( string section ) const
{ 
	for ( auto cond : mConditionals )
	{
		if ( section.compare( cond ) == 0 )
		{
			return true;
		}
	}
	return false;
}

/**************************************************************
* CheckOperator( string section ) const
*
* Input:
*	A string called section that may have an operator.
*
* Output:
*	True - if the the section is an operator.
*	False - if the section is not an operator.
*
* Purpose:
*	Checks a section of text to see if it is an operator not.
*
**************************************************************/
bool LexicalAnalyzer::CheckOperator( string section ) const
{
	
	for ( auto op : mOperators )
	{
		if ( op.compare( section ) == 0 )
		{
			//found a symbol
			return true;
		}
	}

	return false;
}

/**************************************************************
* CheckSymbol( string section ) const
*
* Input: 
*	A string called section that represents a suspected symbol
*
* Output:
*	True - if the section is a symbol
*	False - if the section is not a symbol
*
* Purpose:
*	Checks a given string to see if it a loaded symbol or not.
*	Warning!! - This method will always return false if no
*	symbols exist in the language definition file.
*
**************************************************************/
bool LexicalAnalyzer::CheckSymbol( string section ) const
{
	for ( auto symbol : mSymbols )
	{
		if ( symbol.compare( section ) == 0 )
		{
			//found a symbol

			return true;
		}
	}

	return false;
}

/**************************************************************
* CheckSymbol( string section ) const
*
* Input:
*	A string called section that represents a suspected keyword
*
* Output:
*	True - if the section is a keyword
*	False - if the section is not a keyword
*
* Purpose:
*	Checks a given string to see if it a loaded keyword or not.
*	Warning!! - This method will always return false if no
*	keywords exist in the language definition file.
*
**************************************************************/
bool LexicalAnalyzer::CheckKeyword(string section) const
{
	for (auto keyword : mKeywords)
	{
		if (keyword.compare(section) == 0)
		{
			//found a symbol

			return true;
		}
	}

	return false;
}
/**************************************************************
* LoadInputFile( string section ) const
*
* Input:
*	A string that represents the file to be loaded.
*
* Output:
*	Nothing directly is output, but the mFileLines variable may change.
* 
* Purpose:
*	Opens a file and loads it's line into the mFileLines vector
*
**************************************************************/
void LexicalAnalyzer::LoadInputFile( string fileName )
{
	ifstream file;  //used to help open a file
	string line;	//a temporary place to copy lines from the file

	//opening the file
	file.open( fileName );

	if ( file.is_open() )
	{
		while ( getline( file , line) )
		{
			//empty lines and comments don't need to be tokenized
			if ( line.substr( 0, 2 ).compare( "//" ) != 0 && line.empty() == false )
			{
				mFileLines.push_back( line );
			}
		}

		//closing the file
		file.close();
	}
}


/**************************************************************
* PrintTokens()
*
* Input:
*	A list of tokens in mTokens
*
* Output:
*	Outputs each token and it's identified type to the screen
*
* Purpose:
*	Prints each toke and it's type to the screen. This mainly
*	used for debugging the identification process.
*
**************************************************************/
void LexicalAnalyzer::PrintTokens()
{

	for (auto token : mTokens)
	{
		if (token.type.compare("whitespace") != 0)
		{
			cout << token.value << " : " << token.type << endl;
		}
	}
}

/**************************************************************
* CheckPreprocessor(string line) const
*
* Input:
*	any string suspected of starting with a preprocessor 
*
* Output:
*	a boolean value that is true if found and false if not found
*
* Purpose:
*	To check if a line starts with a pre processor or not.
*
**************************************************************/
bool LexicalAnalyzer::CheckPreprocessor(string line) const
{
	for (auto pp : mPreProcessors)
	{
		if (line.substr(0, pp.length()).compare(pp) == 0)
		{
			return true;
		}
	}
	return false;
}

void LexicalAnalyzer::RDP_Parse()
{
	vector<string> values;
	vector<string> types;

	for (auto Token : mTokens)
	{
		if (Token.type != "whitespace" && Token.type != "preprocessor")
		{
			values.push_back(Token.value);
			types.push_back(Token.type);
		}
	}
	RDP Test(values, types, mSymbolTable);
	int result = Test.Parse();
	cout << result << " blocks found." << endl;
	cout << Test.GetSymbolCount()<< " symbol entries created." << endl;
}

/**************************************************************
* GetType(string section) const
*
* Input:
*	any string which may contain a type
*
* Output:
*	a string that contains the word float, integer, or string depeneding
*	on the detected type.
*
* Purpose:
*	To check if a suspected string contains a integer, float, or string.
*
**************************************************************/
string LexicalAnalyzer::GetType(string section) const
{
	int result = -1;
	result = section.find('.');
	if (result != -1)
	{
		//possibly a float
		try{
			float tempResult = stof(section);
			return "float";
		}
		catch (exception e)
		{
			return "string";
		}
	}
	else
	{
		//possibly an integer

		try
		{
			long tempResult = stoi(section);
			return "integer";
		}
		catch (exception e)
		{
			return "string";
		}

	}

}