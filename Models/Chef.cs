using System.ComponentModel.DataAnnotations;

namespace ChefAPI.Models
{
    public class Chef
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public string Specialise { get; set; }

        [Required]
        public double Experience { get; set; }

    }
}