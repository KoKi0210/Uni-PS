using Microsoft.EntityFrameworkCore;
using System;
using DataLayer.Model;
using Welcome.Others;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.ID).ValueGeneratedOnAdd();

           
            modelBuilder.Entity<DatabaseUser>().HasData(
            new DatabaseUser
            {
                ID = 1,
                Names = "John Doe",
                Email = "jdoe@tu-sofia.bg",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            },
            new DatabaseUser
            {
                ID = 2,
                Names = "John Doe Professor",
                Email = "jdoe@tu-sofia.bg",
                Password = "1234",
                Role = UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddYears(4)
            },
            new DatabaseUser
            {
                ID = 3,
                Names = "John Doe Student",
                Email = "jdoe@tu-sofia.bg",
                Password = "1234",
                Role = UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddYears(2)
            },
            new DatabaseUser
            {
                ID = 4,
                Names = "Eternal Admin",
                Email = "jdoe@tu-sofia.bg",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.MaxValue
            }
            );
        }

        public DbSet<DatabaseUser> Users { get; set; }
        public DbSet<DatabaseLog> Logs { get; set; }
    }
}
