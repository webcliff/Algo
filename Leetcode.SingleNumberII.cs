using System;

public class Test {
	public static void Main() {
		int[] A = {3,3,3,5,4,4,4};
		Console.WriteLine(new Test().FindSingleNumber(A));
	}
	public int FindSingleNumber(int[] A) {
		int[] B=new int[32];
		int n=0;

		for(int i=0;i<32;++i) {
			for(int j=0;j<A.Length;++j) {
				if(((A[j]>>i)&1)!=0) B[i]=(B[i]+1)%3;
			}
			if(B[i]>0) n=n|(1<<i);
		}
		return n;
	}
}

/*

http://www.mitbbs.com/article_t/JobHunting/32547143.html

创建一个长度为32的数组a，a[i]表示所有数字在i位出现的次数。
假如a[i]是3的整数倍，则忽略；否则就把该位取出来组成答案。
空间复杂度O(1).

int sol1(int A[], int n)
{
    int count[32];
    int result = 0;
    for (int i = 0;i < 32;++i) {
        count[i] = 0;
        for (int j = 0;j < n;++j) {
            if ((A[j] >> i) & 1) count[i] = (count[i] + 1) % 3;
        }
        result |= (count[i] << i);
    }
    return result;
}

另一个方法，同样的原理，用3个整数来表示INT的各位的出现次数情况，one表示出现
了1次，two表示出现了2次。当出现3次的时候该位清零。最后答案就是one的值。

int sol2(int A[], int n)
{
    int one = 0, two = 0, three = 0;
    for (int i = 0;i < n;++i) {
        two |= one & A[i];
        one ^= A[i];
        three = one & two;
        one &= ~three;
        two &= ~three;
    }
    return one;
}
*/
