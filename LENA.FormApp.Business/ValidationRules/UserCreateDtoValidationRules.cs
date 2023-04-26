using FluentValidation;
using LENA.FormApp.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
