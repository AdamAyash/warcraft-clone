namespace Sandbox.InputManager.InputMappers
{
    using CoreKitEngine.Engine.EventSystem;
    using CoreKitEngine.Engine.EventSystem.CommonEventImplementations;
    using CoreKitEngine.Engine.InputManager.BaseInputMapper;
    using CoreKitEngine.Engine.Utilities;
    using CoreKitEngine.EventSystem.CommonEventImplementations;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;

    public class SandboxInputMapper : IBaseInputMapper
    {
        private Dictionary<Keys, bool> m_CurrentlyPressedKeysMap;

        private bool m_bIsLeftMouseButtonPressed;
        private bool m_bIsRightMouseButtonPressed;

        public SandboxInputMapper()
        {
            InitializeCurrentlyPressedButtonsMap();

            this.m_bIsLeftMouseButtonPressed = false;
            this.m_bIsRightMouseButtonPressed = false;
        }

        private void InitializeCurrentlyPressedButtonsMap()
        {
            m_CurrentlyPressedKeysMap = new Dictionary<Keys, bool>();

            foreach (Keys key in Utilities.GetEnumValues<Keys>())
            {
                m_CurrentlyPressedKeysMap[key] = false;
            }
        }

        public Event GetKeyboardInputEvent(KeyboardState oKeyboardState)
        {
            foreach (Keys key in Utilities.GetEnumValues<Keys>())
            {
                if (oKeyboardState.IsKeyDown(key))
                {
                    m_CurrentlyPressedKeysMap[key] = true;
                    return new KeyDownEvent(key);
                }

                if(oKeyboardState.IsKeyUp(key) && !m_CurrentlyPressedKeysMap[key])
                {

                }
            }

            return null;
        }

        public Event GetMouseInputEvent(MouseState oMouseState)
        {
            if(oMouseState.LeftButton == ButtonState.Pressed)
            {
                m_bIsLeftMouseButtonPressed = true;
                return new LeftMouseButtonPressedEvent(oMouseState.Position);
            }

            if (oMouseState.LeftButton == ButtonState.Released && m_bIsLeftMouseButtonPressed)
            {
                m_bIsLeftMouseButtonPressed = false;
                return new LeftMouseButtonReleasedEvent();
            }

            return null;
        }
    }
}
