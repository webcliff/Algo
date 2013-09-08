	// Regular Expression Matching
	// http://leetcode.com/onlinejudge#question_10

	// Implement regular expression matching with support for '.' and '*'.

	// '.' Matches any single character.
	// '*' Matches zero or more of the preceding element.

	// The matching should cover the entire input string (not partial).

	// The function prototype should be:
	// bool isMatch(const char *s, const char *p)

	// Some examples:
	// isMatch("aa","a") ? false
	// isMatch("aa","aa") ? true
	// isMatch("aaa","aa") ? false
	// isMatch("aa", "a*") ? true
	// isMatch("aa", ".*") ? true
	// isMatch("ab", ".*") ? true
	// isMatch("aab", "c*a*b") ? true
	// 
	public bool RegularExpressionMatching(string s, string p) {
		if(s==null||p==null) throw new ArgumentNullException();

		return IsMatch(s,0,p,0);
	}

	private bool IsMatch(string s, int i, string p,int j) {
		if(i==s.Length&&j==p.Length) return true;
		if(j==p.Length) return false;

		if(j<p.Length-1&&p[j+1]=='*') {
			if(p[j]=='*') throw new ArgumentException("p");
			int t=i;
			while(true) {
				if(IsMatch(s,t,p,j+2)) return true;
				if(t<s.Length&&(s[t]==p[j]||p[j]=='.')) ++t;
				else return false;
			}
		}

		if(i==s.Length) return false;
		if(p[j]=='*') throw new ArgumentException("p");
		if(p[j]=='.'||s[i]==p[j]) return IsMatch(s,i+1,p,j+1);
		return false;
	}

	public static void Main() {
		Console.WriteLine(new Test().RegularExpressionMatching("aa","a"));
		Console.WriteLine(new Test().RegularExpressionMatching("aa","aa"));
		Console.WriteLine(new Test().RegularExpressionMatching("aaa","aa"));
		Console.WriteLine(new Test().RegularExpressionMatching("aa","a*"));
		Console.WriteLine(new Test().RegularExpressionMatching("aa",".*"));
		Console.WriteLine(new Test().RegularExpressionMatching("ab",".*"));
		Console.WriteLine(new Test().RegularExpressionMatching("aab","c*a*b*"));
	}
