
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
    std::cerr  <<  "Error allocating memory!"  <<  std::endl;
    exit( EXIT_FAILURE );
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
// Array::set()
//
// Sets an element value at a specific index position within
// the array. Bounds checking is not performed.
//
template <class ELEMENT_TYPE>
void  Array<ELEMENT_TYPE>::set(Index  index, const ELEMENT_TYPE  &value)  const
{
  m_values[realIndex(index)]  =  value;
}


//
// Array::get()
//
// Fetches an element value from a specific index position within
// the array. Bounds checking is not performed.
//
template <class ELEMENT_TYPE>
ELEMENT_TYPE  Array<ELEMENT_TYPE>::get( Index  index )  const
{
  return  m_values[realIndex(index)];;
}

//
//Array::at(Index index)
//
//Fetches an element at a specified index and returns a reference to it.
//
template <class ELEMENT_TYPE>
ELEMENT_TYPE& Array<ELEMENT_TYPE>::at(Index index)
{
	return  m_values[realIndex(index)];
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
// SafeArray::set()
//
// Sets an element value at a specific index position within
// the array. Bounds checking is performed.
//
template <class ELEMENT_TYPE>
void  SafeArray<ELEMENT_TYPE>::set( Index  index, const ELEMENT_TYPE  &value )
{
  validateIndex( index );

  Array::set(index, value);
}


//
// SafeArray::get()
//
// Fetches an element value from a specific index position within
// the array. Bounds checking is performed.
//
template <class ELEMENT_TYPE>
ELEMENT_TYPE  SafeArray<ELEMENT_TYPE>::get(Index  index)  const
{
  validateIndex( index );

  return  Array::get(index);
}
//
//SafeArray::at(Index index)
//
//Fetches an element at a specified index and returns a reference to it. An additional check is done to make sure the 
//the index is within the given bounds.
//
template <class ELEMENT_TYPE>
ELEMENT_TYPE& SafeArray<ELEMENT_TYPE>::at(Index index)
{
	validateIndex(index);
	return Array::at(index);
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
    std::cerr  <<  "Index out of range"  <<  std::endl;

    exit( EXIT_FAILURE);
  }
}
