using System.Text.RegularExpressions;
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
            if ( viewModel.tour != null ) {
                _db.Tours.Add( viewModel.tour );
                await _db.SaveChangesAsync();
                return RedirectToAction( "GetToursData" );
            } else {
                viewModel.Transportations = _db.Transportations.Select( a => new SelectListItem {
                    Value = a.ID.ToString(),
                    Text = a.Name
                } ).ToList();
                return View( viewModel );
            }
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
            EditTourViewModel editTourViewModel = new EditTourViewModel();
            editTourViewModel.Transportations = _db.Transportations.Select( a => new SelectListItem {
                Value = a.ID.ToString(),
                Text = a.Name
            } ).ToList();
            editTourViewModel.tour = _db.Tours.FirstOrDefault( x => x.ID == id );
            return View( editTourViewModel );
        }
        
        [HttpPost]
        [Authorize( Roles = RL.RoleAdmin )]
        public async Task<IActionResult> EditTourAsync ( EditTourViewModel editTourViewModel, IFormFile Image, int id ) {
            var existingTour = _db.Tours.FirstOrDefault( x => x.ID == id );
            if ( existingTour == null ) {
                return NotFound();
            }
            ModelState.Remove( "tour.Name" );
            ModelState.Remove( "tour.Distination" );
            ModelState.Remove( "tour.Description" );
            ModelState.Remove( "tour.StartDate" );
            ModelState.Remove( "tour.EndDate" );
            ModelState.Remove( "tour.AdultsTickets" );
            ModelState.Remove( "tour.ChildrenTickets" );
            ModelState.Remove( "tour.InfantTickets" );
            ModelState.Remove( "tour.HotelName" );
            ModelState.Remove( "tour.Meals" );
            ModelState.Remove( "tour.Price" );
            ModelState.Remove( "tour.TransportationId" );
            ModelState.Remove( "tour.TransportationType" );
            ModelState.Remove( "tour.ImageData" );
            ModelState.Remove( "tour.ContentType" );
            ModelState.Remove( "tour.ID" );
            ModelState.Remove( "Image" );

            if ( string.IsNullOrWhiteSpace( editTourViewModel.tour.Name ) ||
                !Regex.IsMatch( editTourViewModel.tour.Name, @"^[a-zA-Z''-'\s]{5,15}$" ) ) {
                ModelState.AddModelError( "tour.Name", "The Name must be 5 to 15 characters long and can only contain letters, spaces, and hyphens." );
            }
            if ( string.IsNullOrWhiteSpace( editTourViewModel.tour.Distination ) ||
                !Regex.IsMatch( editTourViewModel.tour.Distination, @"^[a-zA-Z''-'\s]{5,15}$" ) ) {
                ModelState.AddModelError( "tour.Distination", "The Distination must be 5 to 15 characters long and can only contain letters, spaces, and hyphens." );
            }
            if ( string.IsNullOrWhiteSpace( editTourViewModel.tour.Description ) ||
                !Regex.IsMatch( editTourViewModel.tour.Description, @"^[a-zA-Z''-'\s]{5,50}$" ) ) {
                ModelState.AddModelError( "tour.Description", "The Description must be 5 to 50 characters long and can only contain letters, spaces, and hyphens." );
            }
            if ( editTourViewModel.tour.StartDate == default( DateTime ) ||
                editTourViewModel.tour.StartDate < DateTime.Now ) {
                ModelState.AddModelError( "tour.StartDate", "Start Date must be a valid future date." );
            }
            if ( editTourViewModel.tour.EndDate == default( DateTime ) ||
                editTourViewModel.tour.EndDate <= editTourViewModel.tour.StartDate ) {
                ModelState.AddModelError( "tour.EndDate", "End Date must be a valid date after the Start Date." );
            }
            if ( editTourViewModel.tour.AdultsTickets < 0 ) {
                ModelState.AddModelError( "tour.AdultsTickets", "Adults Tickets must be a non-negative integer." );
            }
            if ( editTourViewModel.tour.ChildrenTickets < 0 ) {
                ModelState.AddModelError( "tour.ChildrenTickets", "Children Tickets must be a non-negative integer." );
            }
            if ( editTourViewModel.tour.InfantTickets < 0 ) {
                ModelState.AddModelError( "tour.InfantTickets", "Infant Tickets must be a non-negative integer." );
            }
            if ( !string.IsNullOrWhiteSpace( editTourViewModel.tour.HotelName ) &&
                !Regex.IsMatch( editTourViewModel.tour.HotelName, @"^[a-zA-Z''-'\s]{3,30}$" ) ) {
                ModelState.AddModelError( "tour.HotelName", "Hotel Name must be 3 to 30 characters long and can only contain letters, spaces, and hyphens." );
            }
            if ( !string.IsNullOrWhiteSpace( editTourViewModel.tour.Meals ) &&
                !Regex.IsMatch( editTourViewModel.tour.Meals, @"^[a-zA-Z\s,]{3,30}$" ) ) {
                ModelState.AddModelError( "tour.Meals", "Meals must be a valid string (e.g., 'Breakfast', 'Lunch')." );
            }
            if ( editTourViewModel.tour.Price > 10000 || editTourViewModel.tour.Price < 10 ) {
                ModelState.AddModelError( "tour.Price", "Price range is from 10 to 100,000" );
            }
            if ( !_db.Transportations.Any( t => t.ID == editTourViewModel.tour.TransportationId ) ) {
                ModelState.AddModelError( "tour.TransportationId", "Please select a valid transportation option." );
            }
            if ( !ModelState.IsValid ) {
                editTourViewModel.tour.ID = id;
                return View( editTourViewModel );
            }

            existingTour.Name = editTourViewModel.tour.Name;
            existingTour.StartDate = editTourViewModel.tour.StartDate;
            existingTour.EndDate = editTourViewModel.tour.EndDate;
            existingTour.AdultsTickets = editTourViewModel.tour.AdultsTickets;
            existingTour.ChildrenTickets = editTourViewModel.tour.ChildrenTickets;
            existingTour.InfantTickets = editTourViewModel.tour.InfantTickets;
            existingTour.HotelName = editTourViewModel.tour.HotelName;
            existingTour.Meals= editTourViewModel.tour.Meals;
            existingTour.Description = editTourViewModel.tour.Description;
            existingTour.Price = editTourViewModel.tour.Price;
            existingTour.Distination = editTourViewModel.tour.Distination;
            existingTour.TransportationId = editTourViewModel.tour.TransportationId;
            existingTour.TransportationType = editTourViewModel.tour.TransportationType;
            existingTour.GuideIncluded = editTourViewModel.tour.GuideIncluded;

            if ( Image != null && Image.Length > 0 ) {
                using ( var memoryStream = new MemoryStream() ) {
                    await Image.CopyToAsync( memoryStream );
                    existingTour.ImageData = memoryStream.ToArray();
                    existingTour.ContentType = Image.ContentType;
                }
            }
            if ( existingTour != null ) {
                _db.Tours.Update( existingTour );
                await _db.SaveChangesAsync();
                return RedirectToAction( "GetToursData" );
            } else {
                return View( existingTour );
            }
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
