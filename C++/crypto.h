
//
//
// James Shaver
//
// File: crypto.h
//
// This header file contains the declarations for the crypto, substitution, and casear classes.
// Substitution and Caesar inherit from the crypto class.
//

#ifndef crypto_h
#define crypto_h

#include "range.h"
#include <string>

using namespace std;

//
// Crypto - an abstract base class that provides a common
// polymorphic interface to the derived classes
// and contains data / functionality shared by
// all the derivatives.
//
class Crypto
{

public:
	
	Crypto(string phrase, Range range) :m_phrase(phrase),
										m_range(range){}
	virtual void decrypt(){}
	virtual void encrypt(){}
	string phrase(){ return m_phrase; }

protected:

	string m_phrase;
	Range m_range;
};

//	
// Caesar - a derivation of Crypto that provides encryption
// and decryption functionality using the Caesar
// cryptography algorithm.
//
class Caesar : public Crypto
{

public:
	
	Caesar ( string phrase, int key, Range range );
	void decrypt();
	void encrypt();

private:

	int normalizeKey(int  origKey);
	int m_key;

};

//
// Substitution - a derivation of Crypto that provides
// encryption and decryption functionality
// using the substibution  cryptography algorithm.
//
class Substitution : public Crypto
{

public:
	
	Substitution(string phrase, string key, Range range);
	void decrypt() ;
	void encrypt();

private:

	int findIndexOf(const string  str, char  c);
	string m_key;

};
#endif

