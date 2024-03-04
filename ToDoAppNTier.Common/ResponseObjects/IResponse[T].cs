namespace ToDoAppNTier.Common.ResponseObjects
{
    // interface for generic response class
    public interface IResponse<T>: IResponse
    {
        T Data { get; set; }

        List<CustomValidationError> ValidationErrors { get; set; }
    }
}
