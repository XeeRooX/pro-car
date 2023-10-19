namespace ProCar.Dtos
{
    public class CarAdminViewDto
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public double EngineСapacity { get; set; }
        public int YearOfIssue { get; set; }
        public int CostPerDay { get; set; }
        public int Deposit { get; set; }
        public int TimeDelayCost { get; set; }
        public double? Horsepower { get; set; }
        public string? Equipment { get; set; }

        public string GearboxType { get; set; } = null!;
        public string CarType { get; set; } = null!;
        public string DriveType { get; set; } = null!;
        public string FuelType { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public List<string> Colors { get; set; } = new();
    }
}
