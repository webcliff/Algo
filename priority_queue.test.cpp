
#include <iostream>
#include <fstream>
#include <vector>
#include <functional>
#include "pq.2.h"

typedef struct Node {
	Node *next;
} Node;

void test(Node *&p) {
	p=p->next;
}

void main() {

	algo::priority_queue<int> pq;

	pq.push(13);
	pq.push(8);
	pq.push(13);
	pq.push(19);
	pq.push(10);

	std::cout<<pq.top()<<std::endl;
	pq.pop();
	std::cout<<pq.top()<<std::endl;
	pq.pop();
	std::cout<<pq.top()<<std::endl;
	pq.pop();
	std::cout<<pq.top()<<std::endl;
	pq.pop();
	std::cout<<pq.top()<<std::endl;
	pq.pop();

	std::cout<<std::endl;

	algo::priority_queue<int,std::vector<int>,std::less<int>> pq2;

	pq2.push(13);
	pq2.push(8);
	pq2.push(19);
	pq2.push(13);
	pq2.push(10);

	std::cout<<pq2.top()<<std::endl;
	pq2.pop();
	std::cout<<pq2.top()<<std::endl;
	pq2.pop();
	std::cout<<pq2.top()<<std::endl;
	pq2.pop();
	std::cout<<pq2.top()<<std::endl;
	pq2.pop();
	std::cout<<pq2.top()<<std::endl;
	pq2.pop();


	Node *p1=new Node();
	test(p1);
	
	Node p={0};

	test(&p);

}
	
