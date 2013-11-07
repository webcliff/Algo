// 写一个程序，找出 5^1234566789893943的从底位开始的1000位数字。
// http://www.mitbbs.com/article_t/JobHunting/32518627.html
using System;
using System.Text;

public class Test {

	//
	// when y is 0:
	// f(x,y) = 1
	// when y is odd 
	// f(x,y) = (f(x,y-1)*f(x,1))%1000
	// when y is even
	// f(x,y) = (f(x,y/2)*f(x,y/2))%1000
	//
	public string FindLowest1000DigitsOutofHugeXSquareY(uint X, ulong Y) {
		if(Y==0) return "1";
		if(Y%2==0) {
			string half = FindLowest1000DigitsOutofHugeXSquareY(X,Y/2);
			return MultipleBigInt(half,half,1000);
		}
		string minusOne = FindLowest1000DigitsOutofHugeXSquareY(X,Y-1);
		return MultipleBigInt(minusOne,X.ToString(), 1000);
	}

	private string MultipleBigInt(string A,string B,int M) {
		StringBuilder product = new StringBuilder();

		int factor=1;
		for(int a=A.Length-1;a>=0;--a) {
			AddTo(product,Multiple(B,A[a],factor));
			if(product.Length>M) {
				product.Remove(0,product.Length-M);
			}
			factor *= 10;
		}
		return product.ToString();
	}

	private string Multiple(string B, char a, int factor) {
		StringBuilder product = new StringBuilder();
		while(factor>=10) {
			product.Append('0'); factor/=10;
		}
		int carry=0, ia=a-'0';
		for(int b=B.Length-1;b>=0;--b) {
			int ib=B[b]-'0';
			int p=ib*ia+carry; 
			carry=p/10; p=p%10;
			product.Insert(0,(char)(p-'0'));
		}
		if(carry>0) product.Insert(0,carry);
		return product.ToString();
	}

	private void AddTo(StringBuilder target, string source) {
		string tsrc = target.ToString();
		target.Clear();

		int t=tsrc.Length-1,s=source.Length-1;
		int carry=0;

		while(t>=0||s>=0) {
			int ti= (t>=0?tsrc[t]-'0':0);
			int si= (s>=0?source[s]-'0':0);
			si +=ti+carry;
			carry=si/10; si=si%10;
			target.Insert(0,(char)(si+'0'));
			--t;--s;
		}
		if(carry>0) target.Insert(0,(char)(carry+'0'));
	}
}
