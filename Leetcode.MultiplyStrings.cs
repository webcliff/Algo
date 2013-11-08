	// http://leetcode.com/onlinejudge#question_43
	// Multiply Strings 	Mar 12 
	// Given two numbers represented as strings, return multiplication of the numbers as a string.

	// Note: The numbers can be arbitrarily large and are non-negative.
	public string MultiplyStrings(string A, string B) {
		if(A==null||B==null) throw new ArgumentNullException();
		if(A.Length==0||B.Length==0) throw new ArgumentException();

		//check if A and B are all digits

		int numOfZeros=0;
		string result="0";
		for(int b=B.Length-1;b>=0;--b) {
			string product = MultipleStringwithChar(A,B[b],numOfZeros++);
			result = Add(result,product);
		}
		return result;
	}

	private string MultipleStringwithChar(string A, char b, int numOfZeros) {
		StringBuilder product = new StringBuilder();
		while(numOfZeros>0) {
			product.Append("0"); 
			--numOfZeros;
		}
		int carry=0, ib=b-'0';
		for(int a=A.Length-1;a>=0;--a) {
			int ia=A[a]-'0';
			ia=ia*ib+carry;
			carry=ia/10; ia=ia%10;
			product.Insert(0,ia);
		}
		if(carry>0) product.Insert(0,carry);
		return product.ToString();
	}

	private string Add(string A, string B) {
		StringBuilder sb = new StringBuilder();
		int carry=0;
		int a=A.Length-1,b=B.Length-1;
		while(a>=0||b>=0) {
			int ia=a>=0 ? A[a]-'0':0;
			int ib=b>=0 ? B[b]-'0':0;
			ia+=ib+carry;
			carry=ia/10; ia=ia%10;
			sb.Insert(0,ia);
			--a;--b;
		}
		if(carry>0) sb.Insert(0,carry);
		return sb.ToString();
	}
/*
123,45
b numOfZeros product result
1 0          615     0,615
4 1          4920    5535



123,5,1 
product 0
carry ib a ia           product
0,1   5  2 3,15,5       50
1     5  1 2,11,1       150
0     5  0 1,6,6        6150




123
 45
a b ia ib carry  sb
2 1 8  5  0      8
1 0 6  4  0      6
0-1 1  0  0      1
return 168
*/
