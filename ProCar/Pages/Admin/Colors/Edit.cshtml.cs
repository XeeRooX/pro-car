using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Pages.Admin.CarTypes;
using ProCar.Services;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ProCar.Pages.Admin.Colors
{
    [Authorize]
    public class EditModel : PageModel
    {
        public string? LastName { get; set; }
        [BindProperty]
        public InputModel? Input { get; set; }
        public ICarTypeService _carTypeService { get; set; }
        public EditModel(ICarTypeService carTypeService)
        {
            _carTypeService = carTypeService;
        }
        public IActionResult OnGet(int id)
        {
            if (!_carTypeService.ElementExists(id))
            {
                return NotFound();
            }
            var item = _carTypeService.GetById(id);
            LastName = item.Name;
            return Page();
        }
    }
    public class InputModel
    {
        [Required(ErrorMessage = "Ёто поле об€зательно дл€ заполнени€")]
        [ColorNameUnique]
        [MaxLength(50, ErrorMessage = "ћаксимальна€ длина названи€ - {0} символов")]
        public string Name { get; set; } = null!;
    }
}
