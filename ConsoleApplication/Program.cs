using Nagarro.EmployeePortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApplication
{
    class Program
    {
       
           static void Main(string[] args)
        {
            while (true)
            {
                System.Console.WriteLine(Messages.SelectAnOption);
                int option;
                if (!Int32.TryParse(System.Console.ReadLine(), out option))
                {
                    System.Console.WriteLine(Messages.invalidInput);
                }
                else
                {
                    switch (option)
                    {
                        case 1:
                            addCategory();
                            break;
                        case 2:
                            addSubCategory();
                            break;
                        case 3:
                            addItem();
                            break;
                        case 4:
                            removeCategory();
                            break;
                        case 5:
                            removeSubCategory();
                            break;
                        case 6:
                            removeItem();
                            break;
                        case 7:
                            editCategory();
                            break;
                        case 8:
                            editSubCategory();
                            break;
                        case 9:
                            editItem();
                            break;
                        case 10:
                            getAllCategories();
                            break;
                        default:
                            System.Console.WriteLine(Messages.invalidOption);
                            break;
                    }
                }
            }
            }
        


    
        private static void addCategory()
        {
            ICategoriesDTO categoryDTO = (ICategoriesDTO)DTOFactory.Instance.Create(DTOType.Category, null);
            categoryDTO.CategoryName = "Food";

            IEcommerceManagerFacade categoryManagerFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager, null);
            OperationResult<int> operationResult = categoryManagerFacade.addCategory(categoryDTO);

            if (operationResult.IsValid())
            {
                System.Console.WriteLine(operationResult.Data);
            }
            else if (operationResult.HasValidationFailed() && operationResult.ValidationResult != null)
            {
                foreach (EmployeePortalValidationFailure error in operationResult.ValidationResult.Errors)
                {
                    System.Console.WriteLine(error.PropertyName + "  " + error.ErrorMessage);
                }
            }
            else if (operationResult.Message != String.Empty && operationResult.StackTrace != String.Empty)
            {
                System.Console.WriteLine(operationResult.Message + "  " + operationResult.StackTrace);
            }
        }

        private static void editCategory()
        {
            ICategoriesDTO categoryDTO = (ICategoriesDTO)DTOFactory.Instance.Create(DTOType.Category, null);
            categoryDTO.CategotyId = 20;
            categoryDTO.CategoryName = "Toys";

            IEcommerceManagerFacade categoryManagerFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager, null);
            OperationResult<ICategoriesDTO> operationResult = categoryManagerFacade.editCategory(categoryDTO);

            if (operationResult.IsValid())
            {
                System.Console.WriteLine(operationResult.Data.CategotyId + "  " + operationResult.Data.CategoryName);
            }
            else if (operationResult.HasValidationFailed() && operationResult.ValidationResult != null)
            {
                foreach (EmployeePortalValidationFailure error in operationResult.ValidationResult.Errors)
                {
                    System.Console.WriteLine(error.PropertyName + "  " + error.ErrorMessage);
                }
            }
            else if (operationResult.Message != String.Empty && operationResult.StackTrace != String.Empty)
            {
                System.Console.WriteLine(operationResult.Message + "  " + operationResult.StackTrace);
            }
        }

        private static void removeCategory()
        {
            int categoryId = 1;

            IEcommerceManagerFacade categoryManagerFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager, null);
            OperationResult<bool> operationResult = categoryManagerFacade.removeCategory(categoryId);

            if (operationResult.IsValid())
            {
                System.Console.WriteLine(operationResult.Data);
            }
            else if (operationResult.HasValidationFailed() && operationResult.ValidationResult != null)
            {
                foreach (EmployeePortalValidationFailure error in operationResult.ValidationResult.Errors)
                {
                    System.Console.WriteLine(error.PropertyName + "  " + error.ErrorMessage);
                }
            }
            else if (operationResult.Message != String.Empty && operationResult.StackTrace != String.Empty)
            {
                System.Console.WriteLine(operationResult.Message + "  " + operationResult.StackTrace);
            }
        }

        private static void getAllCategories()
        {
            IEcommerceManagerFacade categoryManagerFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager, null);
            IList<OperationResult<ICategoriesDTO>> listOperationResult = categoryManagerFacade.GetAllCategories();
            foreach(var category in listOperationResult)
            {
            if (category.IsValid())
            {
                
                    System.Console.WriteLine(category.Data.CategotyId + "  " + category.Data.CategoryName);
                }
            
            else if (category.HasValidationFailed() && category.ValidationResult != null)
            {
                foreach (EmployeePortalValidationFailure error in category.ValidationResult.Errors)
                {
                    System.Console.WriteLine(error.PropertyName + "  " + error.ErrorMessage);
                }
            }
            else if (category.Message != String.Empty && category.StackTrace != String.Empty)
            {
                System.Console.WriteLine(category.Message + "  " + category.StackTrace);
            }
            }
        }
        

        private static void addSubCategory()
        {
            ISubCategoriesDTO subCategoryDTO = (ISubCategoriesDTO)DTOFactory.Instance.Create(DTOType.SubCategory, null);
            subCategoryDTO.SubCategoryName = "apple";
            subCategoryDTO.CategotyId = 2;

            IEcommerceManagerFacade subCategoryManagerFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager, null);
            OperationResult<int> operationResult = subCategoryManagerFacade.addSubCategory(subCategoryDTO);

            if (operationResult.IsValid())
            {
                System.Console.WriteLine(operationResult.Data);
            }
            else if (operationResult.HasValidationFailed() && operationResult.ValidationResult != null)
            {
                foreach (EmployeePortalValidationFailure error in operationResult.ValidationResult.Errors)
                {
                    System.Console.WriteLine(error.PropertyName + "  " + error.ErrorMessage);
                }
            }
            else if (operationResult.Message != String.Empty && operationResult.StackTrace != String.Empty)
            {
                System.Console.WriteLine(operationResult.Message + "  " + operationResult.StackTrace);
            }
        }

        private static void editSubCategory()
        {
            ISubCategoriesDTO subCategoryDTO = (ISubCategoriesDTO)DTOFactory.Instance.Create(DTOType.SubCategory, null);
            subCategoryDTO.SubCategotyId = 1;
            subCategoryDTO.SubCategoryName = "subsub";
            subCategoryDTO.CategotyId = 2;

            IEcommerceManagerFacade subCategoryManagerFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager, null);
            OperationResult<bool> operationResult = subCategoryManagerFacade.EditSubCategory(subCategoryDTO);

            if (operationResult.IsValid())
            {
                System.Console.WriteLine("Successfully updated");
            }
            else if (operationResult.HasValidationFailed() && operationResult.ValidationResult != null)
            {
                foreach (EmployeePortalValidationFailure error in operationResult.ValidationResult.Errors)
                {
                    System.Console.WriteLine(error.PropertyName + "  " + error.ErrorMessage);
                }
            }
            else if (operationResult.Message != String.Empty && operationResult.StackTrace != String.Empty)
            {
                System.Console.WriteLine(operationResult.Message + "  " + operationResult.StackTrace);
            }
        }

        private static void removeSubCategory()
        {
            int subCategoryId = 6;

            IEcommerceManagerFacade subCategoryManagerFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager, null);
            OperationResult<bool> operationResult = subCategoryManagerFacade.deleteSubCategory(subCategoryId);

            if (operationResult.IsValid())
            {
                System.Console.WriteLine("Deleted");
            }
            else if (operationResult.HasValidationFailed() && operationResult.ValidationResult != null)
            {
                foreach (EmployeePortalValidationFailure error in operationResult.ValidationResult.Errors)
                {
                    System.Console.WriteLine(error.PropertyName + "  " + error.ErrorMessage);
                }
            }
            else if (operationResult.Message != String.Empty && operationResult.StackTrace != String.Empty)
            {
                System.Console.WriteLine(operationResult.Message + "  " + operationResult.StackTrace);
            }
        }

        private static void addItem()
        {
            IItemDTO itemDTO = (IItemDTO)DTOFactory.Instance.Create(DTOType.Item, null);
            itemDTO.ItemName = "itemitemitem";
            itemDTO.SubCategotyId = 1;

            IEcommerceManagerFacade itemManagerFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager, null);
            OperationResult<int> operationResult = itemManagerFacade.addItem(itemDTO);

            if (operationResult.IsValid())
            {
                System.Console.WriteLine(operationResult.Data);
            }
            else if (operationResult.HasValidationFailed() && operationResult.ValidationResult != null)
            {
                foreach (EmployeePortalValidationFailure error in operationResult.ValidationResult.Errors)
                {
                    System.Console.WriteLine(error.PropertyName + "  " + error.ErrorMessage);
                }
            }
            else if (operationResult.Message != String.Empty && operationResult.StackTrace != String.Empty)
            {
                System.Console.WriteLine(operationResult.Message + "  " + operationResult.StackTrace);
            }
        }

        private static void editItem()
        {
            IItemDTO itemDTO = (IItemDTO)DTOFactory.Instance.Create(DTOType.Item, null);
            itemDTO.ItemName = "item";
            itemDTO.ItemId = 1;
            itemDTO.SubCategotyId = 2;

            IEcommerceManagerFacade itemManagerFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager, null);
            OperationResult<bool> operationResult = itemManagerFacade.EditItem(itemDTO);

            if (operationResult.IsValid())
            {
                System.Console.WriteLine("Updated");
            }
            else if (operationResult.HasValidationFailed() && operationResult.ValidationResult != null)
            {
                foreach (EmployeePortalValidationFailure error in operationResult.ValidationResult.Errors)
                {
                    System.Console.WriteLine(error.PropertyName + "  " + error.ErrorMessage);
                }
            }
            else if (operationResult.Message != String.Empty && operationResult.StackTrace != String.Empty)
            {
                System.Console.WriteLine(operationResult.Message + "  " + operationResult.StackTrace);
            }
        }

        private static void removeItem()
        {
            int itemId = 7;

            IEcommerceManagerFacade itemManagerFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager, null);
            OperationResult<bool> operationResult = itemManagerFacade.removeItem(itemId);

            if (operationResult.IsValid())
            {
                System.Console.WriteLine("Sucessfully Deleted");
            }
            else if (operationResult.HasValidationFailed() && operationResult.ValidationResult != null)
            {
                foreach (EmployeePortalValidationFailure error in operationResult.ValidationResult.Errors)
                {
                    System.Console.WriteLine(error.PropertyName + "  " + error.ErrorMessage);
                }
            }
            else if (operationResult.Message != String.Empty && operationResult.StackTrace != String.Empty)
            {
                System.Console.WriteLine(operationResult.Message + "  " + operationResult.StackTrace);
            }
        }

    }
}
    

