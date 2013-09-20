using System;
using System.Text;
using System.Collections.Generic;

public class Test {

	public static void Main() {
		List<char> s = new List<char>();
		s.Add('2');s.Add('3');s.Add('4');
		List<List<char>> ss  = new Test().GetSubSet(s);
		Dump(ss);
	}

	public static void Dump<T>(List<List<T>> lists) {
		foreach(List<T> list in lists) {
			Dump(list);
		}
	}

	public static void Dump<T>(List<T> list) {
		foreach(T t in list) {
			Console.Write(t + " ");
		}
		Console.WriteLine();
	}

	// Subsets
	// Given a set of distinct integers, S, return all possible subsets.

	// Note:

	// Elements in a subset must be in non-descending order.
	// The solution set must not contain duplicate subsets.
	// For example,
	// If S = [1,2,3], a solution is:

	// [
	//   [3],
	//   [1],
	//   [2],
	//   [1,2,3],
	//   [1,3],
	//   [2,3],
	//   [1,2],
	//   []
	// ]
	public List<List<char>> GetSubSet(List<char> s) {
		List<List<char>> ss = new List<List<char>>();
		ss.Add(new List<char>());
		GetSubSet(s,0,ss,new List<char>());
		return ss;
	}

	// complxity analysis:
	// f(0) = O(1)+f(1)+f(2)+...+f(N-1)
	//  for f(N-1), there is only one element to subset, complxity is O(2^0)
	//  for f(N-2), there are only two elements to subset, complxity is O(2^1)
	//  ...
	//  for f(1), there are N-2 elements to subset, complxity is O(2^N-2)
	// f(0) = O(2^N-2 + 2^N-3 + ... + 2^0) = O(2^N-1) = O(2^N)
	// CLRS 3rd page 1147
	private void GetSubSet(List<char> s, int start,List<List<char>> ss, List<char> sofar) {
		if(start==s.Count) return;

		for(int i=start;i<s.Count;++i) {
			sofar.Add(s[i]);
			ss.Add(new List<char>(sofar));
			GetSubSet(s,i+1,ss,sofar);
			sofar.RemoveAt(sofar.Count-1);
		}
	}
}  
