using System.Diagnostics;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Travel_Agency_Project.Data;
using Travel_Agency_Project.Models;
using Travel_Agency_Project.Utility;

namespace Travel_Agency_Project.Controllers
{
    public class HomeController ( ApplicationDbContext _db ) : Controller {
		private readonly ILogger<HomeController> _logger;
        private static BookingDetails _bookingDetails = new BookingDetails();
        private static UserDetails _userDetails = new UserDetails();
        private static Payment _payment = new Payment();
        private static TourReservationDetails _TourReservationDetails = new TourReservationDetails();

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
            _TourReservationDetails.TourID = id;
            return View();
        }
        [HttpPost]
        public IActionResult BookingDetails ( BookingDetails model ) {

            _bookingDetails = model;
            return RedirectToAction( "UserDetails" );
            
        }
        
        public IActionResult UserDetails () {
            return View();
        }
        [HttpPost]
        public IActionResult UserDetails ( UserDetails model ) {
           
            _userDetails = model;
            return RedirectToAction( "Payment" );
        }
        public IActionResult Payment () {
            return View();
        }
        [HttpPost]
        public IActionResult Payment ( Payment model ) {

            _payment = model;

            _TourReservationDetails.AdultTickets = _bookingDetails.AdultTickets;
            _TourReservationDetails.ChildTickets = _bookingDetails.ChildTickets;
            _TourReservationDetails.InfantTickets = _bookingDetails.InfantTickets;
            _TourReservationDetails.FirstName = _userDetails.FirstName;
            _TourReservationDetails.LastName = _userDetails.LastName;
            _TourReservationDetails.PhoneNumber = _userDetails.PhoneNumber;
            _TourReservationDetails.PickupLocation = _userDetails.PickupLocation;
            _TourReservationDetails.PaymentMethod = _payment.PaymentMethod;

            //var tourReservationDetails = new TourReservationDetails {
            //    AdultTickets = _bookingDetails.AdultTickets,
            //    ChildTickets = _bookingDetails.ChildTickets,
            //    InfantTickets = _bookingDetails.InfantTickets,
            //    FirstName = _userDetails.FirstName,
            //    LastName = _userDetails.LastName,
            //    PhoneNumber = _userDetails.PhoneNumber,
            //    PickupLocation = _userDetails.PickupLocation,
            //    PaymentMethod = _payment.PaymentMethod,
            //};

            _db.TourReservationDetails.Add( _TourReservationDetails );
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
