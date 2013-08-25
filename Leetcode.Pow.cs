
	//
	// Implement pow(x, n)
	// http://leetcode.com/onlinejudge#question_50
	//
	public double Pow(double x, int n) {
		if(n==0) return 1.0;
		if(n==1) return x;
		if(n==-1) return 1.0/x;

		int i=n/2, j=n%2;
		double p=Pow(x,i);

		return p*p*Pow(x,j);
	}

	// x^7 = x^4 * x^2 * x^1
	public double PowIteratively(double x, int n) {
		int m=n<0 ? n*-1 : n;
		double p=1.0;

		while(m>0) {
			if((m&1)!=0) p*=x;
			x*=x;
			m>>=1;
		}

		if(n<0) p=1.0/p;
		return p;
	}
