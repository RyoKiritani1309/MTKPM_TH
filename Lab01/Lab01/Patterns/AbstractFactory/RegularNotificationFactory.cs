namespace Lab01.Patterns.AbstractFactory
{
    public class RegularNotificationFactory : INotificationFactory
    {
        public IEmailService CreateEmail() => new RegularEmailService();
        public ISmsService CreateSms() => new RegularSmsService();
    }
}