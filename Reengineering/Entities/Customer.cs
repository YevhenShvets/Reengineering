using Reengineering.Enums;

namespace Reengineering.Entities
{
    public class Customer
    {
        public string? Name { get; set; }
        public List<Rental>? Rentals { get; set; }

        public string GenerateStatement()
        {
            float totalAmount = 0.0f;
            int frequentRentalPoints = 0;
            string statement = $"Rental Records for {Name}:\n";

            if (Rentals != null)
            {
                foreach (var rental in Rentals)
                {
                    float rentalAmount = CalculateRentalAmount(rental);
                    frequentRentalPoints += rental.CalculateFrequentRentalPoints();

                    statement += $"\t{rental.Movie?.Title}\t{rentalAmount}\n";
                    totalAmount += rentalAmount;
                }
            }

            statement += $"\nTotal Amount: {totalAmount}\n";
            statement += $"Frequent Renter Points: {frequentRentalPoints}";

            return statement;
        }

        private float CalculateRentalAmount(Rental rental)
        {
            return rental.Movie?.CalculateCharge(rental.DaysRented) ?? 0.0f;
        }
    }
}
