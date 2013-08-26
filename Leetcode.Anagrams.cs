	// http://leetcode.com/onlinejudge#question_49

	// Anagrams          Mar 19 '12
	// Given an array of strings, return all groups of strings that are anagrams.

	// Note: All inputs will be in lower-case.
	public List<List<string>> Anagrams(List<string> input) {
		if(input==null) throw new ArgumentNullException("input");

		Dictionary<string,List<string>> map = new Dictionary<string,List<string>>();
		foreach(string str in input) {
			string key=GetKey(str);
			if(!map.ContainsKey(key)) map[key] = new List<string>();
			map[key].Add(str);
		}

		List<List<string>> anagrams = new List<List<string>>();
		foreach(KeyValuePair<string,List<string>> kvp in map) {
			if(kvp.Value.Count<2) continue;
			anagrams.Add(kvp.Value);
		}

		return anagrams;
	}

	// "abcb" -> a1b2c1
	// O(N) 
	private string GetKey(string str) {
		int[] table = new int['z'-'a'+1];
		for(int i=0;i<table.Length;i++) table[i]=0;

		foreach(char c in str) {
			table[c-'a']+=1;
		}

		StringBuilder sb=new StringBuilder();
		foreach(int i in table) {
			if(table[i]==0) continue;
			sb.AppendFormat("{0}{1}",i+'a',table[i]);
		}
		return sb.ToString();
	}
