namespace Sandbox.InputManager.InputMappers
{
    using CoreKitEngine.Engine.EventSystem;
    using CoreKitEngine.Engine.EventSystem.CommonEventImplementations;
    using CoreKitEngine.Engine.InputManager.BaseInputMapper;
    using CoreKitEngine.Engine.Utilities;
    using CoreKitEngine.EventSystem.CommonEventImplementations;
    using Microsoft.Xna.Framework.Input;

    public class SandboxInputMapper : IBaseInputMapper
    {
        public SandboxInputMapper()
        {
        }

        public Event? GetKeyboardInputEvent(KeyboardState oKeyboardState)
        {
            foreach (Keys key in Utilities.GetEnumValues<Keys>())
            {
                if (oKeyboardState.IsKeyDown(key))
                    return new KeyDownEvent(key);
            }

            return null;
        }

        public Event? GetMouseInputEvent(MouseState oMouseState)
        {
            if(oMouseState.LeftButton == ButtonState.Pressed)
                return new LeftMouseButtonPressedEvent(oMouseState.Position);

            if (oMouseState.LeftButton == ButtonState.Released)
                return new LeftMouseButtonReleasedEvent();

            return null;
        }
    }
}
