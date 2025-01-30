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
        private readonly IContactService _contactService;

        public List<Brand> Brands { get; set; }
        public List<CarType> CarTypes { get; set; }
        public List<Car> Cars { get; set; }

        public int BrandId { get; set; }
        public int CarTypeId { get; set; }
        public bool ShowLoadButton { get; set; } = false;

        public IndexModel(IBrandService brandService, ICarTypeService carTypeService, ICarsService carsService, IContactService contactService)
        {
            _brandService = brandService;
            _carTypeService = carTypeService;
            _carsService = carsService;
            _contactService = contactService;
        }
        public IActionResult OnGet(int brand, int cartype)
        {
            ViewData[nameof(ContactDetails)] = _contactService.GetContactDetails();
            ViewData["SocialNetworks"] = _contactService.GetSocialNetworks();

            const int countLoad = 6;
            int countCars = 0;

            Brands = _brandService.GetAll();
            CarTypes = _carTypeService.GetAll();

            BrandId = brand;
            CarTypeId = cartype;
            if (brand == 0 && cartype == 0)
            {
                countCars = _carsService.CountCars();
                Cars = _carsService.TakeCars(0, countLoad);
            }
            else if(brand !=0)
            {
                if (!_brandService.ElementExists(brand))
                {
                    return NotFound();
                }

                countCars = _brandService.GetById(brand).Cars.Count;
                Cars = _carsService.TakeCars(0, countLoad, brandId: brand);
            }
            else if(cartype != 0)
            {
                if (!_carTypeService.ElementExists(cartype))
                {
                    return NotFound();
                }

                countCars = _carTypeService.GetById(cartype).Cars.Count;
                Cars = _carsService.TakeCars(0, countLoad, carTypeId: cartype);
            }

            if (countCars > countLoad)
            {
                ShowLoadButton = true;
            }

            return Page();
        }


    }
}
