//
//
// James Shaver
//
//
// File: Complex.cpp
//
// This file contains the class declarations for the Complex Number class.
//

#ifndef Complex_H
#define Complex_H

#include <iostream>

using namespace std;

class Complex
{
public:

	Complex(float real, float imaginary);
	float real() const;
	float imaginary() const;
	
	//Mathmatical Operators
    Complex operator+(const Complex &rhs) const;
	Complex operator-(const Complex &rhs) const;
	Complex operator*(const Complex &rhs) const;
	Complex operator/(const Complex &rhs) const;

	//Negation Operator
	Complex operator-() const;

	//Arthimetic assignment operators
	void operator+=(const Complex &rhs);
	void operator-=(const Complex &rhs);
	void operator*=(const Complex &rhs);
	void operator/=(const Complex &rhs);

	//Comparison Operators
	bool operator==(const Complex &rhs) const;
	bool operator!=(const Complex &rhs) const;
	bool operator<=(const Complex &rhs) const;
	bool operator<(const Complex &rhs) const;
	bool operator>=(const Complex &rhs) const;
	bool operator>(const Complex &rhs) const;
	
	//Stream operators
	friend ostream& operator<<(ostream  &os, const Complex &rhs);
	friend istream& operator>>(istream  &is, Complex &rhs);

private:

	float m_real;
	float m_imaginary;
	
};
#endif