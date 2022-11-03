using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Models
{
    public class Location
    {
        [Key]
        public int ID { get; set; }
        [Required][StringLength(100)]
        public string? Title { get; set; }
        [Required][StringLength(50)]
        public string? City { get; set; }
        [Required][StringLength(50)]
        public string? State { get; set; }
        [Required][StringLength(50)]
        public string? Country { get; set; }
        [Required]
        public int Zip { get; set; }
        public JobPost? JobPost { get; set; }
    }
}
