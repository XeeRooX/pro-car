using ProCar.Models;

namespace ProCar.Services
{
    public interface ICarsService
    {
        Car GetById(int id);
        void AddCar();
    }
}
