
namespace ToDoAppNTier.Common.ResponseObjects
{
    // generic response class
    public class Response<T>: Response, IResponse<T>
    {
        public T Data { get; set; }

        // DI. Three ctors
        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }

        public Response(ResponseType responseType, string message) : base(responseType, message)
        {
            
        }

        public Response(ResponseType responseType, T data, List<CustomValidationError> errors) : base(responseType)
        {
            Data = data;
            ValidationErrors = errors;
        }

        // returns ValidationError list
        public List<CustomValidationError> ValidationErrors { get; set; }
    }
}
