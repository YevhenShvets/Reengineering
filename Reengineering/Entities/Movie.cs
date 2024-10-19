using Reengineering.Entities.Prices;

namespace Reengineering.Entities
{
    public class Movie
    {
        public string? Title { get; set; }
        public IPriceCalculator? PriceCalculator { get; set; }
    }
}
