#include <iostream>
#include "flowGraph.h"
#include <fstream>
#include <sstream>
#include <string>

#ifdef _WIN32
#include <sys/types.h>
#include <dirent.h>
#else
#include <experimental/filesystem>
namespace fs = std::experimental::filesystem;
#endif

int main()
{
#ifdef _WIN32
	std::string path = "./test";
    DIR* dirp = opendir(path.c_str());
    struct dirent * dp;
	while ((dp = readdir(dirp)) != NULL) {
		std::string fileName = dp->d_name;
		if(fileName == "." || fileName== "..") continue;
		std::ifstream infile(path + "/" + fileName);
#else
	std::string path = "./graphs";
	for (const auto& entry : fs::directory_iterator(path)) {
		std::ifstream infile(entry.path());
#endif
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

