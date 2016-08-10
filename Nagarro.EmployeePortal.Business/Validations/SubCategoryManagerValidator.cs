using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Business
{
    class SubCategoryManagerValidator : AbstractValidator<ISubCategoriesDTO>
    {
        public SubCategoryManagerValidator()
        {
            RuleSet("AddSubCategory", () =>
            {
                RuleFor(subCategory => subCategory.SubCategoryName)
                            .NotEmpty()
                            .WithMessage("SubCategoryName name is required")
                            .Must((subCategory, SubCategoryName) => { return isSubCategoryNameUnique(subCategory.CategotyId, SubCategoryName); })
                            .WithMessage("SubCategoryName name must be unique");

                RuleFor(subCategory => subCategory.CategotyId)
                               .NotEmpty()
                               .WithMessage("CategotyId is required")
                               .Must(isCategoryIdExist)
                               .WithMessage("CategoryId does't exist");
            });

            RuleSet("removeSubCategory", () =>
            {
                RuleFor(subCategory => subCategory.SubCategotyId)
                                .NotEmpty()
                                .WithMessage("SubCategotyId is required")
                                .Must(isChildExist)
                                .WithMessage("SubCategory can't be removed. Remove all child first");
            });
        }
        
        private bool isSubCategoryNameUnique(int categotyId, String subCategoryName)
        {
            IEcommerceManagerDAC subCategoryManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
            return subCategoryManagerDAC.isSubCategoryNameUnique(categotyId, subCategoryName);
        }

        private bool isCategoryIdExist(int categotyId)
        {
            IEcommerceManagerDAC categoryManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
            return categoryManagerDAC.isCategoryIdExist(categotyId);
        }

        private bool isChildExist(int subCategotyId)
        {
            IEcommerceManagerDAC subCategoryManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
            bool hasChild = subCategoryManagerDAC.isChildExist(subCategotyId);
            if (hasChild)
                return false;
            else
                return true;
        }


    }
}