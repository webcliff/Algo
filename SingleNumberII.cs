using System;

public class Test {
	public static void Main() {
		int[] A = {3,3,3,5,4,4,4};
		Console.WriteLine(new Test().FindSingleNumber(A));
	}
	public int FindSingleNumber(int[] A) {
		int[] B=new int[32];
		int n=0;

		for(int i=0;i<32;++i) {
			for(int j=0;j<A.Length;++j) {
				if(((A[j]>>i)&1)!=0) B[i]=(B[i]+1)%3;
			}
			if(B[i]>0) n=n|(1<<i);
		}
		return n;
	}
}
