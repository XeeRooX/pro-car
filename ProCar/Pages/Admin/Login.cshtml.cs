using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ProCar.Pages.Admin
{
    public class LoginModel : PageModel
    {
        public string Message { get; set; } = "";
        private IConfiguration _configuration;
      

        public LoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string password)
        {
            string adminPassword = _configuration.GetValue<string>("AdminPassword");
            if (password == null || password == "")
            {
                Message = "Ошибка: поле не может быть пустым";
                return Page();
            }
            else if (password != adminPassword)
            {
                Message = "Ошибка: неверный пароль";
                return Page();
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, "admin") };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToPage("/Admin/Index");
        }
    }
}
