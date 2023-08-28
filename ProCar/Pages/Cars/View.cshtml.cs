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
        public void OnGet(int id)
        {
            Car = _carsService.GetById(id);
            CountPhoto = _uploadService.CountCarPhotos(id);
        }
    }
}
