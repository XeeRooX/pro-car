using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Dtos;
using ProCar.Services;
using System.ComponentModel.DataAnnotations;

namespace ProCar.Pages.Admin.Cars
{
    //[Authorize]
    public class AddModel : PageModel
    {
        private ICarsService _carsService;
        private IServerUploadService _uploadService;
        public CarAddGetDto FormData { get; set; }

        [BindProperty]
        public CarAddDto Input { get; set; }
        public AddModel(ICarsService carsService, IServerUploadService uploadService)
        {
            _carsService = carsService;
            _uploadService = uploadService;
        }
        public void OnGet()
        {
            FormData = _carsService.GetDataAddCarsGet();
        }

        public IActionResult OnPost(IFormFileCollection photos)
        {

            Console.WriteLine();
            if (!ModelState.IsValid)
            {
                FormData = _carsService.GetDataAddCarsGet();
                return Page();
            }
            FormData = _carsService.GetDataAddCarsGet();

            int idCar = _carsService.AddCar(Input);
            _uploadService.UploadCarPhoto(idCar, photos);
            
            return new JsonResult(new { redirectUrl = Url.Page("/Admin/Cars/Index") });
        }
    }
}
