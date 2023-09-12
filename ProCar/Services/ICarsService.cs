using ProCar.Dtos;
using ProCar.Models;

namespace ProCar.Services
{
    public interface ICarsService
    {
        Car GetById(int id);
        int AddCar(CarAddDto carInfo);
        void EditCar(CarAddDto carInfo, int id);
        void DeleteCar(int id);
        bool ElementExists(int id);
        List<Car> GetAllCars();
        CarAddGetDto GetDataAddCarsGet();
        CarEditDto GetDataEditCars(int id);
        List<CarAdminViewDto> GetAllCarsForView();
        List<Car> TakeCars(int countLoadedCars, int howManyLoad, int brandId = 0, int carTypeId = 0);
        int CountCars();

    }
}
