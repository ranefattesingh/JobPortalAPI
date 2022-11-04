using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.BAL.BusinessEntities
{
    public class JobSearchQueryParamsBE
    {
        public string Q { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int? LocationID { get; set; }
        public int? DepartmentID { get; set; }
    }
}
