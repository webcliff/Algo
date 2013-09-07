// priority_queue on binary heap

#include <utility>
#include <functional>
#include <vector>

namespace algo {

template <typename T,
	  typename Container = std::vector<T>,
	  typename Compare = std::greater<typename Container::value_type> >
class priority_queue {
public:
	priority_queue() : heap(),compare() {
		heap.resize(1);
	}
	void push(const T &t) {
		heap.push_back(t);
		move_up(size());
	}
	void pop() {
		if(empty()) return;
		std::swap(*(heap.begin()+1),*(heap.rbegin()));
		heap.pop_back();
		move_down(1);
	}
	const T& top() const {
		if(empty()) return NULL;
		return *(heap.begin()+1);
	}
	inline bool empty() const {
		return heap.size()==1;
	}
	inline size_t size() const {
		return heap.size()-1;
	}

private:
	void move_up(int i) {
		while(i>1) {
			auto it=heap.begin()+i;
			int p=parent(i);
			auto pit=heap.begin()+p;
			if(compare(*it,*pit)) break;
			std::swap(*it,*pit);
			i=p;
		}
	}
	void move_down(int i) {
		int l=left(i);
		while(l<=size()) {
			auto it=heap.begin()+i;
			auto lit=heap.begin()+l;
			int offset=compare(*it,*lit) ? l:i;

			int r=right(i);
			if(r<=size()) {
				auto rit=heap.begin()+r;
				offset=compare(*(heap.begin()+offset), *rit) ? r:offset;
			}
			if(offset==i) break;
			std::swap(*it,*(heap.begin()+offset));
			i=offset;
		}
	}
	inline int parent(int i) const { return i/2; }
	inline int left(int i) const { return i*2; }
	inline int right(int i) const { return i*2+1; }

	Container heap;
	Compare compare;
};

}
