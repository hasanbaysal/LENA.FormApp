using AutoMapper;
using LENA.FormApp.Dtos.FormDetailDtos;
using LENA.FormApp.Entities;

namespace LENA.FormApp.Business.Mappings.AutoMapper
{
    public class FormDetailProfile : Profile
    {
        public FormDetailProfile()
        {
            CreateMap<FormDetailCreateDto, FormDetail>().ReverseMap();
        }    

    }
}
