using FactoryMethod.Models;

namespace FactoryMethod
{
    public class BankTransferPaymentFactory : PaymentAbstractFactory
    {
        protected override IPayment CreateConcretePayment()
        {
            IPayment product = new BankTransferPayment();
            // Here is the place for some additional object creation logic.
            return product;
        }
    }
}
