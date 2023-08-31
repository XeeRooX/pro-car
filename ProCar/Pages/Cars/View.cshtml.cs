using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Services;
using ProCar.Models;
using Microsoft.AspNetCore.Authorization;

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

        public IActionResult OnPost(InputModel model)
        {

            return Page();
        }
        public class InputModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public string RentFrom { get; set; } = null!;
            public string RentBefore { get; set; } = null!;
            public string Phone { get; set; } = null!;

        }
    }
    
}
