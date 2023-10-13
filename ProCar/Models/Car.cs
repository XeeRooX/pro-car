using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace ProCar.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public double EngineСapacity { get; set; } // Объем двигатля
        public int YearOfIssue { get; set; } //год выпуска
        public int CostPerDay { get; set; } // стоимость за сутки
        public int Deposit { get; set; } // залог
        public int TimeDelayCost { get; set; } // стоимость задержки по времени
        public double? Horsepower { get; set; }
        public string? Equipment { get; set; }

        public int CarTypeId { get; set; }
        public CarType CarType { get; set; } = new();

        public int BrandId { get; set; }
        public Brand Brand { get; set; } = new();

        public int DriveTypeId { get; set; }
        public DriveType DriveType { get; set; } = new();

        public int FuelTypeId { get; set; }
        public FuelType FuelType { get; set; } = new();

        public int GearboxTypeId { get; set; }
        public GearboxType GearboxType { get; set; } = new();

        public List<Color> Colors { get; set; } = new();

    }
}
