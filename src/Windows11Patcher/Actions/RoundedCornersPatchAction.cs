//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/                 //
//--------------------------------------------------//
using System;
using System.Globalization;
using System.IO;
using Windows11Patcher.HelperClasses;

namespace Windows11Patcher.Actions
{
    public class RoundedCornersPatchAction : IAction
    {
        public bool AutoRun { get; set; }

        private readonly string systemDirectory = Environment.SystemDirectory;
        private readonly string file = "uDWM.dll";
        private readonly string backupFile = "uDWM.dll.bak";

        public void Run()
        {
            if (!PrivilegeChecker.CheckAdminPrivilege())
            {
                ConsoleLogger.Log("Please start the program with admin privileges to use the rounded corner patch.", LogType.Warning);
                return;
            }

            PatchDll();
        }

        private void CreateBackupFile()
        {
            if (File.Exists(systemDirectory + Path.DirectorySeparatorChar + backupFile))
            {
                ConsoleLogger.Log($"Backup file '{backupFile}' already exists.", LogType.Warning);
                return;
            }

            try
            {
                ConsoleLogger.Log($"Creating a backup of the '{file}' file.", LogType.Info);
                File.Copy(
                    systemDirectory + Path.DirectorySeparatorChar + file,
                    systemDirectory + Path.DirectorySeparatorChar + backupFile);
            }
            catch (Exception)
            {
                ConsoleLogger.Log("Failed to create backup of the '{file}' file!", LogType.Error);
            }
        }

        private void PatchDll()
        {
            //Only pach the rounded corners if the action is on auto run or the user wants to patch it.
            if (!AutoRun && !InputHandler.GetBoolInput("Patch the rounded corners?"))
            {
                return;
            }

            CreateBackupFile();

            try
            {
                byte[] test = File.ReadAllBytes(systemDirectory + Path.DirectorySeparatorChar + file);
                //test[1] = byte.Parse("12", NumberStyles.HexNumber);
            }
            catch (Exception e)
            {
                ConsoleLogger.Log(e.Message, LogType.Error);
            }
        }
    }
}
