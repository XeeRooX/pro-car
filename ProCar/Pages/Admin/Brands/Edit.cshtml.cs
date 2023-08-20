using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;

namespace ProCar.Pages.Admin.Brands
{
    [Authorize]
    public class EditModel : PageModel
    {
        private IBrandService _brandService;
        private IServerUploadService _uploadService;

        public string? Message { get; set; }
        public Brand Brand { get; set; } = new();
        public EditModel(IBrandService brandService, IServerUploadService serverUploadService)
        {
            _brandService = brandService;
            _uploadService = serverUploadService;
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

        public IActionResult OnPost(int id, string name, IFormFileCollection uploads)
        {
            if (!_brandService.ElementExists(id))
            {
                return NotFound();
            }
            else if (name == null)
            {
                Message = "ошибка редактирования: неккоректно введено значение";
                Brand = _brandService.GetById(id);
                return Page();
            }
            else if (id != _brandService.ElementExists(name) && 0 != _brandService.ElementExists(name))
            {
                Message = "ошибка редактирования: элемент с таким именем уже существует";
                Brand = _brandService.GetById(id);
                return Page();
            }
            if (uploads.Count != 0)
            {
                if (!_uploadService.TypeFilePng(uploads))
                {
                    Message = "ошибка редактирования: тип файла не поддерживается";
                    return Page();
                }

                _uploadService.UploadBrandPhoto(id, uploads);

                _brandService.EditType(id, name);
                return RedirectToPage("/Admin/Brands/Index");
            }
            _brandService.EditType(id, name);

            return RedirectToPage("/Admin/Brands/Index");
        }
    }
}
