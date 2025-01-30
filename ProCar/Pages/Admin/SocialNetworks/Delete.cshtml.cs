using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProCar.Models;

namespace ProCar.Pages.Admin.SocialNetworks
{
    public class DeleteModel : PageModel
    {
        private readonly ProCar.Models.ApplicationDbContext _context;

        public DeleteModel(ProCar.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SocialNetwork SocialNetwork { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SocialNetworks == null)
            {
                return NotFound();
            }

            var socialnetwork = await _context.SocialNetworks.FirstOrDefaultAsync(m => m.Id == id);

            if (socialnetwork == null)
            {
                return NotFound();
            }
            else 
            {
                SocialNetwork = socialnetwork;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SocialNetworks == null)
            {
                return NotFound();
            }
            var socialnetwork = await _context.SocialNetworks.FindAsync(id);

            if (socialnetwork != null)
            {
                SocialNetwork = socialnetwork;
                _context.SocialNetworks.Remove(SocialNetwork);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
