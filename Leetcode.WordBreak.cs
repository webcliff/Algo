
/*

Word Break 

Given a string s and a dictionary of words dict, determine if s can be segmented into a space-separated sequence of one or more dictionary words.

For example, given
s = "leetcode",
dict = ["leet", "code"].

Return true because "leetcode" can be segmented as "leet code".

==========================================
f(i) -> S[i...N-1] can be devided into words
f(i)      =     true if(S[i...k] is word) && f(k+1)
0<=i<N              i<=k<N-1
 
 */

public bool WordBreak(string S) {
	int N=S.Length;
	bool[] f = new bool[N+1];
	f[N]=true;

	for(int i=N-1;i>=0;--i) {
		for(int k=i;k<N;++k) {
			if(f[k+1]&&IsWord(S.Substring(i,k-i+1))) {
				f[i] = true;
				break;
			}
		}
		f[i]=false;
	}

	return f[0];
}
