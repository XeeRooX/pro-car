using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;

namespace ProCar.Pages.Admin.CarTypes
{
    public class EditModel : PageModel
    {
        private ICarTypeService _typeService;
        public string LastName { get; set; }
        public string ErrorMsg { get; set; }

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

        public IActionResult OnPost(int id, string name)
        {
            if (!_typeService.ElementExists(id))
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(name))
            {
                ErrorMsg = "Ошибка редактирования: значение не может быть пустой строкой";
                return Page();
            }
            if (_typeService.ValueExists(name))
            {
                LastName = name;
                ErrorMsg = "Ошибка редактирования: тип машины с таким именем уже существует";
                return Page();
            }

            _typeService.EditType(id, name);
            return RedirectToPage("/Admin/CarTypes/Index");
        }
    }
}
