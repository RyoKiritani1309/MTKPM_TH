namespace Lab01.Patterns.AbstractFactory
{
    public interface INotificationFactory
    {
        IEmailService CreateEmail();
        ISmsService CreateSms();
    }
}