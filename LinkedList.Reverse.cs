	public static Node ReverseList(Node head) {
		if(head==null) throw new ArgumentNullException();
		Node p=null, c=head, n=c.Next;
		while(n!=null) {
			c.Next=p;
			p=c; c=n; n=n.Next;
		}
		c.Next=p; // set last node.
		return c;
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

		Node head = ReverseList(n1);
		Dump(head);
	}
