using System;
using System.Collections.Generic;
using System.Text;
using Welcome.Others;

namespace Welcome.Model
{
    internal class User
    {
        public string Names { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRolesEnum Role {  get; set; }
    }
}
