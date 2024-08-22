using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel_Agency_Project.Models {
    public class UserFavourites {
        [Key]
        public int ID {
            get; set;
        }
        [Required]
        public string UserId {
            get; set;
        }
        [Required]
        public int TourID {
            get; set;
        }
        [ForeignKey( "TourID" )]
        public Tour tour {
            get; set;
        }
    }
}
