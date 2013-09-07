// Zillow
// Implement insert and delete in a tri-nary tree, much like a binary-tree but with 3 child nodes 
// for each parent instead of two - with the left node being values<parent, the right node values>parent, 
// and the middle node values==parent.
// for example: if I added the following nodes to the tree in this order:5,4,9,5,7,2,2, - the tree would 
// look like this:
//          5
//       /  |  \
//      4   5   9
//     /       /
//    2       7
//    |
//    2     

#include <iostream>

using namespace std;

struct TreeNode {
	TreeNode(int key) : key(key),left(NULL),middle(NULL),right(NULL) {
	}
	int key;
	TreeNode *left;
	TreeNode *middle;
	TreeNode *right;
};

class Tree {
public:
	Tree();
	~Tree();
	void Insert(int key);
	void Delete(int key);

private:
	TreeNode *root;
	TreeNode* Insert(int key, TreeNode *node);
	TreeNode* Delete(int key, TreeNode *node);
	TreeNode* FindMin(TreeNode *node);
	void FreeTree(TreeNode *node);
};

Tree::Tree() : root(NULL) {
}

Tree::~Tree() {
	FreeTree(root);
}

void Tree::Insert(int key) {
	root = Insert(key, root);
}

void Tree::Delete(int key) {
	Delete(key, root);
}

void Tree::FreeTree(TreeNode *node) {
	if(!node) return; // nothing to free

	if(node->left) FreeTree(node->left);
	if(node->middle) FreeTree(node->middle);
	if(node->right) FreeTree(node->right);

	delete node;
}

TreeNode* Tree::Insert(int key, TreeNode *node) {
	if(!node) return new TreeNode(key);
	else if(key<node->key) {
		node->left=Insert(key,node->left);
	}
	else if(key>node->key) {
		node->right=Insert(key,node->right);
	}
	else {
		node->middle=Insert(key,node->middle);
	}
	return node;
}

TreeNode* Tree::Delete(int key, TreeNode *node) {
	if(!node) return NULL; // nothing to remove
	else if(key<node->key) {
		node->left=Delete(key,node->left);
	}
	else if(key>node->key) {
		node->right=Delete(key,node->right);
	}
	else { 
		if(node->middle) { // short circuit the first middle
			TreeNode *toDelete=node->middle;
			node->middle=toDelete->middle;
			delete toDelete;
		}
		else if(node->right) { // successor taking the spot
			TreeNode *successor = FindMin(node->right);
			// reuse the existing memory, left child stay the same
			node->key=successor->key;
			node->right=Delete(successor->key, node->right);
		}
		else { // elevate left child
			TreeNode *toDelete=node;
			node=toDelete->left;
			delete toDelete;
		}
	}
	return node;
}

TreeNode* Tree::FindMin(TreeNode *node) {
	if(!node) return NULL;
	while(node->left) node=node->left;
	return node;
}

//Visual Studio 2012 C++ compiler
void main() {

	Tree tree;

	tree.Insert(5);
	tree.Insert(4);
	tree.Insert(9);
	tree.Insert(5);
	tree.Insert(7);
	tree.Insert(2);
	tree.Insert(2);

	tree.Delete(5);
	tree.Delete(5);
}
