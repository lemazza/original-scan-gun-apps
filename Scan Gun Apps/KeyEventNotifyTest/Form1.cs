using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NSysSvcApi;

namespace KeyEventNotifyTest
{
    public partial class Form1 : Form
    {
        SysSvcApi SysService = null;

        public const int WM_KEYUP = 0x0101;
        public const int WM_KEYDOWN = 0x0100;

        public Form1()
        {
            InitializeComponent();

            SysService = new SysSvcApi();
        }

        public void KeyEventCallbackProc(int KeyValue, int KeyState)
        {
            String msg = String.Empty;
            
            if (Environment.OSVersion.Version.Minor == 2)
            {
                // Windows Mobile
                msg = String.Format("Value:0x{0:X},  State:{1}", KeyValue, KeyState == WM_KEYUP ? "Up" : "Down");
            }
            else
            {
                // Windows CE
                Keys key = (Keys)KeyValue;
                msg = String.Format("Value:{0},  State:{1}", key.ToString(), KeyState == WM_KEYUP ? "Up" : "Down");
            }
            
            listBox1.Items.Add(msg);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SYSSVC_RESULT result = SysService.KeyEventNotificationSet(new SysSvcApi.KeyEventNotifyCALLBACK(KeyEventCallbackProc));
            listBox1.Items.Add(result.ToString());
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SYSSVC_RESULT result = SysService.KeyEventNotificationReset();
            listBox1.Items.Add(result.ToString());
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
    }
}