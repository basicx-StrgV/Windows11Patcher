//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/                 //
//--------------------------------------------------//
using System;

namespace Windows11Patcher.HelperClasses
{
    public static class ConsoleLogger
    {
        /// <summary>
        /// Writes the given message to the console.
        /// </summary>
        /// <param name="message">
        /// The message to write to the console.
        /// </param>
        /// <param name="type">
        /// The type of the log message.
        /// </param>
        public static void Log(string message, LogType type)
        {
            SetConsoleColor(type);
            Console.WriteLine(
                $"{GetPrefix(type)} {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Sets the text color of the console for the given type.
        /// </summary>
        /// <param name="type"></param>
        private static void SetConsoleColor(LogType type)
        {
            switch (type)
            {
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogType.Question:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case LogType.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    return;
            }
        }

        /// <summary>
        /// Get the prefix for the log message.
        /// </summary>
        /// <param name="type">
        /// The type of the log message.
        /// </param>
        /// <returns>
        /// The prefix of the log message.
        /// </returns>
        private static string GetPrefix(LogType type)
        {
            switch (type)
            {
                case LogType.Info:
                    return "[-]";
                case LogType.Warning:
                    return "[*]";
                case LogType.Error:
                    return "[!]";
                case LogType.Question:
                    return "[?]";
                case LogType.Success:
                    return "[+]";
                default:
                    return string.Empty;
            }
        }
    }
}
