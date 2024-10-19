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
                    // Calculate rental charge
                    float rentalCharge = rental.Movie?.PriceCalculator?.CalculateCharge(rental.DaysRented) ?? 0.0f;

                    // Calculate frequent rental points
                    frequentRentalPoints += rental.FrequentRentalPointsCalculator?.CalculateFrequentRentalPoints(rental.DaysRented) ?? 0;

                    // Append rental information to the statement
                    statement += $"\t{rental.Movie?.Title}\t{rentalCharge}\n";
                    totalAmount += rentalCharge;
                }
            }

            // Append total amount and frequent rental points to the statement
            statement += $"\nTotal Amount: {totalAmount}\n";
            statement += $"Frequent Renter Points: {frequentRentalPoints}";

            return statement;
        }
    }
}
