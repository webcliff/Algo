	// Want to enumerate all rearrangements:
	// ABC permutes to ABC,ACB,BAC,BCA,CAB,CBA
	//////////////
	//
	// Solution 1
	// 	http://www.youtube.com/watch?v=uFJhEPrbycQ
	//
	public void ListPermutation(string s) {
		RecPermutation("",s);
	}
	private void RecPermutation(string soFar, string rest) {
		if(rest.Length==0) {
			Console.WriteLine(soFar);
			return;
		}

		for(int i=0;i<rest.Length;++i) {
			string next = soFar + rest[i];
			string remaining = rest.Substring(0,i) + rest.Substring(i+1);
			RecPermutation(next, remaining);
		}
	}

	//
	// Solution 2
	//
	public void ListPermutation(string s) {
		RecPermutation(new StringBuilder(),s,new bool[s.Length],0);
	}

	private void RecPermutation(StringBuilder soFar, string s, bool[] visited, int step) {
		if(soFar.Length==s.Length) {
			Console.WriteLine(soFar.ToString());
			return;
		}

		for(int i=0;i<s.Length;++i) {
			if(visited[i]) continue;

			visited[i]=true;
			soFar.Append(s[i]);
			RecPermutation(soFar, s, visited, step+1);
			soFar.Remove(soFar.Length-1,1);
			visited[i]=false;
		}
	}
