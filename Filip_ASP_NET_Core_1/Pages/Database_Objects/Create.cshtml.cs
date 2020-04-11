using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Filip_ASP_NET_Core_1.Classes;
using Filip_ASP_NET_Core_1.Data;

namespace Filip_ASP_NET_Core_1.Pages.Database_Objects
{
    public class CreateModel : PageModel
    {
        private readonly Filip_ASP_NET_Core_1.Data.Filip_ASP_NET_Core_1Context _context;

        public CreateModel(Filip_ASP_NET_Core_1.Data.Filip_ASP_NET_Core_1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Database_Object Database_Object { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Database_Object.Add(Database_Object);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
