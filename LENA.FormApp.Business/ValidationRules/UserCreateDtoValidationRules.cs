using FluentValidation;
using LENA.FormApp.Dtos.UserDtos;

namespace LENA.FormApp.Business.ValidationRules
{
    public class UserCreateDtoValidationRules : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidationRules()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("{PropertyName} boş olamaz").MaximumLength(30);

            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} boş olamaz").MaximumLength(30);

        }
    }
}
