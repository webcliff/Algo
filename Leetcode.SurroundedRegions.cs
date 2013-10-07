/*Given a 2D board containing 'X' and 'O', capture all regions surrounded by 'X'.

A region is captured by flipping all 'O's into 'X's in that surrounded region .

For example,
X X X X
X O O X
X X O X
X O X X
After running your function, the board should be:

X X X X
X X X X
X X X X
X O X X
*/
public void SurroundRegions(int[,] M) {
	int R=M.GetLength(0);
	int C=M.GetLength(1);
	for(int r=0;r<R;++r) {
		DFS(M,r,0);
		DFS(M,r,C-1);
	}

	for(int c=0;c<C;++c) {
		DFS(M,0,c);
		DFS(M,R-1,c);
	}

	SetRegions(M);
	Reset(M);
}

private void DFS(int[,] M, int r, int c) {
	if(M[r,c]=='-'||M[r,c]=='X') return;

	M[r,c]='-';

	List<Point> adjs = GetAdjs(M,r,c);
	foreach(Point adj in adjs) {
		DFS(M,adj.X,adj.Y);
	}
}
