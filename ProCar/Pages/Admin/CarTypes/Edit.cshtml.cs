using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ProCar.Models;
using ProCar.Services;
using System.ComponentModel.DataAnnotations;

namespace ProCar.Pages.Admin.CarTypes
{
    [Authorize]
    public class EditModel : PageModel
    {
        private ICarTypeService _typeService;
        public string? LastName { get; set; }
        [BindProperty]
        public InputModel? Input { get; set; }


        public EditModel(ICarTypeService typeService)
        {
            _typeService = typeService;
        }
        public IActionResult OnGet(int id)
        {
            if (!_typeService.ElementExists(id))
            {
                return NotFound();
            }

            LastName = _typeService.GetById(id).Name;
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            if (!_typeService.ElementExists(id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                LastName = _typeService.GetById(id).Name;
                return Page();
            }

            _typeService.EditType(id, Input.Name);
            return RedirectToPage("/Admin/CarTypes/Index");
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Это поле обязательно для заполнения")]
            [CarTypeNameUnique]
            public string Name { get; set; } = null!;
        }
    }
}
