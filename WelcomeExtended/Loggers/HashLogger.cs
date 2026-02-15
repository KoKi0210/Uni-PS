using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    internal class HashLogger : ILogger
    {
        private static readonly ConcurrentDictionary<int, string> _logMessages = new ConcurrentDictionary<int, string>();
        private readonly string _name;
        public HashLogger(string name)
        {
            _name = name;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);
            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine("- LOGGER -");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", _name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($" {formatter(state, exception)}");
            Console.WriteLine("- LOGGER -");
            Console.ResetColor();
            _logMessages[eventId.Id] = message;
        }

        public void printLogMessages()
        {
            if (_logMessages.IsEmpty)
            {
                Console.WriteLine("No log messages to display.");
                return;
            }
            Console.WriteLine("Saved log messages:");
            foreach (var kvp in _logMessages)
            {
                Console.WriteLine($"[{kvp.Key}] {kvp.Value}");
            }
        }

        public void printLogMessagesById(EventId id)
        {
            foreach (var kvp in _logMessages)
            {
                if (kvp.Key == id.Id)
                {
                    Console.WriteLine($"[{kvp.Key}] {kvp.Value}");
                    return;
                }
            }
            Console.WriteLine($"No log messages found with EventId: {id.Id}");
        }

        public void DeleteLogMessageById(EventId id)
        {
            if (_logMessages.TryRemove(id.Id, out _))
            {
                Console.WriteLine($"Log message with EventId {id.Id} deleted.");
            }
            else
            {
                Console.WriteLine($"No log message found with EventId: {id.Id}");
            }
        }
    }
}
