using LENA.FormApp.DataAccess.Contexts;
using LENA.FormApp.DataAccess.Interfaces;
using LENA.FormApp.DataAccess.Repositories;
using LENA.FormApp.Entities.Base;

namespace LENA.FormApp.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly AppDbContext _context;
        private IBaseRepository[] arr;

        public Uow(AppDbContext context)
        {
            _context = context;
            FormRepository = new FormRepository(_context);
            FormDetailRepository = new FormDetailRepository(_context);
            UserRepository = new UserRepository(_context);

            arr = new IBaseRepository[]{ FormRepository, UserRepository, FormDetailRepository };
        }

        public IFormRepository FormRepository { get; private set; }
        public IFormDetailRepository FormDetailRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public IGenericRepositort<T> GetGenericRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>( _context);
        }

      
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
