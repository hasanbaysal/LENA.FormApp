using AutoMapper;
using LENA.FormApp.Dtos.UserDtos;
using LENA.FormApp.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.Business.Mappings.AutoMapper
{
    public class AppUserProfile:Profile 
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, UserCreateDto>().ReverseMap();
            CreateMap<AppUser, UserListDto>().ReverseMap();
        }
    }
}
