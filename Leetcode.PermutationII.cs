
	// http://leetcode.com/onlinejudge#question_47

	// Permutations II 	Mar 17
	// Given a collection of numbers that might contain duplicates, return all possible unique permutations.

	// For example,
	// [1,1,2] have the following unique permutations:
	// [1,1,2], [1,2,1], and [2,1,1].
	//
	public List<List<int>> PermutationsII(List<int> input) {
		if(input==null) throw new ArgumentNullException();

		List<List<int>> output = new List<List<int>>();

		List<int> sorted_input = new List<int>(input);
		Sort(sorted_input, 0, sorted_input.Count-1);

		PermutationsII(sorted_input,output,new bool[input.Count],new List<int>(input.Count));

		return output;
	}

	// Consider "1112", 1 can have 3x2x1 permutation by itself, only allow one to remove the duplication.
	//
	private void PermutationsII(List<int> input, List<List<int>> output, bool[] visited,List<int> s) {
		if(s.Count==input.Count) {
			output.Add(new List<int>(s));
			return;
		}

		for(int i=0;i<input.Count;++i) {
			if(visited[i]) continue;

			// this to make sure for duplicated ones, only one permutation is allowed.
			if(i>0 && input[i]==input[i-1] && visited[i-1]==false) continue;

			visited[i]=true;
			s.Add(input[i]);
			PermutationsII(input,output,visited,s);
			s.RemoveAt(s.Count-1);
			visited[i]=false;
		}
	}

	// Or call List<T>.Sort()
	// QuickSort
	private void Sort(List<int> input, int l, int r) {
		if(l>=r) return;

		int m = Partition(input,l,r);
		Sort(input,l,m-1);
		Sort(input,m+1,r);
	}

	private int Partition(List<int> input, int l, int r) {
		int p=input[r];
		int pl=l,pr=l;
		while(pr<r) {
			if(input[pr]<p) {
				swap(input,pl,pr);
				++pl;
			}
			++pr;
		}
		swap(input,pl,r);
		
		return pl;
	}

	private void swap(List<int> input, int l, int r) {
		int t=input[r]; input[r]=input[l];input[l]=t;
	}
