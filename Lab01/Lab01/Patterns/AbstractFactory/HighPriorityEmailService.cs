namespace Lab01.Patterns.AbstractFactory
{
    public class HighPriorityEmailService : IEmailService
    {
        public string SendEmail() => "High Priority Email: Gui mail Server rieng, Bao mat cao!";
    }
}