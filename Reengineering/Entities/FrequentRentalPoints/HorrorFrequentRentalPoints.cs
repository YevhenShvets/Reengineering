namespace Reengineering.Entities.FrequentRentalPoints
{
    public class HorrorFrequentRentalPointsCalculator : IFrequentRentalPointsCalculator
    {
        public int CalculateFrequentRentalPoints(int daysRented)
        {
            return daysRented > 3 ? 2 : 1;
        }
    }
}
