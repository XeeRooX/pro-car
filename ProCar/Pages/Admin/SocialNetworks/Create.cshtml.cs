using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProCar.Models;

namespace ProCar.Pages.Admin.SocialNetworks
{
    public class CreateModel : PageModel
    {
        private readonly ProCar.Models.ApplicationDbContext _context;

        public CreateModel(ProCar.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SocialNetwork SocialNetwork { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SocialNetworks == null || SocialNetwork == null)
            {
                return Page();
            }

            _context.SocialNetworks.Add(SocialNetwork);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
