using LENA.FormApp.Dtos.BaseDtos;
using LENA.FormApp.Dtos.FormDetailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.Dtos.FormDtos
{
    public class FormCreateDto:IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public int AppUserId { get; set; }

        public List<FormDetailCreateDto> FormDetails { get; set; }

    }

   
}
