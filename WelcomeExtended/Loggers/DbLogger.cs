using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Model;
using DataLayer.Database;

namespace WelcomeExtended.Loggers
{
    internal class DbLogger
    {
        public static void Log(string message)
        {
            using (var context = new DatabaseContext())
            {
                var logEntry = new DatabaseLog
                {
                    message = message,
                    logDate = DateTime.Now
                };

                context.Logs.Add(logEntry);

                context.SaveChanges();
            }
        }
    }
}
