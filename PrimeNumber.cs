using System;
using System.Collections.Generic;

public class PrimeNumbers {

	// Sieve of Eratosthenes
	public void PrintAllPrimeNumbers(int N) {
		if(N<2) return; // by definition, 1 is not a prime, 2 is the smallest prime

		bool[] f = new bool[N+1];
		// f[i]==ture -> prime
		f[0]=false; f[1]=false;
		for(int i=2;i<f.Length;++i) f[i]=true;

		int limit=(int)(Math.Sqrt(N)+0.5);
		// only need to search up to sqrt(N), reason:
		//   given i : limit<i<=N and  i*j=N
		//       since j=N/i and i>limit then j<limit
		//       j should have be covered by the search.
		for(int i=2;i<=limit;++i) {
			if(f[i]==false) continue;

			// search start from i*i :
			// given j=i*k and k<i, then it should have been searched during i=k loop.
			for(int j=i*i;j<=N;j+=i)
				if(f[j]) f[j]=false;
		}

		for(int i=2;i<f.Length;++i)
			if(f[i]) Console.Write(i+" ");
	}

	public int FindNthPrimeNumber(int N) {
		if(N<1) throw new ArgumentException("N");

		List<int> soFar = new List<int>(); // keep a list of prime found so far
		soFar.Add(2);
		if(N==1) return soFar[0];
		
		int i=3, count=N;
		while(count>1) {  // done when Nth found.
			bool f=true;
			// iterate found primes, from 0 to sqrt(i), if i can be divided by any prime
			// then i is not a prime
			for(int j=0;soFar[j]*soFar[j]<=i;++j) {
				if(i%soFar[j]==0) { f=false; break;}
			}
			if(f) { soFar.Add(i); --count; }
			++i; 
		}

		return soFar[N-1];

	}

	// http://www.mitbbs.com/article_t/JobHunting/32354635.html
	// 分解质因数: 找出一个正整数的所有质数因子乘积，比如9=3*3，21=3*7
	public void Factorization(int N) {
		while(N>1) {
			int p=2;
			while(N%p!=0) ++p;
			Console.Write(p+" ");
			N=N/p;
		}
	}


	public static void Main() {
		new PrimeNumbers().PrintAllPrimeNumbers(90);
		Console.WriteLine();
		Console.WriteLine(new PrimeNumbers().FindNthPrimeNumber(90000));
		Console.WriteLine();
		new PrimeNumbers().Factorization(990834);
	}
}
