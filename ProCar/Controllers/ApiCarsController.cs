using Microsoft.AspNetCore.Mvc;
using ProCar.Dtos;
using ProCar.Models;
using ProCar.Services;

namespace ProCar.Controllers
{


    [Route("api/cars")]
    [Produces("application/json")]
    [ApiController]
    public class ApiCarsController : Controller
    {
        private IBrandService _brandService;
        private ICarTypeService _carTypeService;
        private ICarsService _carsService;

        public ApiCarsController(IBrandService brandService, ICarTypeService carTypeService, ICarsService carsService) 
        {
            _brandService = brandService;
            _carTypeService = carTypeService;
            _carsService = carsService;
        }

        [HttpPost]
        public IActionResult GetCars([FromBody] InputModel input)
        {
            List<Brand> brands = _brandService.GetAll();
            List<CarType> carTypes = _carTypeService.GetAll();
            List<Car> cars = new();
            int countCars = 0;

            if (input.BrandId == 0 && input.CarTypeId == 0)
            {
                countCars = _carsService.CountCars();
                cars = _carsService.TakeCars(input.CountLoadedCars, input.HowManyLoad);
            }
            else if (input.BrandId != 0)
            {
                if (!_brandService.ElementExists(input.BrandId))
                {
                    return NotFound();
                }

                countCars = _brandService.GetById(input.BrandId).Cars.Count;
                cars = _carsService.TakeCars(input.CountLoadedCars, input.HowManyLoad, brandId: input.BrandId);
            }
            else if (input.CarTypeId != 0)
            {
                if (!_carTypeService.ElementExists(input.CarTypeId))
                {
                    return NotFound();
                }

                countCars = _carTypeService.GetById(input.CarTypeId).Cars.Count;
                cars = _carsService.TakeCars(input.CountLoadedCars, input.HowManyLoad, carTypeId: input.CarTypeId);
            }

            bool isLastPage = false;
            if (countCars - input.CountLoadedCars <= input.HowManyLoad) 
            {
                isLastPage = true;
            }

            List<CarsIndexDto> resCars = new();
            foreach (var c in cars)
            {
                resCars.Add(new CarsIndexDto()
                {
                    Id = c.Id,
                    Brand = c.Brand.Name, 
                    CostPerDay = c.CostPerDay,
                    GearboxType = c.GearboxType.Name,
                    Model = c.Model,
                    YearOfIssue = c.YearOfIssue
                });
            }

            return Json(new { cars = resCars, isLastPage = isLastPage});
        }

        public class InputModel
        {
            public int BrandId { get; set; }
            public int CarTypeId { get; set; }
            public int CountLoadedCars { get; set; }
            public int HowManyLoad { get; set; } = 6;
        }
    }
}
