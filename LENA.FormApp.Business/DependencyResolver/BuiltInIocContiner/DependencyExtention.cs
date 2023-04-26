using FluentValidation;
using LENA.FormApp.Business.Interfaces;
using LENA.FormApp.Business.Managers;
using LENA.FormApp.Business.ValidationRules;
using LENA.FormApp.Business.ValidationRules.DumyValidation;
using LENA.FormApp.Common;
using LENA.FormApp.DataAccess.Contexts;
using LENA.FormApp.DataAccess.UnitOfWork;
using LENA.FormApp.Dtos.DummyDto;
using LENA.FormApp.Dtos.FormDtos;
using LENA.FormApp.Dtos.UserDtos;
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
            services.AddScoped<IUow, Uow>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());



            services.AddTransient<IValidator<DummyUpdatedto>, DummyUpdateDtoValidation>();
            services.AddTransient<IValidator<DummyCrceateDto>, DummyCreateDtoValidator>();


            services.AddTransient<IValidator<UserCreateDto>, UserCreateDtoValidationRules>();
            services.AddTransient<IValidator<FormCreateDto>, FromCreateDtoValidationRules>();

      


            

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IFormService, FormManager>();

        }

    }
}
