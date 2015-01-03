
//
// Author      :  James Shaver
//
// File        :  SafeArray.cpp

#include "SafeArray.h"
#include <iostream>

//SafeArray - is a child of Array.h With the exception that all 
//indexing into the array(for reading or writing elements) will have
//bounds checking performed to ensure the index value is valid.Valid index
//values are greater - than - or - equal - to the lower bound AND less - than - or - equal - to
//the upper bound.

SafeArray::SafeArray(int uppr, int lwr) :mArray(uppr,lwr)
{

}

SafeArray::SafeArray(int uppr):mArray(uppr)
{

}

SafeArray::SafeArray(const SafeArray &copy) : mArray(copy.mArray)
{
	
}

int SafeArray::lowerBound() const
{
	return mArray.lowerBound();
}

int SafeArray::upperBound() const 
{
	return mArray.upperBound();
}

int SafeArray::numElements() const
{
	return mArray.numElements();
}

int SafeArray::size() const
{
	return mArray.size();
}
//set -
//A function that will still allow the caller to place an element at
//a specific index position in the array.If the index is out of range, the
//function should write an error message to the cout stream and terminate
//the program immediately.
void SafeArray::set(int index, ELEMENT_TYPE value)
{
	boundsCheck(index);
	mArray.set(index, value);
}
//get -
//This function will still allow the caller to fetch an element value
//from a specific index position within the array.If the array index is
//out of range, the function should write an error message to the cout
//stream and terminate the program immediately.
ELEMENT_TYPE SafeArray::get(int index)
{
	boundsCheck(index);
	return mArray.get(index);
}

//boundsCheck - 
//A helper method used to check on whether or not a given index is within the bounds of an array.
void SafeArray::boundsCheck(int index) const
{
	if (index >= mArray.upperBound() || index <= mArray.lowerBound())
	{
		std::cout << "Index out of bounds. Closing program" << std::endl;
		exit(EXIT_FAILURE);
	}
}