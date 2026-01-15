namespace Lab01.Patterns.Singleton
{
    public interface ILoggerService
    {
        void Log(string message);
        string GetInstanceId();
    }
}
