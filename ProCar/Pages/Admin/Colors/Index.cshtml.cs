using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Pages.Admin.CarTypes;
using ProCar.Services;
using System.ComponentModel.DataAnnotations;

namespace ProCar.Pages.Admin.Colors
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public List<Color>? Colors { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public string ErrorMsg { get; set; }
        public IColorService _colorService { get; set; }
        public IndexModel(IColorService colorService)
        {
            _colorService = colorService;
        }
        public void OnGet()
        {
            Colors = _colorService.GetAll();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Colors = _colorService.GetAll();
                return Page();
            }

            _colorService.AddItem(Input.Name);
            Colors = _colorService.GetAll();
            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Ёто поле об€зательно дл€ заполнени€")]
            [ColorNameUnique]
            [MaxLength(50, ErrorMessage = "ћаксимальна€ длина названи€ - {0} символов")]
            public string Name { get; set; } = null!;
        }
    }
}
