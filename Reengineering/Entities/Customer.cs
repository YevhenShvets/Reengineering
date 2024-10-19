using Reengineering.Enums;

namespace Reengineering.Entities
{
    public class Customer
    {
        public string? Name { get; set; }
        public List<Rental>? Rentals { get; set; }

        public string GenerateStatement()
        {
            float totalAmount = 0f;
            int frequentRenterPoints = 0;
            string statement = $"Rental Record for {Name}:\n";

            if (Rentals != null)
            {
                foreach (var rental in Rentals)
                {
                    float rentalAmount = CalculateRentalAmount(rental);
                    frequentRenterPoints += CalculateFrequentRenterPoints(rental);

                    statement += $"\t{rental.Movie?.Title}\t{rentalAmount}\n";
                    totalAmount += rentalAmount;
                }
            }

            statement += $"\nTotal Amount: {totalAmount}\n";
            statement += $"Frequent Renter Points: {frequentRenterPoints}";

            return statement;
        }

        private float CalculateRentalAmount(Rental rental)
        {
            float amount = 0f;

            switch (rental.Movie?.Type)
            {
                case MovieType.Regular:
                    amount = rental.DaysRented > 2 ? 2 + ((rental.DaysRented - 2) * 1.5f) : 2;
                    break;
                case MovieType.NewRelease:
                    amount = rental.DaysRented * 3;
                    break;
                case MovieType.Childrens:
                    amount = rental.DaysRented > 3 ? 1.5f + ((rental.DaysRented - 3) * 1.5f) : 1.5f;
                    break;
                default:
                    break;
            }

            return amount;
        }

        private int CalculateFrequentRenterPoints(Rental rental)
        {
            return rental.Movie?.Type == MovieType.NewRelease && rental.DaysRented > 1 ? 2 : 1;
        }
    }
}
