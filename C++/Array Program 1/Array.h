
//
// Author      :  James Shaver
//
// File        :  Array.h

typedef  int  ELEMENT_TYPE;

#ifndef  Array_H
#define  Array_H


//Array - a class that provides the same type of fuctionality as
//built - in arrays, but it allows for specifying lower
//and upper bound index values and uses dynamic memory.
class Array
{
public:

	//Constructors
	Array(int lwr, 
		  int uppr);

	Array(int uppr);

	Array(const Array &copy);

	//Destructor
	~Array();

	//Methods
	void set(int index, ELEMENT_TYPE input);
	ELEMENT_TYPE get(int index);
	int lowerBound() const;
	int upperBound() const;
	int numElements() const;
	int size() const;
	
private:

	//Private member variables
	int mUpper;
	int mLower;
	ELEMENT_TYPE *mData;

	//Helper method
	void boundsMemoryCheck() const;
};


#endif

#ifndef  SafeArray_H
#define  SafeArray_H

//SafeArray - same functionality as Array but adds the additional
//behavior of index bounds checking.
class SafeArray
{
public:

	//Constructors
	SafeArray(int lwr,
		int uppr);

	SafeArray(int uppr);

	SafeArray(const SafeArray &copy);

	//Methods
	int lowerBound() const;
	int upperBound() const;
	int numElements() const;
	int size() const;
	void set(int index, ELEMENT_TYPE value);
	ELEMENT_TYPE get(int index);

private:

	//member variable
	Array mArray;

	//Helper method
	void boundsCheck(int index) const;
};

#endif