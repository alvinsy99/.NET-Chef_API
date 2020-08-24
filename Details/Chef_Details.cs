using System.ComponentModel.DataAnnotations;

namespace ChefAPI.Details
{
    public class Chef_Details
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public string Specialise { get; set; }

    }
}