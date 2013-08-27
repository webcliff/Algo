// http://leetcode.com/onlinejudge#question_44
	//
	// Wildcard Matching 	Mar 16
	// Implement wildcard pattern matching with support for '?' and '*'.

	// '?' Matches any single character.
	// '*' Matches any sequence of characters (including the empty sequence).

	// The matching should cover the entire input string (not partial).

	// The function prototype should be:
	// bool isMatch(const char *s, const char *p)

	// Some examples:
	// isMatch("aa","a") ? false
	// isMatch("aa","aa") ? true
	// isMatch("aaa","aa") ? false
	// isMatch("aa", "*") ? true
	// isMatch("aa", "a*") ? true
	// isMatch("ab", "?*") ? true
	// isMatch("aab", "c*a*b") ? false

	public bool WildcardMatching(string s, string p) {
		if(s==null||p==null) throw new ArgumentNullException();

		return WildcardMatching(s,0,p,0);
	}

	private bool WildcardMatching(string s, int si, string p, int pi) {
		if(pi==p.Length) return si==s.Length;

		if(p[pi]=='*') {
			if(pi==p.Length-1) return true;
			if(p[pi+1]=='*') return WildcardMatching(s,si,p,pi+1);
			while(si<s.Length) {
				if(s[si]==p[pi+1]&&WildcardMatching(s,si,p,pi+1)) return true;
				++si;
			}
			return false;
		}
		if(p[pi]=='?'||p[pi]==s[si]) return WildcardMatching(s,si+1,p,pi+1);
		return false;
	}
