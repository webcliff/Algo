#include <iostream>
#include <cstdio>
#include <vector>
#include <stack>
#define NA -1
using namespace std;

typedef struct edge {
	edge(int n,int w,edge *p) : y(n),weight(w),next(p) {}
	int y;
	int weight;
	edge *next;
} edge;

class graph {
public:
	graph(size_t nodeCnt);
	~graph();
	void add_edge(int x,int y,int w);
	int node_size() const;
	edge *get_edge(int x) const;

private:
	vector<edge*> edges;
};

graph::graph(size_t nodeCnt) {
	edges.resize(nodeCnt);
	for(auto it=edges.begin();it!=edges.end();++it) *it=NULL;
}
graph::~graph() {
	for(auto it=edges.begin();it!=edges.end();++it) {
		edge *p=*it;
		while(p) {
			edge *t=p; p=p->next;
			delete t;
		}
	}
}
void graph::add_edge(int x,int y,int w) {
	edge* e=new edge(y,w,edges[x]);
	edges[x]=e;
}
int graph::node_size() const {
	return edges.size();
}
edge *graph::get_edge(int x) const {
	return edges[x];
}

enum color {WHITE,GRAY,BLACK};

typedef struct state {
	void init(size_t nodeCnt);
	void print();
	vector<color> colors;
	vector<int> dtimes; // discovered time
	vector<int> ftimes; // finished time
	vector<int> preds; // precedents
	vector<int> distances;
} state;

void state::init(size_t nodeCnt) {
	colors.resize(nodeCnt);
	dtimes.resize(nodeCnt);
	ftimes.resize(nodeCnt);
	preds.resize(nodeCnt);
	distances.resize(nodeCnt);
	for(int i=0;i<nodeCnt;++i) {
		colors[i]=WHITE;
		dtimes[i]=ftimes[i]=NA;
		preds[i]=NA;
		distances[i]=NA;
	}
}

void state::print() {
	for(int i=0;i<colors.size();++i) {
		cout<<i;
		cout<<" color:"<<colors[i];
		cout<<" dtime:"<<dtimes[i];
		cout<<" ftime:"<<ftimes[i];
		cout<<" pred:"<<preds[i];
		cout<<" distance:"<<distances[i];
		cout<<endl;
	}
}

graph *read_graph(string file) {
	FILE *fs=fopen(file.c_str(),"r");
	if(!fs) throw runtime_error("i/o error");

	size_t size;
	fscanf(fs,"%d\n", &size);

	graph *g=new graph(size);
	while(true) {
		int x,y,w;
		fscanf(fs,"%d %d %d\n",&x,&y,&w);
		if(ferror(fs)) throw runtime_error("i/o error");
		g->add_edge(x,y,w);
		if(feof(fs)) break;
	}
	return g;
}


void dfs(graph *g,state &s,stack<int> &t,int &time,int start) {
	if(start>g->node_size()-1) throw invalid_argument("start");

	s.colors[start]=GRAY;
	s.dtimes[start]=time; ++time;

	edge *p=g->get_edge(start);
	while(p) {
		int y=p->y;
		if(s.colors[y]==WHITE) {
			s.preds[y]=start;
			s.distances[y]=s.distances[start]+p->weight;

			dfs(g,s,t,time,y);
		}
		p=p->next;
	}
	s.colors[start]=BLACK;
	s.ftimes[start]=time; ++time;
	t.push(start);
}

void dfs(graph *g, state &s,stack<int> &t) {
	s.init(g->node_size());
	int time=0;
	for(int i=0;i<g->node_size();++i) {
		if(s.colors[i]==WHITE) {
			s.distances[i]=0;
			dfs(g,s,t,time,i);
		}
	}
}

void print_path(state &s,int start, int end) {
	if(end==NA) return;
	print_path(s,start,s.preds[end]);
	cout<<' '<<end;
}

void main() {
	graph *g=read_graph("graph.data.txt");
	state s; stack<int> t;
	dfs(g,s,t);
	print_path(s,1,4);
	cout<<endl;
	s.print();
	while(!t.empty()) {
		cout<<t.top()<<' '; t.pop();
	}
}
