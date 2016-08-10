using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Nagarro.EmployeePortal.Shared;
using FluentValidation;
using Nagarro.EmployeePortal.Business;

namespace Nagarro.EmployeePortal.Validations
{
    public static class ValidationExtensions
    {
        public static EmployeePortalValidationResult ToValidationResult(this ValidationResult result)
        {
            IList<EmployeePortalValidationFailure> errors = new List<EmployeePortalValidationFailure>();

            foreach (ValidationFailure failure in result.Errors)
            {
                errors.Add(failure.ToValidationFailure());
            }

            return new EmployeePortalValidationResult(errors);
        }

        public static EmployeePortalValidationFailure ToValidationFailure(this ValidationFailure failure)
        {
            return new EmployeePortalValidationFailure(failure.PropertyName, failure.ErrorMessage, failure.AttemptedValue);
        }

        
    }
}
