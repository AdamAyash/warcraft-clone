namespace CoreKitEngine.Engine.EventSystem.CommonEventImplementations
{
    using Microsoft.Xna.Framework;

    public class LeftMouseButtonPressedEvent : Event
    {
        public Point MousePosition { get; set; }

        public LeftMouseButtonPressedEvent(Point oMousePosition)
        {
            MousePosition = oMousePosition;
        }

        public override EventTypeRegister GetEventTypeRegister()
        {
            return EventTypeRegister.LeftMouseButtonPressedEvent;
        }
    }
}
