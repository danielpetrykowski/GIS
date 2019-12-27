#include <stdlib.h>
#include "queueElement.h"

QueueElement::QueueElement(int verticeId, std::vector<int> currentVerticePath)
{
	_verticeId = verticeId;
	_verticePath = currentVerticePath;
}

int QueueElement::getVerticeId()
{
	return _verticeId;
}

void QueueElement::setVerticeId(int value)
{
	_verticeId = value;
}

std::vector<int> QueueElement::getVerticePath()
{
	return _verticePath;
}

void QueueElement::addVerticeToPath(int newVertice)
{
	_verticePath.push_back(newVertice);
}
