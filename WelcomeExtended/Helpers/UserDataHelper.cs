using System;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    internal static class UserDataHelper
    {
        public static bool ValidateCredentials(this UserData userData, string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Name and password cannot be null or empty.");
            }

            if (userData.ValidateUser(name, password))
            {
                Console.WriteLine("Credentials are valid!");
                return true;
            }
            else
            {
                Console.WriteLine("Credentials are invalid!");
                return false;
            }
        }

        public static User GetUser(this UserData userData ,string name, string password)
        {
            return userData.GetUser(name, password);
        } 
    }
}
