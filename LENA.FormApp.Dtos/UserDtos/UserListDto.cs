using LENA.FormApp.Dtos.BaseDtos;

namespace LENA.FormApp.Dtos.UserDtos
{
    public class UserListDto:IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
