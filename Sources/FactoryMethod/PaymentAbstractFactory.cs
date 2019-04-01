using FactoryMethod.Models;

namespace FactoryMethod
{
    public abstract class PaymentAbstractFactory
    {
        protected abstract IPayment CreateConcretePayment();
        public IPayment CreatePayment()
        {
            return this.CreateConcretePayment();
        }
    }
}
