namespace ToDoAppNTier.Common.ResponseObjects
{
    // base interface for response design architecture
    public interface IResponse
    {
        // response message
        string Message{ get; set; }
        
        // ResponseType is an enum that holds response type exp. Success, ValidationError, NotFound
        ResponseType ResponseType { get; set; }
    }
}