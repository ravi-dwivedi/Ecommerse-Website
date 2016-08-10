using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface ICategoriesDTO:IDTO
    {

      int CategotyId { get; set; }
     string CategoryName { get; set; }
    
    }
}
