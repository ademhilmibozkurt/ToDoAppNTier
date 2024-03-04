
using FluentValidation.Results;
using ToDoAppNTier.Common.ResponseObjects;

namespace ToDoAppNTier.Business.Extensions
{
    // show validation errors like our want type 
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomVE(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new()
                {
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage
                });
            }
            return errors;
        }
    }
}
