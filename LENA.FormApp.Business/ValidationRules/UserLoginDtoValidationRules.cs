using FluentValidation;
using LENA.FormApp.Dtos.UserDtos;

namespace LENA.FormApp.Business.ValidationRules
{
    public class UserLoginDtoValidationRules : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidationRules()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("{PropertyName} boş olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} boş olamaz");
        }
    }
}
