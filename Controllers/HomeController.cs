using System.Diagnostics;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Travel_Agency_Project.Data;
using Travel_Agency_Project.Models;
using Travel_Agency_Project.Utility;
using Travel_Agency_Project.ViewModel;

namespace Travel_Agency_Project.Controllers
{
    public class HomeController ( ApplicationDbContext _db ) : Controller {
		private readonly ILogger<HomeController> _logger;
        private static BookingDetails _bookingDetails = new BookingDetails();
        private static UserDetails _userDetails = new UserDetails();
        private static Payment _payment = new Payment();
        private static UserReservationDetails _UserReservationDetails = new UserReservationDetails();

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

        #region Tour Reservation Details
        public IActionResult BookingDetails ( int id ) {
            _UserReservationDetails.TourID = id;
            _bookingDetails.TourID = id;
            _bookingDetails.Tour = _db.Tours.Include( p => p.TransportationType ).FirstOrDefault( p => p.ID == id );
            return View( _bookingDetails );
        }
        [HttpPost]
        public IActionResult BookingDetails ( BookingDetails model ) {

            _bookingDetails = model;
            return RedirectToAction( "UserDetails", new { id = _UserReservationDetails.TourID } );

        }
        
        public IActionResult UserDetails (int id) {
            _userDetails.TourID = id;
            _userDetails.Tour = _db.Tours.Include( p => p.TransportationType ).FirstOrDefault( p => p.ID == id );
            return View( _userDetails );
        }
        [HttpPost]
        public IActionResult UserDetails ( UserDetails model ) {
           
            _userDetails = model;
            return RedirectToAction( "Payment", new {
                id = _UserReservationDetails.TourID
            } );
        }
        public IActionResult Payment (int id) {
            _payment.TourID = id;
            _payment.Tour = _db.Tours.Include( p => p.TransportationType ).FirstOrDefault( p => p.ID == id );
            return View(_payment);
        }
        [HttpPost]
        public IActionResult Payment ( Payment model ) {

            _payment = model;

            _UserReservationDetails.AdultTickets = _bookingDetails.AdultTickets;
            _UserReservationDetails.ChildTickets = _bookingDetails.ChildTickets;
            _UserReservationDetails.InfantTickets = _bookingDetails.InfantTickets;
            _UserReservationDetails.FirstName = _userDetails.FirstName;
            _UserReservationDetails.LastName = _userDetails.LastName;
            _UserReservationDetails.PhoneNumber = _userDetails.PhoneNumber;
            _UserReservationDetails.PickupLocation = _userDetails.PickupLocation;
            _UserReservationDetails.PaymentMethod = _payment.PaymentMethod;

            _db.UserReservationDetails.Add( _UserReservationDetails );
            _db.SaveChanges();

            return RedirectToAction( "ConfirmOrder" );
        }

        public IActionResult ConfirmOrder () {
            return View();
        }
        #endregion

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
