using Reengineering.Enums;

namespace Reengineering.Entities
{
    public class Rental
    {
        public Movie? Movie { get; set; }
        public int DaysRented { get; set; }

        public int CalculateFrequentRentalPoints()
        {
            if (Movie == null)
            {
                return 1;
            }

            return Movie.Type == MovieType.NewRelease && DaysRented > 1 ? 2 : 1;
        }
    }
}
