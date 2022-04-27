using Core.Utilities.Security.Responses;
using Entities.Dtos.AuthDtos;
using Entities.Dtos.UserDtos;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto);
    }
}