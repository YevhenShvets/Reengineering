namespace Reengineering.Entities.FrequentRentalPoints
{
    public class NewReleaseFrequentRentalPointsCalculator : IFrequentRentalPointsCalculator
    {
        public int CalculateFrequentRentalPoints(int daysRented)
        {
            return daysRented > 1 ? 2 : 1;
        }
    }
}
