	// Count and Say
	// http://leetcode.com/onlinejudge#question_38
	
	// The count-and-say sequence is the sequence of integers beginning as follows:
	// 1, 11, 21, 1211, 111221, ...

	// 1 is read off as "one 1" or 11.
	// 11 is read off as "two 1s" or 21.
	// 21 is read off as "one 2, then one 1" or 1211.

	// Given an integer n, generate the nth sequence.

	// Note: The sequence of integers will be represented as a string.
	public string CountAndSay(int n) {
		if(n<1) throw new ArgumentNullException();

		StringBuilder sb1 = new StringBuilder("1");
		StringBuilder sb2=new StringBuilder();

		while(n>1) {
			int p1=0,p2=0;
			while(p2<=sb1.Length) {
				if(p2==sb1.Length||sb1[p1]!=sb1[p2]) {
					sb2.Append(p2-p1).Append(sb1[p1]);
					p1=p2;
				}
				++p2;
			}
			
			StringBuilder sbt=sb2;
			sb2=sb1;sb1=sbt;
			sb2.Clear();
			--n;
		}

		return sb1.ToString();
	}
