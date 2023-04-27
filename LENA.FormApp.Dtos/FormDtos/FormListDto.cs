using LENA.FormApp.Dtos.BaseDtos;
using LENA.FormApp.Dtos.FormDetailDtos;

namespace LENA.FormApp.Dtos.FormDtos
{
    public class FormListDto : IDto
    {
        public int Id { get; set; }
        public List<FormDetailListDto> FormDetails { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
