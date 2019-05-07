namespace Decorator
{
    public class Limousine : Car
    {
        private const decimal COST = 90000;

        public Limousine()
        {
            _description = "Limousine";
        }

        public override decimal GetCost()
        {
            return COST;
        }
    }
}
