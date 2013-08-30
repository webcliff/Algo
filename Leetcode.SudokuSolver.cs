	// Sudoku Solver 
	// http://leetcode.com/onlinejudge#question_37
	
	// Write a program to solve a Sudoku puzzle by filling the empty cells.

	// Empty cells are indicated by the character '.'.

	// You may assume that there will be only one unique solution.

	public void SudokuSolver(char[,] sudoku) {
		Impl(sudoku);
	}

	private bool Impl(char[,] sudoku) {
		int r,c;
		if(!TryGetFirstEmptyCell(sudoku,out r,out c)) return true;

		char[] digits = GetCandidates(sudoku,r,c);

		foreach(char d in digits) {
			sudoku[r,c]=d;
			if(Impl(sudoku)) return true;
			sudoku[r,c]='.';
		}

		return false;
	}

	private bool TryGetFirstEmptyCell(char[,] sudoku, out int r, out int c) {
		c=0;
		for(r=0;r<sudoku.GetLength(0);++r) {
			for(c=0;c<sudoku.GetLength(1);++c) {
				if(sudoku[r,c]=='.') return true;
			}
		}
		return false;
	}

	private char[] GetCandidates(char[,] sudoku, int r, int c) {
		HashSet<char> allDs = new HashSet<char>();
		for(int i=1;i<10;++i) allDs.Add((char)(i+'0'));

		int R=sudoku.GetLength(0), C=sudoku.GetLength(1);
		for(int i=0;i<R;++i) {
			if(sudoku[r,i]!='.') allDs.Remove(sudoku[r,i]);
			if(sudoku[i,c]!='.') allDs.Remove(sudoku[i,c]);
		}

		int r1=r-r%3,c1=c-c%3;
		for(int i=r1;i<=r1+2;++i) {
			for(int j=c1;j<=c1+2;++j) {
				if(sudoku[i,j]!='.') allDs.Remove(sudoku[i,j]);
			}
		}

		char[] ds = new char[allDs.Count];
		allDs.CopyTo(ds);

		return ds;
	}

	public static void Main() {
		char[,] board = {{'5','3','.','.','7','.','.','.','.'},  
		                 {'6','.','.','1','9','5','.','.','.'},  
		                 {'.','9','8','.','.','.','.','6','.'},  

		                 {'8','.','.','.','6','.','.','.','3'},  
		                 {'4','.','.','8','.','3','.','.','1'},  
		                 {'7','.','.','.','2','.','.','.','6'},  

		                 {'.','6','.','.','.','.','2','8','.'},  
		                 {'.','.','.','4','1','9','.','.','5'},  
		                 {'.','.','.','.','8','.','.','7','9'}};

		new Test().SudokuSolver(board);

	    for (int i = 0; i < 9; i++) {  
	    	for (int j = 0; j < 9; j++) {  
	    	    Console.Write(board[i,j] + " ");  
	        }  
	        Console.WriteLine();  
	    }  
  }
