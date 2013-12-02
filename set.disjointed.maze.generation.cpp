//C:\Chen\SkyDrive\Books\Algorithm\Disjoint Set\h29.pdf
//www.cis.upenn.edu/~cse220/h29.pdf
#include <iostream>
#include <vector>
#include <utility>
#include <memory>
#include <stdexcept>
#include <cstdlib>
#include <ctime>

using namespace std;

typedef unique_ptr<int[]> auto_array;
typedef pair<int,int> wall;
typedef vector<wall*> walls;

class disjoint_set {
	public:
		disjoint_set(size_t r,size_t c);
		void union_set(int a, int b);
		int find_set(int a);
		size_t size() const;

	private:
		void update_parent(int new_p, int new_c);

	private:
		size_t mR;
		size_t mC;
		size_t mLen;
		auto_array pArray;
};

disjoint_set::disjoint_set(size_t r,size_t c) : mR(r),mC(c),mLen(r*c) {
	pArray = auto_array(new int[r*c]);
	for(int i=0;i<mLen;++i) pArray[i]=-1;
}
// weighted union heuristic
void disjoint_set::union_set(int a, int b) {
	int set_a=find_set(a);
	int set_b=find_set(b);
	if(set_a==set_b) return; // already same set

	if(pArray[set_a]<pArray[set_b]) update_parent(set_a,set_b);
	else update_parent(set_b,set_a);
}
// path compression
int disjoint_set::find_set(int a) {
	if(a<0||a>=mLen) throw invalid_argument("a");
	if(pArray[a]<0) return a;
	pArray[a]=find_set(pArray[a]);
	return pArray[a];
}
inline size_t disjoint_set::size() const {
	return mLen;
}
inline void disjoint_set::update_parent(int new_p, int new_c) {
	pArray[new_p]+=pArray[new_c];
	pArray[new_c]=new_p;
}

inline int get_neighbours(int sa,size_t R,size_t C) {

	int b1=0; int b2=C-1; int b3=R*C-C; int b4=R*C-1;
	
	if(sa==b1) {
		int s=rand()%2; return (s==0 ? sa+1 : sa+C);
	}
	else if(sa==b2) {
		int s=rand()%2; return (s==0 ? sa-1 : sa+C);
	}
	else if(sa==b3) {
		int s=rand()%2; return (s==0 ? sa+1 : sa-C);
	}
	else if(sa==b4) {
		int s=rand()%2; return (s==0 ? sa-1 : sa-C);
	}
	else if(sa>b1&&sa<b2) {
		int s=rand()%3; 
		if(s==0) return sa-1;
		else if(s==1) return sa+1;
		else return sa+C;
	}
	else if(sa>b3&&sa<b4) {
		int s=rand()%3; 
		if(s==0) return sa-1;
		else if(s==1) return sa+1;
		else return sa-C;
	}
	else if(sa%C==0&&sa!=b1&&sa!=b3) {
		int s=rand()%3; 
		if(s==0) return sa+1;
		else if(s==1) return sa-C;
		else return sa+C;
	}
	else if(sa%C==C-1&&sa!=b2&&sa!=b4) {
		int s=rand()%3; 
		if(s==0) return sa-1;
		else if(s==1) return sa-C;
		else return sa+C;
	}
	else
	{
		int s=rand()%4; 
		if(s==0) return sa-1;
		else if(s==1) return sa+1;
		else if(s==2) return sa-C;
		else return sa+C;
	}
}

walls *maze_gen(size_t R,size_t C) {

	disjoint_set dset(R,C);
	walls *paths=new walls();
	srand(time(NULL));

	while(dset.find_set(0)!=dset.find_set(dset.size()-1)) {
		int va=rand()%dset.size();
		int vb=get_neighbours(va,R,C);
		if(dset.find_set(va)!=dset.find_set(vb)) {
			dset.union_set(va,vb);
			paths->push_back(new wall(va,vb));
		}
	}
	return paths;
}

void main() {
	walls *paths = maze_gen(7,8);
	for(auto it=paths->begin();it!=paths->end();++it) {
		cout<<(*it)->first<<','<<(*it)->second<<endl;
	}
}
