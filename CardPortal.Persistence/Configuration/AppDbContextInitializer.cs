using CardPortal.Domain.AggregateModel.Vendor.Address.City;
using Microsoft.EntityFrameworkCore;

namespace CardPortal.Persistence.Configuration
{
    public class AppDbContextInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public AppDbContextInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        // Seed Data On Init
        public void SeedData()
        {
            _modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Amsterdam" },
                new City { Id = 2, Name = "Berlin" },
                new City { Id = 3, Name = "Madrid" },
                new City { Id = 4, Name = "Rome" },
                new City { Id = 5, Name = "London" }
            );
        }
    }
}
