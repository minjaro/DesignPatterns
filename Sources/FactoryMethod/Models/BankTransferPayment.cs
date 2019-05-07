namespace FactoryMethod.Models
{
    internal class BankTransferPayment : IPayment
    {
        public string Name => "Bank Transfer";
        public int DueInDays => 7;
    }
}
