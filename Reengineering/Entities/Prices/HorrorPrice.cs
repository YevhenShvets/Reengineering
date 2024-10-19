namespace Reengineering.Entities.Prices
{
    public class HorrorPriceCalculator : IPriceCalculator
    {
        public float CalculateCharge(int daysRented)
        {
            return daysRented > 7 ? 3f + ((daysRented - 7) * 2f) : 3f;
        }
    }
}
