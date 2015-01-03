
//
//
// James Shaver
//
// File: crypto.cpp
//
// Encryption and decryption routines for the caesar and substitution
// algorithms.
//


#include  <string.h>
#include  <math.h>
#include "crypto.h"


#define  NOT_FOUND  (-1)

//
// Substituion Constructor
//
Substitution::Substitution(string phrase, string key, Range range) :Crypto(phrase, range), m_key(key)
{
}

//
// Substitution::decrypt() - decrypts the current phrase into plain readable text.
//
void Substitution::decrypt()
{
	size_t  srcIdx;

	string dest = m_phrase;

	//
	// Process each character
	//
	for (srcIdx = 0; srcIdx < m_phrase.length(); ++srcIdx)
	{
		//
		// Determine the index of the ciphertext character within the
		// key
		//
		int  keyIdx = findIndexOf(m_key, m_phrase[srcIdx]);


		//
		// If the key index was not found, the plaintext character is
		// the ciphertext character. Otherwise, use the key index
		// as the alphabet offset to determine the plaintext character.
		//
		if (keyIdx == NOT_FOUND)
			dest[srcIdx] = m_phrase[srcIdx];
		else
			dest[srcIdx] = m_range.min() + keyIdx;
			
	}

	dest[srcIdx] = 0;
	m_phrase = dest;
}

//
// Substitution::encrypt() - this algorithm replaces characters
// with key characters to encrypt and vice - versa to decrypt.The key for
// this algorithm is a string of unique characters in range of valid
// characters.
//
void Substitution::encrypt()
{
	size_t  srcIdx;
	string dest = m_phrase;

	//
	// Process each character
	//
	for (srcIdx = 0; srcIdx < m_phrase.length(); ++srcIdx)
	{
		//
		// If the plaintext character is in range, then the plaintext
		// character number as the index into the key string to find
		// the cipher character. Otherwise, the ciphertext character
		// is the plaintext character.
		//
		if (!((m_phrase[srcIdx]) < m_range.min() || (m_phrase[srcIdx]) > m_range.max()))
		{
			
			//
			// Determine the character number of the plaintext character
			//
			int  keyIdx = m_phrase[srcIdx] - m_range.min();

			dest[srcIdx] = m_key[keyIdx];
		}
		else
		{
			dest[srcIdx] = m_phrase[srcIdx];
		}
	}

	dest[srcIdx] = 0;
	m_phrase = dest;
}
//
// Returns the index of the first occurance of a character
// within a string. Returns NOT_FOUND if the character is
// not in the string.
//
int  Substitution::findIndexOf(const string  str, char  c)
{
	for (unsigned idx = 0; idx < str.length(); ++idx)
	{
		if (str[idx] == c)  return  idx;
	}

	return  NOT_FOUND;
}

//
// Caesar Constructor
//
Caesar::Caesar(string phrase, int key, Range range) :Crypto(phrase, range), m_key(key)
{
}

//
// Caesar::decrypt() - decrypts a caesar encrypted phrase into plain readable text.
//
void Caesar::decrypt()
{
	m_key = -m_key;
	encrypt();
}

// 
// Caesar::decrypt() - caesar encryption algorithm shifts the ASCII values
// of characters in a message. The key for this algorithm is an integer
// value that specifies the shift amount to use.
//
void Caesar::encrypt()
{
	string dest = m_phrase;
	m_key = normalizeKey(m_key);

	size_t  len = m_phrase.length();

	size_t  idx;

	//
	// Process each character
	//
	for (idx = 0; idx < len; ++idx)
	{
		//
		// Out of range characters are just transfered to
		// the ciphertext
		//
		if (((m_phrase[idx]) < m_range.min() || (m_phrase[idx]) > m_range.max()))
		{
			dest[idx] = m_phrase[idx];
			continue;
		}


		//
		// Determine the alphabet index of the plaintext character
		//
		char  c = m_phrase[idx] - m_range.min();


		//
		// Add the key to the alphabet index to get the ciphertext
		// character. Handle the wrap-around past the last valid
		// character.
		//
		c += m_key % m_range.numCharacters();
		c %= m_range.numCharacters();

		dest[idx] = c + m_range.min();
	}

	dest[idx] = 0;
	m_phrase = dest;
}

//
// Caesar::normalizeKey() - Convert the key value to number within the range
// of valid characters.
//
int  Caesar::normalizeKey( int  origKey )
{
  int  normKey  =  abs(origKey);

  normKey  %=  m_range.numCharacters();

  if (origKey < 0)
	  normKey = m_range.numCharacters() -normKey;

  return  normKey;
}
