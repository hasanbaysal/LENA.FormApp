using LENA.FormApp.Common.ResponseModels;
using LENA.FormApp.Dtos.DummyDto;
using LENA.FormApp.Dtos.UserDtos;
using LENA.FormApp.Entities;

namespace LENA.FormApp.Business.Interfaces
{
    public interface IUserService : IService<UserCreateDto, DummyUpdatedto, UserListDto, AppUser>
    {
        Task<IResponse<UserListDto>> CheckUserPassword(UserLoginDto userListDto);
    }
}
