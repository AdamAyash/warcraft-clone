namespace CoreKitEngine.Engine.EventSystem.EventHandler
{
    public interface ISmartEventHandler
    {
        public void AddMethod<T>(Action<T> callback)
            where T : Event;

        public void Invoke(Event oEvent);
            
    }
}
