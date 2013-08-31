	// Search in Rotated Sorted Array
	// http://leetcode.com/onlinejudge#question_33

	// Suppose a sorted array is rotated at some pivot unknown to you beforehand.

	// (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

	// You are given a target value to search. If found in the array return its index, otherwise return -1.

	// You may assume no duplicate exists in the array.
	//
	public int SearchInRotatedSortedArray(int[] A, int T) {
		if(A==null) throw new ArgumentNullException();

		int l=0,r=A.Length-1;
		while(l<=r) {
			int m=l+(r-l)/2;
			if(A[m]==T) return m;
			if(A[m]>=A[l]) {
				if(T>=A[l]&&T<A[m]) r=m-1;
				else l=m+1;
			}
			else {
				if(T>A[m]&&T<=A[r]) l=m+1;
				else r=m-1;
			}
		}
		return -1;
	}
