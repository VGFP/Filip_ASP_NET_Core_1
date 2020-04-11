using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Filip_ASP_NET_Core_1.Classes;
using Filip_ASP_NET_Core_1.Data;

namespace Filip_ASP_NET_Core_1.Pages.Database_Objects
{
    public class DetailsModel : PageModel
    {
        private readonly Filip_ASP_NET_Core_1.Data.Filip_ASP_NET_Core_1Context _context;

        public DetailsModel(Filip_ASP_NET_Core_1.Data.Filip_ASP_NET_Core_1Context context)
        {
            _context = context;
        }

        public Database_Object Database_Object { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Database_Object = await _context.Database_Object.FirstOrDefaultAsync(m => m.ID == id);

            if (Database_Object == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
