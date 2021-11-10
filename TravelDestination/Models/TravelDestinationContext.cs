using Microsoft.EntityFrameworkCore;

namespace TravelDestination.Models
{
    public class TravelDestinationContext : DbContext
    {
        public TravelDestinationContext(
            DbContextOptions<TravelDestinationContext> options
        ) :
            base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Review>()
                .HasData(new Review {
                    ReviewId = 1,
                    Destination = "Bermuda Triangle",
                    Country = "Atlantic",
                    City = "Ocean",
                    Rating = 10
                },
                new Review {
                    ReviewId = 2,
                    Destination = "Great Pyramids",
                    Country = "Egypt",
                    City = "Giza",
                    Rating = 9
                },
                new Review {
                    ReviewId = 3,
                    Destination = "Great Wall",
                    Country = "China",
                    City = "Beijing",
                    Rating = 10
                },
                new Review {
                    ReviewId = 4,
                    Destination = "Old Faithful",
                    Country = "USA",
                    City = "Yellowstone",
                    Rating = 9
                },
                new Review {
                    ReviewId = 5,
                    Destination = "Rocky Butte",
                    Country = "USA",
                    City = "Portland",
                    Rating = 9
                },
                new Review {
                    ReviewId = 6,
                    Destination = "Rocky Butte",
                    Country = "USA",
                    City = "Portland",
                    Rating = 2
                },
                new Review {
                    ReviewId = 7,
                    Destination = "Rocky Butte",
                    Country = "USA",
                    City = "Portland",
                    Rating = 5
                });
        }
    }
}
