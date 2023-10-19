using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Services;

namespace ProCar.Pages.Admin.Colors
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        public IColorService _colorService { get; set; }
        public DeleteModel(IColorService colorService)
        {
            _colorService = colorService;
        }
        public IActionResult OnGet(int id)
        {
            if(_colorService.ElementExists(id))
            {
                return NotFound();
            }
            return Page();
        }
    }
}
