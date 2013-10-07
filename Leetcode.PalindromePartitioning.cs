/*
Given a string s, partition s such that every substring of the partition is a palindrome.

Return all possible palindrome partitioning of s.

For example, given s = "aab",
Return

  [
    ["aa","b"],
    ["a","a","b"]
  ]
  */
public List<List<string>> PalindromePartitioning(string S, int start, List<List<string>> output, List<string> sofar) {
	if(start>=S.Length) {
		output.Add(new List<string>(soFar));
		return;
	}

	for(int i=start;i<S.Length;++i) {
		if(IsPalindrome(S,start,i)==false) continue;

		sofar.Add(S.Substring(start,i-start+1));

		PalindromePartitioning(S,i+1,output,sofar);

		sofar.RemoveAt(sofar.Count-1);
	}
}
