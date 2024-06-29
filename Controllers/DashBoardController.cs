using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel_Agency_Project.Data;
using Travel_Agency_Project.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Travel_Agency_Project.Controllers {
    public class DashBoardController : Controller {
        private static List<Tour> _tours = new List<Tour>();
        private static List<Transportation> _transportations = new List<Transportation>();
        private readonly ApplicationDbContext _db;

        public DashBoardController ( ApplicationDbContext db ) {
            _transportations.Add( new Transportation { ID = 1, Name = "Car" } );
            _transportations.Add( new Transportation { ID = 2, Name = "Plane" } );
            _transportations.Add( new Transportation { ID = 3, Name = "Bike" } );
            _transportations.Add( new Transportation { ID = 4, Name = "Bus" } );
            _db = db;
        }

        public IActionResult Index () {
            var tours = _db.Tours.Include( t => t.TransportationType ).ToList();
            return View( tours );
        }

        #region AddTour
        public IActionResult AddTour () {
            return View();
        }
        [HttpPost]
        public IActionResult AddTour ( Tour tour ) {
            _db.Tours.Add( tour );
            _db.SaveChanges();
            return RedirectToAction( "Index" );
        }
        #endregion

        //#region GetData
        //public IActionResult GetToursData () {
        //    var tours = _db.Tours.Include(t => t.TransportationType).ToList();
        //    return View( tours );
        //}
        //#endregion

        #region DeleteTour
        public IActionResult DeleteTour (int id) {
            Tour? tour = _db.Tours.FirstOrDefault( x => x.ID == id );
            _db.Tours.Remove(tour);
            _db.SaveChanges();
            return RedirectToAction( "GetToursData" );
        }
        #endregion

        #region EditTour
        public IActionResult EditTour ( int id ) {
            Tour tour = _db.Tours.FirstOrDefault( x => x.ID == id );
            return View( tour );
        }
        [HttpPost]
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

        public IActionResult Profile () {
            return View();
        }
    }
}
