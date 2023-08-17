namespace ProCar.Models
{
    public class CarType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Car> Cars { get; set; } = new();
    }
}
