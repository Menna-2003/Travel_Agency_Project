using Travel_Agency_Project.Models;

namespace Travel_Agency_Project.ViewModel {
    public class TourFilterViewModel {
       
        public string? Distination {
            get; set;
        }
        public DateTime? StartDate {
            get; set;
        }
        public DateTime? EndDate {
            get; set;
        }
        public decimal? MinPrice {
            get; set;
        }
        public decimal? MaxPrice {
            get; set;
        }
        public bool? GuideIncluded {
            get; set;
        }
        public List<Tour> tours {
            get; set;
        }
        public int TotalNumberOfPages {
            get; set;
        }

        public int CurrentPage {
            get; set;
        }
    }
}
