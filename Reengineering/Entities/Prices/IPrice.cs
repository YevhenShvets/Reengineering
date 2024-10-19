namespace Reengineering.Entities.Prices
{
    public interface IPriceCalculator
    {
        float CalculateCharge(int daysRented);
    }
}
