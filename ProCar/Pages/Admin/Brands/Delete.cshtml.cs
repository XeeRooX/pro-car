using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;

namespace ProCar.Pages.Admin.Brands
{
    public class DeleteModel : PageModel
    {
        private IBrandService _brandService;

        public DeleteModel(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public IActionResult OnGet(int id)
        {
            if (!_brandService.ElementExists(id))
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            if (!_brandService.ElementExists(id))
            {
                return NotFound();
            }

            _brandService.DeleteType(id);
            return RedirectToPage("/Admin/Brands/Index");
        }
    }
}
