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

        public IActionResult OnPost(string name, IFormFileCollection uploads)
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

            IFormFileCollection files = uploads;

            var uploadPath = $"{Directory.GetCurrentDirectory()}/Data/imgs/brands";
            Directory.CreateDirectory(uploadPath);

            foreach(var file in files)
            {
                string fullPath = $"{uploadPath}/{file.FileName}";

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }


            Console.WriteLine(name);
            _brandService.AddType(name);
            return RedirectToPage("/Admin/Brands/Index");


        }
    }
}
