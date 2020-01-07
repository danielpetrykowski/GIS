#include <iostream>
#include "flowGraph.h"
#include <fstream>
#include <sstream>
#include <string>
#include <experimental/filesystem>

namespace fs = std::experimental::filesystem;

int main()
{
#ifdef _WIN32
	// Tu sciezka windows way
	std::string path = "";
#else
	std::string path = "./graphs";
#endif
	for (const auto& entry : fs::directory_iterator(path)) {
		//std::cout << entry.path() << std::endl;
		std::ifstream infile(entry.path());
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
		flowGraph.FordFulkerson();
	}

	return 0;
}

