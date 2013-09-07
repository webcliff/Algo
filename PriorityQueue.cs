using System;
using System.Collections.Generic;

// MinQueue
public class PriorityQueue<T> where T : IComparable<T>, new() {
	
	private List<T> mHeap;

	public PriorityQueue(int capacity) {
		mHeap = new List<T>(capacity+1);
		mHeap.Add(new T());
	}

	public bool Empty() {
		return Size()==0;
	}

	public int Size() {
		return mHeap.Count-1;
	}

	// O(1)
	public T Top() {
		if(Empty()) throw new InvalidOperationException("empty queue");
		return mHeap[1];
	}

	// O(logN)
	public void Pop() {
		if(Empty()) return;
		swap(mHeap,1,mHeap.Count-1);
		mHeap.RemoveAt(mHeap.Count-1);
		MoveDown(1);
	}

	// O(logN)
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

		// recursively for clean code
		MoveDown(lc);
	}

	private static void swap(List<T> heap, int a, int b) {
		T t=heap[a]; heap[a]=heap[b]; heap[b]=t;
	}
}
