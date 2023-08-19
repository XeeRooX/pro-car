using ProCar.Dtos;
using ProCar.Models;

namespace ProCar.Services
{
    public interface ICarsService
    {
        Car GetById(int id);
        void AddCar(CarAddDto carInfo);
        void EditCar(CarEditDto carInfo);
        void DeleteCar(int id);
        bool ElementExists(int id);
        List<Car> GetAllCars();
        List<CarAdminViewDto> GetAllCarsForView();

    }
}
