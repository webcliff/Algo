	// Palindrome Number
	// http://leetcode.com/onlinejudge#question_9
	//
	// Determine whether an integer is a palindrome. Do this without extra space.
	//
	public bool PalindromeNumber(int A) {
		if(A<0) return false;

		int l=1;
		while(A/l>9) l*=10;

		while(A>9) {
			int head=A/l, tail=A%10;
			if(head!=tail) return false;
			A = (A%l)/10;
			l=l/100;
		}
		return true;
	}
