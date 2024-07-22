namespace CoreKitEngine.Engine.EventSystem.CommonEventImplementations
{
    public class LeftMouseButtonReleasedEvent : Event
    {
        public override EventTypeRegister GetEventTypeRegister()
        {
            return EventTypeRegister.LeftMouseButtonReleasedEvent;
        }
    }
}
