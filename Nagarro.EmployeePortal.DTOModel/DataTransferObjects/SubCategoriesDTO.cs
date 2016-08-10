using Nagarro.EmployeePortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Nagarro.EmployeePortal.DTOModel
{
     [EntityMapping("Nagarro.EmployeePortal.EntityDataModel.EntityModel.SubCategory", MappingType.TotalExplicit)]
    public class SubCategoriesDTO : DTOBase, ISubCategoriesDTO
    {
         public SubCategoriesDTO()
            : base(DTOType.SubCategory)
        {
        }
         [EntityPropertyMapping(MappingDirectionType.Both, "SubCategotyId")]
        public int SubCategotyId { get; set; }
         [EntityPropertyMapping(MappingDirectionType.Both, "SubCategoryName")]
        public string SubCategoryName { get; set; }
         [EntityPropertyMapping(MappingDirectionType.Both, "CategotyId")]
        public int CategotyId { get; set; }
    }

}
