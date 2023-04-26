using LENA.FormApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LENA.FormApp.DataAccess.Configurations
{
    public class FormDetailConfiguration : IEntityTypeConfiguration<FormDetail>
    {
        public void Configure(EntityTypeBuilder<FormDetail> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            //relations
            builder.HasOne(x => x.Form).WithMany(x => x.FormDetails).HasForeignKey(x => x.FormId);


        }
    }
}
