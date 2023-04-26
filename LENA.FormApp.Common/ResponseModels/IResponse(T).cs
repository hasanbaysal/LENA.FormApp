using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.Common.ResponseModels
{
    public interface IResponse<T>
    {
        T? Data { get; set; }
        List<CustomValidationError>? Errors { get; set; }
    }
}
