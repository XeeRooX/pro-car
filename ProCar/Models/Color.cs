namespace ProCar.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Car> Cars { get; set; } = new();
    }
}
