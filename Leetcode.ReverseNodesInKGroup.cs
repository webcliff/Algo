	// Reverse Nodes in k-Group
	// http://leetcode.com/onlinejudge#question_25

	// Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.

	// If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.

	// You may not alter the values in the nodes, only nodes itself may be changed.

	// Only constant memory is allowed.

	// For example,
	// Given this linked list: 1->2->3->4->5

	// For k = 2, you should return: 2->1->4->3->5

	// For k = 3, you should return: 3->2->1->4->5

	public static Node ReverseNodesInKGroup(Node head,int K) {
		if(head==null||K<0) throw new ArgumentNullException();
		if(K<2) return head;

		int len=0;
		Node node = head;
		while(node!=null) { ++len; node=node.Next; }
		int bump=(len/K)*K;
		node=head;

		Node dummy = new Node();
		Node preHead=dummy, nextHead=node;
		int c=0;
		while(c<bump) {
			Node next = node.Next; node.Next = preHead.Next; preHead.Next=node;

			node = next;
			c++;
			if(c%K==0) { 
				preHead=nextHead; nextHead=node;
			}
		}
		preHead.Next=node;
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

		Node n8 = new Node {Value=8};
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
		n7.Next=n8;

		Node head = ReverseNodesInKGroup(n1,3);
		Dump(head);

	}
