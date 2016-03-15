/***********************************************************
* Author:					James Shaver
* Date Created:				12/3/2015
* Last Modification Date:	2/22/2016
* Lab Number:				CST 320 Lab 2b
* Filename:					LexicalAnalyzer-Tester.cpp
*
* Overview:
*	The purpose of this program is to create three lexical analyzers and load three different files.  After the files have been read,
*	the program then outputs the blocks found and the number of symbol entries. 
*
* Input:
*	Four files:
*	1. preschool-language.txt - a file describing my custom language
*	2. small.txt - a file using my custom language.
*	3. medium.txt - a file using my custom language.
*	4. large.txt - a file using my custom language.
*
* Output:
*	Tokens from the file are displayed on the screen along with their identified type.
*
***********************************************************/
	
#include <iostream>
#include "LexicalAnalyzer.h"
#include <stdlib.h>

int main()
{
	LexicalAnalyzer lexA, lexB, lexC;  //Three LexicalAnalyzers that will be used to load three example language files.
	std::cout << "Lexical Analyzer - reads in three different files sharing a unique langauge and describes it's tokens." << std::endl;

	//Loading in language definitions to each LexicalAnalyzer
	lexA.LoadLanguageDefinition( "preschool-language.txt" );
	lexB.LoadLanguageDefinition( "preschool-language.txt" );
	lexC.LoadLanguageDefinition( "preschool-language.txt" );

	//Loading in the first file
	std::cout << std::endl;
	lexA.LoadInputFile( "small.txt" );
	//Splitting it into tokens
	lexA.Tokenize();
	std::cout << "small.txt results:" << std::endl;
	//Matching each token with a specific type and printing out the results
	lexA.IdentifyTokens();
	//lexA.PrintTokens();
	lexA.RDP_Parse();
	system( "pause" );

	std::cout << std::endl;
	
	//Loading in the second file
	lexB.LoadInputFile( "medium.txt" );
	//Splitting it into tokens
	lexB.Tokenize();
	std::cout << "medium.txt results:" << std::endl;
	//Matching each token with a specific type and printing out the results
	lexB.IdentifyTokens();
	//lexB.PrintTokens();
	lexB.RDP_Parse();
	system( "pause" );

	std::cout << std::endl;

	//Loading in the third file
	lexC.LoadInputFile( "large.txt" );
	//Splitting it into tokens
	std::cout << "large.txt results:" << std::endl;
	lexC.Tokenize();

	//Matching each token with a specific type and printing out the results
	lexC.IdentifyTokens();
	//lexC.PrintTokens();
	lexC.RDP_Parse();

	//A system pause, allowing users to see the information and then press a key to close the program.
	system( "pause" );
}