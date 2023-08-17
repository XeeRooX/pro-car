namespace ProCar.Models
{
    // Тип топлива
    public class FuelType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Car> Cars { get; set; } = new();

    }
}
