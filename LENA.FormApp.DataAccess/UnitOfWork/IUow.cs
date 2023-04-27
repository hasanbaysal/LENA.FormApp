using LENA.FormApp.DataAccess.Interfaces;
using LENA.FormApp.Entities.Base;

namespace LENA.FormApp.DataAccess.UnitOfWork
{
    public interface IUow
    {
        public IFormRepository FormRepository { get; }
        public IFormDetailRepository FormDetailRepository { get; }
        public IUserRepository UserRepository { get; }

        public IGenericRepositort<T> GetGenericRepository<T>() where T : BaseEntity;
        public Task SaveChangeAsync();


    }

}
