using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;

namespace ProCar.Pages.Admin.Brands
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private IBrandService _brandService;
        private IServerUploadService _serverUploadService;

        public DeleteModel(IBrandService brandService, IServerUploadService serverUploadService)
        {
            _brandService = brandService;
            _serverUploadService = serverUploadService;
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
            _serverUploadService.DeleteBrandPhoto(id);
            return RedirectToPage("/Admin/Brands/Index");
        }
    }
}
