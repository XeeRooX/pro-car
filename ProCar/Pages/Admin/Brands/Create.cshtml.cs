using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Services;

namespace ProCar.Pages.Admin.Brands
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private IBrandService _brandService;
        private IServerUploadService _serverUploadService;

        public string Message { get; set; }
        public CreateModel(IBrandService brandService, IServerUploadService serverUploadService)
        {
            _brandService = brandService;
            _serverUploadService = serverUploadService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(string name, IFormFileCollection uploads)
        {
            if (0 != _brandService.ElementExists(name))
            {
                Message = "ошибка добавления: элемент уже существует";
                return Page();
            }
            else if(name == null)
            {
                Message = "ошибка добавления: неккоректно введено значение";
                return Page();
            }
            int id = _brandService.AddType(name).Id;
            if (!_serverUploadService.TypeFilePng(uploads))
            {
                Message = "ошибка добавления: непподерживаемый тип файла";
                return Page();
            }

            _serverUploadService.UploadBrandPhoto(id, uploads);
          
            return RedirectToPage("/Admin/Brands/Index");


        }
    }
}
