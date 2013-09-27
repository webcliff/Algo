	// Merge Sorted Array
	
	// Given two sorted integer arrays A and B, merge B into A as one sorted array.

	// Note:
	// You may assume that A has enough space to hold additional elements from B. 
	// The number of elements initialized in A and B are m and n respectively.

	public void MergeSortedArrays(int[] A, int AL, int[] B, int BL) {
		if(A==null||B==null) throw new ArgumentNullException("A and/or B");
		if(AL>A.Length||BL>B.Length||AL<0||BL<0) throw new ArgumentNullException("AL and/or BL");
		if(AL+BL>A.Length) throw new ArgumentException("A does not have enough extra space");

		int i=AL+BL-1;
		--AL;--BL;
		while(i>=0) {
			if(AL<0) { A[i]=B[BL]; --BL; }
			else if(BL<0) { A[i]=A[AL]; --AL; }
			else if(A[AL]>B[BL]) { A[i]=A[AL]; --AL; }
			else { A[i]=B[BL]; --BL; }
			--i;
		}
	}
