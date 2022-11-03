using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }
        public JobPost? JobPost { get; set; }
    }
}
