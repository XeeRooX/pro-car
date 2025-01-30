using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;

namespace ProCar.Pages
{
    public class ConditionsModel : PageModel
    {
        private readonly IContactService _contactService;
        public ConditionsModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        public void OnGet()
        {
            ViewData[nameof(ContactDetails)] = _contactService.GetContactDetails();
            ViewData["SocialNetworks"] = _contactService.GetSocialNetworks();
        }
    }
}
