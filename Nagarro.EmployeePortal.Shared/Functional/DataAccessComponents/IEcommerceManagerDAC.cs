using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface IEcommerceManagerDAC : IDataAccessComponent
    {

        bool removeCategory(int categoryId);
        bool removeItem(int itemId);
        ICategoriesDTO editCategory(ICategoriesDTO categoryDTO);
        bool isSubCategoryIdExist(int subCategoryId);

        bool isItemNameUnique(String itemName, int subCategoryId);
        bool isChildExist(int subCategoryId);

        bool isCategoryNameUnique(String categoryName);
        bool isCategoryIdExist(int categoryId);
        bool isSubCategoryNameUnique(int categotyId, String subCategoryName);
        bool deleteSubCategory(int categoryId);
        bool EditItem(IItemDTO item);
        ISubCategoriesDTO getSubCategory(int employeeId);

        bool EditSubCategory(ISubCategoriesDTO sub);
        String GetSubCategoryName(int id);
        String GetCategoryName(int id);
        int addCategory(ICategoriesDTO category);
        int addSubCategory(ISubCategoriesDTO category);

        int addItem(IItemDTO category);
        IItemDTO getItem(int employeeId);


        IList<ICategoriesDTO> GetAllCategories();

        IList<ISubCategoriesDTO> GetAllSubCategories(int categoryId);

        IList<IItemDTO> GetAllSubCategoryItems(int categoryId);


    }
}
