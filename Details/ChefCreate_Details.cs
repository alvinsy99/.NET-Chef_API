using System.ComponentModel.DataAnnotations;

namespace ChefAPI.Details
{
    public class ChefCreate_Details
    {

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public string Specialise { get; set; }

        [Required]
        public double Experience { get; set; }
    }
}