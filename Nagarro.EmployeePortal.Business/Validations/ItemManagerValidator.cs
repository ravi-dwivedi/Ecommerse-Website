using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Business
{
    class ItemManagerValidator : AbstractValidator<IItemDTO>
    {
        public ItemManagerValidator()
        {
            RuleFor(item => item.ItemName)
                            .NotEmpty()
                            .WithMessage("Item name is required")
                            .Must((item, ItemName) => { return isItemNameUnique(ItemName, item.SubCategotyId); })
                            .WithMessage("Item name must be unique");
            /*
            RuleFor(item => item.Description)
                            .NotEmpty()
                            .WithMessage("Description is required");

            RuleFor(item => item.Price)
                            .NotEmpty()
                            .WithMessage("Price is required")
                            .GreaterThanOrEqualTo(1)
                            .WithMessage("Price can't be less than 1");
            */

            RuleFor(item => item.SubCategotyId)
                           .NotEmpty()
                           .WithMessage("SubCategotyId is required")
                           .Must(isSubCategoryIdExist)
                           .WithMessage("SubCategoryId does't exist");

        }

        private bool isItemNameUnique(String itemName, int subCategoryId)
        {
            IEcommerceManagerDAC itemManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
            return itemManagerDAC.isItemNameUnique(itemName, subCategoryId);
        }

        private bool isSubCategoryIdExist(int subCategotyId)
        {
            IEcommerceManagerDAC subCategoryManagerDAC = (IEcommerceManagerDAC)DACFactory.Instance.Create(DACType.EcommerceManagerDAC);
            return subCategoryManagerDAC.isSubCategoryIdExist(subCategotyId);
        }
    }
}