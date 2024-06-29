using System.ComponentModel.DataAnnotations;

namespace Travel_Agency_Project.Models {
    public class Transportation {
        [Key]
        public int ID { get; set; }
        [Required]
        public String Name { get; set; }

    }
}
