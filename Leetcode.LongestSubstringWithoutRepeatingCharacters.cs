	// Longest Substring Without Repeating Characters
	// http://leetcode.com/onlinejudge#question_3
	
	// Given a string, find the length of the longest substring without repeating characters. 
	// For example, the longest substring without repeating letters for "abcabcbb" is "abc", 
	// which the length is 3. For "bbbbb" the longest substring is "b", with the length of 1.
	public int LongestSubstringWithoutRepeatingCharacters(string S) {
		if(S==null) throw new ArgumentNullException();

		int max=0,l=0;
		Dictionary<char,int> table = new Dictionary<char,int>();
		for(int i=0;i<S.Length;++i) {
			char c= S[i];
			if(table.ContainsKey(c)) {
				l=i-table[c];
				max=Math.Max(max,l); 
			}
			else ++l;

			table[c]=i;
		}
		max=Math.Max(max,l); 
		return max;
	}


// does not work
// repro case: abba
