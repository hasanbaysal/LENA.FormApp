using AutoMapper;
using FluentValidation;
using LENA.FormApp.Business.Extentions;
using LENA.FormApp.Business.Interfaces;
using LENA.FormApp.Common.Enums;
using LENA.FormApp.Common.ResponseModels;
using LENA.FormApp.DataAccess.UnitOfWork;
using LENA.FormApp.Dtos.DummyDto;
using LENA.FormApp.Dtos.FormDtos;
using LENA.FormApp.Entities;

namespace LENA.FormApp.Business.Managers
{
    public class FormManager :
            GenericManager<FormCreateDto, DummyUpdatedto, FormListDto, Form>, IFormService
    {
        private readonly IMapper _mapper;
        private readonly IValidator<FormCreateDto> _createDtoValidator;
        private readonly IUow _uow;
        public FormManager
        (
            IMapper mapper,
            IValidator<FormCreateDto> createDtoValidator,
            IValidator<DummyUpdatedto> updateDtoValidator,
            IUow uow)
            : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _uow = uow;
        }

        public async Task<IResponse<FormCreateDto>> AddNewForm(FormCreateDto dto)
        {
            var validationRules = _createDtoValidator.Validate(dto);
            if (!validationRules.IsValid)
            {
                return new Response<FormCreateDto>(dto, validationRules.CustomErrorList());
            }

            var mappedData = _mapper.Map<Form>(dto);

            _uow.GetGenericRepository<Form>().Create(mappedData);

            await _uow.SaveChangeAsync();

            return new Response<FormCreateDto>(ResponseType.Success, "");

        }


    }
}
