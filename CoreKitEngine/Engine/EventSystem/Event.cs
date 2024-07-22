namespace CoreKitEngine.Engine.EventSystem
{
    public abstract class Event
    {
        public bool IsHandled { get; set; } = false;

        public Event()
        {
        }

        public abstract EventTypeRegister GetEventTypeRegister();
    }
}
