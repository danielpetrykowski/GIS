#include <iostream>
#include "flowGraph.h"
#include <fstream>
#include <sstream>
#include <string>
#include <sys/types.h>
#include <dirent.h>


int main()
{
#ifdef _WIN32
	// Tu sciezka windows way
	std::string path = "./test";
#else
	std::string path = "./graphs";
#endif
    DIR* dirp = opendir(path.c_str());
    struct dirent * dp;
	while ((dp = readdir(dirp)) != NULL) {
		//std::cout << entry.path() << std::endl;
		std::string fileName = dp->d_name;
		if(fileName == "." || fileName== "..") continue;
		std::ifstream infile(path + "/" + fileName);
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

