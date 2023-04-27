using LENA.FormApp.DataAccess.Contexts;
using LENA.FormApp.DataAccess.Interfaces;
using LENA.FormApp.Entities;

namespace LENA.FormApp.DataAccess.Repositories
{
    public class FormDetailRepository : GenericRepository<FormDetail>, IFormDetailRepository
    {
        public FormDetailRepository(AppDbContext context) : base(context)
        {
        }
    }
}
