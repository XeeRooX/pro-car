using Microsoft.EntityFrameworkCore;
using ProCar.Dtos;
using ProCar.Models;
using System.Dynamic;

namespace ProCar.Services
{
    public class CarsService : ICarsService
    {
        private ApplicationDbContext _context;
        private IColorService _colorService;
        public CarsService(ApplicationDbContext context, IColorService colorService)
        {
            _context = context;
            _colorService = colorService;
        }
        public int AddCar(CarAddDto carInfo)
        {
            var colors = new List<Color>();
            foreach (var colorId in carInfo.Colors)
            {
                var color = _colorService.GetById(colorId);
                colors.Add(color);
            }

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
                Brand = _context.Brands.Find(carInfo.BrandId)!,
                Horsepower = carInfo.Horsepower,
                Equipment = carInfo.Equipment,
                Colors = colors
            };

            _context.Cars.Add(car);
            
            _context.SaveChanges();
            return car.Id;
        }

        public int CountCars()
        {
            return _context.Cars.Count();
        }

        public void DeleteCar(int id)
        {
            Car car = _context.Cars.Find(id)!;
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }

        public void EditCar(CarAddDto carInfo, int id)
        {
            var colors = new List<Color>();
            foreach (var colorId in carInfo.Colors)
            {
                var color = _colorService.GetById(colorId);
                colors.Add(color);
            }

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
            car.Horsepower = carInfo.Horsepower;
            car.Equipment = carInfo.Equipment;
            car.Colors = colors;

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
            return _context.Cars.Include(a => a.Brand).Include(a => a.FuelType).Include(a => a.GearboxType).Include(a => a.CarType).Include(a=>a.DriveType).Include(a=>a.Colors).FirstOrDefault(a => a.Id == id)!;
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


            Car car = _context.Cars.Include(c=>c.Colors).FirstOrDefault(c=>c.Id == id)!;
            var colors =new List<int>();

            foreach (var color in car.Colors)
            {
                colors.Add(color.Id);   
            }

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
                YearOfIssue = car.YearOfIssue,
                Equipment = car.Equipment,
                Horsepower = car.Horsepower,
                Colors = colors
            };

            return result;
        }

        public List<Car> TakeCars(int countLoadedCars, int howManyLoad, int brandId = 0, int carTypeId = 0)
        {
            if (brandId != 0)
            {
                var cars = _context.Cars.
                    Where(c => c.BrandId == brandId).
                    Include(x => x.CarType).Include(x => x.Brand).Include(x => x.DriveType).Include(x => x.FuelType).Include(x => x.GearboxType);

                var res = cars.Skip(countLoadedCars).Take(howManyLoad).ToList();
                return res;
            }
            else if(carTypeId != 0)
            {
                var cars = _context.Cars.
                    Where(c => c.CarTypeId == carTypeId).
                    Include(x => x.CarType).Include(x => x.Brand).Include(x => x.DriveType).Include(x => x.FuelType).Include(x => x.GearboxType);

                var res = cars.Skip(countLoadedCars).Take(howManyLoad).ToList();
                return res;
            }
            else
            {
                var cars = _context.Cars.
                    Include(x => x.CarType).Include(x => x.Brand).Include(x => x.DriveType).Include(x => x.FuelType).Include(x => x.GearboxType);

                var res = cars.Skip(countLoadedCars).Take(howManyLoad).ToList();
                return res;
            }
        }
    }
}
