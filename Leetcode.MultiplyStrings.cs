	// http://leetcode.com/onlinejudge#question_43
	// Multiply Strings 	Mar 12 
	// Given two numbers represented as strings, return multiplication of the numbers as a string.

	// Note: The numbers can be arbitrarily large and are non-negative.
	public string MultiplyStrings(string A, string B) {
		if(A==null||B==null) throw new ArgumentNullException();
		if(A.Length==0||B.Length==0) throw new ArgumentException();

		StringBuilder sb = new StringBuilder('0');
		StringBuilder product = new StringBuilder();

		for(int b=B.Length-1;b>=0;--b) {
			MultiplyStringAndChar(product,A,B[b],B.Length-1-b);
			Add(sb,product.ToString());
		}
		return sb.ToString();
	}

	private void MultiplyStringAndChar(StringBuilder product, string A, char b, int numZeros) {
		product.Clear();
		if(b-'0'==0) { product.Append('0'); return;}

		while(numZeros>0) { product.Insert(0,'0'); --numZeros; }

		int bi=b-'0', carry=0;
		for(int a=A.Length-1;a>=0;--a) {
			int ai=A[a]-'0';
			ai=ai*bi+carry;
			carry=ai/10; ai=ai%10;
			product.Insert(0,(char)('0'+ai));
		}
		if(carry!=0) product.Insert(0,(char)('0'+carry));
	}

	private void Add(StringBuilder sb, string product) {
		string sum=sb.ToString();
		sb.Clear();
		int s=sum.Length-1,p=product.Length-1;
		int carry=0;
		while(s>=0||p>=0) {
			int si= (s>=0 ? sum[s]-'0' : 0);
			int pi= (p>=0 ? product[p]-'0' : 0);
			si =si+pi+carry;
			carry=si/10; si=si%10;
			sb.Insert(0,(char)(si+'0'));
			--s;--p;
		}
		if(carry>0) sb.Insert(0,(char)(carry+'0'));
	}

