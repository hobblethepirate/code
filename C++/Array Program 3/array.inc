

//
//
// James Shaver
//
//
// File: array.cpp
//
// This file contains the implementation of the
// Array class and the SafeArray class.
//


#include  <stdlib.h>
#include  <iostream>
#include  "array.h"



//
// Array construtor
//
template <class ELEMENT_TYPE>
Array<ELEMENT_TYPE>::Array( Index  upperBound, Index  lowerBound )  :
  m_numElements( upperBound - lowerBound + 1 ),
  m_lowerBound( lowerBound ),
  m_values( new  ELEMENT_TYPE[m_numElements] )
{
  if  (! m_values)
  {
	  throw ERR_MEM_ALLOC;
  }
  if (upperBound < lowerBound)
  {
	  throw ERR_BAD_BOUNDS;
  }
}


//
// Array destructor
//
template <class ELEMENT_TYPE>
Array<ELEMENT_TYPE>::~Array()
{
	if (m_refCounter.onlyInstance())
		delete[] m_values;
}

//
// Array::operator[]
//
// Returns the specified index value or sets the specific index value to a given value.
// Intended to replace the get, set, and at member functions from assignment 3. 
// Array indexing supports both const and non-const accesses.
//
template <class ELEMENT_TYPE>
ELEMENT_TYPE& Array<ELEMENT_TYPE>::operator[] (const Index index)
{
	return  m_values[realIndex(index)];
}

template <class ELEMENT_TYPE>
ELEMENT_TYPE& Array<ELEMENT_TYPE>::operator[] (const Index index) const
{
	return  m_values[realIndex(index)];
}

//
// Array::operator=
//
// Sets the current array's m_data to reference rhs' m_data, and set 
// the other array member values to match rhs' values. If m_data has only 
// one existing instance it is deleted.
//
template <class ELEMENT_TYPE>
Array<ELEMENT_TYPE>& Array<ELEMENT_TYPE>::operator=( Array<ELEMENT_TYPE>& rhs)
{
	if (m_refCounter.onlyInstance())
		delete[] m_values;
	m_lowerBound = rhs.m_lowerBound;
	m_numElements = rhs.m_numElements;
	m_values = rhs.m_values;
	m_refCounter = rhs.m_refCounter;
	return *this;
}

//
// SafeArray constructor
//
template <class ELEMENT_TYPE>
SafeArray<ELEMENT_TYPE>::SafeArray( Index  upperBound, Index  lowerBound )  :
  Array( upperBound, lowerBound )
{
}

//
// SafeArray::operator[]
//
// Similar to the Array []operator method with the exception of bounds checking.
//

template <class ELEMENT_TYPE>
ELEMENT_TYPE& SafeArray<ELEMENT_TYPE>::operator[] (const Index index)
{
	validateIndex(index);
	return Array::operator[] (index);
}

//
// SafeArray::validateIndex()
//
// Verifies an index value is within the valid range.
//
template <class ELEMENT_TYPE>
void  SafeArray<ELEMENT_TYPE>::validateIndex(Index  index)  const	
{
  if  ( index  <  lowerBound()  ||
        index  >  upperBound() )
  {
	  throw ERR_OUT_OF_BOUNDS;
  }
}
