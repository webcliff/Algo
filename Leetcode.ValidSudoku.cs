	// Valid Sudoku

	// http://leetcode.com/onlinejudge#question_36

	// Determine if a Sudoku is valid, according to: Sudoku Puzzles - The Rules.

	// The Sudoku board could be partially filled, where empty cells are filled with the character '.'.

	public bool ValidSudoku(char[,] board) {
		if(board==null) throw new ArgumentNullException("board");
		if(board.GetLength(0)!=9||board.GetLength(1)!=9) return false;

		bool[,] rows = new bool[9,9], columns=new bool[9,9], blocks=new bool[9,9];
		for(int r=0;r<9;++r) {
			for(int c=0;c<9;++c) {
				char C = board[r,c];
				if(C=='.') continue;
				if(C>'9'||C<'1') return false;

				int d=C-'1';
				int blockNo = 3*(r/3)+(c/3);
				if(rows[r,d]||columns[c,d]||blocks[blockNo,d]) return false;

				rows[r,d] = true;
				columns[c,d] = true;
				blocks[blockNo,d] = true;
			}
		}
		return true;
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

		Console.WriteLine(new Test().ValidSudoku(board));
	}
