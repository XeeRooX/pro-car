using Microsoft.EntityFrameworkCore;
using ProCar.Models;

namespace ProCar.Services
{
    public class CarTypeService : ICarTypeService
    {
        private ApplicationDbContext _context;
        public CarTypeService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public CarType AddType(string name)
        {
            var carType = new CarType() { Name = name };
            _context.CarTypes.Add(carType);
            _context.SaveChanges();
            return carType; 
        }

        public void DeleteType(int id)
        {
            var carType = _context.CarTypes.Find(id);
            _context.CarTypes.Remove(carType!);
            _context.SaveChanges();
        }

        public void EditType(int id, string name)
        {
            var carType = _context.CarTypes.Find(id);
            carType!.Name = name;
            _context.SaveChanges();
        }

        public bool ElementExists(int id)
        {
            return _context.CarTypes.Find(id) != null;
        }

        public List<CarType> GetAll()
        {
            return _context.CarTypes.ToList();
        }

        public CarType GetById(int id)
        {
            return _context.CarTypes.Include(a=>a.Cars).ThenInclude(a=>a.GearboxType).FirstOrDefault(a=>a.Id == id)!;
        }

        public List<CarType> GetTypesNotEmpty()
        {
            return _context.CarTypes.Include(a => a.Cars).ThenInclude(a => a.GearboxType).Include(a=>a.Cars).ThenInclude(a=>a.Brand).Where(a=>a.Cars.Count!=0).ToList();
        }

        public bool ValueExists(string name)
        {
            return _context.CarTypes.FirstOrDefault(x=>x.Name == name) != null; 
        }
    }
}
