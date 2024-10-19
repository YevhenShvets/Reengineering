using Reengineering.Entities;
using Reengineering.Enums;

var rembo = CreateMovie("Rembo", MovieType.Regular);
var lotr = CreateMovie("The Lord of the Rings", MovieType.NewRelease);
var harryPotter = CreateMovie("Harry Potter", MovieType.Childrens);

var rentals = new List<Rental>
        {
            CreateRental(rembo, 1),
            CreateRental(lotr, 4),
            CreateRental(harryPotter, 5)
        };

var customer = new Customer
{
    Name = "John Doe",
    Rentals = rentals
};

Console.WriteLine(customer.GenerateStatement());

static Movie CreateMovie(string title, MovieType type)
{
    return new Movie
    {
        Title = title,
        Type = type
    };
}

static Rental CreateRental(Movie movie, int daysRented)
{
    return new Rental
    {
        Movie = movie,
        DaysRented = daysRented
    };
}