using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;
using System.ComponentModel.DataAnnotations;

namespace ProCar.Pages.Admin.CarTypes
{
    public class IndexModel : PageModel
    {
        private ICarTypeService _typeService;
        public List<CarType>? CarTypes { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public string ErrorMsg { get; set; }
        public IndexModel(ICarTypeService typeService)
        {
            _typeService = typeService;
        }
        public void OnGet()
        {
            var carTypes = _typeService.GetAll();
            CarTypes = carTypes;
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                CarTypes = _typeService.GetAll();
                return Page();
            }

            _typeService.AddType(Input.Name);
            CarTypes = _typeService.GetAll();
            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Это поле обязательно для заполнения")]
            [CarTypeNameUnique]
            public string Name { get; set; } = null!;
        }
    }
}
