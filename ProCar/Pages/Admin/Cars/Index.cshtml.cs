using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Dtos;
using ProCar.Services;

namespace ProCar.Pages.Admin.Cars
{
    public class IndexModel : PageModel
    {
        private ICarsService _carsService;
        public List<CarAdminViewDto> AllCarsInfo { get; set; }
        public IndexModel(ICarsService carsService)
        {
            _carsService = carsService;
        }
        public void OnGet()
        {
            AllCarsInfo = _carsService.GetAllCarsForView();
            Page();
        }
    }
}
