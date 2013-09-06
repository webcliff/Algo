	// Remove Duplicates from Sorted Array
	// http://leetcode.com/onlinejudge#question_26
	
	// Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.

	// Do not allocate extra space for another array, you must do this in place with constant memory.

	// For example,
	// Given input array A = [1,1,2],

	// Your function should return length = 2, and A is now [1,2].

	public static int RemoveDuplicatesFromSortedArray(int[] A) {
		if(A==null) throw new ArgumentNullException("A");
		if(A.Length<2) return A.Length;

		int slow=0,fast=1;
		while(fast<A.Length) {
			if(A[fast]!=A[slow]) {
				++slow;
				A[slow]=A[fast];
			}
			++fast;
		}
		return slow+1;
	}

