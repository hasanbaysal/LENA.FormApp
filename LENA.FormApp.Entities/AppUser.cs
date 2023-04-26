using LENA.FormApp.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LENA.FormApp.Entities
{
    public class AppUser : BaseEntity
    {

        public AppUser()
        {
            Forms = new();

        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Form> Forms {get; set;}


        
    }
}
