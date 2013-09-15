	// CareerCup
	// 4.4 Given a binary search tree, design an algorithm which creates a linked list of all the 
	// nodes at each depth (i.e., if you have a tree with depth D, you’ll have D linked lists).

	public void CreateLevelLinkedListFromBinaryTree(Node node, int level, List<ListNode> list) {
		if(node==null) return;

		if(list.Count<=level) list.Add(new ListNode(node.Value));
		else list[level].Next = new ListNode(node.Value);

		CreateLevelLinkedListFromBinaryTree(node.Left,level+1,list);
		CreateLevelLinkedListFromBinaryTree(node.Right,level+1,list);
	}



	public List<Node> GetLevelLinkedListFromBinaryTree(Node root) {
		if(root==null) throw new ArgumentNullException("root");

		List<ListNode> list = new List<ListNode>();
		Queue<Node> qa = new Queue<Node>();
		Queue<Node> qb = new Queue<Node>();
		qa.Enqueue(root);

		while(qa.Count>=0) {

			Node n = qa.Dequeue();			
			if(n.Left!=nulll) qb.Enqueue(n.Left);
			if(n.Right!=nulll) qb.Enqueue(n.Right);
			ListNode head = new ListNode(n.Value);
			list.Add(head);

			while(qa.Count>=0) {
				n = qa.Dequeue();			
				if(n.Left!=nulll) qb.Enqueue(n.Left);
				if(n.Right!=nulll) qb.Enqueue(n.Right);
				head.Next = new ListNode(n.Value);
				head = head.Next;
			}

			Queue<Node> q=qa; qa=qb; qb=q;
		}

		return list;
	}

