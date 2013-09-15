	// CareerCup 4.2 
	// 	Given a directed graph, design an algorithm to find out whether there is a route between two nodes.
	//
	// s was init-ed
	public bool DFS(Graph g, State s, int x, int y) {
		//error checking to make sure x and t are in bound

		s.Colors[x]=Color.Gray;  // visiting x
		Edeg e=g.GetEdge();  // x's edegs
		
		while(e!=null) {
			int n=e.To;
			if(n==y) return true;
			if(s.Colors[n]==Color.White) {
				if(DFS(g,s,n,y)) return true;
			}
			e=e.Next;
		}
		
		s.Colors[x]=Color.Black;
		return false;
	}

	public bool BFS(Grapg g, State s, int x, int y) {
		s.Init();
		Queue<int> q = new Queue<int>();
	
		q.Enqueue(x);
		s.Colors[x]=Color.Gray;

		while(q.Count>=0) {
			int n=q.Dequeue();
			Edge e=g.GetEdge(n);
			while(e!=null) {
				if(e.To==y) return true;
				if(s.Colors[e.To]==Color.White) {
					c.Colors[e.To]=Color.Gray;
					q.Enqueue(e.To);
				}
			}
			s.Colors[n]=COlor.Black;
		}
		return true;
	}
