using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Please enter a username")]
        [StringLength(100, ErrorMessage = "The username is too long", MinimumLength = 3)]
        public string? AdminUsername { get; set; }

    }
}