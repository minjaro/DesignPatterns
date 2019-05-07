namespace Decorator
{
    public class AutomaticGearbox : CarPartDecorator
    {
        private const decimal COST = 10700;
        protected Car _innerCar;

        public AutomaticGearbox(Car baseCar)
        {
            _innerCar = baseCar;
        }

        public override decimal GetCost()
        {
            return _innerCar.GetCost() + COST;
        }

        public override string GetDescription()
        {
            return _innerCar.GetDescription() + ", Automatic Gearbox";
        }
    }
}
