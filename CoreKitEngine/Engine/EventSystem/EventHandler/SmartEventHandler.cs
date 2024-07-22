namespace CoreKitEngine.Engine.EventSystem.EventHandler
{
    public class SmartEventHandler<EventType> : ISmartEventHandler
        where EventType : Event
    {
        public Func<EventType, bool> OnSmartEvent { get; private set; }

        public void AddMethod<T>(Func<T, bool> callback) 
            where T : Event
        {
            OnSmartEvent += (Func<EventType, bool>)callback;
        }

        public bool Invoke(Event oEvent)
        {
            return OnSmartEvent.Invoke((EventType)oEvent);
        }
    }
}
