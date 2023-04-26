using AutoMapper;
using LENA.FormApp.Dtos.FormDtos;
using LENA.FormApp.Entities;

namespace LENA.FormApp.Business.Mappings.AutoMapper
{
    public class FormProfile : Profile
    {
        public FormProfile()
        {
            CreateMap<Form, FormCreateDto>().ReverseMap();
            CreateMap<Form, FormListDto>().ReverseMap();
        }

    }
}
