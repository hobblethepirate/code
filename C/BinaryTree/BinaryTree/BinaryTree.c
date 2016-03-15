#include <stdio.h>
#include <limits.h>


/*Binary Tree : start by writing a C program to read a file containing numbers,
sort them in increasing order, and write the output to a file
The file that is read in is numbers.txt and the file that is outputted is numbersout.txt.
*/


struct node
{
	int value;
	struct node *left;
	struct node *right;
};

insert(int val, struct node **leaf)
{
	if (*leaf == 0)
	{
		*leaf = (struct node*) malloc(sizeof(struct node));
		(*leaf)->value = val;

		(*leaf)->left = 0;
		(*leaf)->right = 0;
	}
	else if (val < (*leaf)->value)
	{
		insert(val, &(*leaf)->left);
	}
	else if (val >(*leaf)->value)
	{
		insert(val, &(*leaf)->right);
	}
}

/*
* Used for debugging purposes.
*/
void printTree(struct node* node) {

	if (node == NULL)
	{
		return;
	}
	printTree(node->left);
	printf("%d ", node->value);
	printTree(node->right);
}

int GetLowestBase(struct node* node, int min, int max)
{
	int output = max;
	if (node == NULL)
	{
		return min;
	}
	else if (node->value > min && node->value < max)
	{
		output = node->value;
	}

	int result = GetLowest(node->left, min, max, output);
	if (result > min && result < output && result < max)
	{
		output = result;
	}
	result = GetLowest(node->right, min, max, output);
	if (result > min && result < output && result < max)
	{
		output = result;
	}
	return output;
}

int GetLowest(struct node* node, int min, int max, int output)
{
	if (node == NULL)
	{
		return output;
	}
	int result = GetLowest(node->left, min, max, output);
	if (result > min && result < node->value && result < max)
	{
		output = result;
	}
	else if (node->value > min && result > node->value && node->value < max)
	{
		output = node->value;
	}
	result = GetLowest(node->right, min, max, output);
	if (result > min && result < max)
	{
		output = result;
	}
	return output;

}

void deleteTree(struct node *leaf)
{
	if (leaf != 0)
	{
		deleteTree(leaf->left);
		deleteTree(leaf->right);
		free(leaf);
	}
}

int main()
{
	//setup binary tree
	struct node *root = 0;
	int input = 0;
	int count = 0;
	FILE *inf, *outf;
	printf("Binary Tree by James Shaver\n");
	inf = fopen("numbers.txt", "r");

	if (inf == NULL)
	{
		printf("Unable to open file, closing....");
		fclose(inf);
		return;
	}
	//add integers to binary tree
	while (fscanf(inf, " %d", &input) != EOF)
	{
		insert(input, &root);
		count++;
	}
	//close input file
	fclose(inf);
 	printTree(root);
	int output = INT_MIN;

	//open output file
	outf = fopen("numbersout.txt", "w");
	for (int a = 0; a < count; a++)
	{
		output = GetLowestBase(root, output, INT_MAX);
		fprintf(outf, "%d ", output);
	}

	//close output file
	fclose(outf);
	//delete binary tree
	deleteTree(root);

	getch();

}