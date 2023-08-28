using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Services;

namespace ProCar.Pages.Admin.Cars
{
    public class DeleteModel : PageModel
    {
        private ICarsService _carsService;
        private IServerUploadService _uploadService;
        public DeleteModel(ICarsService carsService, IServerUploadService uploadService)
        {
            _carsService = carsService;
            _uploadService = uploadService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int id)
        {
            if (!_carsService.ElementExists(id))
            {
                return NotFound();
            }

            _carsService.DeleteCar(id);
            _uploadService.DeleteCarPhoto(id);

            return RedirectToPage("/Admin/Cars/Index");
        }
    }
}
