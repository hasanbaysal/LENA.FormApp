using LENA.FormApp.Dtos.BaseDtos;

namespace LENA.FormApp.Dtos.UserDtos
{
    public class UserCreateDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
