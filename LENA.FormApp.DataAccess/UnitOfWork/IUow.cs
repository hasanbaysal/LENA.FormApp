using LENA.FormApp.DataAccess.Interfaces;
using LENA.FormApp.DataAccess.Repositories;
using LENA.FormApp.Entities;
using LENA.FormApp.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.DataAccess.UnitOfWork
{
    public interface IUow
    {
        public IFormRepository  FormRepository { get;  }
        public IFormDetailRepository  FormDetailRepository { get;  }
        public IUserRepository UserRepository { get; }

        public IGenericRepositort<T> GetGenericRepository<T>() where T: BaseEntity;
        public Task SaveChangeAsync();
       

    }

}
