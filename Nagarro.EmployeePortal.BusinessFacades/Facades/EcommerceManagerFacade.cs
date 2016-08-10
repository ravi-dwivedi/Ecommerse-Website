using Nagarro.EmployeePortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nagarro.EmployeePortal.BusinessFacades
{
    public class EcommerceManagerFacade : FacadeBase, IEcommerceManagerFacade
    {
        public EcommerceManagerFacade()
            :base(FacadeType.EcommerceManager)
        {

        }

        public OperationResult<bool> removeItem(int itemId)
        {
            IEcommerceManagerBDC itemManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager, null);
            return itemManagerBDC.removeItem(itemId);
        }



        public OperationResult<ICategoriesDTO> editCategory(ICategoriesDTO categoryDTO)
        {
            IEcommerceManagerBDC categoryManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager, null);
            return categoryManagerBDC.editCategory(categoryDTO);
        }

        public OperationResult<bool> removeCategory(int categoryId)
        {
            IEcommerceManagerBDC categoryManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager, null);
            return categoryManagerBDC.removeCategory(categoryId);
        }


        public OperationResult<bool> deleteSubCategory(int categoryId)
        {
            IEcommerceManagerBDC employeeManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager);
            return employeeManagerBDC.deleteSubCategory(categoryId);
        }

        public OperationResult<bool> EditItem(IItemDTO item)
        {
            IEcommerceManagerBDC employeeManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager);
            return employeeManagerBDC.EditItem(item);
        }
        public OperationResult<ISubCategoriesDTO> getSubCategory(int employeeId)
        {
            IEcommerceManagerBDC employeeManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager);
            return employeeManagerBDC.getSubCategory(employeeId);
        }
         public OperationResult<bool> EditSubCategory(ISubCategoriesDTO sub)
        {
            IEcommerceManagerBDC employeeManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager);
            return employeeManagerBDC.EditSubCategory(sub);
        }

        public OperationResult<String> GetSubCategoryName(int id)
        {
            IEcommerceManagerBDC employeeManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager);
            return employeeManagerBDC.GetSubCategoryName(id);
        }

        public OperationResult<String> GetCategoryName(int id)
        {
            IEcommerceManagerBDC employeeManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager);
            return employeeManagerBDC.GetCategoryName(id);
        }
        public OperationResult<int> addCategory(ICategoriesDTO category)
        {
            IEcommerceManagerBDC employeeManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager);
            return employeeManagerBDC.addCategory(category);
        }

        public OperationResult<int> addSubCategory(ISubCategoriesDTO category)
        {
            IEcommerceManagerBDC employeeManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager);

            return employeeManagerBDC.addSubCategory(category);
        }

        public OperationResult<int> addItem(IItemDTO category)
        {
            IEcommerceManagerBDC employeeManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager);

            return employeeManagerBDC.addItem(category);
        }



        public OperationResult<IItemDTO> getItem(int employeeId)
        {
            IEcommerceManagerBDC employeeManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager);

            return employeeManagerBDC.getItem(employeeId);
        }


        public IList<OperationResult<ICategoriesDTO>> GetAllCategories()
        {
            IEcommerceManagerBDC employeeManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager);

            return employeeManagerBDC.GetAllCategories();
        }



        public IList<OperationResult<ISubCategoriesDTO>> GetAllSubCategories(int categoryId)
        {
            IEcommerceManagerBDC employeeManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager);

            return employeeManagerBDC.GetAllSubCategories(categoryId);
        }



        public IList<OperationResult<IItemDTO>> GetAllSubCategoryItems(int categoryId)
        {
            IEcommerceManagerBDC employeeManagerBDC = (IEcommerceManagerBDC)BDCFactory.Instance.Create(BDCType.EcommerceManager);
            return employeeManagerBDC.GetAllSubCategoryItems(categoryId);
        }
    }
}
