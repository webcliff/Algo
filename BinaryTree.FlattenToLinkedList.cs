	public static void Main() {
	    //      1
	    //    /  \
	    //   2    3
	    //  / \  
	    // 4  5  
	    Node n1 = new Node {Value=1};
	    Node n2 = new Node {Value=2};
	    Node n3 = new Node {Value=3};
	    Node n4 = new Node {Value=4};
	    Node n5 = new Node {Value=5};
	    Node n6 = new Node {Value=6};
	    Node n7 = new Node {Value=7};
	    Node n8 = new Node {Value=8};

	    n1.Left=n2;n1.Right=n3;
	    n2.Left=n4;n2.Right=n5;

	    Node head = new Test().FlattenBST2(n1);

	    while(head!=null) {
	    	Console.Write(head.Value + "->");
	    	head=head.Right;
	    }
	}


	//
	// solution 1 : recursively
	//
	public Node FlattenBST(Node root) {
		Node prev=null,head=null;
		Traverse(root, ref prev, ref head);
		return head;
	}
	public void Traverse(Node node, ref Node prev, ref Node head) {
		if(node==null) return;

		Traverse(node.Left,ref prev, ref head);

		if(prev==null) { prev=node;  head=node;}
		else {
			prev.Right=node;
			node.Left=prev;
			prev=node;
		}

		Traverse(node.Right,ref prev, ref head);
	}

	//
	// solution 1 : itratively
	//
	public Node FlattenBST2(Node node) {
		Stack<Node> s = new Stack<Node>();
		Node prev=null, head=null;
		while(s.Count>0||node!=null) {
			if(node!=null) {
				s.Push(node);
				node=node.Left;
			}
			else {
				node=s.Pop();

				if(prev==null) { prev=node; head=node;}
				else { prev.Right=node; node.Left=prev; prev=node; }

				node=node.Right;
			}
		}
		return head;
	}
