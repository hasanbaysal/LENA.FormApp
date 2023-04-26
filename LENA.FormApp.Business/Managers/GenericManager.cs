using AutoMapper;
using FluentValidation;
using LENA.FormApp.Business.Extentions;
using LENA.FormApp.Business.Interfaces;
using LENA.FormApp.Common.Enums;
using LENA.FormApp.Common.ResponseModels;
using LENA.FormApp.DataAccess.Interfaces;
using LENA.FormApp.DataAccess.UnitOfWork;
using LENA.FormApp.Dtos.BaseDtos;
using LENA.FormApp.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.Business.Managers
{
    public  class GenericManager<CreateDto, UpdateDto, ListDto, T> 
        :IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {

        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _UpdateDtoValidator;
        private readonly IUow _uow;
       
        protected GenericManager(IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator, IUow uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _UpdateDtoValidator = updateDtoValidator;
            _uow = uow;

          
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {

            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var converted = _mapper.Map<T>(dto);
                _uow.GetGenericRepository<T>().Create(converted);

                await _uow.SaveChangeAsync();

                return new Response<CreateDto>(ResponseType.Success, dto);
            }

            return new Response<CreateDto>(dto, result.CustomErrorList());

        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var data = await _uow.GetGenericRepository<T>().GetAllAsync();
            var converted = _mapper.Map<List<ListDto>>(data);
            return new Response<List<ListDto>>(ResponseType.Success, converted);
        }

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {

            var data = await _uow.GetGenericRepository<T>().GetbyFilter(x => x.Id == id);

            if (data == null)

                return new Response<IDto>(ResponseType.NotFound, $"{id} id data bulunamadı");

            var mappedData = _mapper.Map<IDto>(data);

            return new Response<IDto>(ResponseType.Success, mappedData);
        }

        public async  Task<IResponse> RemoveAsync(int id)
        {
            var data = await _uow.GetGenericRepository<T>().FindAsync(id);
            if (data == null)

                return new Response(ResponseType.NotFound, $"{id} id data bulunamadı");

            _uow.GetGenericRepository<T>().Remove(data);
            await _uow.SaveChangeAsync();

            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var validation = _UpdateDtoValidator.Validate(dto);
            if (!validation.IsValid)
                return new Response<UpdateDto>(dto, validation.CustomErrorList());

            var data = await _uow.GetGenericRepository<T>().FindAsync(dto.Id);
            if (data == null)
                return new Response<UpdateDto>(ResponseType.NotFound, $"{dto.Id} id data bulunamadı ");


            var mappedData = _mapper.Map<T>(dto);
            _uow.GetGenericRepository<T>().Update(mappedData, data);

            await _uow.SaveChangeAsync();

            return new Response<UpdateDto>(ResponseType.Success, dto);
        }
    }
}
