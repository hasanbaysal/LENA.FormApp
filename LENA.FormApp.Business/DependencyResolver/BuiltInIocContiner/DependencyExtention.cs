using LENA.FormApp.Business.Interfaces;
using LENA.FormApp.Business.Managers;
using LENA.FormApp.Common;
using LENA.FormApp.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.Business.DependencyResolver.BuiltInIocContiner
{
    public static class DependencyExtention
    {
        public static void AddBusinessDependencies(this IServiceCollection services, Action<ConnectionStringInformation> info)
        {
            var con = new ConnectionStringInformation();
            info(con);

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(con.ConnectionString);
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddScoped<IUserService, UserManager>();

        }

    }
}
