namespace FactoryMethod.Models
{
    public interface IPayment
    {
        string Name { get; }
        int DueInDays { get; }
    }
}
