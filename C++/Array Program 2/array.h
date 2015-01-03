
// James Shaver
//
//
// File: array.h
//
// This file contains the class declarations for an
// Array class and a SafeArray class.
//


#ifndef  array_H
#define  array_H

#include "refCounter.h"

/*
* Constraints for the TYPE datatype for the Array<> template class:
*
*   - TYPE must support the use of a default constructor.
*   - TYPE must support the use of a copy constructor (sometimes user defined to work properly)
*   - For copying the new type must match existing type ( ex Array<float> b = c; (c must be of type float). 
*	- Similary for copying data from an existing array to an existing array their types must match. 
*	  (ex a = b; (Array a type must equal the Array b type)
*/
template<class ELEMENT_TYPE>
class  Array
{
  public  :

    typedef  int  Index;


    Array( Index  upperBound, Index  lowerBound = 0 );
    ~Array();

    void  set( Index  index, const ELEMENT_TYPE  &value )  const;

    ELEMENT_TYPE  get( Index  index )  const;
	
	ELEMENT_TYPE& at(Index index);
	

    Index  lowerBound()  const  { return  m_lowerBound; }
    Index  upperBound()  const  { return  m_lowerBound + m_numElements - 1; }

	
    unsigned  numElements()  const  { return  m_numElements; }
    unsigned  size()  const         { return  m_numElements * sizeof(ELEMENT_TYPE); }

  private  :

    const unsigned int  m_numElements;
    const Index         m_lowerBound;

    ELEMENT_TYPE  *m_values;

    Index  realIndex(Index  index)  const  { return  index - m_lowerBound; }
	RefCounter     m_refCounter;
};


/*
* Constraints for the TYPE datatype for the SafeArray<> template class:
*
*   - TYPE must support the use of a default constructor.
*   - TYPE must support the use of a copy constructor (sometimes user defined to work properly)
*   - For copying the new type must match existing type ( ex SafeArray<float> b = c; (c must be of type float).
*	- Similary for copying data from an existing SafeArray to an existing SafeArray their types must match.
*	  (ex a = b; (Array a type must equal the Array b type)
*
*/
template<class ELEMENT_TYPE>
class  SafeArray  :  public Array<ELEMENT_TYPE>
{
  public  :

    SafeArray( Index  upperBound, Index  lowerBound = 0 );

    void  set( Index  index, const ELEMENT_TYPE  &value );

    ELEMENT_TYPE  get( Index  index )  const;
	ELEMENT_TYPE& at(Index index);

  private  :

    void  validateIndex( Index  index )  const;
};

#include "array.inc"
#endif
