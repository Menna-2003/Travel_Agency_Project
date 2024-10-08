﻿using System.ComponentModel.DataAnnotations;
using Travel_Agency_Project.Models;

namespace Travel_Agency_Project.ViewModel
{
    public class UserDetails
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Name")]
        [Length(3, 10)]
        public string FirstName
        {
            get; set;
        }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Name")]
        [Length(3, 10)]
        public string LastName
        {
            get; set;
        }

        [Required]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression( @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number" )]
        public string PhoneNumber
        {
            get; set;
        }
        [Required]
        public string PickupLocation
        {
            get; set;
        }

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
