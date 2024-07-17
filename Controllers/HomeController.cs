using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel_Agency_Project.Data;
using Travel_Agency_Project.Models;

namespace Travel_Agency_Project.Controllers {
	public class HomeController ( ApplicationDbContext _db ) : Controller {
		private readonly ILogger<HomeController> _logger;

		public IActionResult Index () {
            var tours = _db.Tours.Include( t => t.TransportationType ).ToList();
            return View( tours );
        }

        public IActionResult ViewAllTours () {
            var tours = _db.Tours.Include( t => t.TransportationType ).ToList();
            return View(tours);
        }

        public IActionResult TourDetails (int id) {
            var tour = _db.Tours.Include( p => p.TransportationType ).FirstOrDefault( p => p.ID == id );
            if ( tour == null ) {
                return NotFound(); // Or handle the case where the product doesn't exist
            }
            return View( tour );
        }
        public IActionResult BookingDetails (  ) {
            return View();
        }
        public IActionResult UserDetails () {
            return View();
        }
        public IActionResult Payment () {
            return View();
        }
        public IActionResult ConfirmOrder () {
            return View();
        }

        public IActionResult AboutUs () {
            return View();
        }

        public ActionResult Reservations () {
            return View();  
        }

        [AllowAnonymous]
        public IActionResult GetImage ( int id ) {
            var tour = _db.Tours.Find( id );
            if ( tour == null || tour.ImageData == null ) {
                return NotFound();
            }

            return File( tour.ImageData, tour.ContentType );
        }


        [ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
		public IActionResult Error () {
			return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
		}
	}
}
