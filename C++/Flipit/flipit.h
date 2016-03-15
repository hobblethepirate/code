
//
//
// Author      :  James Shaver
//
// File        :  flipIt.h
//
//
// Description :  Declarations for the FlipIt game class.
//

#ifndef  flipit_H
#define  flipit_H
	

#include  "grid.h"


	class  FlipIt
	{
	public:

	enum  Color  { clear_ = false, solid_ = true };

	enum  Pattern  { cross_, x_, square_, hollowSquare_, corners_ };

	FlipIt(int      nRows,
		int      nCols,
		int      gameNum,
		int      complexity,
		Pattern  pattern,
		bool     wrap);

	int  numRows()  const;
	int  numCols()  const;

	void  click(int  row, int  col);

	Color  fetch(int  row, int  col) const;

	bool  done() const;

private:
	// you get to define the private member variables/functions
	bool mWrap;
	
	Grid mGrid = Grid(0, 0);
	Pattern mPattern;
	
	void reverse(int row, int col);
	void topLeft(int row, int col);
	void topRight(int row, int col);
	void top(int row, int col);
	void left(int row, int col);
	void right(int row, int col);
	void bottomLeft(int row, int col);
	void bottomRight(int row, int col);
	void bottom(int row, int col);
	
};


#endif