using FactoryMethod.Models;

namespace FactoryMethod
{
    public class CashPaymentFactory : PaymentAbstractFactory
    {
        protected override IPayment CreateConcretePayment()
        {
            IPayment product = new CashPayment();
            // Here is the place for some additional object creation logic.
            return product;
        }
    }
}
