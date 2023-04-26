using LENA.FormApp.DataAccess.Contexts;
using LENA.FormApp.DataAccess.Interfaces;
using LENA.FormApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.DataAccess.Repositories
{
    public class FormDetailRepository : GenericRepository<FormDetail>, IFormDetailRepository
    {
        public FormDetailRepository(AppDbContext context) : base(context)
        {
        }
    }
}
