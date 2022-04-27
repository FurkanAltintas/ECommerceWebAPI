namespace Core.Utilities.Security.Responses
{
    public class ErrorApiDataResponse<T> : ApiDataResponse<T>
    {
        public ErrorApiDataResponse(T data) : base(success: false)
        {
            Data = data;
        }

        public ErrorApiDataResponse(T data, string message) : base(success: false, message)
        {
            Data = data;
        }
    }
}