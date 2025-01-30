using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;

namespace ProCar.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IContactService _contactService;
        [BindProperty]
        public ContactDetails ContactDetails { get; set; } = default!;

        [BindProperty]
        public List<SocialNetwork> SocialNetworks { get; set; } = default!;

        public ContactModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        public void OnGet()
        {
            ContactDetails = _contactService.GetContactDetails();
            SocialNetworks = _contactService.GetSocialNetworks();

            ViewData[nameof(ContactDetails)] = _contactService.GetContactDetails();
            ViewData["SocialNetworks"] = _contactService.GetSocialNetworks();
        }
    }
}
