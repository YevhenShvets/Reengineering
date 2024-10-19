namespace Reengineering.Entities.Prices
{
    public class NewReleasePriceCalculator : IPriceCalculator
    {
        public float CalculateCharge(int daysRented)
        {
            return daysRented * 3;
        }
    }
}
