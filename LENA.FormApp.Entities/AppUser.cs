﻿using LENA.FormApp.Entities.Base;

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
        public List<Form> Forms { get; set; }



    }
}
