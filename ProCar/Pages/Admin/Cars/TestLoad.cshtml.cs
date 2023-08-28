using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProCar.Pages.Admin.Cars
{
    public class TestLoadModel : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPost(List<IFormFile> files) 
        {
            Console.WriteLine("Count -->> " + files.Count);
        }
    }
}
