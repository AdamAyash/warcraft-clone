namespace CoreKitEngine.Engine.InputManager
{
    using CoreKitEngine.Engine.EventSystem;
    using CoreKitEngine.Engine.InputManager.BaseInputMapper;
    using Microsoft.Xna.Framework.Input;

    public class InputManager
    {
        private IBaseInputMapper m_oBaseInputMapperImplementation;

        public InputManager(IBaseInputMapper oBaseInputMapperImplementation)
        {
            this.m_oBaseInputMapperImplementation = oBaseInputMapperImplementation;
        }
        public Event GetKeyboardInputEvent(KeyboardState oKeyboardState)
        {
            return this.m_oBaseInputMapperImplementation.GetKeyboardInputEvent(oKeyboardState);
        }

        public Event GetMouseInputEvent(MouseState oMouseState)
        {
            return this.m_oBaseInputMapperImplementation.GetMouseInputEvent(oMouseState);
        }
    }
}
