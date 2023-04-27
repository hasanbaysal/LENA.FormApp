using LENA.FormApp.Entities.Base;

namespace LENA.FormApp.Entities
{
    public class FormDetail : BaseEntity
    {

        public string Name { get; set; }
        public int InputType { get; set; }
        public bool Required { get; set; }
        public Form Form { get; set; }
        public int FormId { get; set; }


    }
}
