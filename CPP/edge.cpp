#include <stdlib.h>
#include "edge.h"

Edge::Edge(int startVertice, int endVertice, int capacity)
{
	_startVertice = startVertice;
	_endVertice = endVertice;
	_capacity = capacity;
	_flow = 0;
}

Edge::~Edge()
{
}

int Edge::getFlow()
{
	return _flow;
}

void Edge::setFlow(int value)
{
	_flow = value;
	_availableFlow = _capacity - _flow;
}

int Edge::getAvailableFlow()
{
	return _availableFlow;
}

void Edge::setAvailableFlow(int value)
{
	_availableFlow = value;
	_flow = _capacity - _availableFlow;
}

int Edge::getCapacity()
{
	return _capacity;
}

void Edge::setCapacity(int value)
{
	_capacity = value;
}
