using AutoMapper;
using LENA.FormApp.Dtos.UserDtos;
using LENA.FormApp.Entities;

namespace LENA.FormApp.Business.Mappings.AutoMapper
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, UserCreateDto>().ReverseMap();
            CreateMap<AppUser, UserListDto>().ReverseMap();
        }
    }
}
