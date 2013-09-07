	// Generate Parentheses
	// http://leetcode.com/onlinejudge#question_22
	// http://blog.csdn.net/ithomer/article/details/8872746
	
	// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

	// For example, given n = 3, a solution set is:

	// "((()))", "(()())", "(())()", "()(())", "()()()"

	public List<string> GenerateParentheses(int n) {
		if(n<0) throw new ArgumentException("n");
		List<string> output = new List<string>();

		GenerateParentheses(n,output,n,n,"");
		return output;
	}

	private void GenerateParentheses(int n, List<string> output, int l, int r, string str) {
		if(r==0) {
			output.Add(str); 
			return;
		}

		if(l>0) GenerateParentheses(n,output,l-1,r,str+'(');

		if(r>l) GenerateParentheses(n,output,l,r-1,str+')');
	}

