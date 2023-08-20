using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Services;

namespace ProCar.Pages.Admin.Cars
{
    public class AddModel : PageModel
    {
        private ICarsService _carsService;
        public AddModel(ICarsService carsService)
        {
            _carsService = carsService;
        }
        public void OnGet()
        {
        }
    }
}
