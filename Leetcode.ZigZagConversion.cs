	// ZigZag Conversion
	// http://leetcode.com/onlinejudge#question_6

	// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

	// P   A   H   N
	// A P L S I I G
	// Y   I   R
	// And then read line by line: "PAHNAPLSIIGYIR"
	// Write the code that will take a string and make this conversion given a number of rows:

	// string convert(string text, int nRows);
	// convert("PAYPALISHIRING", 3) should return "PAHNAPLSIIGYIR".
	//
	public string ZigZagConversion(string text, int rows) {
		if(text==null||rows<1) throw new ArgumentException();

		int distance=rows*2-2;
		StringBuilder sb = new StringBuilder();
		for(int k=0;k<rows;++k) {
			int i=k;
			while(i<text.Length) {
				sb.Append(text[i]);
				
				int offset=distance-k*2;

				if(k!=0&&k!=rows-1) {
					if(i+offset<text.Length) sb.Append(text[i+offset]);
				}
				i+=distance;
			}
		}
		return sb.ToString();
	}

