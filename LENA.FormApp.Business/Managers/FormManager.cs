using AutoMapper;
using FluentValidation;
using LENA.FormApp.Business.Interfaces;
using LENA.FormApp.Common.ResponseModels;
using LENA.FormApp.DataAccess.UnitOfWork;
using LENA.FormApp.Dtos.DummyDto;
using LENA.FormApp.Dtos.FormDtos;
using LENA.FormApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.Business.Managers
{
    public class FormManager : GenericManager<FormCreateDto, DummyUpdatedto, FormListDto, Form>, IFormService
    {
        protected FormManager
            (
            IMapper mapper,
            IValidator<FormCreateDto> createDtoValidator,
            IValidator<DummyUpdatedto> updateDtoValidator,
            IUow uow)
            : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }

        public Task<IResponse<FormCreateDto>> AddNewForm(FormCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
