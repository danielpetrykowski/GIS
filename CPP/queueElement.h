#ifndef __QUEUEELEMENT_H__
#define __QUEUEELEMENT_H__
#include <vector>

class QueueElement
{
public:
	QueueElement(int verticeId, std::vector<int> currentVerticePath);

	int getVerticeId();
	void setVerticeId(int value);
	std::vector<int> getVerticePath();
	void addVerticeToPath(int newVertice);

private:
	int _verticeId;
	std::vector<int> _verticePath;
};

#endif
