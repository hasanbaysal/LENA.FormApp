using LENA.FormApp.Dtos.BaseDtos;

namespace LENA.FormApp.Dtos.FormDetailDtos
{
    public class FormDetailCreateDto : IDto
    {
        public string Name { get; set; }
        public int InputType { get; set; }
        public bool Required { get; set; }
        public int FormId { get; set; }
    }
}
