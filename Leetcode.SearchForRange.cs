	// Search for a Range
	// http://leetcode.com/onlinejudge#question_34
	
	// Given a sorted array of integers, find the starting and ending position of a given target value.

	// Your algorithm's runtime complexity must be in the order of O(log n).

	// If the target is not found in the array, return [-1, -1].

	// For example,
	// Given [5, 7, 7, 8, 8, 10] and target value 8,
	// return [3, 4].
	public void SearchForRange(int[] A, int T, out int rl, out int rr) {
		if(A==null) throw new ArgumentNullException();
		
		rl = SearchForLeftBound(A, T, 0, A.Length-1);

		if(rl==-1) { rr=-1; return; }

		rr=SearchForRightBound(A,T,0,A.Length-1);
	}

	private int SearchForLeftBound(int[] A, int T, int l, int r) {
		if(l>r) return -1;
		int m = l+(r-l)/2;

		if(A[m]==T) {
			if(m==0) return m;
			if(A[m-1]<T) return m;
			return SearchForLeftBound(A,T,l,m-1);
		}
		else if(A[m]<T) 
			return SearchForLeftBound(A,T,m+1,r);
		else
			return SearchForLeftBound(A,T,l,m-1);
	}

	private int SearchForRightBound(int[] A, int T, int l, int r) {
		if(l>r) return -1;
		int m = l+(r-l)/2;

		if(A[m]==T) {
			if(m==r) return m;
			if(A[m+1]>T) return m;
			return SearchForRightBound(A,T,m+1,r);
		}
		else if(A[m]<T) 
			return SearchForRightBound(A,T,m+1,r);
		else
			return SearchForRightBound(A,T,l,m-1);
	}

