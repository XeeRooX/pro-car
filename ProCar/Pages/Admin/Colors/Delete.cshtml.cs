using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Services;

namespace ProCar.Pages.Admin.Colors
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        public ICarTypeService _carTypeService { get; set; }
        public DeleteModel(ICarTypeService carTypeService)
        {
            _carTypeService = carTypeService;
        }
        public IActionResult OnGet(int id)
        {
            if(_carTypeService.ElementExists(id))
            {
                return NotFound();
            }
            return Page();
        }
    }
}
