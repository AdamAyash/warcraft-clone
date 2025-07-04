#pragma once
#include "../Core/Core.h"
#include "Texture2D.h"
#include "../Core/OpenGL/VertexArray.h"
#include "glm.hpp"
#include "Shader/Shader.h"
#include "../Core/Window.h"

namespace WCCEngine
{
	class WCC_API Renderer2D
	{
	public:
		Renderer2D(IN const WindowProperties& oWindowProperties);
		~Renderer2D();

	public:
		void Render(IN const Ref<Texture2D>& oTexture, IN const glm::vec2& oPosition, OPTIONAL const glm::vec2* oSize = nullptr,
			OPTIONAL float fRotation = 0.0f, OPTIONAL glm::vec3 oColor = glm::vec3(1.0f));

	private:
		const bool Initialize();
		void ClearBackgroundColor();

		void DoTransformations(IN const glm::vec2& oPosition, const glm::vec2& oSize, 
			IN float fRotation, IN glm::vec3& oColor);

	private:
		WindowProperties m_oWindowProperties;
		Scope<VertexArray> m_pVertexArray;
		Ref<Shader> m_oTexture2DShader;
	};
}
