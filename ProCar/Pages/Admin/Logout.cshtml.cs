using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProCar.Pages.Admin
{
    public class LogoutModel : PageModel
    {
        public LogoutModel()
        {
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.User.Identity!.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToPage("/Index");
            }
            return NotFound();
        }
    }
}
