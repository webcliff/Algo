	// 3Sum Closest
	// http://leetcode.com/onlinejudge#question_16

	// Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. Return the sum of the three integers. You may assume that each input would have exactly one solution.

	//     For example, given array S = {-1 2 1 -4}, and target = 1.

	//     The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
	//
	public int ThreeSumClosest(int[] A, int sum) {
		if(A==null) throw new ArgumentNullException("A");
		if(A.Length<3) throw new ArgumentException("A");
		
		QuickSort(A,0,A.Length-1);
		int ret=int.MaxValue;
		for(int i=0;i<A.Length-2;++i) {
			int l=i+1,r=A.Length-1;
			while(l<r) {
				int tSum=A[i]+A[l]+A[r];
				
				if(tSum==sum) return sum;
				if(tSum>sum) --r;
				else ++l;

				if(Math.Abs(tSum-sum)<Math.Abs(ret-sum)) ret=tSum;
			}
		}
		return ret;
	}

	private void QuickSort(int[] A, int l, int r) {
		if(l>=r) return;

		int m=Partition(A,l,r);
		QuickSort(A,l,m-1);
		QuickSort(A,m+1,r);
	}

	private int Partition(int[] A,int l,int r) {
		int p=A[r];
		int slow=l,fast=l;
		while(fast<r) {
			if(A[fast]<p) {
				swap(A,slow,fast);
				++slow;
			}
			++fast;
		}
		swap(A,slow,r);
		return slow;
	}

	private void swap(int[] A,int a,int b) {
		int t=A[a];A[a]=A[b];A[b]=t;
	}
