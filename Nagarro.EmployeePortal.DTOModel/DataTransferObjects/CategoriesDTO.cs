using Nagarro.EmployeePortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Nagarro.EmployeePortal.DTOModel
{
     [EntityMapping("Nagarro.EmployeePortal.EntityDataModel.EntityModel.Category", MappingType.TotalExplicit)]
    public class CategoriesDTO : DTOBase, ICategoriesDTO
    {
         public CategoriesDTO()
            : base(DTOType.Category)
        {
        }
           [EntityPropertyMapping(MappingDirectionType.Both, "CategotyId")]
        public int CategotyId { get; set; }
          [EntityPropertyMapping(MappingDirectionType.Both, "CategoryName")]
           public string CategoryName { get; set; }
    

    }
}
