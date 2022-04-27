using Entities.Dtos.UserDtos;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IUserApiService
    {
        Task<List<UserDetailDto>> GetListAsync();
    }
}
