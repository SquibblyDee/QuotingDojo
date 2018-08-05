using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class UserQuotes
    {
        [Required]
        [Display(Name = "Your Name:")]
        public string Name { get; set; }
        [Required]
        public string Quote { get; set; }
    }
}