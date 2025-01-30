using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProCar.Models;

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
        public DbSet<SocialNetwork> SocialNetworks { get; set; } = null!;
        public DbSet<ContactDetails> ContactDetails { get; set; } = null!;

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

            modelBuilder.Entity<ContactDetails>().HasData(
                new ContactDetails()
                {
                    Id = 1,
                    Address = "г. Оренбург, ул. Одесская, 23",
                    Email = "proavtooren@yandex.ru",
                    PhoneNumber = "+7 969 749 00-43",
                    MapPoint = "https://api-maps.yandex.ru/services/constructor/1.0/js/?um=constructor%3Ae15ba2ef1d406f5e87f54c6717959fd2adddc1f41e48301d66d7136c56266532&amp;width=100%25&amp;height=600&amp;lang=ru_RU&amp;scroll=false"
                });

            modelBuilder.Entity<SocialNetwork>().HasData(
                new SocialNetwork() { Id = 1, Name = "Телеграм", Icon= "telegram", Link= "https://t.me/yandex_taxi23" },
                new SocialNetwork() { Id = 2, Name = "whats app", Icon = "whatsapp", Link = "https://wa.me/79697490043" },
                new SocialNetwork() { Id = 3, Name = "instagram", Icon = "instagram", Link = "https://www.instagram.com/fgfdg" }
                );
        }
    }
}
