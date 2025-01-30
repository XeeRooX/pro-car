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
    public class IndexModel : PageModel
    {
        private readonly ProCar.Models.ApplicationDbContext _context;

        public IndexModel(ProCar.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SocialNetwork> SocialNetwork { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SocialNetworks != null)
            {
                SocialNetwork = await _context.SocialNetworks.ToListAsync();
            }
        }
    }
}
