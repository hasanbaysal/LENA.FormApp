using LENA.FormApp.Common.ResponseModels;
using LENA.FormApp.Dtos.DummyDto;
using LENA.FormApp.Dtos.FormDtos;
using LENA.FormApp.Dtos.UserDtos;
using LENA.FormApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.Business.Interfaces
{
    public interface IFormService: IService<FormCreateDto, DummyUpdatedto, FormListDto , Form>
    {
        Task<IResponse<FormCreateDto>> AddNewForm(FormCreateDto dto);
    }
}
