using AutoMapper;
using FluentValidation;
using LENA.FormApp.Business.Extentions;
using LENA.FormApp.Business.Interfaces;
using LENA.FormApp.Common.Enums;
using LENA.FormApp.Common.ResponseModels;
using LENA.FormApp.DataAccess.UnitOfWork;
using LENA.FormApp.Dtos.DummyDto;
using LENA.FormApp.Dtos.UserDtos;
using LENA.FormApp.Entities;

namespace LENA.FormApp.Business.Managers
{
    public class UserManager : GenericManager<UserCreateDto, DummyUpdatedto, UserListDto, AppUser>, IUserService
    {


        private readonly IUow _uow;
        private readonly IValidator<UserLoginDto> _userLoginValidator;
        private readonly IValidator<UserCreateDto> _createDtoValidator;
        private readonly IMapper _mapper;
        public UserManager(
                IMapper mapper,
                IValidator<UserCreateDto> createDtoValidator,
                IValidator<DummyUpdatedto> updateDtoValidator,
                IUow uow,
                IValidator<UserLoginDto> userLoginValidator)
                : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _userLoginValidator = userLoginValidator;
            _createDtoValidator = createDtoValidator;
            _mapper = mapper;

        }

        public async Task<Response<UserListDto>> CheckUserPassword(UserLoginDto loignDto)
        {

            var validationResult = _userLoginValidator.Validate(loignDto);

            if (!validationResult.IsValid)
            {
                return new Response<UserListDto>(new UserListDto(), validationResult.CustomErrorList());
            }

            var user = _uow.GetGenericRepository<AppUser>().GetbyFilterAsync(x => x.UserName == loignDto.UserName && x.Password == loignDto.Password);
            if (user == null)
                return new Response<UserListDto>(ResponseType.NotFound, "kullanıcı adı veya şifre hatalı");


            return new Response<UserListDto>(ResponseType.Success, _mapper.Map<UserListDto>(user));
        }

        public override async Task<IResponse<UserCreateDto>> CreateAsync(UserCreateDto dto)
        {

            var validationResult = _createDtoValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                var user = await _uow.UserRepository.GetbyFilterAsync(x => x.UserName == dto.UserName);

                if (user != null)
                {
                    return new Response<UserCreateDto>(ResponseType.Error, "Bu kullanıcı Adı zaten kayıtlı");
                }
            }
            return await base.CreateAsync(dto);
        }
    }


}
