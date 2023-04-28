using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Bar
    {
        [Required]
        [StringLength(10, ErrorMessage = "My error")]
        public string  Name { get; set; }
        public int Count { get; set; }
        [Range(0.33, 5)]
        public double Volume { get; set; }
        // [EmailAddress]
        // [Phone]
    }
}
