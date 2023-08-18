using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;

namespace ProCar.Pages.Admin.Brands
{
    public class IndexModel : PageModel
    {
        private IBrandService _brandService;
        public List<Brand>? Brands { get; set; }
        public IndexModel(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public void OnGet()
        {
            var allBrands = _brandService.GetAll();
            Brands = allBrands;
        }
    }
}
