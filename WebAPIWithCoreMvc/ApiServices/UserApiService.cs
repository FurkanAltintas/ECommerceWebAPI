using Core.Utilities.Security.Responses;
using Entities.Dtos.UserDtos;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class UserApiService : IUserApiService
    {
        private readonly HttpClient _httpClient;

        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserDetailDto>> GetListAsync()
        {
            var response = await _httpClient.GetAsync("Users");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseSuccess = await response.Content.ReadFromJsonAsync<ApiDataResponse<IEnumerable<UserDetailDto>>>();
            return responseSuccess.Data.ToList();
        }
    }
}
