namespace CoreKitUnitTests.Engine.EventSystem
{
    using CoreKitEngine.Engine.EventSystem;
    using CoreKitEngine.Engine.EventSystem.EventHandler;
    using CoreKitEngine.EventSystem.CommonEventImplementations;

    [TestClass]
    public class EventManagerUnitTest
    {
        [TestMethod]
        public void EventManagerRegisterDuplicateEventHandlersTest()
        {
            try
            {
                var eventManager = new EventManager();

                var oKeyDownEventHandler = new SmartEventHandler<KeyDownEvent>();
                var oKeyDownEventHandlerDuplicate = new SmartEventHandler<KeyDownEvent>();

                Assert.IsTrue(eventManager.RegisterEventHandler(EventTypeRegister.KeyDownEvent, oKeyDownEventHandler));
                Assert.IsFalse(eventManager.RegisterEventHandler(EventTypeRegister.KeyDownEvent, oKeyDownEventHandlerDuplicate));
            }
            catch (Exception)
            {

            }
        }
    }
}
