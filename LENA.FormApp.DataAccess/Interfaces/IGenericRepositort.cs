using LENA.FormApp.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.DataAccess.Interfaces
{
    public interface IGenericRepositort<T>:IBaseRepository where T:BaseEntity
    {
        Task<List<T>> GetAllAsync(bool asNoTracking = false);
        Task<T?> FindAsync(object id);
        Task<T?> GetbyFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        IQueryable<T> GetQueryable();
        void Remove(T entity);
        void Create(T entity);
        void Update(T entity, T unchanged);

    }
}
