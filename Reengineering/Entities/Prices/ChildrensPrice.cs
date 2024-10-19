namespace Reengineering.Entities.Prices
{
    public class ChildrensPriceCalculator : IPriceCalculator
    {
        public float CalculateCharge(int daysRented)
        {
            return daysRented > 3 ? 1.5f + ((daysRented - 3) * 1.5f) : 1.5f;
        }
    }
}
