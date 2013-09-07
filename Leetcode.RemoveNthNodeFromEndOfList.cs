	// Remove Nth Node From End of List
	// http://leetcode.com/onlinejudge#question_19

	// Given a linked list, remove the nth node from the end of list and return its head.

	// For example,

	//    Given linked list: 1->2->3->4->5, and n = 2.

	//    After removing the second node from the end, the linked list becomes 1->2->3->5.
	public Node RemoveNthNodeFromEndOfList(Node head, int N) {
		if(head==null) throw new ArgumentNullException("head");
		if(N<0) throw new ArgumentException("N");

		Node dummy = new Node { Next=head };
		Node slow=dummy, fast=head;

		while(N>0) {
			if(fast==null) return head;
			fast=fast.Next;
			--N;
		}

		while(fast!=null) {
			slow=slow.Next; fast=fast.Next;
		}
		if(slow.Next!=null) slow.Next=slow.Next.Next;

		return dummy.Next;
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

		Node head = new Test().RemoveNthNodeFromEndOfList(n1,0);
		Dump(head);
	}
