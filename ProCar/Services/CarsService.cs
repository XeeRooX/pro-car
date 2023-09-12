using Microsoft.EntityFrameworkCore;
using ProCar.Dtos;
using ProCar.Models;
using System.Dynamic;

namespace ProCar.Services
{
    public class CarsService : ICarsService
    {
        private ApplicationDbContext _context;
        public CarsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public int AddCar(CarAddDto carInfo)
        {
            var car = new Car()

            {
                Model = carInfo.Model,
                EngineСapacity = carInfo.EngineСapacity,
                YearOfIssue = carInfo.YearOfIssue,
                CostPerDay = carInfo.CostPerDay,
                Deposit = carInfo.Deposit,
                TimeDelayCost = carInfo.TimeDelayCost,
                CarType = _context.CarTypes.Find(carInfo.CarTypeId)!,
                DriveType = _context.DriveTypes.Find(carInfo.DriveTypeId)!,
                GearboxType = _context.GearboxTypes.Find(carInfo.GearboxTypeId)!,
                FuelType = _context.FuelTypes.Find(carInfo.FuelTypeId)!,
                Brand = _context.Brands.Find(carInfo.BrandId)!
            };

            _context.Cars.Add(car);
            
            _context.SaveChanges();
            return car.Id;
        }

        public void DeleteCar(int id)
        {
            Car car = _context.Cars.Find(id)!;
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }

        public void EditCar(CarAddDto carInfo, int id)
        {
            Car car = _context.Cars.Find(id)!;
            car.CostPerDay = carInfo.CostPerDay;
            car.Model = carInfo.Model;
            car.EngineСapacity = carInfo.EngineСapacity;
            car.YearOfIssue = carInfo.YearOfIssue;
            car.Deposit = carInfo.Deposit;
            car.TimeDelayCost = carInfo.TimeDelayCost;
            car.CarType = _context.CarTypes.Find(carInfo.CarTypeId)!;
            car.DriveType = _context.DriveTypes.Find(carInfo.DriveTypeId)!;
            car.GearboxType = _context.GearboxTypes.Find(carInfo.GearboxTypeId)!;
            car.FuelType = _context.FuelTypes.Find(carInfo.FuelTypeId)!;
            car.Brand = _context.Brands.Find(carInfo.BrandId)!;

            _context.SaveChanges();
        }

        public bool ElementExists(int id)
        {
            return _context.Cars.Find(id) != null;
        }

        public List<Car> GetAllCars()
        {
            return _context.Cars.Include(c=>c.GearboxType).ToList();
        }

        public List<CarAdminViewDto> GetAllCarsForView()
        {
            List<CarAdminViewDto> resultCars = new();
            var cars = _context.Cars.
                Include(c => c.CarType).
                Include(c => c.DriveType).
                Include(c => c.GearboxType).
                Include(c => c.FuelType).
                Include(c => c.Brand);

            foreach (Car car in cars)
            {
                resultCars.Add(new CarAdminViewDto()
                {
                    Id = car.Id,
                    Model = car.Model,
                    EngineСapacity = car.EngineСapacity,
                    YearOfIssue = car.YearOfIssue,
                    CostPerDay = car.CostPerDay,
                    Deposit = car.Deposit,
                    TimeDelayCost = car.TimeDelayCost,
                    CarType = car.CarType.Name,
                    DriveType = car.DriveType.Name,
                    GearboxType = car.GearboxType.Name,
                    FuelType = car.FuelType.Name,
                    Brand = car.Brand.Name,
                });
            }

            return resultCars;
        }

        public Car GetById(int id)
        {
            return _context.Cars.Include(a => a.Brand).Include(a => a.FuelType).Include(a => a.GearboxType).Include(a => a.CarType).Include(a=>a.DriveType).FirstOrDefault(a => a.Id == id)!;
        }

        public CarAddGetDto GetDataAddCarsGet()
        {
            CarAddGetDto result = new()
            {
                Brands = _context.Brands.ToList(),
                CarTypes = _context.CarTypes.ToList(),
                DriveTypes = _context.DriveTypes.ToList(),
                FuelTypes = _context.FuelTypes.ToList(),
                GearboxTypes = _context.GearboxTypes.ToList()
            };

            return result;
        }

        public CarEditDto GetDataEditCars(int id)
        {
            Car car = _context.Cars.Find(id)!;
            CarEditDto result = new()
            {
                BrandId = car.BrandId,
                CarId = id,
                CarTypeId = car.CarTypeId,
                CostPerDay = car.CostPerDay,
                Deposit = car.Deposit,
                DriveTypeId = car.DriveTypeId,
                EngineСapacity = car.EngineСapacity,
                FuelTypeId = car.FuelTypeId,
                GearboxTypeId = car.GearboxTypeId,
                Model = car.Model,
                TimeDelayCost = car.TimeDelayCost,
                YearOfIssue = car.YearOfIssue
            };

            return result;
        }
    }
}
