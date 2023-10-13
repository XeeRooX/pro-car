using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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
        public DbSet<Color> Colors { get; set; } = null!;
        //public DbSet<CarColor> CarColors { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //    modelBuilder.Entity<Car>()
        //.HasMany(e => e.Colors)
        //.WithMany(e => e.Cars)
        //.UsingEntity<CarColor>(
        //    l => l.HasOne<Color>(e => e.Color).WithMany(e => e.CarColors).HasForeignKey(e => e.ColorId),
        //    r => r.HasOne<Car>(e => e.Car).WithMany(e => e.CarColors).HasForeignKey(e => e.CarId));

        //    modelBuilder.Entity<Car>().HasOptional();

            modelBuilder.Entity<GearboxType>().HasData(
                new GearboxType() { Id = 1, Name = "механическая" },
                new GearboxType() { Id = 2, Name = "автомат" },
                new GearboxType() { Id = 3, Name = "вариатор" },
                new GearboxType() { Id = 4, Name = "робот" }
                );
            modelBuilder.Entity<DriveType>().HasData(
                new DriveType() { Id = 1, Name = "передний" },
                new DriveType() { Id = 2, Name = "полный" },
                new DriveType() { Id = 3, Name = "задний" }
                );
            modelBuilder.Entity<FuelType>().HasData(
                new FuelType() { Id = 1, Name = "бензин" },
                new FuelType() { Id = 2, Name = "дизель" },
                new FuelType() { Id = 3, Name = "электричество" },
                new FuelType() { Id = 4, Name = "пропан" },
                new FuelType() { Id = 5, Name = "метан" }
                );
        }
    }
}
