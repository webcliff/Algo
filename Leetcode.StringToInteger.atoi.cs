	// String to Integer (atoi)
	// http://leetcode.com/onlinejudge#question_8

	// Implement atoi to convert a string to an integer.

	// Hint: Carefully consider all possible input cases. If you want a challenge, please do not see below and ask yourself what are the possible input cases.

	// Notes: It is intended for this problem to be specified vaguely (ie, no given input specs). You are responsible to gather all the input requirements up front.

	// Requirements for atoi:
	// The function first discards as many whitespace characters as necessary until the first non-whitespace character is found. Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.

	// The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.

	// If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.

	// If no valid conversion could be performed, a zero value is returned. If the correct value is out of the range of representable values, INT_MAX (2147483647) or INT_MIN (-2147483648) is returned.
	//
	public int atoi(string a) {
		if(a==null) return 0;

		bool hasInt=false,hasSign=false, negative=false;
		int i=0,r=0;
		while(i<a.Length) {
			char c=a[i];
			if(c==' '||c=='\t') {
				if(hasInt) break; // "3 "
				if(hasSign) return 0; // "+ "
				continue;
			}
			else if(c=='-'||c=='+') {
				if(hasInt) break; // "3+"
				if(hasSign) return 0; // "+-"
				if(c=='-') negative=true;
			}
			else if(c>='0'&&c<='9') {
				int n=(int)(c-'0');
				if(negative) {
					int limit=(int.MinValue+n)/10;
					if(r*-1<limit) return int.MinValue;
				}
				else {
					int limit=(int.MaxValue-n)/10;
					if(r>limit) return int.MaxValue;
				}
				r=r*10+n;
			}
			else {
				if(hasInt) break; // "3w"
				return 0;
			}
			++i;
		}
		return negative ? r*-1 : r;
	}

	public static void Main() {
		Console.WriteLine(new Test().atoi("525"));
		Console.WriteLine(new Test().atoi("55"));
		Console.WriteLine(new Test().atoi("655"));
		Console.WriteLine(new Test().atoi("2147483647"));
		Console.WriteLine(new Test().atoi("2147483648"));
		Console.WriteLine(new Test().atoi("-2147483648"));
		Console.WriteLine(new Test().atoi("-2147483649"));
	}
