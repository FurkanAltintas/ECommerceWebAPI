using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserDtos;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<UserDto> AddAsync(UserAddDto userAddDto)
        {
            var user = await _userDal.AddAsync(new User
            {
                FirstName = userAddDto.FirstName,
                LastName = userAddDto.LastName,
                UserName = userAddDto.UserName,
                Email = userAddDto.Email,
                Password = userAddDto.Password,
                Address = userAddDto.Address,
                CreatedDate = DateTime.Now,
                CreatedUserId = 1,
                UpdatedDate = DateTime.Now,
                UpdatedUserId = 1,
                DateOfBirth = userAddDto.DateOfBirth,
                Gender = userAddDto.Gender
            });

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Gender = user.Gender,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userDal.DeleteAsync(id);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _userDal.GetAsync(u => u.Id == id);
            UserDto userDto = new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender
            };
            return userDto;
        }

        public async Task<IEnumerable<UserDetailDto>> GetListAsync()
        {
            List<UserDetailDto> userDetailDtos = new();
            var response = await _userDal.GetListAsync();
            foreach (var item in response)
            {
                userDetailDtos.Add(new()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    UserName = item.UserName,
                    Email = item.Email,
                    Password = item.Password,
                    Address = item.Address,
                    DateOfBirth = item.DateOfBirth,
                    Gender = item.Gender ? "Erkek" : "Kadın",
                    Id = item.Id
                });
            }
            return userDetailDtos;
        }

        public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var user = await _userDal.UpdateAsync(new()
            {
                Id = userUpdateDto.Id,
                FirstName = userUpdateDto.FirstName,
                LastName =userUpdateDto.LastName,
                Email = userUpdateDto.Email,
                Password = userUpdateDto.Password,
                UserName = userUpdateDto.UserName,
                CreatedUserId = 1,
                CreatedDate = DateTime.Now,
                UpdatedUserId = 1,
                UpdatedDate = DateTime.Now,
                Address = userUpdateDto.Address,
                DateOfBirth = userUpdateDto.DateOfBirth,
                Gender = userUpdateDto.Gender
            });

            return userUpdateDto;
        }
    }
}