namespace CoreKitEngine.Engine.LogSystem
{
    public class Logger : ILoggerService
    {
        private static ILoggerService m_LoggerInstance = null;

        private Logger()
        {
        }

        public static ILoggerService GetLoggerInstance()
        {
            if(m_LoggerInstance == null)
                m_LoggerInstance = new Logger();

            return m_LoggerInstance;
        }

        public void Log(LogSeverity eLogSeverity, string strMessage)
        {
            Console.WriteLine(FormatMessage(eLogSeverity, strMessage));
        }

        private string FormatMessage(LogSeverity logSeverity, string message)
        {
            return String.Format("[{0}] {1} {2}", logSeverity.ToString(),
                Utilities.Utilities.GetCurrentDateTime(), message);
        }
    }
}
