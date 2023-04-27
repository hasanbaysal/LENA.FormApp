using LENA.FormApp.Common.ResponseModels;
using LENA.FormApp.Dtos.DummyDto;
using LENA.FormApp.Dtos.FormDtos;
using LENA.FormApp.Entities;

namespace LENA.FormApp.Business.Interfaces
{
    public interface IFormService : IService<FormCreateDto, DummyUpdatedto, FormListDto, Form>
    {
        Task<IResponse<FormCreateDto>> AddNewForm(FormCreateDto dto);
    }
}
