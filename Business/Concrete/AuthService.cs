using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Security.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.AuthDtos;
using Entities.Dtos.UserDtos;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(IUserService userService, ITokenService tokenService, IMapper mapper)
        {
            _userService = userService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userService.GetAsync(u => u.UserName == loginDto.UserName && u.Password == loginDto.Password);
            if (user == null)
            {
                return new ErrorApiDataResponse<UserDto>(null, Messages.UserNotFound);
            }
            else
            {
                if (user.Data.TokenExpireDate == null || String.IsNullOrEmpty(user.Data.Token))
                {
                    UpdateToken(user);
                }

                if (user.Data.TokenExpireDate < DateTime.Now)
                {
                    UpdateToken(user);
                }
            }
            return new SuccessApiDataResponse<UserDto>(user.Data, Messages.SystemLoginSuccessful);
        }

        private async Task<ApiDataResponse<UserDto>> UpdateToken(ApiDataResponse<UserDto> user)
        {
            var accessToken = _tokenService.CreateToken(user.Data.Id, user.Data.UserName);
            var userUpdateDto = _mapper.Map<UserUpdateDto>(user.Data);
            userUpdateDto.Token = accessToken.Token;
            userUpdateDto.TokenExpireDate = accessToken.Expiration;
            userUpdateDto.UpdateUserId = user.Data.Id;
            var newUserUpdateDto = await _userService.UpdateAsync(userUpdateDto);
            var userDto = _mapper.Map<UserDto>(userUpdateDto);
            return new SuccessApiDataResponse<UserDto>(userDto, Messages.SystemLoginSuccessful);
        }
    }
}