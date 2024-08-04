namespace CoreKitEngine.Engine.EventSystem
{
    using System;
    using CoreKitEngine.Engine.EventSystem.EventHandler;
    using CoreKitEngine.Engine.LogSystem;
    using System.Collections.Generic;
    using System.Diagnostics;

    public sealed class EventManager
    {
        private static EventManager m_oEventManagerInstance = null;

        private ILoggerService m_oLoggerService;

        private Dictionary<EventTypeRegister, ISmartEventHandler> m_oEventHandlerMap;
        private Queue<Event> m_oEventQueue;

        private EventManager()
        {
            m_oEventHandlerMap = new Dictionary<EventTypeRegister, ISmartEventHandler>();
            m_oEventQueue = new Queue<Event>();
            m_oLoggerService = Logger.GetLoggerInstance();
        }

        ~EventManager()
        {
        }

        public static EventManager GetEventManagerInstance()
        {
            if(m_oEventManagerInstance == null)
                m_oEventManagerInstance = new EventManager();

            return m_oEventManagerInstance;
        }

        public void DispatchEvents()
        {
            if (!(m_oEventQueue.Count > 0))
                return;

            Event oEvent = m_oEventQueue.Dequeue();

            if (oEvent == null)
                return;

            ISmartEventHandler oEventHandler = null;

            try
            {
                oEventHandler = m_oEventHandlerMap[oEvent.GetEventTypeRegister()];
                Debug.Assert(oEventHandler != null);
            }
            catch (KeyNotFoundException exception)
            {
                m_oLoggerService.Log(LogSeverity.ERROR, exception.StackTrace);
            }

            oEventHandler.Invoke(oEvent);
        }

        public void RegisterEvent(Event oEvent)
        {
            if(oEvent != null)
                m_oEventQueue.Enqueue(oEvent);
        }

        public bool RegisterEventHandler(EventTypeRegister eEventType, ISmartEventHandler oEventHandler)
        {
            try
            {
                m_oEventHandlerMap.Add(eEventType, oEventHandler);
            }
            catch(ArgumentException exception)
            {
                m_oLoggerService.Log(LogSeverity.ERROR, exception.StackTrace);
                return false;
            }

            return true;
        }

        public bool UnRegisterEventHandler(EventTypeRegister eEventType)
        {
            return m_oEventHandlerMap.Remove(eEventType);
        }
    }
}
