using System;

using System.Collections.Generic;
using System.Windows.Forms;

/* 
 * This demonstration requires the most recent firmware installed on the
 * internal RFID module. Handhelds produced after September, 2013 may
 * have the updated RFID firmware, but older units need to first have that
 * firmware update performed.
 */
namespace AlienBlockReadLockTest
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