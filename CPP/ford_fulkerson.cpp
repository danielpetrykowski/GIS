#include <iostream>
#include "flowGraph.h"
#include <fstream>
#include <sstream>
#include <string>

int main()
{
	std::ifstream infile("graph.txt");
	std::string line;
	std::vector<std::string> lines;
	while (std::getline(infile, line)) {
		lines.push_back(line);
	}

	if (lines.size() == 0) {
		std::cout << "No file given" << std::endl;
		return 0;
	}

	FlowGraph flowGraph = FlowGraph(lines);
	int maxFlow = flowGraph.FordFulkerson();
	std::cout << "Maksymalny przeplyw w grafie wynosi: " << maxFlow << std::endl;

	return 0;
}

