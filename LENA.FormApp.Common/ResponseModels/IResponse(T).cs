namespace LENA.FormApp.Common.ResponseModels
{
    public interface IResponse<T>:IResponse
    {
        T? Data { get; set; }
        List<CustomValidationError>? Errors { get; set; }
    }
}
