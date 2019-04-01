using FactoryMethod;
using FactoryMethod.Models;
using Xunit;

namespace Tests
{
    public class FactoryMethod_PaymentsTests
    {
        [Fact]
        public void PaymentFactory_CreateCashPayment()
        {
            PaymentAbstractFactory paymentFactory = new CashPaymentFactory();
            IPayment cashPayment = paymentFactory.CreatePayment();
            Assert.Equal("Cash", cashPayment.Name);
            Assert.Equal(0, cashPayment.DueInDays);
        }

        [Fact]
        public void PaymentFactory_CreateBankTransferPayment()
        {
            PaymentAbstractFactory paymentFactory = new BankTransferPaymentFactory();
            IPayment bankTransferPayment = paymentFactory.CreatePayment();
            Assert.Equal("Bank Transfer", bankTransferPayment.Name);
            Assert.Equal(7, bankTransferPayment.DueInDays);
        }

        [Fact]
        public void PaymentFactory_CreateCreditCardPayment()
        {
            PaymentAbstractFactory paymentFactory = new CreditCardPaymentFactory();
            IPayment creditCardPayment = paymentFactory.CreatePayment();
            Assert.Equal("Credit Card", creditCardPayment.Name);
            Assert.Equal(0, creditCardPayment.DueInDays);
        }
    }
}
