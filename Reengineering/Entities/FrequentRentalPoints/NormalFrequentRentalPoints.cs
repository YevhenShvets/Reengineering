namespace Reengineering.Entities.FrequentRentalPoints
{
    public class NormalFrequentRentalPointsCalculator : IFrequentRentalPointsCalculator
    {
        public int CalculateFrequentRentalPoints(int daysRented)
        {
            return 1; // Standard frequent renter points for normal movies.
        }
    }
}
