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
    public class IndexModel : PageModel
    {
        private readonly Travel_Agency_Project.Data.ApplicationDbContext _context;

        public IndexModel(Travel_Agency_Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Transportation> Transportation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Transportation = await _context.Transportations.ToListAsync();
        }
    }
}
