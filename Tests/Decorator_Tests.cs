using Decorator;
using Xunit;

namespace Tests
{
    public class Decorator_Tests
    {
        [Fact]
        public void CarPriceUpdated_WhenISelectEngineAndGearbox()
        {
            // Given
            Car car = new Limousine();

            // When
            car = new DieselEngine(car);
            car = new AutomaticGearbox(car);

            // Then
            Assert.Equal(114201, car.GetCost());
        }
    }
}
