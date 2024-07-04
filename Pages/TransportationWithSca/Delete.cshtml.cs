using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Travel_Agency_Project.Data;
using Travel_Agency_Project.Models;

namespace Travel_Agency_Project.Pages.TransportationWithSca
{
    public class DeleteModel : PageModel
    {
        private readonly Travel_Agency_Project.Data.ApplicationDbContext _context;

        public DeleteModel(Travel_Agency_Project.Data.ApplicationDbContext context)
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

            var transportation = await _context.Transportations.FirstOrDefaultAsync(m => m.ID == id);

            if (transportation == null)
            {
                return NotFound();
            }
            else
            {
                Transportation = transportation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = await _context.Transportations.FindAsync(id);
            if (transportation != null)
            {
                Transportation = transportation;
                _context.Transportations.Remove(Transportation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
