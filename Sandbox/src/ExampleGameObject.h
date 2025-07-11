#pragma once
#include "Engine/GameObjects/GameObject.h"

class ExampleGameObject : public WCCEngine::GameObject
{
public:
	ExampleGameObject();
	~ExampleGameObject();

public:
	virtual void Update(IN const WCCEngine::GameTime& oGameTime) override;

public:
	glm::vec2 oTargetPosition;
};