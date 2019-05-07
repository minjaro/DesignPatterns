using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public class DieselEngine : CarPartDecorator
    {
        private const decimal COST = 13500;
        protected Car _innerCar;

        public DieselEngine(Car baseCar)
        {
            _innerCar = baseCar;
        }

        public override decimal GetCost()
        {
            return _innerCar.GetCost() + COST;
        }

        public override string GetDescription()
        {
            return _innerCar.GetDescription() + ", Diesel Engine";
        }
    }
}
