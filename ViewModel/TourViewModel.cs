using Microsoft.AspNetCore.Mvc.Rendering;
using Travel_Agency_Project.Models;

namespace Travel_Agency_Project.ViewModel
{
    public class TourViewModel
    {
        public List<Tour> tour
        {
            get; set;
        }

        public string? Distination
        {
            get; set;
        }
        public List<SelectListItem>? Distinations
        {
            set; get;
        }
    }
}
