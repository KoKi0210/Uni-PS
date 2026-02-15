using System;
using System.Collections.Generic;
using System.Text;
using Welcome.Model;

namespace WelcomeExtended.Helpers
{
    internal static class UserHelper
    {
        public static void ToUserString(this User user)
        {
            if (user == null)
            {
                Console.WriteLine("User does not exist!");

            }
            else
            {
                Console.WriteLine("User data: ");
                Console.WriteLine($"ID: {user.ID}");
                Console.WriteLine($"Names: {user.Names}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Role: {user.Role}");
                Console.WriteLine($"Expires: {user.Expires}");
            }
        }
    }
}
