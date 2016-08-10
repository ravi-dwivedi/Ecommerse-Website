using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Business
{
    public class CategoryManagerValidator : AbstractValidator<ICategoriesDTO>
    {
        public CategoryManagerValidator()
        {
            RuleSet("addCategory", () =>
            {
                RuleFor(category => category.CategoryName)
                            .NotEmpty()
                            .WithMessage("Category name is required")
                            .Must(isCategoryNameUnique)
                            .WithMessage("Category name must be unique");
            });

            RuleSet("removeCategory", () =>
            {
                RuleFor(category => category.CategotyId)
                               .NotEmpty()
                               .WithMessage("CategotyId is required")
                               .Must(isChildExist)
                               .WithMessage("Category can't be removed. Remove all child first");
            });

        }

        private bool isCategoryNameUnique(String categoryName)
        {
            IEcommerceManagerDAC categoryManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
            return categoryManagerDAC.isCategoryNameUnique(categoryName);
        }

        private bool isChildExist(int categotyId)
        {
            IEcommerceManagerDAC categoryManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
            bool hasChold = categoryManagerDAC.isChildExist(categotyId);
            if (hasChold)
                return false;
            else
                return true;
        }
    }
}
