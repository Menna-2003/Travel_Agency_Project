using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.VisualBasic;
using Travel_Agency_Project.Utility;

namespace Travel_Agency_Project.Models {
    public class Tour {
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
        [RegularExpression( @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Name" )]
        [Length( 3, 15 )]
        public string Distination {
            get; set;
        }
        [RegularExpression( @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Name" )]
        [Required]
        [Length( 5, 50 )]
        public string Description {
            get; set;
        }
        [Required]
        public string StartDate {
            get; set;
        }
        [Required]
        public string EndDate {
            get; set;
        }
        [Required]
        [Range( 10, 100000, ErrorMessage = "Price range is from 10 to 100,000" )]
        public int Price {
            get; set;
        }
        [Required]
        public int AdultsTickets {
            get; set;
        }
        [Required]
        public int ChildrenTickets {
            get; set;
        }
        [Required]
        public int InfantTickets {
            get; set;
        }
        [Required]
        public string HotelName {
            get; set;
        }
        [Required]
        public string Meals {
            get; set;
        }
        [Required]
        public bool GuideIncluded {
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
        public byte[] ImageData {
            get; set;
        }
        public string ContentType {
            get; set;
        }
    }
}
