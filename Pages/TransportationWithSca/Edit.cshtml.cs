using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travel_Agency_Project.Data;
using Travel_Agency_Project.Models;

namespace Travel_Agency_Project.Pages.TransportationWithSca
{
    public class EditModel : PageModel
    {
        private readonly Travel_Agency_Project.Data.ApplicationDbContext _context;

        public EditModel(Travel_Agency_Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Transportation Transportation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation =  await _context.Transportations.FirstOrDefaultAsync(m => m.ID == id);
            if (transportation == null)
            {
                return NotFound();
            }
            Transportation = transportation;
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

            _context.Attach(Transportation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportationExists(Transportation.ID))
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

        private bool TransportationExists(int id)
        {
            return _context.Transportations.Any(e => e.ID == id);
        }
    }
}
