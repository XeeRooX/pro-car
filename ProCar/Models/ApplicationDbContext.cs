using Microsoft.EntityFrameworkCore;

namespace ProCar.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<CarType> CarTypes { get; set; } = null!;
        public DbSet<DriveType> DriveTypes { get; set; } = null!;
        public DbSet<GearboxType> GearboxTypes { get; set; } = null!;
        public DbSet<FuelType> FuelTypes { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
    }
}
