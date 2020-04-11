using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Filip_ASP_NET_Core_1.Classes;
using Filip_ASP_NET_Core_1.Data;

namespace Filip_ASP_NET_Core_1.Pages.Database_Objects
{
    public class EditModel : PageModel
    {
        private readonly Filip_ASP_NET_Core_1.Data.Filip_ASP_NET_Core_1Context _context;

        public EditModel(Filip_ASP_NET_Core_1.Data.Filip_ASP_NET_Core_1Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Database_Object).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Database_ObjectExists(Database_Object.ID))
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

        private bool Database_ObjectExists(int id)
        {
            return _context.Database_Object.Any(e => e.ID == id);
        }
    }
}
