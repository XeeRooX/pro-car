using System.Security.Principal;

namespace ProCar.Dtos
{
    public class CarEditDto
    {
        public int CarId { get; set; }
        public string Model { get; set; } = null!;
        public double EngineСapacity { get; set; }
        public int YearOfIssue { get; set; }
        public int CostPerDay { get; set; }
        public int Deposit { get; set; }
        public int TimeDelayCost { get; set; }

        public int GearboxTypeId { get; set; }
        public int CarTypeId { get; set; }
        public int DriveTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int BrandId { get; set; }
    }
}
