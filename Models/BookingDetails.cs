using System.ComponentModel.DataAnnotations;
namespace Travel_Agency_Project.Models
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
    }
}
