using System.ComponentModel.DataAnnotations;
using Travel_Agency_Project.Models;

namespace Travel_Agency_Project.ViewModel
{
    public class BookingDetails
    {
        [Required]
        public int AdultTickets
        {
            get; set;
        }
        [Required]
        public int ChildTickets
        {
            get; set;
        }
        [Required]
        public int InfantTickets
        {
            get; set;
        }
        public int TourID
        {
            get; set;
        }

        public Tour Tour
        {
            get; set;
        }
    }
}
