namespace CoreKitEngine.Engine.LogSystem
{
    public interface ILoggerService
    {
        public void Log(LogSeverity eLogSeverity, string strMessage);
    }
}
