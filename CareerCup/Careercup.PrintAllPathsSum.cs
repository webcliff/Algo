	// 4.8 You are given a binary tree in which each node contains a value. 
	// Design an algorithm to print all paths which sum up to that value. 
	// Note that it can be any path in the tree – it does not have to start at the root.

	public void PrintAllPaths(Node root, int N) {
		if(root==null) return;

		PrintAllPaths(root.Left,N);
		PrintAllPathsFromNode(root,N, new List<Node>());
		PrintAllPaths(root.Right,N);
	}

	private void PrintAllPathsFromNode(Node node, int N, List<Node> soFar) {
		if(N==0) Dump(soFar);
		if(node==null) return; 

		soFar.Add(node);
		PrintAllPathsFromNode(node.Left,N-node.Value,soFar);
		PrintAllPathsFromNode(node.Right,N-node.Value,soFar);
		soFar.RemoveAt(soFar.Count-1);
	}
