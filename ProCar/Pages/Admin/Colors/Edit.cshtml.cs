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
        public IColorService _colorService { get; set; }
        public EditModel(IColorService colorService)
        {
            _colorService = colorService;
        }
        public IActionResult OnGet(int id)
        {
            if (!_colorService.ElementExists(id))
            {
                return NotFound();
            }
            var item = _colorService.GetById(id);
            LastName = item.Name;
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (!_colorService.ElementExists(id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                LastName = _colorService.GetById(id).Name;
                return Page();
            }

            _colorService.EditItem(id, Input.Name);
            return RedirectToPage("/Admin/Colors/Index");
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
