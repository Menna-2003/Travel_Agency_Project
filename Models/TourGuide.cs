using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel_Agency_Project.Models {
    public class TourGuide {

        [Key]
        public int ID {
            get; set;
        }
        [Required]
        [RegularExpression( @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Name" )]
        [Length( 5, 15 )]
        public string Name {
            get; set;
        }

        [Required]
        public int TourId {
            get; set;
        }
        [ForeignKey( "TourId" )]
        public Tour Tour {
            get; set;
        }


    }
}
