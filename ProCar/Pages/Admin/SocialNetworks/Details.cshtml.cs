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
    public class DetailsModel : PageModel
    {
        private readonly ProCar.Models.ApplicationDbContext _context;

        public DetailsModel(ProCar.Models.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
