namespace CoreKitEngine.Engine.InputManager.BaseInputMapper
{
    using CoreKitEngine.Engine.EventSystem;
    using Microsoft.Xna.Framework.Input;

    public interface IBaseInputMapper
    {
        public Event GetKeyboardInputEvent(KeyboardState oKeyboardState);
        public Event GetMouseInputEvent(MouseState oMouseState);
    }
}
