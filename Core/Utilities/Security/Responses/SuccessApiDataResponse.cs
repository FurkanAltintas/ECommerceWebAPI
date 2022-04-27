namespace Core.Utilities.Security.Responses
{
    public class SuccessApiDataResponse<T> : ApiDataResponse<T>
    {
        public SuccessApiDataResponse(T data) : base()
        {
            Data = data;
        }

        public SuccessApiDataResponse(T data, string message) : base(success: true, message)
        {
            Data = data;
        }
    }
}