	// Remove Element
	// http://leetcode.com/onlinejudge#question_27
	// Given an array and a value, remove all instances of that value in place and return the new length.

	// The order of elements can be changed. It doesn't matter what you leave beyond the new length.

	public static int RemoveElement(int[] A, int a) {
		if(A==null) throw new ArgumentNullException("A");
		if(A.Length==0) return 0;

		int fwd=0,bwd=A.Length-1;
		while(fwd<=bwd) {
			if(A[fwd]!=a) ++fwd;
			else if(A[bwd]==a) --bwd;
			else  { 
				A[fwd]=A[bwd];
				++fwd;--bwd;
			}
		}
		return fwd;
	}

