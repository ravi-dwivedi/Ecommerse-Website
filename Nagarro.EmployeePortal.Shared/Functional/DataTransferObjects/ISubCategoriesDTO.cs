using System;
using System.Collections.Generic;

namespace Nagarro.EmployeePortal.Shared
{
    public interface ISubCategoriesDTO: IDTO
    {
      int SubCategotyId { get; set; }
       string SubCategoryName { get; set; }
      int CategotyId { get; set; }
    }
}
