using System;
using System.Collections.Generic;
using System.Text;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        private int id;
        public string Names { get; set; }
        private string _password;
        public string Email { get; set; }
        public UserRolesEnum Role {  get; set; }
        private DateTime expires;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value; 
            }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }

        }

        public DateTime Expires
        {
            get { return expires; }
            set { expires = value; }
        }

        private string Encrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return password;
            {
                return password;
            }
            char[] chars = password.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(chars[i] + 3); 
            }
            return new string(chars);
        }

        private string Decrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return password;

            char[] chars = password.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(chars[i] - 3);
            }
            return new string(chars);
        }
    }
}
