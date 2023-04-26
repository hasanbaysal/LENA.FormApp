using LENA.FormApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LENA.FormApp.DataAccess.Configurations
{
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);


            //relations

            builder.HasOne(x => x.AppUser).WithMany(x => x.Forms).HasForeignKey(x => x.AppUserId);


        }

    }
}
