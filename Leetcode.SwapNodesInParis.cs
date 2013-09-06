	// Swap Nodes in Pairs
	// http://leetcode.com/onlinejudge#question_24
	
	// Given a linked list, swap every two adjacent nodes and return its head.

	// For example,
	// Given 1->2->3->4, you should return the list as 2->1->4->3.

	// Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.

	public Node SwapNodesInPairs(Node head) {
		if(head==null) throw new ArgumentNullException();

		Node dummy = new Node { Next=head };
		Node p=dummy, c=head, n;
		while(c!=null&&c.Next!=null) {
			n=c.Next;	
			Node t=n.Next;

			n.Next=c;
			c.Next=t;
			p.Next=n;

			p=c;
			c=t;
		}

		return dummy.Next;
	}

	public class Node {
		public Node Next { get; set; }
		public int Value { get; set; }
	}

	public static void Dump(Node head) {
		while(head!=null) {
			Console.Write(head.Value);
			Console.Write("->");
			head=head.Next;
		}
		Console.WriteLine();
	}

	public static void Main() {

		Node n7 = new Node {Value=7};
		Node n6 = new Node {Value=6};
		Node n5 = new Node {Value=5};
		Node n4 = new Node {Value=4};
		Node n3= new Node {Value=3};
		Node n2 = new Node {Value=2};
		Node n1 = new Node {Value=1};

		n1.Next=n2;
		n2.Next=n3;
		n3.Next=n4;
		n4.Next=n5;
		n5.Next=n6;
		n6.Next=n7;

		Node head = new Test().SwapNodesInPairs(n1);
		Dump(head);

	}
