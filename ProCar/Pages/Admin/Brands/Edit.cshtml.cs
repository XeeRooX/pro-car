using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;

namespace ProCar.Pages.Admin.Brands
{
    public class EditModel : PageModel
    {
        private IBrandService _brandService;

        public string? Message { get; set; }
        public Brand Brand { get; set; } = new();
        public EditModel(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public IActionResult OnGet(int id)
        {
            if (!_brandService.ElementExists(id))
            {
                return NotFound();
            }

            Brand = _brandService.GetById(id);
            return Page();
        }

        public IActionResult OnPost(int id, string name)
        {
            if (!_brandService.ElementExists(id) )
            {
                return NotFound();
            }
            else if(name == null)
            {
                Message = "ошибка редактирования: неккоректно введено значение";
                Brand = _brandService.GetById(id);
                return Page();
            }
            else if (_brandService.ElementExists(name))
            {
                Message = "ошибка редактирования: элемент с таким именем уже существует";
                Brand = _brandService.GetById(id);
                return Page();
            }

            _brandService.EditType(id, name);
            return RedirectToPage("/Admin/Brands/Index");
        }
    }
}
