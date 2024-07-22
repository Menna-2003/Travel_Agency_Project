using System.ComponentModel.DataAnnotations;
using Travel_Agency_Project.Models;

namespace Travel_Agency_Project.ViewModel
{
    public class Payment
    {
        [Required]
        public int PaymentMethod { get; set; }
       
        public int TourID {
            get; set;
        }
        public Tour Tour {
            get; set;
        }

        public int AdultTickets {
            get; set;
        }
        public int ChildTickets {
            get; set;
        }
        public int InfantTickets {
            get; set;
        }
    }
}
