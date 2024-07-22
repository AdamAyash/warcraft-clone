namespace CoreKitEngine.Engine.LogSystem
{
    public interface ILoggerService
    {
        public void Log(LogSeverity eLogSeverity, string strMessage);
        public void Log(LogSeverity eLogSeverity, string strMessage, params MessageKey[] oMessageKeys);
    }
}
