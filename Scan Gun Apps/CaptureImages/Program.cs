using System;

using System.Collections.Generic;
using System.Windows.Forms;

namespace CaptureImages
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