using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Welcome.Others;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Database.DatabaseContext())
            {
                context.Database.EnsureCreated();
                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Names = "user",
                    Password = "password",
                    Email = "email",
                    Expires = DateTime.Now,
                    Role = UserRolesEnum.STUDENT
                });
                context.SaveChanges();
                var users = context.Users.ToList();
            }


            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            using (var context = new Database.DatabaseContext())
            {
                var user = context.Users.Where(u => u.Names == name && u.Password == password).FirstOrDefault();
                if (user != null)
                {
                    Console.WriteLine($"Welcome, {user.Names}!");
                }
                else
                {
                    Console.WriteLine("Invalid credentials.");
                }
            }
        }
    }
}
