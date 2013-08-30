	// Search Insert Position
	// http://leetcode.com/onlinejudge#question_35

	// Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

	// You may assume no duplicates in the array.

	// Here are few examples.
	// [1,3,5,6], 5 → 2
	// [1,3,5,6], 2 → 1
	// [1,3,5,6], 7 → 4
	// [1,3,5,6], 0 → 0
	////////////////////
	// when binary search ends, l points to the insert position
	// 
	public int SearchInsertPosition(int[] N, int T) {
		if(N==null) throw new ArgumentNullException("N");
		if(N.Length==0) return 0;

		int l=0,r=N.Length-1;
		while(l<=r) {
			int m = l+(r-l)/2;
			if(N[m]==T) return m;
			else if(N[m]>T) r=m-1;
			else l=m+1;
		}
		return l;
	}


	public static void Main() {

		int[] N1={1,3,5,6};

		Console.WriteLine(new Test().SearchInsertPosition(N1,5));
		Console.WriteLine(new Test().SearchInsertPosition(N1,2));
		Console.WriteLine(new Test().SearchInsertPosition(N1,7));
		Console.WriteLine(new Test().SearchInsertPosition(N1,0));
	}

