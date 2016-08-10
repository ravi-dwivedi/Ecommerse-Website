using Nagarro.EmployeePortal.Shared;
using Nagarro.EmployeePortal.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Business
{
    public class EcommerceManagerBDC : BDCBase, IEcommerceManagerBDC
    {

        public EcommerceManagerBDC()
            : base(BDCType.EcommerceManager)
        {

        }


        public OperationResult<ICategoriesDTO> editCategory(ICategoriesDTO categoryDTO)
        {
            OperationResult<ICategoriesDTO> retVal = null;
            try
            {
                EmployeePortalValidationResult validationResult = Validator<CategoryManagerValidator, ICategoriesDTO>.Validate(categoryDTO, "addCategory");
                if (!validationResult.IsValid)
                {
                    retVal = OperationResult<ICategoriesDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    IEcommerceManagerDAC categoryManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC, null);
                    ICategoriesDTO addedCategory = categoryManagerDAC.editCategory(categoryDTO);
                    retVal = OperationResult<ICategoriesDTO>.CreateSuccessResult(addedCategory);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<ICategoriesDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<ICategoriesDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }

        public OperationResult<bool> removeCategory(int categoryId)
        {
            OperationResult<bool> retVal = null;
            try
            {
                ICategoriesDTO categoryDTO = (ICategoriesDTO)DTOFactory.Instance.Create(DTOType.Category, null);
                categoryDTO.CategotyId = categoryId;


                IEcommerceManagerDAC categoryManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC, null);
                    bool isRemoved = categoryManagerDAC.removeCategory(categoryId);
                    retVal = OperationResult<bool>.CreateSuccessResult(isRemoved);
                
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<bool>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<bool>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }


        public OperationResult<bool> removeItem(int itemId)
        {
            OperationResult<bool> retVal = null;
            try
            {
                IEcommerceManagerDAC itemManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC, null);
                bool isDeleted = itemManagerDAC.removeItem(itemId);
                retVal = OperationResult<bool>.CreateSuccessResult(isDeleted);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<bool>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<bool>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }

        public OperationResult<bool> deleteSubCategory(int categoryId)
        {

            OperationResult<bool> retVal = null;
            try
            {

                IEcommerceManagerDAC employeeManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
                bool employeeDTO = employeeManagerDAC.deleteSubCategory(categoryId);

                retVal = OperationResult<bool>.CreateSuccessResult(employeeDTO);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<bool>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<bool>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;

        }

        public OperationResult<bool> EditItem(IItemDTO item)
        {
            OperationResult<bool> retVal = null;
            try
            {
                EmployeePortalValidationResult validationResult = Validator<ItemManagerValidator, IItemDTO>.Validate(item);
                if (!validationResult.IsValid)
                {
                    retVal = OperationResult<bool>.CreateFailureResult(validationResult);
                }
                else
                {
                    IEcommerceManagerDAC employeeManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
                    bool employeeDTO = employeeManagerDAC.EditItem(item);

                    retVal = OperationResult<bool>.CreateSuccessResult(employeeDTO);
                }

            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<bool>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<bool>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<ISubCategoriesDTO> getSubCategory(int employeeId)
        {
            OperationResult<ISubCategoriesDTO> retVal = null;
            try
            {
                IEcommerceManagerDAC employeeManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
                ISubCategoriesDTO employeeDTO = employeeManagerDAC.getSubCategory(employeeId);

                retVal = OperationResult<ISubCategoriesDTO>.CreateSuccessResult(employeeDTO);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<ISubCategoriesDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<ISubCategoriesDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<bool> EditSubCategory(ISubCategoriesDTO sub)
        {

            OperationResult<bool> retVal = null;
            try
            {
                // functionality to insert notice
                EmployeePortalValidationResult validationResult = Validator<SubCategoryManagerValidator, ISubCategoriesDTO>.Validate(sub, "AddSubCategory");
                if (!validationResult.IsValid)
                {
                    retVal = OperationResult<bool>.CreateFailureResult(validationResult);
                }
                else
                {
                    IEcommerceManagerDAC employeeManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
                    bool employeeDTO = employeeManagerDAC.EditSubCategory(sub);

                    retVal = OperationResult<bool>.CreateSuccessResult(employeeDTO);
                }


            }
            catch (DACException dacEX)
            {
                retVal = OperationResult<bool>.CreateErrorResult(dacEX.Message, dacEX.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<bool>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }


        public OperationResult<String> GetSubCategoryName(int id)
        {
            OperationResult<String> retVal = null;

            try
            {
                IEcommerceManagerDAC employeeManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
                String employeeId = employeeManagerDAC.GetSubCategoryName(id);

                retVal = OperationResult<String>.CreateSuccessResult(employeeId);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<String>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<String>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<String> GetCategoryName(int id)
        {
            OperationResult<String> retVal = null;

            try
            {
                IEcommerceManagerDAC employeeManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
                String employeeId = employeeManagerDAC.GetCategoryName(id);

                retVal = OperationResult<String>.CreateSuccessResult(employeeId);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<String>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<String>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }
        public OperationResult<int> addCategory(ICategoriesDTO category)
        {
            OperationResult<int> retVal = null;
            try
            {

                EmployeePortalValidationResult validationResult = Validator<CategoryManagerValidator, ICategoriesDTO>.Validate(category, "addCategory");
                if (!validationResult.IsValid)
                {
                    retVal = OperationResult<int>.CreateFailureResult(validationResult);
                }
                else
                {
                    IEcommerceManagerDAC employeeManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
                    int employeeId = employeeManagerDAC.addCategory(category);

                    retVal = OperationResult<int>.CreateSuccessResult(employeeId);
                }

              
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<int>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<int>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<int> addSubCategory(ISubCategoriesDTO category)
        {



            OperationResult<int> retVal = null;
            try
            {
                EmployeePortalValidationResult validationResult = Validator<SubCategoryManagerValidator, ISubCategoriesDTO>.Validate(category, "AddSubCategory");

                if (!validationResult.IsValid)
                {
                    retVal = OperationResult<int>.CreateFailureResult(validationResult);

                }
                else
                {
                    IEcommerceManagerDAC employeeManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
                    int employeeId = employeeManagerDAC.addSubCategory(category);
                    retVal = OperationResult<int>.CreateSuccessResult(employeeId);
                }


            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<int>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<int>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<int> addItem(IItemDTO category)
        {
            OperationResult<int> retVal = null;
            try
            {


                EmployeePortalValidationResult validationResult = Validator<ItemManagerValidator, IItemDTO>.Validate(category);
                if (!validationResult.IsValid)
                {
                    retVal = OperationResult<int>.CreateFailureResult(validationResult);
                }
                else
                {
                    IEcommerceManagerDAC employeeManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
                    int employeeId = employeeManagerDAC.addItem(category);

                    retVal = OperationResult<int>.CreateSuccessResult(employeeId);
                }

            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<int>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<int>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }



        public OperationResult<IItemDTO> getItem(int employeeId)
        {
            OperationResult<IItemDTO> retVal = null;
            try
            {
                IEcommerceManagerDAC employeeManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
                IItemDTO employeeDTO = employeeManagerDAC.getItem(employeeId);

                retVal = OperationResult<IItemDTO>.CreateSuccessResult(employeeDTO);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IItemDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IItemDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }


        public IList<OperationResult<ICategoriesDTO>> GetAllCategories()
        {
            IList<OperationResult<ICategoriesDTO>> retVal = new List<OperationResult<ICategoriesDTO>>();
            try
            {
                IEcommerceManagerDAC employeeManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
                IList<ICategoriesDTO> employeeDTOList = employeeManagerDAC.GetAllCategories();

                foreach (ICategoriesDTO emp in employeeDTOList)
                {
                    retVal.Add(OperationResult<ICategoriesDTO>.CreateSuccessResult(emp));
                }
            }
            catch (DACException dacEx)
            {
                retVal.Clear();
                retVal.Add(OperationResult<ICategoriesDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace));
            }
            catch (Exception ex)
            {
                retVal.Clear();
                ExceptionManager.HandleException(ex);
                retVal.Add(OperationResult<ICategoriesDTO>.CreateErrorResult(ex.Message, ex.StackTrace));
            }

            return retVal;
        }



        public IList<OperationResult<ISubCategoriesDTO>> GetAllSubCategories(int categoryId)
        {
            IList<OperationResult<ISubCategoriesDTO>> retVal = new List<OperationResult<ISubCategoriesDTO>>();
            try
            {
                IEcommerceManagerDAC employeeManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
                IList<ISubCategoriesDTO> employeeDTOList = employeeManagerDAC.GetAllSubCategories(categoryId);

                foreach (ISubCategoriesDTO emp in employeeDTOList)
                {
                    retVal.Add(OperationResult<ISubCategoriesDTO>.CreateSuccessResult(emp));
                }
            }
            catch (DACException dacEx)
            {
                retVal.Clear();
                retVal.Add(OperationResult<ISubCategoriesDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace));
            }
            catch (Exception ex)
            {
                retVal.Clear();
                ExceptionManager.HandleException(ex);
                retVal.Add(OperationResult<ISubCategoriesDTO>.CreateErrorResult(ex.Message, ex.StackTrace));
            }

            return retVal;
        }



        public IList<OperationResult<IItemDTO>> GetAllSubCategoryItems(int categoryId)
        {
            IList<OperationResult<IItemDTO>> retVal = new List<OperationResult<IItemDTO>>();
            try
            {
                IEcommerceManagerDAC employeeManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
                IList<IItemDTO> employeeDTOList = employeeManagerDAC.GetAllSubCategoryItems(categoryId);

                foreach (IItemDTO emp in employeeDTOList)
                {
                    retVal.Add(OperationResult<IItemDTO>.CreateSuccessResult(emp));
                }
            }
            catch (DACException dacEx)
            {
                retVal.Clear();
                retVal.Add(OperationResult<IItemDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace));
            }
            catch (Exception ex)
            {
                retVal.Clear();
                ExceptionManager.HandleException(ex);
                retVal.Add(OperationResult<IItemDTO>.CreateErrorResult(ex.Message, ex.StackTrace));
            }

            return retVal;
        }


    }
}
