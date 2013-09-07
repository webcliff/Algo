public class Node : IComparable<Node> {
	public Node Next { get; set; }
	public int Value { get; set; }
	public int CompareTo(Node other) {
		return Value.CompareTo(other.Value);
	}
}

public class Test {

	// Merge k Sorted Lists
	// http://leetcode.com/onlinejudge#question_23
	// Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.
	// 
	// Memory : O(K)
	// Time : O(NlogN)
	public Node MergeKSortedList(List<Node> sortedList) {
		PriorityQueue<Node> pq = new PriorityQueue<Node>(sortedList.Count);

		foreach(Node head in sortedList) pq.Push(head);
		
		Node dummy = new Node();
		Node tail = dummy;
		while(!pq.Empty()){
			Node min = pq.Top(); pq.Pop();
			if(min.Next!=null) pq.Push(min.Next);
			tail.Next=min; tail=min;
		}
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
		Node n3 = new Node {Value=3};
		Node n2 = new Node {Value=2};
		Node n1 = new Node {Value=1};

		n1.Next=n2;
		n2.Next=n3;
		n3.Next=n4;
		n4.Next=n5;
		n5.Next=n6;
		n6.Next=n7;

		Node n17 = new Node {Value=7};
		Node n16 = new Node {Value=6};
		Node n15 = new Node {Value=5};
		Node n14 = new Node {Value=4};
		Node n13 = new Node {Value=3};
		Node n12 = new Node {Value=2};
		Node n11 = new Node {Value=1};

		n11.Next=n12;
		n12.Next=n13;
		n13.Next=n14;
		n14.Next=n15;
		n15.Next=n16;
		n16.Next=n17;

		Node n114 = new Node {Value=8};
		Node n113 = new Node {Value=7};
		Node n112 = new Node {Value=7};
		Node n111 = new Node {Value=4};

		n111.Next=n112;
		n112.Next=n113;
		n113.Next=n114;

		List<Node> sortedList = new List<Node>(3);
		sortedList.Add(n1);
		sortedList.Add(n11);
		sortedList.Add(n111);

		Node merged = new Test().MergeKSortedList(sortedList);
		Dump(merged);
	}
}
