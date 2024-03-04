
namespace ToDoAppNTier.Common.ResponseObjects
{
    public class Response : IResponse
    {
        // thid class base for validation error returns
        
        // DI. Two different constructor
        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }

        public Response(ResponseType responseType, string message)
        {
            Message = message;
            ResponseType = responseType;
        }

        public string Message { get; set; }
        public ResponseType ResponseType {  get; set; }
        
    }
        // response is queryble. enum response types
        public enum ResponseType
        {
            Success,
            ValidationError,
            NotFound
        }
}
