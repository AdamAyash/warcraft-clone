namespace CoreKitEngine.EventSystem.CommonEventImplementations
{
    using CoreKitEngine.Engine.EventSystem;
    using Microsoft.Xna.Framework.Input;
    public class KeyDownEvent : Event
    {
        public Keys KeyPressed { get; private set; }
        public KeyDownEvent(Keys eKeyPressed)
        {
            this.KeyPressed = eKeyPressed;
        }

        public override EventTypeRegister GetEventTypeRegister()
        {
            return EventTypeRegister.KeyDownEvent;
        }
    }
}
