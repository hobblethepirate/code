

// Author      :  James Shaver
//
// File        :  Array.cpp

#include "Array.h"
#include <iostream>

//normal lower & upper bounds constructor
Array::Array(int uppr, int lwr) : mLower(lwr), mUpper(uppr), mData(new ELEMENT_TYPE[abs(uppr-lwr)])
{
	boundsMemoryCheck();	
}

//no lower bounds constructor
Array::Array(int uppr) : mLower(0), mUpper(uppr), mData(new ELEMENT_TYPE[abs(uppr)])
{
	boundsMemoryCheck();
}

//deep copy constructor
Array::Array(const Array &copy) : mLower(copy.mLower), mUpper(copy.mUpper), mData(new ELEMENT_TYPE[abs(copy.mUpper-copy.mLower)])
{
	boundsMemoryCheck();
	for (int ctr = copy.mLower; ctr <= copy.mUpper; ctr++)
	{
		mData[ctr] = copy.mData[ctr];
	}
	
}

//set -
//function that will allow the caller to place an element value at a
//specific index position in the array.
void Array::set(int index, ELEMENT_TYPE input)
{
	mData[index-mLower]= input;
}

//get - 
//function that will allow the caller to fetch an element value from a
//specific index position within the array.
ELEMENT_TYPE Array::get(int index)
{
	return mData[index-mLower];
}

//lowerBound - 
//function which returns the index for of the lower bound
//for the array.
int Array::lowerBound() const	
{
	return mLower;
}

//upperBound - 
//function which returns the index of the upper bound
//for the array.
int Array::upperBound() const
{
	return mUpper;
}

//numElements - 
//function which returns the number of elements the array
//can hold.
int Array::numElements() const
{
	return abs(mUpper - mLower);
}

//size -
//function which returns the number of bytes that were allocated
//to hold all the elements.
int Array::size() const
{
	return sizeof(ELEMENT_TYPE)* numElements();
}

//boundsCheck - 
//private function which checks two integers to see if they provide an array of size 1 or greater. 
//If improper bounds are given an error message is displayed and the program using the array closes.
void Array::boundsMemoryCheck() const
{
   if (!mData)
	{
		std::cout << "Not enough memory available for the given array size. Closing Program" << std::endl;
		exit(EXIT_FAILURE);
   }
   else if (mUpper < mLower)
   {
	   std::cout << "Upper bound is greater than the lower bound given for the array. Closing Program" << std::endl;
	   exit(EXIT_FAILURE);
   }
}

//destructor
Array::~Array()
{
	delete[]  mData;
}