	// Reverse Integer
	// http://leetcode.com/onlinejudge#question_7

	// Reverse digits of an integer.

	// Example1: x = 123, return 321
	// Example2: x = -123, return -321

	// Have you thought about this?
	// Here are some good questions to ask before coding. Bonus points for you if you have already thought through this!

	// If the integer's last digit is 0, what should the output be? ie, cases such as 10, 100.

	// Did you notice that the reversed integer might overflow? Assume the input is a 32-bit integer, then the reverse of 1000000003 overflows. How should you handle such cases?

	// Throw an exception? Good, but what if throwing an exception is not an option? You would then have to re-design the function (ie, add an extra parameter).
	public int ReverseInteger(int A) {
		int B=0;
		while(A!=0) {
			int c=A%10;
			
			if(A>0) {
				int limit = (int.MaxValue-c)/10;
				if(B>limit) throw new OverflowException();
			}
			else {
				int limit = (int.MinValue-c)/10;
				if(B<limit) throw new OverflowException();
			}

			B=B*10+A%10;
			A=A/10;
		}
		return B;
	}
