using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Dtos;
using ProCar.Services;

namespace ProCar.Pages.Admin.Cars
{
    public class AddModel : PageModel
    {
        private ICarsService _carsService;
        public CarAddGetDto FormData { get; set; }
        [BindProperty]
        public CarAddDto Input { get; set; }
        public AddModel(ICarsService carsService)
        {
            _carsService = carsService;
        }
        public void OnGet()
        {
            FormData = _carsService.GetDataAddCarsGet();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                FormData = _carsService.GetDataAddCarsGet();
                return Page();
            }

            _carsService.AddCar(Input);
            FormData = _carsService.GetDataAddCarsGet();
            return RedirectToPage("/Admin/Cars/Index");
        }
    }
}
