namespace Lab01.Patterns.AbstractFactory
{
    public class HighPriorityNotificationFactory : INotificationFactory
    {
        public IEmailService CreateEmail() => new HighPriorityEmailService();
        public ISmsService CreateSms() => new HighPrioritySmsService();
    }
}   