using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NBarcodeApi;

namespace Barcode_Demo_WM
{
    public partial class Form1 : Form
    {
        BarcodeApi barcode = null;

        #region  ########## Play_Sound ##########
        [DllImport("coredll.dll")]
        private static extern int PlaySound(string szSound, IntPtr hModule, int flags);

        private enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0,         // play synchronously (default)
            SND_ASYNC = 0x1,        // play asynchronously
            SND_NODEFAULT = 0x2,    // silence (!default) if sound not found
            SND_MEMORY = 0x4,       // pszSound points to a memory file
            SND_LOOP = 0x8,         // loop the sound until next sndPlaySound
            SND_NOSTOP = 0x10,      // don't stop any currently playing sound
            SND_NOWAIT = 0x2000,    // don't wait if the driver is busy
            SND_ALIAS = 0x10000,    // name is a registry alias
            SND_ALIAS_ID = 0x110000,// alias is a predefined ID
            SND_FILENAME = 0x20000, // name is file name
            SND_RESOURCE = 0x40004, // name is resource name or atom
        };
        public void Play_Sound(string fileName)
        {
            PlaySound(fileName, IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC));
        }
        public void Play_Sound_NOSTOP(string fileName)
        {
            PlaySound(fileName, IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC | PlaySoundFlags.SND_NOSTOP));
        }
        #endregion

        int[] KeyValues = { 0xD3, // "SCAN" key
                            0xD2, // Gun trigger
                            0xEF, // "F7" key
                            0xF0  // "F8" key
                          };

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Text = "BarcodeDemoWM";

            barcode = new BarcodeApi();
            BARCODE_RESULT result = barcode.Open();
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                MessageBox.Show(result.ToString());
                Application.Exit();
            }

            barcode.SetCallback(new BarcodeApi.BARCODECALLBACK(CallbackProc));
        }

        private void Form1_Closed(object sender, EventArgs e)
        {
            if (barcode != null)
            {
                barcode.Stop();
                barcode.Close();
                barcode = null;
            }
        }

        void CallbackProc()
        {
            string Value = new string(new char[512]);
            string SymName = new string(new char[512]);
            string SymType = new string(new char[2]);

            if (barcode.GetBarcodeData(ref Value, ref SymName, ref SymType) == BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {

                Value = Value.Substring(0, Value.IndexOf(Char.MinValue));
                SymName = SymName.Substring(0, SymName.IndexOf(Char.MinValue));
                SymType = SymType.Substring(0, SymType.IndexOf(Char.MinValue));

                Play_Sound(@"\Windows\success.wav");
                ListViewItem item = new ListViewItem(Convert.ToString(listView1.Items.Count + 1));
                item.SubItems.Add(Value);
                item.SubItems.Add(SymName);
                //item.SubItems.Add(SymType);
                listView1.Items.Add(item);
                listView1.EnsureVisible(listView1.Items.Count - 1);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Array.IndexOf(KeyValues, e.KeyValue) > -1)
            {
                if (barcode != null)
                    barcode.Start();
            }           

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (Array.IndexOf(KeyValues, e.KeyValue) > -1)
            {
                if (barcode != null)
                    barcode.Stop();
            }

            base.OnKeyUp(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (barcode == null)
                return;

            barcode.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (barcode == null)
                return;

            barcode.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        
    }
}