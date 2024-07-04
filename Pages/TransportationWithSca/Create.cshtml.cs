using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Travel_Agency_Project.Data;
using Travel_Agency_Project.Models;

namespace Travel_Agency_Project.Pages.TransportationWithSca
{
    public class CreateModel : PageModel
    {
        private readonly Travel_Agency_Project.Data.ApplicationDbContext _context;

        public CreateModel(Travel_Agency_Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Transportation Transportation { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Transportations.Add(Transportation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
