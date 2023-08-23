using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Services;

namespace ProCar.Pages.Admin.Cars
{
    public class DeleteModel : PageModel
    {
        private ICarsService _carsService;
        public DeleteModel(ICarsService carsService)
        {
            _carsService = carsService;
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

            return RedirectToPage("/Admin/Cars/Index");
        }
    }
}
