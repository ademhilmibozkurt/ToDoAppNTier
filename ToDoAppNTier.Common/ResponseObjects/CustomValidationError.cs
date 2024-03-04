
namespace ToDoAppNTier.Common.ResponseObjects
{
    // check given property is valid or not
    // this class is a base for error messages and alerts
    public class CustomValidationError
    {
        public string ErrorMessage { get; set; }
        public string PropertyName { get; set; }
    }
}
