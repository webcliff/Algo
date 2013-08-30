	// Combination Sum
	// http://leetcode.com/onlinejudge#question_39

	// Given a set of candidate numbers (C) and a target number (T), find all unique combinations in C where the candidate numbers sums to T.

	// The same repeated number may be chosen from C unlimited number of times.

	// Note:

	// All numbers (including target) will be positive integers.
	// Elements in a combination (a1, a2, � , ak) must be in non-descending order. (ie, a1 ? a2 ? � ? ak).
	// The solution set must not contain duplicate combinations.
	// For example, given candidate set 2,3,6,7 and target 7, 
	// A solution set is: 
	// [7] 
	// [2, 2, 3] 
	public List<List<int>> CombinationSum(int[] C, int T) {
		if(C==null||T<0) throw new ArgumentNullException();

		List<List<int>> combs = new List<List<int>>();

		QuickSort(C,0,C.Length-1);
		CombinationSum(C,T,0,combs,new List<int>());

		return combs;
	}

	private void CombinationSum(int[] C, int T, int start, List<List<int>> combs, List<int> comb) {
		if(T==0) { combs.Add(new List<int>(comb)); return; }
		if(T<0) return;

		for(int i=start;i<C.Length;++i) {
			comb.Add(C[i]);
			CombinationSum(C,T-C[i],i,combs,comb);
			comb.RemoveAt(comb.Count-1);
		}
	}

	private void QuickSort(int[] C, int l, int r) {
		if(l>=r) return;

		int p = Partition(C,l,r);
		QuickSort(C,l,p-1);
		QuickSort(C,p+1,r);
	}

	private int Partition(int[] C, int l, int r) {
		int m=C[r];

		int s=l,f=l;
		while(f<r) {
			if(C[f]<m) {
				swap(C,s,f);
				s++;
			}
			f++;
		}
		swap(C,s,r);

		return s;
	}

	private void swap(int[] C, int i,int j) {
		int t=C[i];C[i]=C[j];C[j]=t;
	}
