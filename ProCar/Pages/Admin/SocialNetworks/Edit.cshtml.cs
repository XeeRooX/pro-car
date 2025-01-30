using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProCar.Models;

namespace ProCar.Pages.Admin.SocialNetworks
{
    public class EditModel : PageModel
    {
        private readonly ProCar.Models.ApplicationDbContext _context;

        public EditModel(ProCar.Models.ApplicationDbContext context)
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

            var socialnetwork =  await _context.SocialNetworks.FirstOrDefaultAsync(m => m.Id == id);
            if (socialnetwork == null)
            {
                return NotFound();
            }
            SocialNetwork = socialnetwork;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SocialNetwork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialNetworkExists(SocialNetwork.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SocialNetworkExists(int id)
        {
          return (_context.SocialNetworks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
