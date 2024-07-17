using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travel_Agency_Project.Utility;

namespace Travel_Agency_Project.Models {
    public class Reservations {
        [Key]
        public int ID {
            get; set;
        }

        [Required]
        [RegularExpression( @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Name" )]
        [Length( 3, 20 )]
        public string Name {
            get; set;
        }

        [Required]
        [RegularExpression( "^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid" )]
        [DataType( DataType.EmailAddress )]
        public string Email {
            get; set;
        }

        [Required]
        [DataType( DataType.PhoneNumber )]
        [RegularExpression( @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number" )]
        public string PhoneNumber {
            get; set;
        }

        [Required]
        [FutureDateAttribute( ErrorMessage = "The booking date must be in the future." )]
        public DateTime BookingDate {
            get; set;
        }

        [Required]
        [FutureTime( ErrorMessage = "The appointment time must be in the future." )]
        public TimeSpan AppointmentTime {
            get; set;
        }

        [Required]
        public int TransportationId {
            get; set;
        }

        [ForeignKey( "TransportationId" )]
        public Transportation TransportationType {
            get; set;
        }

       
    }
}
