namespace CoreKitEngine.Engine.EventSystem.EventHandler
{
    public class SmartEventHandler<EventType> : ISmartEventHandler
        where EventType : Event
    {
        public Action<EventType> OnSmartEvent { get; private set; }

        public void AddMethod<T>(Action<T> callback) 
            where T : Event
        {
            OnSmartEvent += (Action<EventType>)callback;
        }

        public void Invoke(Event oEvent)
        {
            OnSmartEvent.Invoke((EventType)oEvent);
        }
    }
}
