#include "flipit.h"
#include <cstdlib>

// Author      :  James Shaver
//
// File        :  flipit.cpp



//FlipIt - Constructor
//The six settings for each game are provided as
//parameters to the constructor.The constructor should do
//whatever is necessary to setup the member data for a new
//game.See the FAQ for more information about initializing a
//new game.

FlipIt::FlipIt(int      nRows,
	int      nCols,
	int      gameNum,
	int      complexity,
	Pattern  pattern,
	bool     wrap)
{

	//setup game board
	int row, col;
	srand(gameNum);
	mGrid = Grid(nRows, nCols);
	mPattern = pattern;
	mWrap = wrap;

	for (int clicks = 1; clicks <= complexity; clicks++)
	{
		row = (rand()) % nRows;
		col = (rand()) % nCols;
		click(row, col);
	}
}

//numRows-
//Takes no parameters, returns the number of rows in the
//game grid for the game.
int  FlipIt::numRows() const
{
	return mGrid.numRows();
}

//Takes no parameters, returns the number of columns in the
//game grid for the game.
int FlipIt::numCols() const
{
	return mGrid.numCols();
}


//click - 
//Parameters are zero - based row and column values.You can assume
//that the row value is greater - than - or - equal - to zero AND
//less - than the number of rows values passed into the construtor.
//You can assume the column value is greater - than - or - equal - to zero
//AND less - than the number of columns value passed into constructor.
//This function should update the internal engine data based on
//having the row, column grid position selected.It should take into
//account pattern and wrap flag settings that were provided when
//the FlipIt object was created.
void FlipIt::click(int row, int col)
{
	switch (mPattern)
	{
	case cross_:

		reverse(row, col);
		top(row, col);
		left(row, col);
		bottom(row, col);
		right(row, col);
		break;

	case x_:

		reverse(row, col);
		topLeft(row, col);
		bottomLeft(row, col);
		topRight(row, col);
		bottomRight(row, col);
		break;

	case square_:

		reverse(row, col);
		topLeft(row, col);
		top(row, col);
		topRight(row, col);
		right(row, col);
		bottomRight(row, col);
		bottom(row, col);
		bottomLeft(row, col);
		left(row, col);
		break;

	case hollowSquare_:

		if (mGrid.fetch(row, col) != true)
		{
			mGrid.clear(row, col);
		}
		topLeft(row, col);
		top(row, col);
		topRight(row, col);
		right(row, col);
		bottomRight(row, col);
		bottom(row, col);
		bottomLeft(row, col);
		left(row, col);
		break;

	case corners_:

		if (mGrid.fetch(row, col) != true)
		{
			mGrid.clear(row, col);
		}
		topLeft(row, col);
		topRight(row, col);
		bottomRight(row, col);
		bottomLeft(row, col);
		break;
	}
}

//bottom - 
//There are two parameters row and col. The given row and col are used to 
//reverse the cell below of it.
void FlipIt::bottom(int row, int col)
{
	if (row + 1 < numRows())
	{
		reverse(row + 1, col);
	}
	else if (mWrap==true)
	{
		reverse(0, col);
	}
}

//bottomLeft - 
//There are two parameters row and col. The given row and col are used to 
//reverse the cell to the bottom left of it.
void FlipIt::bottomLeft(int row, int col)
{	
	if (row + 1 < numRows() && col - 1 >= 0)
	{
		reverse(row + 1, col - 1);
	}
	else if (mWrap == true)
	{
		if (row + 1 == numRows() && col - 1 < 0)
		{
			reverse(0, numCols() - 1);
		}
		else if (col - 1 < 0)
		{
			reverse(row +1, numCols() - 1);		
		}
		else {
			reverse(0,col-1 );
		}
	}
}

//left - 
//There are two parameters row and col. The given row and column are used to 
//reverse the cell to the left of it.
void FlipIt::left(int row, int col)
{
	if (col - 1 >= 0)
	{
		reverse(row, col - 1);
	}
	else if (mWrap==true)
	{
		reverse(row, numCols() - 1);
	}
}

//topLeft - 
//There are two parameters row and col. The given row and column are used to 
//reverse the cell to the top left of it.
void FlipIt::topLeft(int row, int col)
{
	if (row > 0 && col > 0)
	{
		reverse(row - 1, col - 1);
	}
	else if (mWrap==true)
	{
		if (row - 1 < 0 && col - 1 < 0)
		{
			reverse(numRows() - 1, numCols() - 1);	
		} 
		else if (row - 1 >= 0 && col - 1 < 0)
		{
			reverse(row-1, numCols() - 1);			
		}
		else 
		{
			reverse(numRows() - 1, col-1);			
		}
	}
}

//topRight - 
//There are two parameters row and col. The given row and column are used to 
//reverse the cell to top right of it.
void FlipIt::top(int row, int col)
{
	if (row - 1 >= 0)
	{
		reverse(row - 1, col);
	}
	else if (mWrap==true)
	{
		reverse(numRows() - 1, col);
	}
}

//topRight - 
//There are two parameters row and col. The given row and col are used to 
//reverse the cell to the top right of it.
void FlipIt::topRight(int row, int col)
{
	if (row - 1 >=0 && col + 1 < numCols())
	{
		reverse(row - 1, col + 1);
	}
	else if (mWrap == true)
	{
		if (row - 1 < 0 && col + 1 == numCols())
		{
			reverse(numRows() - 1, 0);
		}
		else if (col + 1 == numCols()){
			reverse(row - 1, 0);
		}
		else
		{
			reverse(numRows() - 1, col + 1);
		}
	}
}

//right - 
//There are two parameters row and col. The given row and col are used to 
//reverse the cell to the right of it.
void FlipIt::right(int row, int col)
{
	if (col+1 < numCols())
	{
		reverse(row, col +1);
	}
	else if (mWrap == true)
	{
		reverse(row, 0);
	}
}

//bottomRight - 
//There are two parameters row and col. The given row and col are used to 
//reverse the cell to the bottom right of it.
void FlipIt::bottomRight(int row, int col)
{
	if (row < numRows()-1 && col < numCols()-1)
	{
		reverse(row + 1, col + 1);
	}
	else if (mWrap == true)
	{
		if (row + 1 == numRows() && col + 1 != numCols())
		{
			reverse(0, col+1);		
		}
		else if (row + 1 == numRows() && col + 1 == numCols())
		{
			reverse(0, 0);	
		}
		else
		{
			reverse(row + 1 , 0);
		}
	}
}

//fetch -
//Parameters are zero - based row and column values.You can assume
//that the row value is greater - than - or - equal - to zero AND
//less - than the number of rows values passed into the construtor.
//You can assume the column value is greater - than - or - equal - to zero
//AND less - than the number of columns value passed into constructor.
//This function returns whether or not the cell at the specified
//grid position is currently clear or solid.
FlipIt::Color FlipIt::fetch(int  row, int  col) const
{
	if (mGrid.fetch(row, col) == true)
	{
		return solid_;
	}
	else
	{
		return clear_;
	}
}

//done -
//No parameters.This function returns true if all grid positions
//are clear(indicating the game is over).If any grid position
//is solid, false should be returned.
bool FlipIt::done() const
{
	int rowsMax = mGrid.numRows()-1;
	int colsMax = mGrid.numCols()-1;

	for (int r = 0; r <= rowsMax; r++)
	{
		for (int c = 0; c <= colsMax; c++)
		{
			if (mGrid.fetch(r, c) == true)
			{
				return false;
			}
		}
	}
	return true;
}

//reverse-
//There are two parameters row and col. The given row and col are used to manipulate the member Grid, if a given 
//cell is set to clear, it is then set to 'set' and vice versa.
void FlipIt::reverse(int row, int col)
{
	Color temp = fetch(row, col);

	if (temp == solid_)
	{
		mGrid.clear(row, col);
	}
	else
	{
		mGrid.set(row, col);
	}
}