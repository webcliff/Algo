	// 3.4 In the classic problem of the Towers of Hanoi, you have 3 rods and N disks of 
	// different sizes which can slide onto any tower. The puzzle starts with disks sorted 
	// in ascending order of size from top to bottom (e.g., each disk sits on top of an even
	//  larger one). You have the following constraints: 
	// (A) Only one disk can be moved at a time. 
	// (B) A disk is slid off the top of one rod onto the next rod. 
	// (C) A disk can only be placed on top of a larger disk. 
	// Write a program to move the disks from the first rod to the last using Stacks.
	
	public void TowersOfHanoi(int N) {
		TowersOfHanoi(N,1,3,2);
	}

	private void TowersOfHanoi(int n, int f, int t, int b) {
		if(n==0) return;

		TowersOfHanoi(n-1,f,b,t);
		Console.WriteLine("Move {0} from {1} to {2}", n,f,t);
		TowersOfHanoi(n-1,b,t,f);
	}
