namespace CoreKitEngine.Engine.EventSystem.EventHandler
{
    public interface ISmartEventHandler
    {
        public void AddMethod<T>(Func<T, bool> callback)
            where T : Event;

        public bool Invoke(Event oEvent);
            
    }
}
