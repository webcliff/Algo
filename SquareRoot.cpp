// http://leetcode.com/groups/facebook-interviews/forum/topic/implement-sqrtx/
// Implement sqrt(x) to calculate square root of a float point valus x.
// Newton-rhapson method is not allowed.
//
// binary search
float square_root(float x) {
	if(x<0) throw invalid_argument("x");
	float eps=1e-5;
	float l=0,r=x;
	while(true) {
		float p=l/2+r/2;
		float delta=p*p-x;
		if(delta>eps) r=p;
		else if(delta<-1*eps) l=p;
		else return p;
	}
}

///////////////////////////////////////

// http://en.wikipedia.org/wiki/Newton's_method#Pseudocode

// for derivative:
// if f(x)=x^r, then f'(x)=r*x^(r-1)

// given f(x)=x^2-y
// x1=x0-f(x)/f'(x)


#include <iostream>
#include <stdexcept>

using namespace std;

float square_root(float y) {
	if(y<0) throw invalid_argument("y");

	float x0=1.0, epsilon=1e-27;
	while(true) {
		float x1=x0/2+y/(x0*2);
		if(abs(x1-x0)<epsilon) return x1;
		x0=x1;
	}
}



