using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;

namespace ProCar.Pages.Admin.CarTypes
{
    public class IndexModel : PageModel
    {
        private ICarTypeService _typeService;
        public List<CarType>? CarTypes { get; set; }
        public IndexModel(ICarTypeService typeService)
        {
            _typeService = typeService;
        }
        public void OnGet()
        {
            var carTypes = _typeService.GetAll();
            CarTypes = carTypes;
        }
    }
}
