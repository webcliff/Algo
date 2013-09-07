using System;
using System.Collections.Generic;

// A Minimal Queue
public class PriorityQueue<T> where T : IComparable<T>, new() {
	
	private List<T> mHeap;

	public PriorityQueue() {
		mHeap = new List<T>();
		mHeap.Add(new T());
	}

	public bool Empty() {
		return Size()==0;
	}

	public int Size() {
		return mHeap.Count-1;
	}

	public T Top() {
		if(Empty()) throw new InvalidOperationException("empty queue");
		return mHeap[1];
	}

	public void Pop() {
		if(Empty()) return;
		swap(mHeap,1,mHeap.Count-1);
		mHeap.RemoveAt(mHeap.Count-1);
		MoveDown(1);
	}

	public void Push(T t) {
		mHeap.Add(t);
		MoveUp(mHeap.Count-1);
	}

	private int GetParent(int i) { return i/2;}
	private int GetLeftChild(int i) { return i*2;}
	private int GetRightChild(int i) { return i*2+1;}

	private void MoveUp(int i) {
		while(i>1) {
			int p=GetParent(i);
			if(mHeap[i].CompareTo(mHeap[p])>0) break;
			swap(mHeap,p,i);
			i=p;
		}
	}

	private void MoveDown(int i) {
		int lc = GetLeftChild(i);
		int rc = GetRightChild(i);
		if(lc>=mHeap.Count) return;

		if(rc<mHeap.Count && mHeap[lc].CompareTo(mHeap[rc])>0) lc=rc;

		if(mHeap[i].CompareTo(mHeap[lc])>0) swap(mHeap,i,lc);
		
		// Recusive for clean code
		MoveDown(lc);
	}

	private static void swap(List<T> heap, int a, int b) {
		T t=heap[a]; heap[a]=heap[b]; heap[b]=t;
	}
}

public class Test {
		public static void Main() {
		PriorityQueue<int> pq = new PriorityQueue<int>();
		pq.Push(13);
		pq.Push(8);
		pq.Push(13);
		pq.Push(19);
		pq.Push(10);

		Console.WriteLine(pq.Top());
		pq.Pop();
		Console.WriteLine(pq.Top());
		pq.Pop();
		Console.WriteLine(pq.Top());
		pq.Pop();
		Console.WriteLine(pq.Top());
		pq.Pop();
		Console.WriteLine(pq.Top());
		pq.Pop();
	}
}
