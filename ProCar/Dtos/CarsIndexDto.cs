namespace ProCar.Dtos
{
    public class CarsIndexDto
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public int YearOfIssue { get; set; } 
        public int CostPerDay { get; set; }
        public string Brand { get; set; } = null!;
        public string GearboxType { get; set; } = null!;
    }
}
