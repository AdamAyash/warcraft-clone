namespace CoreKitEngine.Engine.EventSystem
{
    using CoreKitEngine.Engine.Common.Messages;
    using CoreKitEngine.Engine.EventSystem.EventHandler;
    using CoreKitEngine.Engine.LogSystem;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public sealed class EventManager
    {
        private ILoggerService m_oLoggerService;

        private Dictionary<EventTypeRegister, ISmartEventHandler> m_oEventHandlerMap;
        private Queue<Event> m_oEventQueue;

        public EventManager()
        {
            m_oEventHandlerMap = new Dictionary<EventTypeRegister, ISmartEventHandler>();
            m_oEventQueue = new Queue<Event>();
            m_oLoggerService = Logger.GetLoggerInstance();
        }

        ~EventManager()
        {
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

            if (!(oEventHandler.Invoke(oEvent)))
            {
                m_oLoggerService.Log(LogSeverity.INFO, Messages.NULL_EVENT_POINTER_ENCOUNTERED, 
                    new MessageKey("EVENT", oEventHandler.ToString()));
            }
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
