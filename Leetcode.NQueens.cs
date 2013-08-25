	// LeetCode : N-Queens
	// http://leetcode.com/onlinejudge#question_51

	// The n-queens puzzle is the problem of placing n queens on an n�n chessboard such that no two queens attack each other.

	// Given an integer n, return all distinct solutions to the n-queens puzzle.

	// Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space respectively.

	// For example,
	// There exist two distinct solutions to the 4-queens puzzle:

	// [
	//  [".Q..",  // Solution 1
	//   "...Q",
	//   "Q...",
	//   "..Q."],

	//  ["..Q.",  // Solution 2
	//   "Q...",
	//   "...Q",
	//   ".Q.."]
	// ]

	public List<List<string>> NQueens(int N) {
		if(N<0) throw new ArgumentException("N");

		List<List<int>> soFar = new List<List<int>>();

		NQueens(N,soFar,new List<int>(N), new bool[N]);

		return Convert(soFar);
	}

	private void NQueens(int N, List<List<int>> soFar, List<int> placement, bool[] visited) {
		if(placement.Count==N) {
			if(ValidPlacement(placement)) soFar.Add(new List<int>(placement));
			return;
		}
		for(int i=0;i<N;++i) {
			if(visited[i]) continue;

			visited[i]=true;
			placement.Add(i);

			NQueens(N,soFar,placement,visited);

			placement.RemoveAt(placement.Count-1);
			visited[i]=false;
		}
	}

	// for (r1,c1) and (r2,c2)
	// 	c2-c1==r2-r1 or c2-c1==r1-r2
	private bool ValidPlacement(List<int> placement) {
		for(int i=0;i<placement.Count;++i) {
			for(int j=i+1;j<placement.Count;++j) {
				 int delta = placement[i]-placement[j];
				 if(delta==i-j || delta==j-i) return false;
			}
		}
		return true;
	}

	private List<List<string>> Convert(List<List<int>> placements) {
		const char QUEEN = 'Q', EMPTY='.';
		List<List<string>> solutions = new List<List<string>>(placements.Count);
		foreach(List<int> placement in placements) {
			List<string> solution = new List<string>(placement.Count);
			foreach(int i in placement) {
				StringBuilder sb = new StringBuilder();
				int k=0;
				while(k<i) { sb.Append(EMPTY); k++; }
				sb.Append(QUEEN);
				k+=1;
				while(k<placement.Count) { sb.Append(EMPTY); k++; }
				solution.Add(sb.ToString());
			}
			solutions.Add(solution);
		}
		return solutions;
	}
