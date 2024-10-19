using Reengineering.Entities;
using Reengineering.Enums;

namespace ReengineeringTests.Tests
{
    public class CustomerTests
    {
        private Movie _rembo = new()
        {
            Title = "Rembo",
            Type = MovieType.Regular
        };
        private Movie _lotr = new()
        {
            Title = "The Lord of the Rings",
            Type = MovieType.NewRelease
        };
        private Movie _harryPotter = new()
        {
            Title = "Harry Potter",
            Type = MovieType.Childrens
        };
        private List<Rental> _rentals;
        private Customer _underTest;

        public CustomerTests()
        {
            _rentals = new();
            _underTest = new()
            {
                Name = "John Doe",
                Rentals = _rentals
            };
        }

        [Fact]
        public void GenerateStatement_NormalFLow()
        {
            // Given
            _rentals.AddRange([
                    new Rental 
                    {
                        Movie = _rembo,
                        DaysRented = 1
                    },
                    new Rental
                    {
                        Movie = _lotr,
                        DaysRented = 4
                    },
                    new Rental
                    {
                        Movie = _harryPotter,
                        DaysRented = 5
                    }
                ]);

            // When
            var result = _underTest.GenerateStatement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("Rembo\t2", result);
            Assert.Contains("The Lord of the Rings\t12", result);
            Assert.Contains("Harry Potter\t4,5", result);
            Assert.Contains("Amount: 18,5", result);
            Assert.Contains("Frequent Renter Points: 4", result);
        }

        [Fact]
        public void GenerateStatement_RegularWithoutAdditionalAmount()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _rembo,
                        DaysRented = 1
                    }
                ]);

            // When
            var result = _underTest.GenerateStatement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("Rembo\t2", result);
            Assert.Contains("Amount: 2", result);
            Assert.Contains("Frequent Renter Points: 1", result);
        }
        
        [Fact]
        public void GenerateStatement_RegularWithAdditionalAmount()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _rembo,
                        DaysRented = 3
                    }
                ]);

            // When
            var result = _underTest.GenerateStatement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("Rembo\t3,5", result);
            Assert.Contains("Amount: 3,5", result);
            Assert.Contains("Frequent Renter Points: 1", result);
        }

        [Fact]
        public void GenerateStatement_NewReleaseWithoutAdditionalFrequentPoints()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _lotr,
                        DaysRented = 1
                    }
                ]);

            // When
            var result = _underTest.GenerateStatement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("The Lord of the Rings\t3", result);
            Assert.Contains("Amount: 3", result);
            Assert.Contains("Frequent Renter Points: 1", result);
        }
        
        [Fact]
        public void GenerateStatement_NewReleaseWithAdditionalFrequentPoints()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _lotr,
                        DaysRented = 4
                    }
                ]);

            // When
            var result = _underTest.GenerateStatement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("The Lord of the Rings\t12", result);
            Assert.Contains("Amount: 12", result);
            Assert.Contains("Frequent Renter Points: 2", result);
        }

        [Fact]
        public void GenerateStatement_ChildrensWithoutAdditionalAmount()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _harryPotter,
                        DaysRented = 1
                    }
                ]);

            // When
            var result = _underTest.GenerateStatement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("Harry Potter\t1,5", result);
            Assert.Contains("Amount: 1,5", result);
            Assert.Contains("Frequent Renter Points: 1", result);
        }
        
        [Fact]
        public void GenerateStatement_ChildrensWithAdditionalAmount()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _harryPotter,
                        DaysRented = 5
                    }
                ]);

            // When
            var result = _underTest.GenerateStatement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("Harry Potter\t4,5", result);
            Assert.Contains("Amount: 4,5", result);
            Assert.Contains("Frequent Renter Points: 1", result);
        }

        [Fact]
        public void GenerateStatement_WithoutFilm()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = null,
                        DaysRented = 5
                    }
                ]);

            // When
            var result = _underTest.GenerateStatement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("\t0", result);
            Assert.Contains("Amount: 0", result);
            Assert.Contains("Frequent Renter Points: 1", result);
        }
    }
}
