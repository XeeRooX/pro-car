using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Dtos;
using ProCar.Services;

namespace ProCar.Pages.Admin.Cars
{
    [Authorize]
    public class EditModel : PageModel
    {
        private ICarsService _carsService;
        private IServerUploadService _uploadService;
        private readonly IColorService _colorService;
        public CarAddGetDto DropdownFormData { get; set; }
        public CarEditDto FormData { get; set; }
        public List<Models.Color> Colors { get; set; }
        public int CountPhotos { get; set; }
        public string RequestString { get; set; }
        [BindProperty]
        public CarAddDto Input { get; set; }
        public EditModel(ICarsService carsService, IServerUploadService uploadService, IColorService colorService)
        {
            _carsService = carsService;
            _uploadService = uploadService;
            _colorService = colorService;
        }
        public IActionResult OnGet(int id)
        {
            if (!_carsService.ElementExists(id))
            {
                return NotFound();
            }

            DropdownFormData = _carsService.GetDataAddCarsGet();
            FormData = _carsService.GetDataEditCars(id);
            Colors = _colorService.GetAll();
            CountPhotos = _uploadService.CountCarPhotos(id);
            RequestString = $"{id}/";

            return Page();
        }

        public IActionResult OnPost(int id, IFormFileCollection photos)
        {
            if (!_carsService.ElementExists(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                DropdownFormData = _carsService.GetDataAddCarsGet();
                FormData = _carsService.GetDataEditCars(id);
                return Page();
            }

            _carsService.EditCar(Input, id);
            Colors = _colorService.GetAll();
            _uploadService.DeleteCarPhoto(id);
            _uploadService.UploadCarPhoto(id, photos);

            return new JsonResult(new { redirectUrl = Url.Page("/Admin/Cars/Index") });
        }
    }
}
