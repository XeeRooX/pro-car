namespace ProCar.Models
{
    // Тип коробки передач
    public class GearboxType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Car> Cars { get; set; } = new();
    }
}
