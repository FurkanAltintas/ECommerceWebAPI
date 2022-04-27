using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Security.Responses;
using Core.Utilities.Security.Token;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserDtos;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public UserService(IUserDal userDal, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _userDal = userDal;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public async Task<ApiDataResponse<UserDto>> AddAsync(UserAddDto userAddDto)
        {
            var user = _mapper.Map<User>(userAddDto);
            // Todo: CreatedDate ve CreatedUserId düzenlenecek.
            user.CreatedDate = DateTime.Now;
            user.CreatedUserId = 1;
            var userAdd = await _userDal.AddAsync(user);
            var userDto = _mapper.Map<UserDto>(userAdd);
            return new SuccessApiDataResponse<UserDto>(userDto, Messages.Added);
        }

        //public async Task<ApiDataResponse<AccessToken>> Authenticate(UserForLoginDto userForLoginDto)
        //{
        //    var user = await _userDal.GetAsync(u => u.UserName == userForLoginDto.UserName && u.Password == userForLoginDto.Password);
        //    if (user == null) return null;

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);
        //    var tokenDescriptor = new SecurityTokenDescriptor()
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //            new Claim(ClaimTypes.Name, user.UserName),
        //            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7), // 7 gün geçerli olucak
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    AccessToken accessToken = new()
        //    {
        //        Token = tokenHandler.WriteToken(token),
        //        Expiration = (DateTime)tokenDescriptor.Expires,
        //        UserName = user.UserName,
        //        UserId = user.Id
        //    };
        //    return await Task.Run(() => accessToken);
        //}

        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return new SuccessApiDataResponse<bool>(await _userDal.DeleteAsync(id), Messages.Deleted);
        }

        public async Task<ApiDataResponse<UserDto>> GetAsync(Expression<Func<User, bool>> filter)
        {
            var user = await _userDal.GetAsync(filter);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return new SuccessApiDataResponse<UserDto>(userDto, Messages.Listed);
            }
            return new ErrorApiDataResponse<UserDto>(null, Messages.NotListed);
        }

        public async Task<ApiDataResponse<UserDto>> GetByIdAsync(int id)
        {
            var user = await _userDal.GetAsync(u => u.Id == id);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return new SuccessApiDataResponse<UserDto>(userDto, Messages.Listed);
            }
            return new ErrorApiDataResponse<UserDto>(null, Messages.NotListed);
        }

        public async Task<ApiDataResponse<IEnumerable<UserDetailDto>>> GetListAsync(Expression<Func<User, bool>> filter = null)
        {
            if (filter == null)
            {
                var response = await _userDal.GetListAsync();
                var userDetailDtos = _mapper.Map<IEnumerable<UserDetailDto>>(response);
                return new SuccessApiDataResponse<IEnumerable<UserDetailDto>>(userDetailDtos, Messages.Listed);
            }
            else
            {
                var response = await _userDal.GetListAsync(filter);
                var userDetailDtos = _mapper.Map<IEnumerable<UserDetailDto>>(response);
                return new SuccessApiDataResponse<IEnumerable<UserDetailDto>>(userDetailDtos, Messages.Listed);
            }
        }

        public async Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var user = _mapper.Map<User>(userUpdateDto);
            user.UpdatedDate = DateTime.Now;
            user.UpdatedUserId = 1;
            user.Token = userUpdateDto.Token;
            user.TokenExpireDate = userUpdateDto.TokenExpireDate;
            var userUpdate = await _userDal.UpdateAsync(user);
            var resultUpdate = _mapper.Map<UserUpdateDto>(userUpdate);
            return new SuccessApiDataResponse<UserUpdateDto>(resultUpdate, Messages.Updated);
        }
    }
}