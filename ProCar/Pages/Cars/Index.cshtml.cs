using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;
using System.Reflection.Metadata.Ecma335;

namespace ProCar.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private IBrandService _brandService;
        private ICarTypeService _carTypeService;
        private ICarsService _carsService;

        public List<Brand> Brands { get; set; }
        public List<CarType> CarTypes { get; set; }
        public List<Car> Cars { get; set; }

        public int BrandId { get; set; }
        public int CarTypeId { get; set; }

        public IndexModel(IBrandService brandService, ICarTypeService carTypeService, ICarsService carsService)
        {
            _brandService = brandService;
            _carTypeService = carTypeService;
            _carsService = carsService;
        }
        public void OnGet(int brand, int cartype)
        {
            Brands = _brandService.GetAll();
            CarTypes = _carTypeService.GetAll();

            BrandId = brand;
            CarTypeId = cartype;
            if (brand == 0 && cartype == 0)
            {
                Cars = _carsService.GetAllCars();
            }
            else if(brand !=0)
            {
                Cars = _brandService.GetById(brand).Cars;
            }
            else if(cartype != 0)
            {
                Cars = _carTypeService.GetById(cartype).Cars;
            }
        }


    }
}
