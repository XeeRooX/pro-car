using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Services;

namespace ProCar.Pages.Admin.Brands
{
    public class CreateModel : PageModel
    {
        private IBrandService _brandService;

        public string Message { get; set; }
        public CreateModel(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(string name)
        {
            if (_brandService.ElementExists(name))
            {
                Message = "ошибка добавления: элемент уже существует";
                return Page();
            }
            else if(name == null)
            {
                Message = "ошибка добавления: неккоректно введено значение";
                return Page();
            }

            Console.WriteLine(name);
            _brandService.AddType(name);
            return RedirectToPage("/Admin/Brands/Index");


        }
    }
}
