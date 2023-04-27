using FluentValidation;
using LENA.FormApp.Dtos.DummyDto;

namespace LENA.FormApp.Business.ValidationRules.DumyValidation
{
    public class DummyCreateDtoValidator : AbstractValidator<DummyCreateDto>
    {
        public DummyCreateDtoValidator()
        {

        }
    }
}
