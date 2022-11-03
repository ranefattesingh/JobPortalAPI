using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Models
{
    public class JobPost
    {
        [Key]
        public int ID { get; set; }
        [StringLength(10)]
        [Required]
        public string? Code { get; set; }
        [StringLength(100)]
        [Required]
        public string? Title { get; set; }
        public Location? Location { get; set; }
        public int LocationID { get; set; }
        public Department? Department { get; set; }
        public int DepartmentID { get; set; }
        [Required]
        [StringLength(200)]
        public string? Description { get; set; }
        [Required]
        public DateTime PostedDate { get; set; }
        [Required]
        public DateTime ClosingDate { get; set; }
    }
}
