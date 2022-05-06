//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/                 //
//--------------------------------------------------//
using System;
using Microsoft.Win32;
using Windows11Patcher.HelperClasses;

namespace Windows11Patcher.Actions
{
    public class ContextMenuPatchAction : IAction
    {
        public bool AutoRun { get; set; }

        private readonly RegistryKey regRoot = Registry.CurrentUser;
        private readonly string regPrimaryKey = "SOFTWARE\\CLASSES\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}";
        private readonly string regSeconderyKey = "SOFTWARE\\CLASSES\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32";
        private readonly string regValueName = "";
        private readonly string regValue = "";

        public void Run()
        {
            ConsoleLogger.Log("Checking context menu patch status.", LogType.Info);
            if (CheckIfPatched())
            {
                ConsoleLogger.Log("Context menu is already patched.", LogType.Warning);
                RemovePatch();
                return;
            }
            ConsoleLogger.Log("Context menu is not patched.", LogType.Info);

            AddPatch();
        }

        private void AddPatch()
        {
            //Only pach the context menu if the action is on auto run or the user wants to patch it.
            if (!AutoRun && !InputHandler.GetBoolInput("Patch the context menu?"))
            {
                return;
            }

            try
            {
                ConsoleLogger.Log("Patching the context menu.", LogType.Info);
                regRoot.CreateSubKey(regSeconderyKey)
                    .SetValue(regValueName, regValue);
                ConsoleLogger.Log("Context menu patch successfull.", LogType.Success);
            }
            catch (Exception)
            {
                ConsoleLogger.Log("Failed to patch the context menu.", LogType.Error);
            }
        }

        private void RemovePatch()
        {
            //Only remove the pach if the action is not on auto run or the user wants to remove it.
            if (AutoRun || !InputHandler.GetBoolInput("Remove the context menu patch?"))
            {
                return;
            }

            try
            {
                ConsoleLogger.Log("Removing the context menu patch.", LogType.Info);
                regRoot.DeleteSubKeyTree(regPrimaryKey);
                ConsoleLogger.Log("Context menu patch removed successfull.", LogType.Success);
            }
            catch (Exception)
            {
                ConsoleLogger.Log("Failed to remove the context menu patch.", LogType.Error);
            }
        }

        /// <summary>
        /// Checks if the system is already patched.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the system is already patched and <see langword="false"/> if not.
        /// </returns>
        private bool CheckIfPatched()
        {
            if (regRoot.OpenSubKey(regPrimaryKey) == null)
            {
                return false;
            }

            if (regRoot.OpenSubKey(regSeconderyKey) == null)
            {
                return false;
            }

            if (regRoot.OpenSubKey(regSeconderyKey).GetValue(regValueName) == null)
            {
                return false;
            }

            if (regRoot.OpenSubKey(regSeconderyKey).GetValue(regValueName).ToString() != regValue)
            {
                return false;
            }

            return true;
        }
    }
}
