using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Dtos;
using ProCar.Services;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ProCar.Pages.Admin.Cars
{
    //[Authorize]
    public class AddModel : PageModel
    {
        private ICarsService _carsService;
        private IServerUploadService _uploadService;
        private IColorService _colorService;
        public CarAddGetDto FormData { get; set; }
        public List<Models.Color> Colors { get; set; }
        [BindProperty]
        public CarAddDto Input { get; set; }
        public AddModel(ICarsService carsService, IServerUploadService uploadService, IColorService colorService)
        {
            _carsService = carsService;
            _uploadService = uploadService;
            _colorService = colorService;
        }
        public void OnGet()
        {
            FormData = _carsService.GetDataAddCarsGet();
            Colors = _colorService.GetAll();
        }

        public IActionResult OnPost(IFormFileCollection photos)
        {

            Console.WriteLine();
            if (!ModelState.IsValid)
            {
                Colors = _colorService.GetAll();
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
