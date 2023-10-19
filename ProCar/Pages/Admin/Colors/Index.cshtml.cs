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
        public class InputModel
        {
            [Required(ErrorMessage = "Ёто поле об€зательно дл€ заполнени€")]
            [ColorNameUnique]
            [MaxLength(50, ErrorMessage = "ћаксимальна€ длина названи€ - {0} символов")]
            public string Name { get; set; } = null!;
        }
    }
}
