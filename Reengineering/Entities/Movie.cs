using Reengineering.Enums;

namespace Reengineering.Entities
{
    public class Movie
    {
        public string? Title { get; set; }
        public MovieType Type { get; set; }

        public float CalculateCharge(int daysRented)
        {
            if (daysRented <= 0) return 0f;

            return Type switch
            {
                MovieType.Regular => CalculateRegularCharge(daysRented),
                MovieType.NewRelease => daysRented * 3,
                MovieType.Childrens => CalculateChildrensCharge(daysRented),
                _ => 0f
            };
        }

        private float CalculateRegularCharge(int daysRented)
        {
            return daysRented > 2 ? 2 + ((daysRented - 2) * 1.5f) : 2;
        }

        private float CalculateChildrensCharge(int daysRented)
        {
            return daysRented > 3 ? 1.5f + ((daysRented - 3) * 1.5f) : 1.5f;
        }
    }
}
