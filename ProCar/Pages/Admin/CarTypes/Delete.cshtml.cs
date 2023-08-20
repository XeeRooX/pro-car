using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Services;

namespace ProCar.Pages.Admin.CarTypes
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private ICarTypeService _typeService;
        public DeleteModel(ICarTypeService typeService)
        {
            _typeService = typeService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int id) 
        {
            if(!_typeService.ElementExists(id))
            {
                return NotFound();
            }

            _typeService.DeleteType(id);

            return RedirectToPage("/Admin/CarTypes/Index");
        }    
    }
}
