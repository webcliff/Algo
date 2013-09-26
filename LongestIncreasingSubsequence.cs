using System;
using System.Text;
using System.Collections.Generic;

public class Test {

	public static void Main() {
		double[] D = {1,5,4,5,10,3,25,39,38,0,1};
		new Test().FindLongestIncreasingSubseq(D);
	}

	// Longest Increasing Subsequence
	////////////////////////
	// Given a sequence of n real numbers A(1) ... A(n), determine a subsequence (not necessarily contiguous) 
	// of maximum length in which the values in the subsequence form a strictly increasing sequence.
	////////////////////////
	// f(i) 0<=i<N
	// =1          i=0
	// =max(g(k))     
	//  0<=k<i
	//  g(k) = f(k)+1 if S[i]>S[k]
	//       = 1      else
	public void FindLongestIncreasingSubseq(double[] D) {
		int[] f=new int[D.Length];
		int[] p=new int[D.Length];
		f[0]=1;
		for(int i=0;i<p.Length;++i) p[i]=-1;

		for(int i=1;i<f.Length;++i) {
			f[i]=1;p[i]=i;
			for(int k=0;k<i;++k) {
				if(D[i]>D[k] && f[k]+1>f[i]) {
					f[i]=f[k]+1;p[i]=k;
				}
			}
		}

		int y=0,l=int.MinValue;
		for(int i=0;i<f.Length;++i) {
			if(f[i]>l) {
				l=f[i];y=i;
			}
		}

		Print(D,p,y);
	}

	private void Print(double[] D, int[] p, int y) {
		if(y<0) return;
		Print(D,p,p[y]);
		Console.Write(D[y] + " ");
	}
}  
