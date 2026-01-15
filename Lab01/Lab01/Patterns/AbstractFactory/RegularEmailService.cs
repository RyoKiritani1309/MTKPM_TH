namespace Lab01.Patterns.AbstractFactory
{
    public class RegularEmailService : IEmailService
    {
        public string SendEmail() => "Regular Email: Gui mail bang SMTP mien phi.";
    }
}