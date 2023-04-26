using FluentValidation;
using LENA.FormApp.Dtos.DummyDto;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.Business.ValidationRules.DumyValidation
{
    public class DummyUpdateDtoValidation:AbstractValidator<DummyUpdatedto>
    {
        public DummyUpdateDtoValidation()
        {
            
        }
    }
}
