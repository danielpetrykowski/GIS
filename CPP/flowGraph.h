#ifndef __FLOWGRAPH_H__
#define __FLOWGRAPH_H__

#include <vector>
#include <map>
#include <string>
#include <memory>
#include "edge.h"
#include "queueElement.h"

class FlowGraph
{
public:
	FlowGraph(std::vector<std::string> lines);
	int FordFulkerson();
	std::vector<int> FindExtendedPath();
	int GetExtendedFlow(std::vector<int> path);
	void UpdateFlow(std::vector<int> path, int flowValue);
	int getVertice();
	void setVertice(int value);
	int getSource();
	void setSource(int value);
	int getSink();
	void setSink(int value);

	std::unique_ptr<std::map<int, std::vector<int>>> _adjacencyMap;
	std::unique_ptr<std::map<std::pair<int, int>, Edge>> _edges;

private:
	int _verticesNum;
	int _source;
	int _sink;
};

#endif
