	// Letter Combinations of a Phone Number
	// http://leetcode.com/onlinejudge#question_17
	
	// Given a digit string, return all possible letter combinations that the number could represent.

	// A mapping of digit to letters (just like on the telephone buttons) is given below.

	// Input:Digit string "23"
	// Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
	// Note:
	// Although the above answer is in lexicographical order, your answer could be in any order you want.

	public List<string> LetterCombinationsOfAPhoneNumber(Dictionary<char,char[]> table, string phone) {
		if(phone==null) throw new ArgumentNullException("phone");

		List<string> output = new List<string>();

		LetterCombinationsOfAPhoneNumber(table, phone, output, 0, "");

		return output;
	}

	private void LetterCombinationsOfAPhoneNumber(
		Dictionary<char,char[]> table, string phone, List<string> output, int start, string str) {
		if(str.Length==phone.Length) {
			output.Add(str);
			return;
		}

		for(int i=start;i<phone.Length;++i) {
			char[] letters = table[phone[start]];
			for(int l=0;l<letters.Length;++l) {
				LetterCombinationsOfAPhoneNumber(table,phone,output,i+1,str+letters[l]);
			}
		}
	}

	private static void Dump<T>(List<List<T>> llstr) {
		foreach(List<T> lstr in llstr) {
			Dump<T>(lstr);
		}
	}

	private static void Dump<T>(IList<T> lstr) {
		foreach(T str in lstr) {
			Console.Write(str);
			Console.Write(" ");
		}
		Console.WriteLine();
	}

	public static void Dump(Node head) {
		while(head!=null) {
			Console.Write(head.Value);
			Console.Write("->");
			head=head.Next;
		}
		Console.WriteLine();
	}

	public static void Main() {
		Dictionary<char,char[]> table = new Dictionary<char,char[]>();
		table['2'] = new char[] {'a','b','c'};
		table['3'] = new char[] {'d','e','f'};

		List<string> words = new Test().LetterCombinationsOfAPhoneNumber(table, "23");

		Dump(words);
	}
