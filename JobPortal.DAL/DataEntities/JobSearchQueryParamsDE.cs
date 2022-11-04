using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DAL.DataEntities
{
    public class JobSearchQueryParamsDE
    {
        public string Q { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int? LocationID { get; set; }
        public int? DepartmentID { get; set; }
    }
}
