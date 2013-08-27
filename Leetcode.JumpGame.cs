	// http://leetcode.com/onlinejudge#question_55
	//
	// Jump Game 	Mar 25
	// Given an array of non-negative integers, you are initially positioned at the first index of the array.

	// Each element in the array represents your maximum jump length at that position.

	// Determine if you are able to reach the last index.

	// For example:
	// A = [2,3,1,1,4], return true.
	// A = [3,2,1,0,4], return false.
	//
	public bool JumpGame(int[] A) {
		if(A==null) throw new ArgumentNullException();

		int cover = 0;
		for(int i=0;i<A.Length;++i) {
			if(i>cover) return false;
			cover=Math.Max(cover,A[i]+i);
			if(cover>=A.Length-1) return true;
		}
		return false;
	}

	// DP:
	// f(i)=true if 
	//	1.i+A[i]>=A.Length-1  or
	//	2.f(i+k) is true  for any 1<=k<=A[i]
	public bool JumpGame_DP(int[] A) {
		if(A==null) throw new ArgumentNullException();
		if(A.Length==0) throw new ArgumentException(); 

		bool[] f = new bool[A.Length];
		for(int i=0;i<f.Length-1;++i) f[i]=false;
		f[f.Length-1]=true;

		for(int i=f.Length-2;i>=0;--i) {
			for(int k=A[i];k>=1;--k) {
				if(k+i<f.Length&&f[i+k]) {
					f[i] = true; break;
				}
			}
		}
		return f[0];
	}
