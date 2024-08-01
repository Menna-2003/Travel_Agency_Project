using System.Diagnostics;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Travel_Agency_Project.Data;
using Travel_Agency_Project.Models;
using Travel_Agency_Project.Utility;
using Travel_Agency_Project.ViewModel;

namespace Travel_Agency_Project.Controllers
{
    public class HomeController ( ApplicationDbContext _db, UserManager<IdentityUser> userManager ) : Controller {
		private readonly ILogger<HomeController> _logger;
        private static BookingDetails _bookingDetails;
        private static UserDetails _userDetails;
        private static Payment _payment;
        private static UserReservationDetails _UserReservationDetails;
        TourViewModel tourViewModel = new TourViewModel();
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public IActionResult Index () {
            tourViewModel.tour = _db.Tours.Include( t => t.TransportationType ).ToList();
            tourViewModel.Distinations = _db.Tours.Select( a => new SelectListItem() { Value = a.Distination, Text = a.Distination } ).Distinct().ToList();
            return View( tourViewModel );
        }

        public IActionResult ViewAllTours () {
            var tours = _db.Tours.Include( t => t.TransportationType ).ToList();
            return View(tours);
        }

        public IActionResult TourDetails (int id) {
            var tour = _db.Tours.Include( p => p.TransportationType ).FirstOrDefault( p => p.ID == id );
            if ( tour == null ) {
                return NotFound(); // Or handle the case where the tour doesn't exist
            }
            return View( tour );
        }

        #region Tour Reservation Details
  
        #region bookingDetails
        public IActionResult BookingDetails ( int id ) {
            _UserReservationDetails = new UserReservationDetails();
            _UserReservationDetails.TourID = id;

            _bookingDetails = new BookingDetails();
            _bookingDetails.TourID = id;
            _bookingDetails.Tour = _db.Tours.Include( p => p.TransportationType ).FirstOrDefault( p => p.ID == id );
            return View( _bookingDetails );
        }
        [HttpPost]
        public IActionResult BookingDetails ( BookingDetails model ) {

            _bookingDetails = model;
            _UserReservationDetails.AdultTickets = _bookingDetails.AdultTickets;
            _UserReservationDetails.ChildTickets = _bookingDetails.ChildTickets;
            _UserReservationDetails.InfantTickets = _bookingDetails.InfantTickets;
            return RedirectToAction( "UserDetails", new {
                id = _UserReservationDetails.TourID,
                AdultTickets = _UserReservationDetails.AdultTickets,
                ChildTickets = _UserReservationDetails.ChildTickets,
                InfantTickets = _UserReservationDetails.InfantTickets,
            } );

        }
        #endregion

        #region userDetails
        public IActionResult UserDetails (int id, int AdultTickets, int ChildTickets ,int InfantTickets ) {
            _userDetails = new UserDetails();
            _userDetails.TourID = id;
            _userDetails.AdultTickets = AdultTickets;
            _userDetails.ChildTickets = ChildTickets;
            _userDetails.InfantTickets = InfantTickets;
            _userDetails.Tour = _db.Tours.Include( p => p.TransportationType ).FirstOrDefault( p => p.ID == id );
            return View( _userDetails );
        }
        [HttpPost]
        public IActionResult UserDetails ( UserDetails model ) {
           
            _userDetails = model;

            _UserReservationDetails.FirstName = _userDetails.FirstName;
            _UserReservationDetails.LastName = _userDetails.LastName;
            _UserReservationDetails.PhoneNumber = _userDetails.PhoneNumber;
            _UserReservationDetails.PickupLocation = _userDetails.PickupLocation;

            return RedirectToAction( "Payment", new {
                id = _UserReservationDetails.TourID,
                AdultTickets = _UserReservationDetails.AdultTickets,
                ChildTickets = _UserReservationDetails.ChildTickets,
                InfantTickets = _UserReservationDetails.InfantTickets,
            } );

        }
        #endregion

        #region payment
        public IActionResult Payment ( int id, int AdultTickets, int ChildTickets, int InfantTickets ) {
            _payment = new Payment();
            _payment.TourID = id;
            _payment.AdultTickets = AdultTickets;
            _payment.ChildTickets = ChildTickets;
            _payment.InfantTickets = InfantTickets;
            _payment.Tour = _db.Tours.Include( p => p.TransportationType ).FirstOrDefault( p => p.ID == id );
            return View(_payment);

        }
        [HttpPost]
        public IActionResult Payment ( Payment model ) {
            var userId = _userManager.GetUserId( User );

            Console.WriteLine(userId);

            if ( userId == null ) {
                // Handle the case where the user is not logged in or the user ID is not found
                return RedirectToAction( "Error" );
            }

            _payment = model;

            _UserReservationDetails.PaymentMethod = _payment.PaymentMethod;
            _UserReservationDetails.UserId = userId; // Set the User ID

            _db.UserReservationDetails.Add( _UserReservationDetails );
            _db.SaveChanges();

            return RedirectToAction( "ConfirmOrder" );
        }
        #endregion

        public IActionResult ConfirmOrder () {
            return View();
        }

        #endregion
      
        #region cart
        public IActionResult Cart () {
            var userId = _userManager.GetUserId( User );
            var reservations = _db.UserReservationDetails.Include( t => t.tour ).Where( r => r.UserId == userId ).ToList();
            return View( reservations );
        }
        public IActionResult ViewTourReserved ( int id ) {
            var userId = _userManager.GetUserId( User );
            var reservation = _db.UserReservationDetails.Include( t => t.tour ).Where( r => r.UserId == userId ).FirstOrDefault(x=>x.ID == id);

            return View( reservation );
        }
        public IActionResult DeleteReservation ( int id ) {
            UserReservationDetails? Reservation = _db.UserReservationDetails.FirstOrDefault( x => x.ID == id );
            _db.UserReservationDetails.Remove( Reservation );
            _db.SaveChanges();
            return RedirectToAction( "Cart" );
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
