namespace Core.Utilities.Security.Responses
{
    public class SuccessApiResponse : ApiResponse
    {
        public SuccessApiResponse() : base(success: true)
        {

        }

        public SuccessApiResponse(string message) : base(success: true, message)
        {

        }
    }
}