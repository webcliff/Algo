	// Divide Two Integers
	// http://leetcode.com/onlinejudge#question_29
	
	// Divide two integers without using multiplication, division and mod operator.
	public int DivideTwoIntegers(int a, int b) {
		if(b==0) throw new OverflowException();

		bool sign = false;
		if(a<0) sign = !sign;
		if(b<0) sign = !sign;

		int ret = DivideTwoPositiveIntegers(Math.Abs(a), Math.Abs(b));
		return sign ? ret*-1 : ret;
	}

	private int DivideTwoPositiveIntegers(int a, int b) {
		if(a<b) return 0;
		int ret=0, t=1, bt=b;
		while(a>=bt) {
			a=a-bt;
			ret+=t; 
			bt<<=1; t<<=1;
		}
		ret += DivideTwoPositiveIntegers(a,b);
		return ret;
	}
