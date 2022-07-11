using System;

using System.Collections.Generic;
using System.Windows.Forms;

namespace KeyEventNotifyTest
{
    static class Program
    {
        [MTAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }
    }
}