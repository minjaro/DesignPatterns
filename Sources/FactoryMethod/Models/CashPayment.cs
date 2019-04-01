namespace FactoryMethod.Models
{
    internal class CashPayment : IPayment
    {
        public string Name => "Cash";
        public int DueInDays => 0;
    }
}
