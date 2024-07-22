using CoreKitEngine.Engine.LogSystem;

namespace CoreKitUnitTests
{
    [TestClass]
    public class LogSystemUnitTest
    {
        ILoggerService? m_oLoggerService;

        [TestMethod]
        public void LoggerGetInstanceTest()
        {
            m_oLoggerService = Logger.GetLoggerInstance();
            Assert.IsNotNull(m_oLoggerService);
        }
    }
}