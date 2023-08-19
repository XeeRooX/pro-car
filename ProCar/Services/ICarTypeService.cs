using ProCar.Models;

namespace ProCar.Services
{
    public interface ICarTypeService
    {
        CarType GetById(int id);
        CarType AddType(string name);
        void EditType(int id, string name);
        void DeleteType(int id);
        bool ElementExists(int id);
        bool ValueExists(string name);
        List<CarType> GetAll();
    }
}
