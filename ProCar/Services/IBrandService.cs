using ProCar.Models;

namespace ProCar.Services
{
    public interface IBrandService
    {
        Brand GetById(int id);
        Brand AddType(string name);
        void EditType(int id, string name);
        void DeleteType(int id);
        bool ElementExists(int id);
        List<Brand> GetAll();
        int ElementExists(string name);
    }
}
