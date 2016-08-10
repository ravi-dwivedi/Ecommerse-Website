using Nagarro.EmployeePortal.EntityDataModel.EntityModel;
using Nagarro.EmployeePortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Nagarro.EmployeePortal.EntityDataModel;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.Objects.DataClasses;



namespace Nagarro.EmployeePortal.Data
{
    public class EcommerceManagerDAC : DACBase, IEcommerceManagerDAC
    {
        public EcommerceManagerDAC()
            : base(DACType.EcommerceManagerDAC)
        {

        }

        public bool removeCategory(int categoryId)
        {
            bool retVal = false;
            try
            {
                using (var database = new EcommerceEntities())
                {
                    var categoryEntities = database.Categories;
                    Category category = categoryEntities.Where(i => i.CategotyId == categoryId).FirstOrDefault();
                    if (category != null)
                    {
                        categoryEntities.Remove(category);
                        database.SaveChanges();
                        retVal = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return retVal;
        }

        public bool removeItem(int itemId)
        {
            bool retVal = false;
            try
            {
                using (var database = new EcommerceEntities())
                {
                    var itemEntities = database.Items;
                    Item item = itemEntities.Where(i => i.ItemId == itemId).FirstOrDefault();
                    if (item != null)
                    {
                        itemEntities.Remove(item);
                        database.SaveChanges();
                        retVal = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return retVal;
        }


        public bool isSubCategoryIdExist(int subCategoryId)
        {
            bool retVal = false;
            try
            {
                using (var database = new EcommerceEntities())
                {
                    SubCategory subCategory = database.SubCategories.Where(i => i.SubCategotyId == subCategoryId).FirstOrDefault();
                    if (subCategory != null)
                    {
                        retVal = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return retVal;
        }

        public bool isItemNameUnique(String itemName, int subCategoryId)
        {
            bool retVal = true;
            try
            {
                using (var database = new EcommerceEntities())
                {
                    Item item = database.Items.Where(i => i.ItemName == itemName && i.SubCategotyId == subCategoryId).FirstOrDefault();
                    if (item != null)
                    {
                        retVal = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return retVal;
        }
        public bool isChildExist(int subCategoryId)
        {
            bool retVal = false;
            try
            {
                using (var database = new EcommerceEntities())
                {
                    var item = database.Items.Where(i => i.SubCategotyId == subCategoryId).FirstOrDefault();
                    if (item != null)
                    {
                        retVal = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return retVal;
        }

        public bool isCategoryNameUnique(String categoryName)
        {
            bool retVal = true;
            try
            {
                using (var database = new EcommerceEntities())
                {
                    Category category = database.Categories.Where(i => i.CategoryName == categoryName).FirstOrDefault();
                    if (category != null)
                    {
                        retVal = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return retVal;
        }

        public bool isCategoryIdExist(int categoryId)
        {
            bool retVal = false;
            try
            {
                using (var database = new EcommerceEntities())
                {
                    Category category = database.Categories.Where(i => i.CategotyId == categoryId).FirstOrDefault();
                    if (category != null)
                    {
                        retVal = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return retVal;
        }
        public bool isSubCategoryNameUnique(int categotyId, String subCategoryName)
        {
            bool retVal = true;
            try
            {
                using (var database = new EcommerceEntities())
                {
                    SubCategory subCategory = database.SubCategories.Where(i => i.CategotyId == categotyId && i.SubCategoryName == subCategoryName).FirstOrDefault();
                    if (subCategory != null)
                    {
                        retVal = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return retVal;
        }


        public bool deleteSubCategory(int categoryId)
        {
            bool retVal = false;
            using (EcommerceEntities employeePortalEntities = new EcommerceEntities())
            {
                try
                {
                    SubCategory cat = employeePortalEntities.SubCategories.Where(category => category.SubCategotyId == categoryId).FirstOrDefault();
                    employeePortalEntities.SubCategories.Remove(cat);
                    employeePortalEntities.SaveChanges();
                    retVal = true;
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }


            }
            return retVal;

        }

        public bool EditItem(IItemDTO item)
        {
            bool retVal = false;
            using (EcommerceEntities employeePortalEntities = new EcommerceEntities())
            {
                try
                {
                    var employeeEntity = employeePortalEntities.Items.FirstOrDefault(employee => employee.ItemId == item.ItemId);
                    if (employeeEntity != null)
                    {

                        employeeEntity.SubCategotyId = item.SubCategotyId;
                        employeeEntity.ItemName = item.ItemName;
                        employeePortalEntities.SaveChanges();
                        retVal = true;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return retVal;
        }

        public ICategoriesDTO editCategory(ICategoriesDTO categoryDTO)
        {
            ICategoriesDTO retVal = null;
            try
            {
                using (var database = new EcommerceEntities())
                {
                    var category = database.Categories.Where(c => c.CategotyId == categoryDTO.CategotyId).FirstOrDefault();
                    if (category != null)
                    {
                        category.CategoryName = categoryDTO.CategoryName;
                        database.SaveChanges();

                        retVal = (ICategoriesDTO)DTOFactory.Instance.Create(DTOType.Category, null);
                        EntityConverter.FillDTOFromEntity(category, retVal);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return retVal;
        }

        public int addCategory(ICategoriesDTO category)
        {

            int retVal = default(int);

            using (EcommerceEntities employeePortalEntities = new EcommerceEntities())
            {
                try
                {
                    Category employee = new Category();
                    EntityConverter.FillEntityFromDTO(category, employee);
                    Category addedEmployee = employeePortalEntities.Categories.Add(employee);
                    employeePortalEntities.SaveChanges();
                    retVal = addedEmployee.CategotyId;
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }

            return retVal;
        }

        public int addSubCategory(ISubCategoriesDTO category)
        {

            int retVal = default(int);

            using (EcommerceEntities employeePortalEntities = new EcommerceEntities())
            {
                try
                {
                    SubCategory employee = new SubCategory();
                    EntityConverter.FillEntityFromDTO(category, employee);
                    SubCategory addedEmployee = employeePortalEntities.SubCategories.Add(employee);
                    employeePortalEntities.SaveChanges();
                    retVal = addedEmployee.SubCategotyId;
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }

            return retVal;
        }

        public int addItem(IItemDTO category)
        {

            int retVal = default(int);

            using (EcommerceEntities employeePortalEntities = new EcommerceEntities())
            {
                try
                {
                    Item employee = new Item();
                    EntityConverter.FillEntityFromDTO(category, employee);
                    Item addedEmployee = employeePortalEntities.Items.Add(employee);
                    employeePortalEntities.SaveChanges();
                    retVal = addedEmployee.ItemId;
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }

            return retVal;
        }



        public IItemDTO getItem(int employeeId)
        {
            IItemDTO employeeDTO = null;
            using (EcommerceEntities employeePortalEntities = new EcommerceEntities())
            {
                try
                {
                    var employeeEntity = employeePortalEntities.Items.FirstOrDefault(employee => employee.ItemId == employeeId);
                    if (employeeEntity != null)
                    {
                        employeeDTO = (IItemDTO)DTOFactory.Instance.Create(DTOType.Item);
                        EntityConverter.FillDTOFromEntity(employeeEntity, employeeDTO);
                    }

                }

                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return employeeDTO;
        }

        public String GetCategoryName(int id)
        {
            String retVal = "";
            using (EcommerceEntities employeePortalEntities = new EcommerceEntities())
            {
                try
                {
                    var employeeEntity = (employeePortalEntities.Categories).Where(category => category.CategotyId == id).FirstOrDefault();
                    retVal = employeeEntity.CategoryName;
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return retVal;
        }

        public String GetSubCategoryName(int id)
        {
            String retVal = "";
            using (EcommerceEntities employeePortalEntities = new EcommerceEntities())
            {
                try
                {
                    var employeeEntity = (employeePortalEntities.SubCategories).Where(category => category.SubCategotyId == id).FirstOrDefault();
                    retVal = employeeEntity.SubCategoryName;
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return retVal;
        }

        public IList<ICategoriesDTO> GetAllCategories()
        {
            IList<ICategoriesDTO> employeeDTOList = new List<ICategoriesDTO>();
            ICategoriesDTO employeeDTO = null;
            using (EcommerceEntities employeePortalEntities = new EcommerceEntities())
            {
                try
                {
                    var employeeEntity = (employeePortalEntities.Categories);

                    foreach (var emp in employeeEntity)
                    {

                        employeeDTO = (ICategoriesDTO)DTOFactory.Instance.Create(DTOType.Category);
                        EntityConverter.FillDTOFromEntity(emp, employeeDTO);
                        employeeDTOList.Add(employeeDTO);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return employeeDTOList;
        }



        public IList<ISubCategoriesDTO> GetAllSubCategories(int categoryId)
        {
            IList<ISubCategoriesDTO> employeeDTOList = new List<ISubCategoriesDTO>();
            ISubCategoriesDTO employeeDTO = null;
            using (EcommerceEntities employeePortalEntities = new EcommerceEntities())
            {
                try
                {
                    var employeeEntity = (employeePortalEntities.SubCategories).Where(subcategory => subcategory.CategotyId == categoryId);

                    foreach (var emp in employeeEntity)
                    {

                        employeeDTO = (ISubCategoriesDTO)DTOFactory.Instance.Create(DTOType.SubCategory);
                        EntityConverter.FillDTOFromEntity(emp, employeeDTO);
                        employeeDTOList.Add(employeeDTO);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return employeeDTOList;
        }



        public IList<IItemDTO> GetAllSubCategoryItems(int categoryId)
        {
            IList<IItemDTO> employeeDTOList = new List<IItemDTO>();
            IItemDTO employeeDTO = null;
            using (EcommerceEntities employeePortalEntities = new EcommerceEntities())
            {
                try
                {
                    var employeeEntity = (employeePortalEntities.Items).Where(item => item.SubCategotyId == categoryId);

                    foreach (var emp in employeeEntity)
                    {

                        employeeDTO = (IItemDTO)DTOFactory.Instance.Create(DTOType.Item);
                        EntityConverter.FillDTOFromEntity(emp, employeeDTO);
                        employeeDTOList.Add(employeeDTO);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return employeeDTOList;
        }



        public ISubCategoriesDTO getSubCategory(int employeeId)
        {
            ISubCategoriesDTO employeeDTO = null;
            using (EcommerceEntities employeePortalEntities = new EcommerceEntities())
            {
                try
                {
                    var employeeEntity = employeePortalEntities.SubCategories.FirstOrDefault(employee => employee.SubCategotyId == employeeId);
                    if (employeeEntity != null)
                    {
                        employeeDTO = (ISubCategoriesDTO)DTOFactory.Instance.Create(DTOType.SubCategory);
                        EntityConverter.FillDTOFromEntity(employeeEntity, employeeDTO);
                    }

                }

                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return employeeDTO;
        }

        public bool EditSubCategory(ISubCategoriesDTO sub)
        {
            bool retVal = false;
            using (EcommerceEntities employeePortalEntities = new EcommerceEntities())
            {
                try
                {
                    var employeeEntity = employeePortalEntities.SubCategories.FirstOrDefault(employee => employee.SubCategotyId == sub.SubCategotyId);
                    if (employeeEntity != null)
                    {

                        employeeEntity.CategotyId = sub.CategotyId;
                        employeeEntity.SubCategoryName = sub.SubCategoryName;
                        employeePortalEntities.SaveChanges();
                        retVal = true;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return retVal;
        }


    }
}


