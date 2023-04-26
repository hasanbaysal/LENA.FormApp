using FluentValidation;
using LENA.FormApp.Dtos.FormDtos;

namespace LENA.FormApp.Business.ValidationRules
{
    public class FromCreateDtoValidationRules : AbstractValidator<FormCreateDto>
    {
        public FromCreateDtoValidationRules()
        {
            RuleFor(x => x.AppUserId).NotEmpty().WithMessage("{PropertyName} bu alan boş olamaz");
            RuleFor(x => x.CreatedDate).NotEmpty().WithMessage("{PropertyName} bu alan boş olamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("{PropertyName} bu alan boş olamaz").MaximumLength(200); 
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} bu alan boş olamaz").MaximumLength(60);

            RuleFor(x => x.FormDetails).NotNull().ForEach(c =>
            {
                c.SetValidator(new FormDetailCretoDtoValidationRules()).WithMessage("Geçersiz Bir Giriş");
               
            });

        }
    }
}
