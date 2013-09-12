	// Balanced Binary Tree
	// http://leetcode.com/onlinejudge#question_110

	// Given a binary tree, determine if it is height-balanced.

	// For this problem, a height-balanced binary tree is defined as a binary tree 
	// in which the depth of the two subtrees of every node never differ by more than 1.
	
	// CareerCup 4.1
  ///////////////////////////
  // Solution 1
  //
	public bool IsBalancedBinaryTree(Node node, out int height) {
		height = 0;
		if(node==null) return true;

		int lH,rH;
		if(!IsBalancedBinaryTree(node.Left,out lH)) return false;
		if(!IsBalancedBinaryTree(node.Right, out rH)) return false;

		height=Math.Max(lH,rH)+1;
		
		return Math.Abs(lH-rH)<2;
	}

  // Solution 2
  //
	public bool IsBalancedTree(Node node) {
		if(node==null) return true;

		int leftMaxDepth = GetMaxDepth(node.Left);
		int rightMaxDepth = GetMaxDepth(node.Right);
		
		if(Math.Abs(rightMaxDepth-leftMaxDepth)>1) return false;

		return IsBalancedTree(node.Left) && IsBalancedTree(node.Right);
	}

  // Solution 3
  //
	public bool IsBalancedTreeIteratively(Node node) {
		int min=int.MaxValue; int max=int.MinValue;
		int h = 0;
		Stack<Node> s = new Stack<Node>();
		while(s.Count!=0 || node !=null) {
			if(node!=null) {
				s.Push(node); ++h;
				if(node.Left==null&&node.Right==null) {
					min=Math.Min(min,h);
					max=Math.Max(max,h);
				}
				node=node.Left;
			}
			else {
				node=s.Pop(); --h;
				node=node.Right;
			}
		}

		return max-min>1;
	}

	public bool IsBalancedBinaryTree(Node node, out int height) {
		height = 0;
		if(node==null) return true;

		int lH,rH;
		if(!IsBalancedBinaryTree(node.Left,out lH)) return false;
		if(!IsBalancedBinaryTree(node.Right, out rH)) return false;

		height=Math.Max(lH,rH)+1;
		
		return Math.Abs(lH-rH)<2;
	}
