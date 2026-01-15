namespace Lab01.Patterns.AbstractFactory
{
    public class HighPrioritySmsService : ISmsService
    {
        public string SendSms() => "High Priority SMS: SMS Brandname, den ngay lap tuc!";
    }
}