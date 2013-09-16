	// Longest Palindromic Substring 
	// http://leetcode.com/onlinejudge#question_5
	
	// Given a string S, find the longest palindromic substring in S. 
	// You may assume that the maximum length of S is 1000, and there 
	// exists one unique longest palindromic substring.
	////////////////////////
	// DP
	// f(i,j) -> true if S[i]~S[j] is palindrome
	// f(i,i) = true
	// f(i,i+1) = S[i]==S[i+1]
	// f(i,j) = f(i+1,j-1) && S[i]==S[j]
	//
	public string FindLongestPalindromicSubstring(string S) {
		if(S==null) throw new ArgumentNullException("S");
		if(S.Length<2) return S;

		bool[,] f = new bool[S.Length,S.Length];
		int maxLen=int.MinValue, start=int.MinValue;
		for(int i=S.Length-1;i>=0;--i) {
			for(int j=i;j<S.Length;++j) {
				if(i==j) f[i,j]=true;
				else if(j==i+1) f[i,j]=(S[i]==S[j]);
				else f[i,j]=(f[i+1,j-1]&&S[i]==S[j]);

				if(f[i,j]&&(j-i+1)>maxLen) {
					maxLen=j-i+1; start=i;
				}
			}
		}
		return S.Substring(start,maxLen);
	}
