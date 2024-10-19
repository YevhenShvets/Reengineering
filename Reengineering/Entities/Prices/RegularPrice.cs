namespace Reengineering.Entities.Prices
{
    public class RegularPriceCalculator : IPriceCalculator
    {
        public float CalculateCharge(int daysRented)
        {
            return daysRented > 2 ? 2 + ((daysRented - 2) * 1.5f) : 2;
        }
    }
}
