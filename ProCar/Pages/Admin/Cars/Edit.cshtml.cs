using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Dtos;
using ProCar.Services;

namespace ProCar.Pages.Admin.Cars
{
    public class EditModel : PageModel
    {
        private ICarsService _carsService;
        public CarAddGetDto DropdownFormData { get; set; }
        public CarEditDto FormData { get; set; }

        [BindProperty]
        public CarAddDto Input { get; set; }
        public EditModel(ICarsService carsService)
        {
            _carsService = carsService;
        }
        public IActionResult OnGet(int id)
        {
            if (!_carsService.ElementExists(id))
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!! "+id.ToString());
                return NotFound();
            }

            DropdownFormData = _carsService.GetDataAddCarsGet();
            FormData = _carsService.GetDataEditCars(id);
            Console.WriteLine("Id: " + id);

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (!_carsService.ElementExists(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                DropdownFormData = _carsService.GetDataAddCarsGet();
                FormData = _carsService.GetDataEditCars(id);
                return Page();
            }

            _carsService.EditCar(Input, id);
            return RedirectToPage("/Admin/Cars/Index");
        }
    }
}
