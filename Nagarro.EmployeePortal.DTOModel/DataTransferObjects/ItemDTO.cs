using Nagarro.EmployeePortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Nagarro.EmployeePortal.DTOModel
{
     [EntityMapping("Nagarro.EmployeePortal.EntityDataModel.EntityModel.Item", MappingType.TotalExplicit)]
    public class ItemDTO : DTOBase, IItemDTO
    {

         public ItemDTO()
            : base(DTOType.Item)
        {
        }
         [EntityPropertyMapping(MappingDirectionType.Both, "ItemId")]
        public int ItemId { get; set; }
         [EntityPropertyMapping(MappingDirectionType.Both, "ItemName")]
        public string ItemName { get; set; }
         [EntityPropertyMapping(MappingDirectionType.Both, "SubCategotyId")]
        public int SubCategotyId { get; set; }
    }
}
