using System.ComponentModel.DataAnnotations;

namespace ProCar.Dtos
{
    public class CarEditGetDto
    {
        public string Model { get; set; } = null!;
        public double EngineСapacity { get; set; }
        public int YearOfIssue { get; set; }
        public int CostPerDay { get; set; }
        public int Deposit { get; set; }
        public int TimeDelayCost { get; set; }
    }
}
