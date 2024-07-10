namespace CoreKitEngine.Engine.LogSystem
{
    public interface ILoggerService
    {
        public void LogAlert(string message);
        public void LogError(string message);
        public void LogInformation(string message);
        public void LogWarning(string message);
        public void LogCritical(string message);
        public void LogDebug(string message);
    }
}
