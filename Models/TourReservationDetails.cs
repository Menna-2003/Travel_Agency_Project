using System.ComponentModel.DataAnnotations;

namespace Travel_Agency_Project.Models {
    public class TourReservationDetails {

        [Key]
        public int ID {
            get; set;
        }

        [Required]
        public string AdultTickets { get; set; }
        [Required]
        public string ChildTickets { get; set; }
        [Required]
        public string InfantTickets { get; set; }

        [Required]
        [RegularExpression( @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Name" )]
        [Length( 3, 10 )]
        public string FirstName {
            get; set;
        }
        [Required]
        [RegularExpression( @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Name" )]
        [Length( 3, 10 )]
        public string LastName {
            get; set;
        }

        [Required]
        [DataType( DataType.PhoneNumber )]
        [RegularExpression( @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number" )]
        public string PhoneNumber {
            get; set;
        }

        [Required]
        public string PickupLocation { get; set; }

        [Required]
        public int PaymentMethod {
            get; set;
        }
        public string PayPalUsername {
            get; set;
        }
        public string PayPalPassword {
            get; set;
        }
        public int CardNumber {
            get; set;
        }
        public int ExpireDate {
            get; set;
        }
        public int CardSecurityCode {
            get; set;
        }

    }
}
