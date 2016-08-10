using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nagarro.EmployeePortal.Shared;

namespace Ecommerce.Controllers
{
    public class EcommerceController : Controller
    {
        //
        // GET: /Ecommerce/

        public ActionResult Index()
        {

            IList<Category> retVal = new List<Category>();
            IEcommerceManagerFacade employeeFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager);
            IList<OperationResult<ICategoriesDTO>> result = employeeFacade.GetAllCategories();

            if (result.Count() > 0)
            {
                foreach (OperationResult<ICategoriesDTO> emp in result)
                {
                    if (emp.IsValid())
                    {

                        Category tempEmp = new Category();
                        tempEmp.CategoryName = emp.Data.CategoryName;
                        tempEmp.CategotyId = emp.Data.CategotyId;
                        retVal.Add(tempEmp);
                    }
                }

            }


            return View(retVal);
        }


        [HttpPost]
        public ActionResult GetAllSubCategories(int id)
        {
            IList<SubCategory> retVal = new List<SubCategory>();
            IEcommerceManagerFacade employeeFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager);
            IList<OperationResult<ISubCategoriesDTO>> result = employeeFacade.GetAllSubCategories(id);

            if (result.Count() > 0)
            {
                foreach (OperationResult<ISubCategoriesDTO> emp in result)
                {
                    if (emp.IsValid())
                    {

                        SubCategory tempEmp = new SubCategory();
                        tempEmp.CategotyId = emp.Data.CategotyId;
                        tempEmp.SubCategoryName = emp.Data.SubCategoryName;
                        tempEmp.SubCategotyId = emp.Data.SubCategotyId;

                        retVal.Add(tempEmp);
                    }
                }

            }

            return View(retVal);
        }




        [HttpGet]
        public ActionResult GetAllSubCategoriesItems(int id)
        {
            IList<Item> retVal = new List<Item>();
            IEcommerceManagerFacade employeeFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager);
            IList<OperationResult<IItemDTO>> result = employeeFacade.GetAllSubCategoryItems(id);


            if (result.Count() > 0)
            {
                foreach (OperationResult<IItemDTO> emp in result)
                {
                    if (emp.IsValid())
                    {

                        Item tempEmp = new Item();
                        tempEmp.ItemName = emp.Data.ItemName;
                        tempEmp.SubCategotyId = emp.Data.SubCategotyId;
                        tempEmp.ItemId = emp.Data.ItemId;

                        retVal.Add(tempEmp);
                    }
                }

            }
            ActionResult resu = PartialView("GetAllSubCategoriesItems", retVal); ;
            return resu;
        }




        public static int addcategoryId = -1;
        [HttpGet]
        public ActionResult InsertSubCategory(int id)
        {
            IEcommerceManagerFacade employeeFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager);
            OperationResult<String> result = employeeFacade.GetCategoryName(id);
            addcategoryId = id;
            if (result.IsValid())
            {
                ViewBag.Header = result.Data;
            }
            return View();
        }


        [HttpPost]
        public ActionResult InsertSubCategory(SubCategory sub)
        {
            ActionResult retVal = null;

            if (ModelState.IsValid)
            {
                sub.CategotyId = addcategoryId;
                IEcommerceManagerFacade employeeFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager);
                ISubCategoriesDTO subDTO = (ISubCategoriesDTO)DTOFactory.Instance.Create(DTOType.SubCategory);
                subDTO.SubCategoryName = sub.SubCategoryName;
                subDTO.CategotyId = sub.CategotyId;
                OperationResult<int> result = employeeFacade.addSubCategory(subDTO);
                if (result.IsValid())
                {
                    retVal = new JsonResult()
                    {
                        Data = "Sucessfully Added",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else if (result.HasValidationFailed() && result.ValidationResult != null)
                {
                    this.HandleValidationFailure(result);
                    return InsertSubCategory(addcategoryId);
                }
                else
                {
                    OperationResult<int> succes = OperationResult<int>.CreateFailureResult("SubCategory can't be added. Please try after sometime.");
                    succes.IsValid();
                    retVal = new JsonResult()
                    {
                        Data = succes
                    };
                }
            }
            else
            {
                retVal = new JsonResult()
                {
                    Data = "Not Added",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            return retVal;
        }


        protected bool HandleValidationFailure<T>(OperationResult<T> result)
        {
            bool retVal = false;

            if (result.HasValidationFailed() && result.ValidationResult != null)
            {
                retVal = true;

                foreach (EmployeePortalValidationFailure error in result.ValidationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return retVal;
        }


        public static int addItemcategoryId = -1;
        [HttpGet]
        public ActionResult AddItem(int id)
        {
            IEcommerceManagerFacade employeeFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager);
            OperationResult<String> result = employeeFacade.GetSubCategoryName(id);
            addItemcategoryId = id;
            if (result.IsValid())
            {
                ViewBag.Header = result.Data;
            }

            return View();
        }



        [HttpPost]
        public ActionResult AddItem(Item item)
        {
            ActionResult retVal = null;

            if (ModelState.IsValid)
            {
                item.SubCategotyId = addItemcategoryId;
                IEcommerceManagerFacade employeeFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager);
                IItemDTO itemDTO = (IItemDTO)DTOFactory.Instance.Create(DTOType.Item);
                itemDTO.ItemName = item.ItemName;
                itemDTO.SubCategotyId = item.SubCategotyId;
                OperationResult<int> result = employeeFacade.addItem(itemDTO);
                if (result.IsValid())
                {
                    retVal = new JsonResult()
                    {
                        Data = "Sucessfully Added",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else if (result.HasValidationFailed() && result.ValidationResult != null)
                {
                    this.HandleValidationFailure(result);
                    return AddItem(addItemcategoryId);
                }
                else
                {
                    OperationResult<int> succes = OperationResult<int>.CreateFailureResult("Item can't be added. Please try after sometime.");
                    succes.IsValid();
                    retVal = new JsonResult()
                    {
                        Data = succes
                    };
                }
            }
            else
            {
                retVal = new JsonResult()
                {
                    Data = "Not Added",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            return retVal;
        }

        public static int updateSubCategoryId = -1;

        [HttpGet]
        public ActionResult EditSubCategory(int id)
        {
            updateSubCategoryId = id;
            IEcommerceManagerFacade employeeFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager);
            OperationResult<ISubCategoriesDTO> subCategory = employeeFacade.getSubCategory(id);

            subCategory.IsValid();

            SubCategory cat = new SubCategory();
            cat.CategotyId = subCategory.Data.CategotyId;
            cat.SubCategoryName = subCategory.Data.SubCategoryName;
            cat.SubCategotyId = subCategory.Data.SubCategotyId;
            IList<OperationResult<ICategoriesDTO>> CATEGORIES = employeeFacade.GetAllCategories();
            List<SelectListItem> listCategories = new List<SelectListItem>();

            foreach (OperationResult<ICategoriesDTO> emp in CATEGORIES)
            {
                if (emp.IsValid())
                {
                    if (subCategory.Data.CategotyId == emp.Data.CategotyId)
                        listCategories.Add(new SelectListItem { Text = emp.Data.CategoryName, Value = emp.Data.CategotyId + "", Selected = true });
                    else
                        listCategories.Add(new SelectListItem { Text = emp.Data.CategoryName, Value = emp.Data.CategotyId + "" });

                }
            }

            ViewBag.Categories = (IEnumerable<SelectListItem>)listCategories;
            return View(cat);

        }



        [HttpPost]
        public ActionResult EditSubCategory(SubCategory sub)
        {
            JsonResult retVal;
            if (ModelState.IsValid)
            {
                sub.SubCategotyId = updateSubCategoryId;
                IEcommerceManagerFacade employeeFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager);

                ISubCategoriesDTO subCategoryDTO = (ISubCategoriesDTO)DTOFactory.Instance.Create(DTOType.SubCategory);
                subCategoryDTO.SubCategotyId = sub.SubCategotyId;
                subCategoryDTO.SubCategoryName = sub.SubCategoryName;
                subCategoryDTO.CategotyId = sub.CategotyId;
                OperationResult<bool> result = employeeFacade.EditSubCategory(subCategoryDTO);

                if (result.IsValid())
                {
                    retVal = new JsonResult()
                    {
                        Data = "Sucessfully Updated",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else if (result.HasValidationFailed() && result.ValidationResult != null)
                {
                    this.HandleValidationFailure(result);
                    return EditSubCategory(updateSubCategoryId);
                }
                else
                {
                    OperationResult<int> succes = OperationResult<int>.CreateFailureResult("SubCategory can't be Edited. Please try after sometime.");
                    succes.IsValid();
                    retVal = new JsonResult()
                    {
                        Data = succes
                    };
                }
            }
            else
            {
                retVal = new JsonResult()
                {
                    Data = "Not Updated",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            return retVal;

        }



        public static int deleteSubCategory = -1;

        [HttpGet]
        public ActionResult DeleteSubCategory(int id)
        {
            IEcommerceManagerFacade employeeFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager);

            OperationResult<ISubCategoriesDTO> subCategoryDTO = employeeFacade.getSubCategory(id);
            deleteSubCategory = id;
            subCategoryDTO.IsValid();
            SubCategory category = new SubCategory();
            category.CategotyId = deleteSubCategory;
            category.SubCategoryName = subCategoryDTO.Data.SubCategoryName;
            category.SubCategotyId = subCategoryDTO.Data.SubCategotyId;
            return View(category);
        }



        [HttpPost]
        public ActionResult DeleteSubCategory()
        {
            IEcommerceManagerFacade employeeFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager);

            OperationResult<bool> result = employeeFacade.deleteSubCategory(deleteSubCategory);
            JsonResult retVal;
            if (result.IsValid())
            {
                retVal = new JsonResult()
                {
                    Data = "Sucessfully Deleted",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                retVal = new JsonResult()
                {
                    Data = "Not Deleted",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            return retVal;

        }




        public static int updateItemId = -1;

        [HttpGet]
        public ActionResult EditItem(int id)
        {
            updateItemId = id;
            IEcommerceManagerFacade employeeFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager);
            OperationResult<IItemDTO> itemDTO = employeeFacade.getItem(id);
            itemDTO.IsValid();
            OperationResult<ISubCategoriesDTO> subCategoryDTO = employeeFacade.getSubCategory(itemDTO.Data.SubCategotyId);
            subCategoryDTO.IsValid();

            Item item = new Item();
            item.SubCategotyId = itemDTO.Data.SubCategotyId;
            item.ItemName = itemDTO.Data.ItemName;
            item.ItemId = itemDTO.Data.ItemId;
            List<SelectListItem> tempList = new List<SelectListItem>();
            tempList.Add(new SelectListItem { Text = subCategoryDTO.Data.SubCategoryName, Value = subCategoryDTO.Data.SubCategotyId + "", Selected = true });
            ViewBag.subcategory = (IEnumerable<SelectListItem>)(tempList);
            IList<OperationResult<ICategoriesDTO>> CATEGORIES = employeeFacade.GetAllCategories();
            List<SelectListItem> listCategories = new List<SelectListItem>();

            foreach (OperationResult<ICategoriesDTO> emp in CATEGORIES)
            {
                if (emp.IsValid())
                {
                    if (subCategoryDTO.Data.CategotyId == emp.Data.CategotyId)
                        listCategories.Add(new SelectListItem { Text = emp.Data.CategoryName, Value = emp.Data.CategotyId + "", Selected = true });
                    else
                        listCategories.Add(new SelectListItem { Text = emp.Data.CategoryName, Value = emp.Data.CategotyId + "" });

                }
            }

            ViewBag.Categories = (IEnumerable<SelectListItem>)listCategories;
            return View(item);

        }



        [HttpPost]
        public ActionResult EditItem(Item item)
        {
            item.ItemId = updateItemId;
            IEcommerceManagerFacade employeeFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager);

            IItemDTO itemDTO = (IItemDTO)DTOFactory.Instance.Create(DTOType.Item);
            itemDTO.ItemId = item.ItemId;
            itemDTO.ItemName = item.ItemName;
            itemDTO.SubCategotyId = item.SubCategotyId;

            OperationResult<bool> result = employeeFacade.EditItem(itemDTO);
            JsonResult retVal;
            if (result.IsValid())
            {
                retVal = new JsonResult()
                {
                    Data = "Sucessfully Updated",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                retVal = new JsonResult()
                {
                    Data = "Not Updated",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            return retVal;

        }



        public ActionResult GetSubCategoryDropDownList(int id)
        {
            IEcommerceManagerFacade employeeFacade = (IEcommerceManagerFacade)FacadeFactory.Instance.Create(FacadeType.EcommerceManager);
            IList<OperationResult<ISubCategoriesDTO>> result = employeeFacade.GetAllSubCategories(id);
            List<SelectListItem> listCategories = new List<SelectListItem>();

            foreach (OperationResult<ISubCategoriesDTO> emp in result)
            {
                if (emp.IsValid())
                {
                    listCategories.Add(new SelectListItem { Text = emp.Data.SubCategoryName, Value = emp.Data.SubCategotyId + "" });

                }
            }
            return new JsonResult()
                {
                    Data = listCategories,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
        }







    }
}
