namespace FactoryMethod.Models
{
    internal class CreditCardPayment : IPayment
    {
        public string Name => "Credit Card";
        public int DueInDays => 0;
    }
}
