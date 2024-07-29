using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travel_Agency_Project.Data;
using Travel_Agency_Project.Models;
using Travel_Agency_Project.Utility;
using Travel_Agency_Project.ViewModel;

namespace Travel_Agency_Project.Controllers {
    [Authorize]
    public class DashBoardController : Controller {
        private readonly ApplicationDbContext _db;
        public AddTourViewModel _addTourViewModel;
        public DashBoardController ( ApplicationDbContext db ) {
            _db = db;
        }

        public IActionResult Index () {
            return View();
        }

        #region AddTour
        [Authorize(Roles = RL.RoleAdmin)]
        public IActionResult AddTour () {
            //_addTourViewModel = new AddTourViewModel();
            ////var transportations = _db.Transportations
            ////                    .Select( a => new SelectListItem {
            ////                        Value = a.ID.ToString(),
            ////                        Text = a.Name
            ////                    } ).ToList();

            ////ViewBag.Transportations = transportations;

            //_addTourViewModel.Transportations = _db.Transportations.Select( a => new SelectListItem() { Value = a.ID.ToString(), Text = a.Name } ).ToList();

            //return View( _addTourViewModel );

            var addTourViewModel = new AddTourViewModel();
            addTourViewModel.Transportations = _db.Transportations.Select( a => new SelectListItem {
                Value = a.ID.ToString(),
                Text = a.Name
            } ).ToList();

            return View( addTourViewModel );

        }
        
        [HttpPost]
        [Authorize( Roles = RL.RoleAdmin )]
        public async Task<IActionResult> AddTour ( AddTourViewModel viewModel, IFormFile Image ) {

            if ( Image != null && Image.Length > 0 ) {
                using ( var memoryStream = new MemoryStream() ) {
                    await Image.CopyToAsync( memoryStream );
                    viewModel.tour.ImageData = memoryStream.ToArray();
                    viewModel.tour.ContentType = Image.ContentType;
                }
            }
            viewModel.tour.TransportationId = viewModel.transportationID;
            viewModel.tour.TransportationType = _db.Transportations.FirstOrDefault( x => x.ID == viewModel.transportationID );
            //if ( ModelState.IsValid && viewModel.tour.TransportationType == null ) {
                _db.Tours.Add( viewModel.tour );
                await _db.SaveChangesAsync();
                return RedirectToAction( "GetToursData" );
            //} else {
            //    // Re-populate Transportations in case of validation error
            //    viewModel.Transportations = _db.Transportations.Select( a => new SelectListItem {
            //        Value = a.ID.ToString(),
            //        Text = a.Name
            //    } ).ToList();
            //    return View( viewModel );
            //}
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
            return RedirectToAction( "GetToursData" );
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
        public async Task<IActionResult> EditTourAsync ( Tour tour, IFormFile Image ) {
            var existingTour = await _db.Tours.FindAsync( tour.ID );
            if ( existingTour == null ) {
                return NotFound();
            }

            existingTour.Name = tour.Name;
            existingTour.StartDate = tour.StartDate;
            existingTour.EndDate = tour.EndDate;
            existingTour.AdultsTickets = tour.AdultsTickets;
            existingTour.ChildrenTickets = tour.ChildrenTickets;
            existingTour.InfantTickets = tour.InfantTickets;
            existingTour.HotelName = tour.HotelName;
            existingTour.Meals= tour.Meals;
            existingTour.Description = tour.Description;
            existingTour.Price = tour.Price;
            existingTour.Distination = tour.Distination;
            existingTour.TransportationId = tour.TransportationId;
            existingTour.GuideIncluded = tour.GuideIncluded;

            if ( Image != null && Image.Length > 0 ) {
                using ( var memoryStream = new MemoryStream() ) {
                    await Image.CopyToAsync( memoryStream );
                    existingTour.ImageData = memoryStream.ToArray();
                    existingTour.ContentType = Image.ContentType;
                }
            }

            _db.Tours.Update( existingTour );
            await _db.SaveChangesAsync();
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
        
        public IActionResult GetImage ( int id ) {
            var tour = _db.Tours.Find( id );
            if ( tour == null || tour.ImageData == null ) {
                return NotFound();
            }

            return File( tour.ImageData, tour.ContentType );
        }
    }
}
