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
        public void AddCar(CarAddDto carInfo)
        {
            var car = new Car() 
            {
                Model = carInfo.Model,
                EngineСapacity = carInfo.EngineСapacity,
                YearOfIssue = carInfo.YearOfIssue,
                CostPerDay = carInfo.CostPerDay,
                Deposit = carInfo.Deposit,  
                TimeDelayCost = carInfo.TimeDelayCost,
                CarTypeId = carInfo.CarTypeId,
                DriveTypeId = carInfo.DriveTypeId,
                GearboxTypeId = carInfo.GearboxTypeId,
                FuelTypeId = carInfo.FuelTypeId,
                BrandId = carInfo.BrandId
            };

            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            Car car = _context.Cars.Find(id)!;
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }

        public void EditCar(CarEditDto carInfo)
        {
            Car car = _context.Cars.Find(carInfo.CarId)!;
            car.CostPerDay = carInfo.CostPerDay;
            car.Model = carInfo.Model;
            car.EngineСapacity = carInfo.EngineСapacity;
            car.YearOfIssue = carInfo.YearOfIssue;
            car.Deposit = carInfo.Deposit;
            car.TimeDelayCost = carInfo.TimeDelayCost;
            car.CarTypeId = carInfo.CarTypeId;
            car.DriveTypeId = carInfo.DriveTypeId;  
            car.GearboxTypeId = carInfo.GearboxTypeId;
            car.FuelTypeId = carInfo.FuelTypeId;
            car.BrandId = carInfo.BrandId;

            _context.SaveChanges();
        }

        public bool ElementExists(int id)
        {
            return _context.Cars.Find(id) == null;
        }

        public List<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public List<CarAdminViewDto> GetAllCarsForView()
        {
            List<CarAdminViewDto> resultCars = new();
            var cars = _context.Cars.
                Include(c=>c.CarType).
                Include(c=>c.DriveType).
                Include(c=>c.GearboxType).
                Include(c=>c.FuelType).
                Include(c=>c.Brand);

            foreach (Car car in cars)
            {
                resultCars.Add(new CarAdminViewDto()
                {
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
            return _context.Cars.Find(id)!;
        }
    }
}
