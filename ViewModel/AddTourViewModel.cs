using Microsoft.AspNetCore.Mvc.Rendering;
using Travel_Agency_Project.Models;

namespace Travel_Agency_Project.ViewModel {
    public class AddTourViewModel {

        public Tour tour { get; set; }
        public int transportationID { get; set; }
        public List<SelectListItem>? Transportations {
            set; get;
        }

    }
}
