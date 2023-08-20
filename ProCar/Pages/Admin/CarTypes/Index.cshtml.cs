using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;

namespace ProCar.Pages.Admin.CarTypes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private ICarTypeService _typeService;
        public List<CarType>? CarTypes { get; set; }
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

        public IActionResult OnPost(int id, string name) 
        {
            if (string.IsNullOrEmpty(name))
            {
                ErrorMsg = "������ ����������: �������� �� ����� ���� ������ �������";
                CarTypes = _typeService.GetAll();
                return Page();
            }
            if (_typeService.ValueExists(name))
            {
                ErrorMsg = "������ ����������: ������� � ����� ������ ��� ����������";
                CarTypes = _typeService.GetAll();
                return Page();
            }
            
            _typeService.AddType(name);
            CarTypes = _typeService.GetAll();
            return Page();
        }
    }
}
