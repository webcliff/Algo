	public static void Dump(Node head) {
		while(head!=null) {
			Console.Write(head.Value);
			Console.Write("->");
			head=head.Next;
		}
		Console.WriteLine();
	}

	// Add Two Numbers
	// http://leetcode.com/onlinejudge#question_2
	// You are given two linked lists representing two non-negative numbers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

	// Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
	// Output: 7 -> 0 -> 8

	public Node AddTwoNumbers(Node a, Node b) {
		if(a==null||b==null) throw new ArgumentNullException();
		int carry=0;
		Node dummy=new Node();
		Node node=dummy;
		while(a!=null||b!=null) {

			if(a!=null) { carry+=a.Value;a=a.Next; }
			if(b!=null) { carry+=b.Value; b=b.Next; }
			node.Next=new Node { Value=carry%10 }; node=node.Next;
			carry=carry/10;
		}
		if(carry>0) {
			node.Next=new Node{ Value=carry};
		}
		return dummy.Next;
	}

	public static void Main() {
		Node a2 = new Node {Value=2};
		Node a4 = new Node {Value=4};
		Node a3 = new Node {Value=3};
		Node b5 = new Node {Value=5};
		Node b6= new Node {Value=6};
		Node b4 = new Node {Value=4};

		a2.Next=a4;
		a4.Next=a3;

		b5.Next=b6;
		b6.Next=b4;

		Node c=new Test().AddTwoNumbers(a2,b5);

		Dump(c);
	}
