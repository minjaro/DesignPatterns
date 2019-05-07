namespace Decorator
{
    public abstract class Car
    {
        protected string _description = "Your car configuration is empty";

        public string GetDescription()
        {
            return _description;
        }

        public abstract decimal GetCost();
    }
}
