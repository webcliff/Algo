	// Valid Parentheses
	// http://leetcode.com/onlinejudge#question_20
	
	// Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

	// The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.

	public bool ValidParentheses(string str) {
		if(str==null) throw new ArgumentNullException("str");
		Stack<char> s = new Stack<char>();
		int i=0;
		while(i<str.Length) {
			if(str[i]=='('||str[i]=='{'||str[i]=='[') {
				s.Push(str[i]);
				++i; continue;
			}

			if(s.Count==0) return false;

			if( (str[i]==')'&&s.Peek()=='(') || 
				(str[i]=='}'&&s.Peek()=='{') ||
				(str[i]==']'&&s.Peek()=='[')) {
				s.Pop();
				++i; continue;
			}
			return false;

		}
		return s.Count==0;
	}
