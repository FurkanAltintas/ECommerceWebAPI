using Core.Utilities.Security.Responses;
using Entities.Dtos.AuthDtos;
using Entities.Dtos.UserDtos;

namespace Business.Abstract
{
    public interface IAuthService
    {

        Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto);
    }
}