using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;

namespace ProCar.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICarTypeService _carTypeService;
        private readonly IContactService _contactService;
     
        public List<CarType> CarTypes { get; set; }
        public int CountTypes { get; set; }
        public int CountCars { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ICarTypeService carTypeService, IContactService contact)
        {
            _carTypeService = carTypeService;
            _logger = logger;
            _contactService = contact;
        }

        public void OnGet()
        {
            CarTypes = _carTypeService.GetTypesNotEmpty();
            CountTypes = 3;
            CountCars = 3;

            ViewData[nameof(ContactDetails)] = _contactService.GetContactDetails();
            ViewData["SocialNetworks"] = _contactService.GetSocialNetworks();
        }

    }
}