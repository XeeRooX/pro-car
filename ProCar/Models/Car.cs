using Microsoft.AspNetCore.Authorization;
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

        public CarType CarType { get; set; } = null!;

    }
}
