using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SysSvc_Demo
{
    static class Program
    {
        [MTAThread]
        static void Main()
        {
            Application.Run(new FrmSysSvc());
        }
    }
}