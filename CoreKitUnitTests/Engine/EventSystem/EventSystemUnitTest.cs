
using CoreKitEngine.Engine.EventSystem.EventHandler;
using CoreKitEngine.Engine.EventSystem;
using CoreKitEngine.EventSystem.CommonEventImplementations;

namespace CoreKitUnitTests.Engine.EventSystem
{
    [TestClass]
    public class EventSystemUnitTest
    {

        private EventManager eventManager = EventManager.GetEventManagerInstance();

        [TestMethod]
        public void GetEventManagerInstancTest()
        {
            Assert.IsNotNull(eventManager);
        }

        [TestMethod]
        public void RegisterDuplicateEventHandlersTest()
        {
            var oKeyDownEventHandler = new SmartEventHandler<KeyDownEvent>();
            var oKeyDownEventHandlerDuplicate = new SmartEventHandler<KeyDownEvent>();

            eventManager.RegisterEventHandler(EventTypeRegister.KeyDownEvent, oKeyDownEventHandler);

            Assert.IsFalse(eventManager.RegisterEventHandler(EventTypeRegister.KeyDownEvent, oKeyDownEventHandlerDuplicate));
        }
    }
}
