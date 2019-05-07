using FactoryMethod.Models;

namespace FactoryMethod
{
    public class CreditCardPaymentFactory : PaymentAbstractFactory
    {
        protected override IPayment CreateConcretePayment()
        {
            IPayment product = new CreditCardPayment();
            // Here is the place for some additional object creation logic.
            return product;
        }
    }
}
