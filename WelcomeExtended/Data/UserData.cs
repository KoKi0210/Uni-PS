using System;
using System.Collections.Generic;
using System.Text;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data
{
    internal class UserData
    {
        private List<User> _users;
        private static int _nextId;

        public UserData()
        {
            _users = new List<User>();
            _nextId = 0;
        }

        public void addUser(User user)
        {
            _nextId++;
            user.ID = _nextId;
            _users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }

        public bool ValidateUser(string name, string password)
        {
            foreach (var user in _users)
            {
                if (user.Names == name && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateUserLambda(string name, string password)
        {
            return _users.Where(x => x.Names == name && x.Password == password).FirstOrDefault() != null ? true : false;
        }

        public bool ValidateUserLinq(string name, string password)
        {
            var ret = from user in _users
                      where user.Names == name && user.Password == password
                      select user.ID;

            return ret != null ? true : false;
        }

        public User GetUser(string name, string password)
        {
            var userToGet = from user in _users
                      where user.Names == name && user.Password == password
                      select user;

            if (userToGet != null)
            {
                return userToGet.First();
            }
            throw new ArgumentException("User not found!");
        }

        public void setActive(string name, DateTime dateTime)
        {
            var userToSet = from user in _users
                      where user.Names == name
                      select user;
            if (userToSet != null)
            {
                userToSet.First().Expires = dateTime;
                return;
            }
            Console.WriteLine("User not found!");
        }

        public void AsssignUserRole(string name, UserRolesEnum role)
        {
            var userToSet = from user in _users
                      where user.Names == name
                      select user;
            if (userToSet != null)
            {
                userToSet.First().Role = role;
                return;
            }
            Console.WriteLine("User not found!");
        }
    }
}
