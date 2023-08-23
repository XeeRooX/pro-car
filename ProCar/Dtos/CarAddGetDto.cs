using ProCar.Models;

namespace ProCar.Dtos
{
    public class CarAddGetDto
    {
        public List<GearboxType> GearboxTypes { get; set; }
        public List<CarType> CarTypes { get; set; }
        public List<Models.DriveType> DriveTypes { get; set; }
        public List<FuelType> FuelTypes { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
