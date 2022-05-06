using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

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
            if (CheckIfPatched())
            {
                return;
            }

            regRoot.CreateSubKey(regSeconderyKey)
                .SetValue(regValueName, regValue);
        }

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
