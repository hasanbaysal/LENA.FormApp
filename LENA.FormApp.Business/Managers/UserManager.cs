using AutoMapper;
using FluentValidation;
using LENA.FormApp.Business.Extentions;
using LENA.FormApp.Business.Interfaces;
using LENA.FormApp.Common.Enums;
using LENA.FormApp.Common.ResponseModels;
using LENA.FormApp.DataAccess.UnitOfWork;
using LENA.FormApp.Dtos.DummyDto;
using LENA.FormApp.Dtos.FormDetailDtos;
using LENA.FormApp.Dtos.FormDtos;
using LENA.FormApp.Dtos.UserDtos;
using LENA.FormApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.Business.Managers
{
    public class UserManager : GenericManager<UserCreateDto, DummyUpdatedto, UserListDto, AppUser>, IUserService
    {

     

        public UserManager(
                IMapper mapper,
                IValidator<UserCreateDto> createDtoValidator,
                IValidator<DummyUpdatedto> updateDtoValidator, IUow uow,
                IValidator<FormCreateDto> formCreateDtovalidator)
                :base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
           
        }

        public async Task<IResponse<FormCreateDto>> AddNewForm(FormCreateDto dto)
        {
            var validationRules = _formCreateDtovalidator.Validate(dto);
            if (!validationRules.IsValid)
            {
                return new Response<FormCreateDto>(dto, validationRules.CustomErrorList());
            }

            var mappedData = _mapper.Map<Form>(dto);

            uow.GetGenericRepository<Form>().Create(mappedData);
            await uow.SaveChangeAsync();

            return new Response<FormCreateDto>(ResponseType.Success,"");

        }
    }


}
