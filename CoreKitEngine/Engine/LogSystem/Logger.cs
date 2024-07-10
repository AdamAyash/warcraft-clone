namespace CoreKitEngine.Engine.LogSystem
{
    public class Logger : ILoggerService
    {
        private static Logger m_LoggerInstance = null;

        private Logger()
        {
        }

        public static Logger GetLoggerInstance()
        {
            if(m_LoggerInstance == null)
                m_LoggerInstance = new Logger();

            return m_LoggerInstance;
        }

        private void Log(string message, LogSeverity logSeverity)
        {
            Console.WriteLine(FormatMessage(logSeverity, message));
        }

        public void LogInformation(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Log(message, LogSeverity.INFO);
        }

        public void LogAlert(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Log(message, LogSeverity.ALERT);
        }

        public void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Log(message, LogSeverity.WARNING);
        }

        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Log(message, LogSeverity.ERROR);
        }

        public void LogCritical(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Log(message, LogSeverity.CRITICAL);
        }
        public void LogDebug(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Log(message, LogSeverity.DEBUG);
        }

        private string FormatMessage(LogSeverity logSeverity, string message)
        {
            return String.Format("[{0}] {1} {2}", logSeverity.ToString(),
                Utilities.Utilities.GetCurrentDateTime(), message);
        }
    }
}
