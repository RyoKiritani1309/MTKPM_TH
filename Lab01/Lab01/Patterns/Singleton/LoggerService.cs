namespace Lab01.Patterns.Singleton
{
    public class LoggerService : ILoggerService
    {
        private readonly Guid _id;

        public LoggerService()
        {
            _id = Guid.NewGuid();
        }

        public void Log(string message)
        {
            Console.WriteLine($"[Log ID: {_id}] {message}");
        }

        public string GetInstanceId()
        {
            return _id.ToString();
        }
    }
}