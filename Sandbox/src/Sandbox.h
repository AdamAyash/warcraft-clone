#pragma once

#include <Engine/Core/Application.h>

class Sandbox : public WCCEngine::Application
{
public:
	Sandbox();
	~Sandbox();

public:
	virtual void Initialize() override;
};