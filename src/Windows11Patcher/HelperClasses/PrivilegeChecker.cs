//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/                 //
//--------------------------------------------------//
using System;
using System.Security.Principal;

namespace Windows11Patcher.HelperClasses
{
    public static class PrivilegeChecker
    {
        /// <summary>
        /// Checks if the process has admin privileges.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the process hast admin privileges or <see langword="false"/> if not.
        /// </returns>
        public static bool CheckAdminPrivilege()
        {
            try
            {
                using (WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent())
                {
                    return 
                        new WindowsPrincipal(windowsIdentity)
                        .IsInRole(WindowsBuiltInRole.Administrator);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
