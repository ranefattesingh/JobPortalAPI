using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exception
{
    public class NotFoundException : System.Exception
    {
        private NotFoundException()
        {

        }
        public NotFoundException(string resource, int id) 
            : base(string.Format("{0} with id {1} not found.", resource, id))
        {
            
        }
    }
}
