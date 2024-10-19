using Reengineering.Entities.FrequentRentalPoints;
using Reengineering.Entities.Prices;
using Reengineering.Entities;

var rembo = CreateMovie("Rembo", new RegularPriceCalculator());
var lotr = CreateMovie("The Lord of the Rings", new NewReleasePriceCalculator());
var harryPotter = CreateMovie("Harry Potter", new ChildrensPriceCalculator());

var rentals = new List<Rental>
        {
            CreateRental(rembo, 1, new NormalFrequentRentalPointsCalculator()),
            CreateRental(lotr, 4, new NewReleaseFrequentRentalPointsCalculator()),
            CreateRental(harryPotter, 5, new NormalFrequentRentalPointsCalculator())
        };

var customer = new Customer
{
    Name = "John Doe",
    Rentals = rentals
};

Console.WriteLine(customer.GenerateStatement());
static Movie CreateMovie(string title, IPriceCalculator priceCalculator)
{
    return new Movie
    {
        Title = title,
        PriceCalculator = priceCalculator
    };
}

static Rental CreateRental(Movie movie, int daysRented, IFrequentRentalPointsCalculator frequentRentalPointsCalculator)
{
    return new Rental
    {
        Movie = movie,
        DaysRented = daysRented,
        FrequentRentalPointsCalculator = frequentRentalPointsCalculator
    };
}