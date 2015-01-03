
//
//
// James Shaver
//
//
// File: array.h
//
// This file contains the class declarations for an
// Array class and a SafeArray class.
//

#define  ERR_BAD_BOUNDS     1
#define  ERR_MEM_ALLOC      2
#define  ERR_OUT_OF_BOUNDS  3

#ifndef  array_H
#define  array_H

#include "refCounter.h"

/*
* Constraints for the TYPE datatype for the Array<> template class:
*
*   - TYPE must support the use of a default constructor.
*   - TYPE must support the use of a copy.
*   - TYPE must support the use of assignment.
*
*/
template<class ELEMENT_TYPE>
class  Array
{
  public  :

    typedef  int  Index;

    Array( Index  upperBound, Index  lowerBound = 0 );

    ~Array();

	Array<ELEMENT_TYPE>& operator=( Array<ELEMENT_TYPE>& rhs);

	ELEMENT_TYPE& operator[] (const Index index);
	ELEMENT_TYPE& operator[] (const Index index) const;

    Index  lowerBound()  const  { return  m_lowerBound; }
    Index  upperBound()  const  { return  m_lowerBound + m_numElements - 1; }
	
    unsigned  numElements()  const  { return  m_numElements; }
    unsigned  size()  const         { return  m_numElements * sizeof(ELEMENT_TYPE); }

  private  :

    unsigned int  m_numElements;
    Index         m_lowerBound;

    ELEMENT_TYPE  *m_values;

    Index  realIndex(Index  index)  const  { return  index - m_lowerBound; }
	RefCounter     m_refCounter;
};


/*
* Constraints for the TYPE datatype for the SafeArray<> template class:
*
*   - TYPE must support the use of a default constructor.
*   - TYPE must support the use of a copy.
*   - TYPE must support assignment.
*
*/
template<class ELEMENT_TYPE>
class  SafeArray  :  public Array<ELEMENT_TYPE>
{
  public  :

    SafeArray( Index  upperBound, Index  lowerBound = 0 );
	ELEMENT_TYPE& operator[] (const Index index);
   
  private  :

    void  validateIndex( Index  index )  const;
};

#include "array.inc"
#endif
