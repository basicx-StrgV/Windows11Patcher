//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/                 //
//--------------------------------------------------//
using System;

namespace Windows11Patcher.HelperClasses
{
    public static class InputHandler
    {
        public static bool GetBoolInput(string promtMessage)
        {
            ConsoleLogger.Log($"{promtMessage} [Y]es/[N]o", LogType.Question);
            string input = Console.ReadLine().Trim().ToUpper();
            switch (input)
            {
                case "YES":
                    return true;
                case "Y":
                    return true;
                case "NO":
                    return false;
                case "N":
                    return false;
                default:
                    ConsoleLogger.Log("Ivalid input!", LogType.Error);
                    return GetBoolInput(promtMessage);
            }
        }
    }
}
