using FluentValidation;
using LENA.FormApp.Dtos.FormDetailDtos;

namespace LENA.FormApp.Business.ValidationRules
{
    public class FormDetailCretoDtoValidationRules : AbstractValidator<FormDetailCreateDto>
    {
        public FormDetailCretoDtoValidationRules()
        {
            RuleFor(x => x.InputType).NotEmpty().WithMessage("{PropertyName} bu olamaz");
            RuleFor(x => x.InputType).InclusiveBetween(1, 3).WithMessage("{PropertyName} geçersiz değer");
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} bu alan boş olamaz");
            RuleFor(x => x.FormId).NotEmpty().WithMessage("{PropertyName} bu alan boş olamaz");

        }
    }

}
