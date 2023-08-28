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
        public CarAddGetDto DropdownFormData { get; set; }
        public CarEditDto FormData { get; set; }
        public int CountPhotos { get; set; }
        public string RequestString { get; set; }
        [BindProperty]
        public CarAddDto Input { get; set; }
        public EditModel(ICarsService carsService, IServerUploadService uploadService)
        {
            _carsService = carsService;
            _uploadService = uploadService;
        }
        public IActionResult OnGet(int id)
        {
            if (!_carsService.ElementExists(id))
            {
                return NotFound();
            }

            DropdownFormData = _carsService.GetDataAddCarsGet();
            FormData = _carsService.GetDataEditCars(id);
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
            _uploadService.DeleteCarPhoto(id);
            _uploadService.UploadCarPhoto(id, photos);

            return new JsonResult(new { redirectUrl = Url.Page("/Admin/Cars/Index") });
        }
    }
}
