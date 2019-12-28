#ifndef __EDGE_H__
#define __EDGE_H__

#include <stdlib.h>

class Edge
{
public:
	Edge(int startVertice, int endVertice, int capacity);
	~Edge();

	// which is which?
	int getFlow();
	void setFlow(int flow);
	int getAvailableFlow();
	void setAvailableFlow(int availableFlow);
	int getCapacity();
	void setCapacity(int value);

	int _startVertice;
	int _endVertice;
	int _capacity;
private:
	int _flow;
	int _availableFlow;

};

#endif
