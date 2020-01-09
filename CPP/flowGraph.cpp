#include <stdlib.h>
#include "flowGraph.h"
#include <memory>
#include <boost/algorithm/string.hpp>
#include <queue>
#include <iostream>
#include <chrono>

FlowGraph::FlowGraph(std::vector<std::string> lines)
{
	_adjacencyMap = std::make_unique<std::map<int, std::vector<int>>>();
	_edges = std::make_unique<std::map<std::pair<int, int>, Edge>>();
	_verticesNum = std::stoi(lines[0]);
	_source = std::stoi(lines[1]);
	_sink = std::stoi(lines[2]);

	for(int i = 0; i < _verticesNum; ++i) {
		std::vector<int> v;
		(*_adjacencyMap)[i] = v;
	}

	for(int i = 0; i < _verticesNum; ++i) {
		auto text = lines[i + 3];
		std::vector<std::string> splittedLine;
		std::vector<int> capacities;

		boost::split(splittedLine, text, [](char c){return c == ';';});
		for(auto const& element: splittedLine) {
			capacities.push_back(stoi(element));
		}

		for(int j = 0; j < _verticesNum; ++j) {
			if (i == j || capacities[j] == 0)
				continue;

			if (_edges->count(std::make_pair(i,j)) > 0) {
				_edges->at(std::make_pair(i,j)).setCapacity(capacities[j]);
				_edges->at(std::make_pair(i,j)).setFlow(0);
				continue;
			}

			auto edge = Edge(i,j,capacities[j]);
			(*_adjacencyMap)[i].push_back(j);
			(*_edges).insert({std::make_pair(i,j),edge});

			auto edge2 = Edge(j,i,0);
			(*_adjacencyMap)[j].push_back(i);
			(*_edges).insert({std::make_pair(j,i), edge2});
		}
	}
}

int FlowGraph::FordFulkerson()
{
	int maxFlow = 0;
	// start time measure
	auto begin = std::chrono::high_resolution_clock::now();

	auto extendedPath = FindExtendedPath();
	while(!extendedPath.empty()) {
		auto valueFlowToUpdate = GetExtendedFlow(extendedPath);
		UpdateFlow(extendedPath, valueFlowToUpdate);
		maxFlow +=valueFlowToUpdate;
		extendedPath = FindExtendedPath();
	}

	// end time measure
	auto end = std::chrono::high_resolution_clock::now();
	std::cout << maxFlow << "; " << (std::chrono::duration_cast<std::chrono::nanoseconds>(end-begin).count()) << "ns" << std::endl;

	return maxFlow;
}

std::vector<int> FlowGraph::FindExtendedPath()
{
	std::queue<QueueElement> verticesToVisit = std::queue<QueueElement>();
	std::vector<bool> visitedVertices(_verticesNum);
	std::vector<int> verticePath{_source};
	verticesToVisit.push(QueueElement(_source, verticePath));
	visitedVertices[_source] = true;
	while(verticesToVisit.size() > 0) {
		QueueElement queueElement = verticesToVisit.front();
		verticesToVisit.pop();
		for(auto it = (*_adjacencyMap)[queueElement.getVerticeId()].begin(); it != (*_adjacencyMap)[queueElement.getVerticeId()].end(); ++it) {
			if (visitedVertices[*it] || (*_edges).find(std::make_pair(queueElement.getVerticeId(), *it))->second.getAvailableFlow() == 0)
				continue;
			auto path = queueElement.getVerticePath();
			path.push_back(*it);

			if (*it == _sink) {
				return path;
			}

			verticesToVisit.push(QueueElement(*it, path));
			visitedVertices[*it] = true;
		}
	}

	return std::vector<int>();
}

int FlowGraph::GetExtendedFlow(std::vector<int> path)
{
	int minAvailableFlow = INT_MAX;
	auto startVertice = path[0];
	for(size_t i = 1; i < path.size(); ++i) {
		int endVertice = path[i];
		if (minAvailableFlow > (*_edges).find(std::make_pair(startVertice, endVertice))->second.getAvailableFlow()) {
			minAvailableFlow = (*_edges).find(std::make_pair(startVertice, endVertice))->second.getAvailableFlow();
		}
		startVertice = endVertice;
	}

	return minAvailableFlow;
}

void FlowGraph::UpdateFlow(std::vector<int> path, int flowValue)
{
	auto startVertice = path[0];
	for(size_t i = 1; i < path.size(); ++i) {
		auto endVertice = path[i];

		(*_edges).find(std::make_pair(startVertice, endVertice))->second.setFlow(
				(*_edges).find(std::make_pair(startVertice, endVertice))->second.getFlow() + flowValue);
		(*_edges).find(std::make_pair(endVertice, startVertice))->second.setFlow(
				(*_edges).find(std::make_pair(endVertice, startVertice))->second.getFlow() - flowValue);

		startVertice = endVertice;
	}
}
