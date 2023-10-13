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
        public List<CarType>? Colors { get; set; }
        public InputModel Input { get; set; }
        public string ErrorMsg { get; set; }
        public ICarTypeService _carTypeService { get; set; }
        public IndexModel(ICarTypeService carTypeService)
        {
            _carTypeService = carTypeService;
        }
        public void OnGet()
        {
            Colors = _carTypeService.GetAll();
        }
        public class InputModel
        {
            [Required(ErrorMessage = "��� ���� ����������� ��� ����������")]
            [ColorNameUnique]
            [MaxLength(50, ErrorMessage = "������������ ����� �������� - {0} ��������")]
            public string Name { get; set; } = null!;
        }
    }
}
