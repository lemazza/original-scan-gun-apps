using System;

using System.Collections.Generic;
using System.Windows.Forms;

namespace BarcodeSetup
{
    static class Program
    {
        [MTAThread]
        static void Main()
        {
            IntPtr hWnd = UnmanagedAPI.FindWindow(UnmanagedAPI.NETCF_WND_CLASS_NAME, frmMain.WindowsName);
            if (hWnd != IntPtr.Zero)
            {
                UnmanagedAPI.ShowWindow(hWnd, 5);
                UnmanagedAPI.SetForegroundWindow(hWnd);
                System.Diagnostics.Debug.WriteLine("Already executed");
                return;
            }

            Application.Run(new frmMain());
        }
    }
}