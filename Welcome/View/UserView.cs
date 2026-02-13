using System;
using System.Collections.Generic;
using System.Text;
using Welcome.ViewModel;

namespace Welcome.View
{
    internal class UserView
    {
        private UserViewModel _userModel;
        public UserView(UserViewModel userModel)
        {
            _userModel = userModel;
        }
        public void Display()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("User: " + _userModel.Name);
            Console.WriteLine("Email: " + _userModel.Email);
            Console.WriteLine("Role: " + _userModel.Role);
        }
    }
}
