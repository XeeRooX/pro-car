using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;
using System.Diagnostics;

namespace ProCar.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;
        private readonly IContactService _contactService;

        public ErrorModel(ILogger<ErrorModel> logger, IContactService contact)
        {
            _contactService = contact;
            _logger = logger;
        }

        public void OnGet()
        {
            ViewData[nameof(ContactDetails)] = _contactService.GetContactDetails();
            ViewData["SocialNetworks"] = _contactService.GetSocialNetworks();

            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}