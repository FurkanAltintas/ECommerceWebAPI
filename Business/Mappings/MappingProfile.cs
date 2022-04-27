using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.UserDtos;

namespace Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDetailDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserAddDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<UserDto, UserUpdateDto>().ReverseMap();

            // TSource, TDestination
        }
    }
}
