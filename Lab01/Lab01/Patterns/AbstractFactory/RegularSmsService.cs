namespace Lab01.Patterns.AbstractFactory
{
    public class RegularSmsService : ISmsService
    {
        public string SendSms() => "Regular SMS: Gui SMS cham (co the bi delay).";
    }
}