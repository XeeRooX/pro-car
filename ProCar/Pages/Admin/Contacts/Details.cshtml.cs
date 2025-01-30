using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProCar.Models;

namespace ProCar.Pages.Admin.Contacts
{
    public class DetailsModel : PageModel
    {
        private readonly ProCar.Models.ApplicationDbContext _context;

        public DetailsModel(ProCar.Models.ApplicationDbContext context)
        {
            _context = context;
        }

      public ContactDetails ContactDetails { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ContactDetails == null)
            {
                return NotFound();
            }

            var contactdetails = await _context.ContactDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (contactdetails == null)
            {
                return NotFound();
            }
            else 
            {
                ContactDetails = contactdetails;
            }
            return Page();
        }
    }
}
