	// CareerCup 
	// 4.3 Given a sorted (increasing order) array, write an algorithm to create a binary tree with minimal height.
	public Node CreateBinarySearchTree(int[] A, int l, int r) {
		if(l>r) return null;

		int m=l+(r-l)/2;
		Node node = new Node(A[m]);
		
		node.Left = CreateBinarySearchTree(A,l,m-1);
		node.Right = CreateBinarySearchTree(A,m+1,r);

		return node;
	}
