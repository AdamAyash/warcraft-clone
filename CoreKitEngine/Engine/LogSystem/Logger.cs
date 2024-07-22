namespace CoreKitEngine.Engine.LogSystem
{
    using System.Text;

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

        public void Log(LogSeverity eLogSeverity, string strMessage, params MessageKey[] messageKeys)
        {
            StringBuilder oStringBuilder = new StringBuilder();
            oStringBuilder.Append(strMessage);
            
            for(int nIndex = 0; nIndex < messageKeys.Length; nIndex++) 
            {
                MessageKey oCurrentKey = messageKeys[nIndex];
                oStringBuilder.Replace(oCurrentKey.Key, oCurrentKey.Value);
            }

            Console.WriteLine(FormatMessage(eLogSeverity, oStringBuilder.ToString()));
        }

        private string FormatMessage(LogSeverity logSeverity, string message)
        {
            return String.Format("[{0}] {1} {2}", logSeverity.ToString(),
                Utilities.Utilities.GetCurrentDateTime(), message);
        }
    }
}
