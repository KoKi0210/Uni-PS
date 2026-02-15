using System;
using System.Collections.Generic;
using System.Text;

namespace WelcomeExtended.Loggers
{
    internal class SuccesssfulLoginFileLogger
    {
        private readonly string _fullPath;

        public SuccesssfulLoginFileLogger(string fileName)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string othersFolderPath = Path.Combine(currentDirectory, "..", "..", "..", "Others");
            _fullPath = Path.Combine(othersFolderPath, fileName);
        }

        public void Log(string name)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_fullPath, true))
                {
                    writer.WriteLine($"{name} logged: {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to log message to file: {ex.Message}");
            }
        }
    }
}
