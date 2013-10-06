

private int[] CalcPrefixFunction(string P) {
	int[] pi=new int[P.Length];
	int j=0;
	for(int i=1;i<P.Length;++i) {
		while(j>0&&P[i]!=P[j])  j=pi[j-1];

		if(P[i]==P[j]) ++j;

		pi[j]=j;
	}
	return pi;
}

public void StringMatchKMP(string T,string P) {
	int[] pi = CalcPrefixFunction(P);
	int j=0;
	for(int i=0;i<T.Length;++i) {
		while(j>0&&P[j]!=T[i]) j=pi[j-1];

		if(T[i]==P[j]) ++j;

		if(j==P.Length) {
			Print(T,i-P.Length,P.Length);
			j=pi[j];
		}
	}
}

public void StringMatchRabinKarp(string T,string P) {
	int prime = PickPrime();
	int h=CalcH(prime,P.Length);

	int t,pp;
	for(int i=0;i<P.Length;++i) {
		pp = (pp*10+P[i])%prime;
		t = (10*t+T[i])%prime;
	}

	for(int i=0;i<T.Length-P.Length;++i) {
		if(pp==t) {
			if(Compare(P,T,i)) Output;
		}
		if(i<T.Length-P.Length)
			t=(10(t-h*T[i+1])+T[i+P.Length+1])%prime;
	}
}
