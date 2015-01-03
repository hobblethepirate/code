
//
//
// James Shaver
//
//
// File: refCounter.cpp
//
// This file contains the member function bodies for the
// reference counter class.
//


#include  <iostream>
#include  "refCounter.h"

using namespace std;


//
// Constructor
//
RefCounter::RefCounter()  :  m_cnt(new int(1))
{
  if  (! m_cnt)
  {
    cerr  <<  "Memory allocation error!"  <<  endl;
    exit(EXIT_FAILURE);
  }
}


//
// Copy constructor
//
RefCounter::RefCounter(const RefCounter  &rhs) :
  m_cnt(rhs.m_cnt)
{
  (*m_cnt)++;
}

//
// RefCounter::operator=
//
// Decrements or deletes the prior m_cnt depending on the
// number of instances. Sets m_cnt to reference rhs.m_cnt.
// Increments the new m_cnt.
//
RefCounter& RefCounter::operator=(const RefCounter& rhs)
{
	if (!--(*m_cnt))
		delete m_cnt;
	m_cnt = rhs.m_cnt;
	(*m_cnt)++;

	return *this;
}

//
// Destructor
//
RefCounter::~RefCounter()
{	
  if  ( ! --(*m_cnt) )
    delete m_cnt;
 }
