using LENA.FormApp.DataAccess.Contexts;
using LENA.FormApp.DataAccess.Interfaces;
using LENA.FormApp.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.DataAccess.Repositories
{
    public  class GenericRepository<T> : IGenericRepositort<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private DbSet<T> dbset;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            dbset = _context.Set<T>();
        }
        public void Create(T entity)
        {
            
            dbset.Add(entity);

        }
        public async Task<T?> FindAsync(object id)
        {
           return await dbset.FindAsync(id);
        }
        public async Task<List<T>> GetAllAsync(bool asNoTracking = false)
        {
            return  asNoTracking ?
                        await dbset.AsNoTracking().ToListAsync()  
                            : await dbset.ToListAsync();

        }
        public async Task<T?> GetbyFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {

            return asNoTracking ?
                     await dbset.AsNoTracking().Where(filter).FirstOrDefaultAsync() :
                    await dbset.Where(filter).FirstOrDefaultAsync();

        }
        public IQueryable<T> GetQueryable()
        {
          return dbset.AsQueryable();
        }
        public void Remove(T entity)
        {
             dbset.Remove(entity);

        }
        public void Update(T entity, T unchanged)
        {
            dbset.Entry(unchanged).CurrentValues.SetValues(entity);
          
        }
    }
}
