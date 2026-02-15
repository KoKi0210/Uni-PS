using System;
using System.IO;

namespace WelcomeExtended.Loggers
{
    internal class ErrorFileLogger
    {
        private readonly string _fullPath;

        public ErrorFileLogger(string fileName)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string othersFolderPath = Path.Combine(currentDirectory, "..", "..", "..", "Others");
            _fullPath = Path.Combine(othersFolderPath, fileName);
        }

        public void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_fullPath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to log message to file: {ex.Message}");
            }
        }
    }
}
