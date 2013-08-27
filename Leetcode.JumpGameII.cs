
	// http://leetcode.com/onlinejudge#question_45
	// Jump Game II 	Mar 17 
	// Given an array of non-negative integers, you are initially positioned at the first index of the array.

	// Each element in the array represents your maximum jump length at that position.

	// Your goal is to reach the last index in the minimum number of jumps.

	// For example:
	// Given array A = [2,3,1,1,4]

	// The minimum number of jumps to reach the last index is 2. (Jump 1 step from index 0 to 1, then 3 steps to the last index.)
	//
	public int JumpGameII(int[] A) {
		if(A==null) throw new ArgumentNullException();

		int count=0, start=0, end=0,max=int.MinValue;

		while(end<A.Length-1) {
			count++;
			for(int i=start;i<=end;++i) {
				if(A[i]+i>=A.Length-1) return count;
				max=Math.Max(max,A[i]+i);
			}
			if(end==max) return -1;

			start=end+1; end=max;
		}
		return -1;
	}
