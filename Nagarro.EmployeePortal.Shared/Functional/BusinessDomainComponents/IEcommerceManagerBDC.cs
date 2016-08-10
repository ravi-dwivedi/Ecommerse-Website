using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface IEcommerceManagerBDC : IBusinessDomainComponent
    {

        OperationResult<ICategoriesDTO> editCategory(ICategoriesDTO categoryDTO);
        OperationResult<bool> removeCategory(int categoryId);

        OperationResult<bool> removeItem(int itemId);
        OperationResult<bool> deleteSubCategory(int categoryId);

        OperationResult<bool> EditItem(IItemDTO item);
        OperationResult<ISubCategoriesDTO> getSubCategory(int employeeId);

        OperationResult<bool> EditSubCategory(ISubCategoriesDTO sub);

        OperationResult<String> GetSubCategoryName(int id);
        OperationResult<String> GetCategoryName(int id);
        OperationResult<int> addCategory(ICategoriesDTO category);
        OperationResult<int> addSubCategory(ISubCategoriesDTO category);
        OperationResult<int> addItem(IItemDTO category);
        OperationResult<IItemDTO> getItem(int employeeId);


        IList<OperationResult<ICategoriesDTO>> GetAllCategories();
        IList<OperationResult<ISubCategoriesDTO>> GetAllSubCategories(int categoryId);


        IList<OperationResult<IItemDTO>> GetAllSubCategoryItems(int categoryId);
    }
}
