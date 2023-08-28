using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Services;

namespace ProCar.Pages.Admin.Cars
{
    public class TestLoad2Model : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }
        private IServerUploadService _uploadService;

        public TestLoad2Model(IServerUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        public void OnGet()
        {
        }
        //public void OnPost(List<IFormFile> files) 
        //{
        //    Console.WriteLine("Count -->> " + files.Count);
        //}

        public IActionResult OnPost(IFormFileCollection Photos)
        {
            Console.WriteLine("Count1 -->> " +Photos.Count);
            //Console.WriteLine("Count2 -->> " + Input.Photos.Count);
            Console.WriteLine(Input.Title);

            _uploadService.DeleteCarPhoto(1);
            _uploadService.UploadCarPhoto(1, Photos);

            return new JsonResult(new { redirectUrl = Url.Page("/Admin/Cars/Index") });
        }

        public class InputModel
        {
            //public IFormFileCollection Photos { get; set; }
            public string Title { get; set; }
        }
    }
}
