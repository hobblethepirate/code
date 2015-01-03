//
//
// James Shaver
//
//
// File: Complex.cpp
//
// This file contains the implementation of the Complex Number Class.
//

#include "Complex.h"
#include <iostream>

using namespace std;

//
//Complex Constructor
//
Complex::Complex(float real, float imaginary) :m_real(real), m_imaginary(imaginary)
{

}

//
//Complex::real()
//
//Fetches the real value for the complex equation.
//
float Complex::real() const{ return m_real; }

//
//Complex::imaginary()
//
//Fetches the imaginary value for the complex equation.
//
float Complex::imaginary() const { return m_imaginary; }


//Addition:
//(a + bi) + (c + di) = (a + c) + (b + d)i
Complex Complex::operator+(const Complex  &rhs) const
{
	return Complex((m_real+rhs.real()), (m_imaginary + rhs.imaginary()));
}

//Subtraction:
//(a + bi) - (c + di) = (a - c) + (b - d)i
Complex Complex::operator-(const Complex  &rhs) const
{
	return Complex((m_real - rhs.real()), (m_imaginary - rhs.imaginary()));
}

//Multiplication:
//	(a + bi)(c + di) = (ac - bd) + (ad + bc)i
Complex Complex::operator*(const Complex &rhs) const
{
	return Complex((m_real*rhs.m_real)- (m_imaginary*rhs.m_imaginary), ((m_real*rhs.imaginary())+(m_imaginary*rhs.m_real)));
}

//Division:
//(a + bi)     (ac + bd)   (bc - ad)i
//-------- = -------- - +----------
//(c + di)     (c2 + d2)   (c2 + d2)
//
//Note : c2 above means c squared
//	   d2 above means d square
Complex Complex::operator/(const Complex &rhs) const 
{
	float temp = ((m_imaginary*rhs.m_real) - (m_real*rhs.m_imaginary)) / ((rhs.m_real *rhs.m_real) + (rhs.m_imaginary*rhs.m_imaginary));
	return Complex((m_real*rhs.real() + m_imaginary*rhs.imaginary()) / (rhs.real()*rhs.real() + rhs.imaginary()*rhs.imaginary()),
				  temp);
}
//Negation operator - returns the negative version of the complex function
Complex Complex::operator-() const
{
	return Complex(-m_real, -m_imaginary);
}

//arthimetic assignment operators
void Complex::operator+=(const Complex &rhs)
{	
	*this = *this + rhs;
}
void Complex::operator-=(const Complex &rhs) 
{
	*this = *this - rhs;
}
void Complex::operator*=(const Complex &rhs) 
{
	*this = *this*rhs;
}
void Complex::operator/=(const Complex &rhs) 
{
	*this = *this / rhs;
}

//comparision operators
bool Complex::operator==(const Complex &rhs) const
{
	return m_real == rhs.real() && m_imaginary == rhs.imaginary();
}
bool Complex::operator!=(const Complex &rhs) const
{
	return !operator==(rhs);
}
bool Complex::operator<=(const Complex &rhs) const
{
	return operator<(rhs) || operator==(rhs);
}
bool Complex::operator<(const Complex &rhs) const
{
	return m_real < rhs.real() || m_real == rhs.real() && m_imaginary < rhs.imaginary();
}
bool Complex::operator>=(const Complex &rhs) const
{
	return operator>(rhs) || operator==(rhs);
}
bool Complex::operator>(const Complex &rhs) const
{
	return m_real > rhs.real() || m_real == rhs.real() && m_imaginary > rhs.imaginary();
}	

//Complex Stream Insertion
//------------------------
//
//Output of complex numbers should be in this format:
//
//a + bi
//
//Except for in these conditions :
//
//-if the real portion(a) is zero, then the real portion
//and the operator should not be displayed.This the only
//circumstance where the imaginary portion(b) could be displayed
//as negative.
//
//- if the imaginary portion(b) is zero, then only the
//real portion should be displayed.
//
//- if the imaginary portion(b) is one, then only "i"
//should be displayed, not b.
//
ostream& operator<<(ostream  &os, const Complex &rhs)
{
	float r = rhs.m_real;
	float i = rhs.m_imaginary;
	if (r != 0)
	{	
		os << r;
		if (i == 0){
			return os;
		}
	}
	if (i > 0 && i!=1)
	{
		if (r == 0)
		{
			return os << i << "i";
		}
		return os << " + " << i << "i";
	}
	else if (i <0 && i!=-1)
	{
		return os << " - " << abs(i) << "i";
	}
	else
	{
		if (i == 1)
		{
			if (r == 0)
			{
				return os << "i";
			}
			else
			{
				return os << " + i";
			}
		}
		else if (i == -1)
		{
			if (r == 0)
			{
				return os << "-i";
			}
			else
			{
				return os << " - i";
			}
		}
		else 
		{
			return os << 0;
		}
	}
}

//Stream Extraction Operator
//--------------------------
//
//The stream extraction operator should read complex numbers
//of the following format :
//
//a + bi
//
//You can make the following assumptions about values that are
//being read from an input stream :
//
//-the real number(a) and imaginary number(b) :
//o will always exist in the input stream, even if they are zero
//o can be integer or floating point values
//o could be negative or positive
//
//- the operator will be a single character and will be either
//a '+' character or a '-' character
//
//- there will be an 'i' character immediately following the
//imaginary number(b)
//
//- there will be a space between the real number and the
//operator character AND between the operator character and
//the imaginary number
//
//No validation of input formats is required.
//Unhandled inputs are character stringsl
istream& operator>>(istream  &is,  Complex &rhs)
{
	char d, i;
	is >> rhs.m_real >> d >> rhs.m_imaginary >> i;
	if (d == '-' && rhs.m_imaginary < 0){
		rhs.m_imaginary = abs(rhs.m_imaginary);
	}
	else if (d=='-' && rhs.m_imaginary > 0)
	{
		rhs.m_imaginary = -rhs.m_imaginary;
	}
	
	return is;
}

