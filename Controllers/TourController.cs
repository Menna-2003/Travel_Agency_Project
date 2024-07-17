using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel_Agency_Project.Data;
using Travel_Agency_Project.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Travel_Agency_Project.Controllers {
    public class TourController : Controller {
        private readonly ApplicationDbContext _db;
        public TourController ( ApplicationDbContext db ) {
            _db = db;
        }
        public IActionResult Index ( int? page ) {
            const int pageSize = 10; // Number of tours per page

            // Ensure page number is valid, default to 1 if not specified or less than 1
            int currentPage = page ?? 1;
            if ( currentPage < 1 ) {
                currentPage = 1;
            }

            // Calculate number of tours to skip based on current page
            int skipNumberTours = ( currentPage - 1 ) * pageSize;

            // Base query
            var query = _db.Tours
                .Include( m => m.TransportationType )
                .OrderBy( m => m.ID ); // Replace with your sorting logic

            // Fetch tours for the current page
            var _tours = query.Skip( skipNumberTours ).Take( pageSize ).ToList();

            // Calculate total number of pages
            int totalNumberOfPages = ( int ) Math.Ceiling( query.Count() / ( double ) pageSize );

            var model = new TourFilterViewModel {
                tours = _tours,
                CurrentPage = currentPage,
                TotalNumberOfPages = totalNumberOfPages
            };

            return View( model );
        }


        public IActionResult Filter ( string destination, DateTime? startDate, DateTime? endDate, decimal? minPrice, decimal? maxPrice, int? page) {

            //var _tours = _db.Tours.Include( m => m.TransportationType ).
            //Where( m => ( string.IsNullOrEmpty( destination ) || m.Distination == destination ) ||
            //            ( ( !minPrice.HasValue || m.Price >= minPrice ) &&
            //            ( !maxPrice.HasValue || m.Price <= maxPrice ) ) ).ToList();

            // Apply filtering conditions
            var query = _db.Tours.Include( m => m.TransportationType ).AsQueryable().Where( m => ( string.IsNullOrEmpty( destination ) || m.Distination == destination ) ||
                        ( ( !minPrice.HasValue || m.Price >= minPrice ) &&
                        ( !maxPrice.HasValue || m.Price <= maxPrice ) ) );

            const int pageSize = 10; // Number of tours per page
            // Ensure page number is valid, default to 1 if not specified or less than 1
            int currentPage = page ?? 1;
            if ( currentPage < 1 ) {
                currentPage = 1;
            }
            int skipNumberTours = ( currentPage - 1 ) * pageSize;
            int totalNumberOfPages = ( int ) Math.Ceiling( query.Count() / ( double ) pageSize );

            var _tours = query.Skip( skipNumberTours ).Take( pageSize ).ToList();

            var AllTours = new TourFilterViewModel() {
                tours = _tours,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                CurrentPage = currentPage,
                TotalNumberOfPages = totalNumberOfPages
            };
            return View( AllTours );
        }
    }
}
