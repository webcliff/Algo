// Using an adjacency matrix representation of directed graph, 
// find if a universal sink exist(a node with in-degree of n-1 and outdegree of 0). 
// If it exists you must also be able to tell the node which is the sink"

using System;

public class Test {
	public static void Main() {
		int[,] G = {
			{0,0,1,1,1},
			{0,0,0,1,0},
			{0,0,0,1,0},
			{0,0,0,0,0},
			{1,1,0,1,0}
		};

		int sink;
		if(new Test().TryFindUniversalSink(G,out sink)) {
			Console.WriteLine(sink);
		}
	}

	public bool TryFindUniversalSink(int[,] G, out int sink) {
		if(G==null) throw new ArgumentNullException("G");
		if(G.GetLength(0)!=G.GetLength(1)) throw new ArgumentException("G");

		int L=G.GetLength(0);
		int r=0,c=0;
		while(r<L&&c<L) {
			if(G[r,c]==0) ++c;
			else ++r;
		}
		sink=r;
		if(r==L) return false;
		for(int i=0;i<L;++i) {
			if(i!=sink && G[i,sink]!=1) return false;
			if(G[sink,i]!=0) return false;
		}
		return true;
	}
}
