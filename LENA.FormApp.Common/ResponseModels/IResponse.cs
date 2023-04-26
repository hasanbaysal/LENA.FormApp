using LENA.FormApp.Common.Enums;

namespace LENA.FormApp.Common.ResponseModels
{
    public interface IResponse
    {
        string Message { get; set; }
        ResponseType ResponseType { get; set; }
    }


}
