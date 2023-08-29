using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Services;
using ProCar.Models;

namespace ProCar.Pages.Cars
{
    public class ViewModel : PageModel
    {
        private readonly ICarsService _carsService;
        private readonly IServerUploadService _uploadService;

        public Car Car { get; set; } = new();
        public int CountPhoto { get; set; }
        public ViewModel(ICarsService carsService, IServerUploadService uploadService)
        {
            _carsService = carsService;
            _uploadService = uploadService;
        }
        public IActionResult OnGet(int id)
        {
            Car = _carsService.GetById(id);
            if(Car == null)
            {
                return NotFound();
            }
            CountPhoto = _uploadService.CountCarPhotos(id);
            return Page();
        }
    }
}
