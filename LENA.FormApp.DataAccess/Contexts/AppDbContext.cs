using LENA.FormApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace LENA.FormApp.DataAccess.Contexts
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormDetail> FormDetails { get; set; }

    }
}
