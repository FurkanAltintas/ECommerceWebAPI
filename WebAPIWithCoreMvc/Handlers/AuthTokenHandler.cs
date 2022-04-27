using System.Net;
using System.Net.Http.Headers;
using WebAPIWithCoreMvc.Exceptions;

namespace WebAPIWithCoreMvc.Handlers
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthTokenHandler()
        {

        }

        public AuthTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) // Oturum açmış mı ?
            {
                string token = _httpContextAccessor.HttpContext.Session.GetString("token"); // token değerini almış oluyoruz
                // Not: Login olurken Session üzerinde token değerini setliyorduk ve get ile alıyoruz.

                if (!request.Headers.Contains("Authorization"))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                //if (request.Headers.Contains("Authorization") && !String.IsNullOrEmpty(token))
                //{
                //    request.Headers.Add("Authorization", $"Bearer {token}");
                //}

            }
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizeException();
            }

            return response;
        }
    }
}