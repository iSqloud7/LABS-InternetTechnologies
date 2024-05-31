using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Albums.Models
{
    public class AddUserToRoleModel
    {
        public string email { get; set; }
        public string selectedRole { get; set; }
        public List<string> roles { get; set; } // листа на сите можни улоги
        public AddUserToRoleModel()
        {
            roles = new List<string>(); // иницијализирање на листа улоги, за избегнување null вредности
        }
    }
}