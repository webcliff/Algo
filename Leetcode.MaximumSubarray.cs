	// http://leetcode.com/onlinejudge#question_53
	//
	// Maximum subarray Mar 21 '12
	// 
	// Find the contiguous subarray within an array (containing at least one number) which has the largest sum.

	// For example, given the array [−2,1,−3,4,−1,2,1,−5,4],
	// the contiguous subarray [4,−1,2,1] has the largest sum = 6.
	///////
	// Solution : DP O(n)
	// max[i] -> maximum sum ending at A[i]
	// then
	// 	max[0]=A[0]
	//  max[i]=max[i-1]>0 ? max[i-1]+A[i] : A[i]
	//
	// test cases:
	// 	int[] AA1 = {1,-3,4,-1,2,1,-5,4};
	// 	int[] AA2 = {-3,4,-1,2,1,-5,4};
	// 	int[] AA3 = {-1,-5};
	// 	int[] AA4 = {4,6,7,8};

	public int MaximumSubarray(int[] A) {
		if(A==null||A.Lenght<1) throw new ArgumentNullException();

		if(A.Length==1) return A[0];

		int isum=A[0], max=isum;
		for(int i=1;i<A.Length;++i) {
			if(isum>0) isum+=A[i];
			else isum=A[i];

			max=Math.Max(max,isum);
		}
		return max;
	}

