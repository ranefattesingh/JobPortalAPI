using Persistance.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.BAL.BusinessEntities
{
    public class LocationBE
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int Zip { get; set; }
    }
}
