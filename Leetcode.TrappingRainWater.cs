	// http://leetcode.com/onlinejudge#question_42
	//
	// Trapping Rain Water 	Mar 10
	// Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.

	// For example, 
	// Given [0,1,0,2,1,0,1,3,2,1,2,1], return 6.

	// The above elevation map is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped. Thanks Marcos for contributing this image!
	///////////////////
	// Solution:
	//
	// 算法很简单，核心思想是：对某个值A[i]来说，能trapped的最多的water取决于在i之前最高的值leftMostHeight[i]和在i右边的最高的值rightMostHeight[i]。（均不包含自身）。如果min(left,right) > A[i]，那么在i这个位置上能trapped的water就是min(left,right) – A[i]。
	// 有了这个想法就好办了，第一遍从左到右计算数组leftMostHeight，第二遍从右到左计算rightMostHeight，在第二遍的同时就可以计算出i位置的结果了，而且并不需要开空间来存放rightMostHeight数组。

	// 时间复杂度是O(n)，只扫了两遍。
	//
	public int TrappingRainWater(int[] H) {
		if(H==null) throw new ArgumentNullException();
		if(H.Length<3) return 0;

		int[] LMax = new int[H.Length];
		LMax[0]=int.MinValue; LMax[1]=H[0];
		for(int i=2;i<H.Length;++i) {
			LMax[i]=Math.Max(LMax[i-1],H[i-1]);
		}

		int sum=0;
		int rMax=H[H.Length-1];
		for(int i=H.Length-2;i>0;--i) {
			int si = Math.Min(rMax,LMax[i])-H[i];
			if(si>0) sum+=si;
			rMax=Math.Max(rMax,H[i]);
		}
		return sum;
	}
