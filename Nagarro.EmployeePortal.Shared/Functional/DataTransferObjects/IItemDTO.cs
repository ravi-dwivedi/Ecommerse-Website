using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface IItemDTO:IDTO
    {
       int ItemId { get; set; }
         string ItemName { get; set; }
         int SubCategotyId { get; set; }
    }
}
