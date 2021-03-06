	// Two Sum
	// http://leetcode.com/onlinejudge#question_1
		
	// Given an array of integers, find two numbers such that they add up to a specific target number.

	// The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.

	// You may assume that each input would have exactly one solution.

	// Input: numbers={2, 7, 11, 15}, target=9
	// Output: index1=1, index2=2
	public int[] TwoSum(int[] numbers,  int sum) {
		if(numbers==null) throw new ArgumentNullException("numbers");

		int[] indices = new int[2];
		Dictionary<int,int> table = new Dictionary<int,int>();
		for(int i=0;i<numbers.Length;++i) {
			if(table.ContainsKey(numbers[i])) {
				indices[0]=table[numbers[i]];indices[1]=i;
				break;
			}
			table[sum-numbers[i]]=i;
		}
		return indices;
	}
