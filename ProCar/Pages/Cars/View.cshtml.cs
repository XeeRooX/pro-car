using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Services;
using ProCar.Models;

namespace ProCar.Pages.Cars
{
    public class ViewModel : PageModel
    {
        private readonly ICarsService _carsService;

        public Car Car { get; set; } = new();
        public ViewModel(ICarsService carsService)
        {
            _carsService = carsService;
        }
        public void OnGet(int id)
        {
            Car = _carsService.GetById(id);
        }
    }
}
