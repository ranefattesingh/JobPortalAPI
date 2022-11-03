using Persistance.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.BAL.BusinessEntities
{
    public class JobPostBE
    {
        public int ID { get; set; }
        public string? Code { get; set; }
        public string? Title { get; set; }
        public Location? Location { get; set; }
        public int LocationID { get; set; }
        public Department? Department { get; set; }
        public int DepartmentID { get; set; }
        public string? Description { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}
