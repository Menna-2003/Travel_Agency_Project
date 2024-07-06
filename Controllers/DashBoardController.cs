using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel_Agency_Project.Data;
using Travel_Agency_Project.Models;
using Travel_Agency_Project.Utility;

namespace Travel_Agency_Project.Controllers {
    [Authorize]
    public class DashBoardController : Controller {
        private readonly ApplicationDbContext _db;

        public DashBoardController ( ApplicationDbContext db ) {
            _db = db;
        }

        public IActionResult Index () {
            return View();
        }

        #region AddTour
        [Authorize(Roles = RL.RoleAdmin)]
        public IActionResult AddTour () {
            return View();
        }
        [HttpPost]
        [Authorize( Roles = RL.RoleAdmin )]
        public IActionResult AddTour ( Tour tour ) {
            _db.Tours.Add( tour );
            _db.SaveChanges();
            return RedirectToAction( "Index" );
        }
        #endregion

        #region GetData
        [Authorize( Roles = RL.RoleAdmin )]
        public IActionResult GetToursData () {
            var tours = _db.Tours.Include( t => t.TransportationType ).ToList();
            return View( tours );
        }
        #endregion

        #region DeleteTour
        [Authorize( Roles = RL.RoleAdmin )]
        public IActionResult DeleteTour (int id) {
            Tour? tour = _db.Tours.FirstOrDefault( x => x.ID == id );
            _db.Tours.Remove(tour);
            _db.SaveChanges();
            return RedirectToAction( "Index" );
        }
        #endregion

        #region EditTour
        [Authorize( Roles = RL.RoleAdmin )]
        public IActionResult EditTour ( int id ) {
            Tour tour = _db.Tours.FirstOrDefault( x => x.ID == id );
            return View( tour );
        }
        [HttpPost]
        [Authorize( Roles = RL.RoleAdmin )]
        public IActionResult EditTour ( Tour tour ) {
            Tour tr = _db.Tours.SingleOrDefault(c=>c.ID == tour.ID);

            tr.Name = tour.Name;
            tr.GroupNumber = tour.GroupNumber;
            tr.Description = tour.Description;
            tr.Price = tour.Price;
            tr.Time = tour.Time;
            tr.Duration = tour.Duration;
            tr.Distination = tour.Distination;
            tr.TransportationId = tour.TransportationId;
            tr.Date = tour.Date;
            tr.Fees = tour.Fees;
            tr.GuideIncluded = tour.GuideIncluded;
            _db.Tours.Update( tr );
            _db.SaveChanges();
            return RedirectToAction( "Index" );
        }
        #endregion

        public IActionResult ViewTour ( int id ) {
            Tour tour = _db.Tours.FirstOrDefault( x => x.ID == id );
            return View( tour );
        }
        [Authorize( Roles = RL.RoleAdmin )]
        public IActionResult TourGuide () {
            return View();
        }
        [Authorize( Roles = RL.RoleAdmin )]
        public IActionResult TourGuideDetails () {
            return View();
        }
        public IActionResult Profile () {
            return View();
        }
    }
}
