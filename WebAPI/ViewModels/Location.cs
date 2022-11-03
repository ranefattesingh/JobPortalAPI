using Persistance.EntityFramework.Models;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class Location
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string? Title { get; set; }
        [Required]
        [StringLength(50)]
        public string? City { get; set; }
        [Required]
        [StringLength(50)]
        public string? State { get; set; }
        [Required]
        [StringLength(50)]
        public string? Country { get; set; }
        [Required]
        public int Zip { get; set; }
    }
}
