using LENA.FormApp.Entities.Base;

namespace LENA.FormApp.Entities
{
    public class Form:BaseEntity
    {
        public Form()
        {
            FormDetails = new();

        }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }


        public List<FormDetail> FormDetails { get; set; }

    }
}
