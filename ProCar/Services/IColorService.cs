using ProCar.Models;

namespace ProCar.Services
{
    public interface IColorService
    {
        Color GetById(int id);
        Color AddItem(string name);
        void EditItem(int id, string name);
        void DeleteItem(int id);
        bool ElementExists(int id);
        List<Color> GetAll();
        int ElementExists(string name);
    }
}
