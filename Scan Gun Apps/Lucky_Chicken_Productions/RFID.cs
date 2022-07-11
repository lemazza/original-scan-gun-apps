using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NRfidApi;
using System.Runtime.InteropServices;
using System.Collections;
using System.Net;
using System.IO;

namespace Lucky_Chicken_Productions
{
    public partial class RFID : Form
    {
        List<string> Tags;
        RfidApi rfid;
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
        private void Play_Sound(string fileName)
        {
            PlaySound(fileName, IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC));
        }
        private void Play_Sound_NOSTOP(string fileName)
        {
            PlaySound(fileName, IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC | PlaySoundFlags.SND_NOSTOP));
        }
        #endregion

        int[] KeyValues = { 0xD3, // "SCAN" key
                            0xD2, // Gun trigger
                            0xEF, // "F7" key
                            0xF0  // "F8" key
                          };

        public RFID()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.WindowState = FormWindowState.Maximized;
            cbReads.SelectedIndex = 0;
            Tags = new List<string>();
            rfid = new RfidApi();
            btnClear.Enabled = false;
            btnSubmit.Enabled = false;
            // RFID reader module to apply power to. 
            rfid.PowerOn();

            // RFID reader module for communication with the port is open.
            if (rfid.Open() == RFID_RESULT.RFID_RESULT_SUCCESS)
            {
                //===============================================================================
                //  RFID reader tag data read by the application at the end to register 
                // callback fuction is called.
                rfid.SetCallback(new RfidCallbackProc(CallbackProc));
            }
            else
            {
                //  RFID reader module to an authorized power is removed.
                rfid.PowerOff();
                MessageBox.Show("RFID Open Failed");

              //  this.Close();
            }
        }        
        // trigger KeyDown
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Array.IndexOf(KeyValues, e.KeyValue) > -1)
            {
                if (btnScan.Text.Equals("Scan"))
                    btnScan_Click(null, null);                    
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (Array.IndexOf(KeyValues, e.KeyValue) > -1)
            {
                if (btnScan.Text.Equals("Stop"))
                    btnScan_Click(null, null);
            }
            base.OnKeyUp(e);
        }

        // Callback function registered by the application,
        public void CallbackProc(RFIDCALLBACKDATA CallbackData)
        {
            string Msg = new string(new char[512]);

            // Data GetResult function and read the values separated by a CallbackType Reply to the reporting process.
            rfid.GetResult(Msg, CallbackData.CallbackType, CallbackData.wParam, CallbackData.lParam);
            Msg = Msg.Substring(0, Msg.IndexOf("\0"));

            UnitProc(Msg, CallbackData.CallbackType);
        }

        // Units
        private void UnitProc(string Msg, RFID_CALLBACK_TYPE Type)
        {
            // Memory modules of the Data from the tags and read through it runs so Callback delegate.
            if (Type == RFID_CALLBACK_TYPE.RFIDCALLBACKTYPE_DATA)
            {
                if (!Tags.Contains(Msg))
                {
                    units.Items.Add(ProductHelper.GetProductName(Msg).Trim());
                    units.Items.Add("   " + Msg);                    
                    Tags.Add(Msg.Trim());
                    lblNumOfItems.Text = Tags.Count.ToString();
                    btnClear.Enabled = true;
                    btnSubmit.Enabled = true;                    
                }

                Play_Sound_NOSTOP(@"\Windows\Success.wav");
            }
            // Run from the command module to receive the results of running Callback delegate.
            else if (Type == RFID_CALLBACK_TYPE.RFIDCALLBACKTYPE_REPLY)
            {
                if (Msg.Equals("OK") || Msg.Equals("Multi Read Stop") || Msg.Equals(""))
                {
                    btnScan.Text = "Scan";
                }
                else
                {
                    MessageBox.Show(Msg);
                    btnScan.Text = "Scan";
                }
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {            
            RFID_READ_TYPE ReadType;

            if (btnScan.Text.Equals("Scan"))
            {
                btnScan.Text = "Stop";
                if (cbReads.SelectedIndex == 0)
                    ReadType = RFID_READ_TYPE.EPC_GEN2_ONE_TAG;
                else
                    ReadType = RFID_READ_TYPE.EPC_GEN2_MULTI_TAG;
                // RFID tag reads from the EPC data.
                rfid.ReadEpc(false, ReadType, String.Empty);
            }
            else
            {
                rfid.Stop();
            }
        }

        private void RFID_Closing(object sender, CancelEventArgs e)
        {
            // RFID reader module, open a port for communication with the close.
            rfid.Close();
            rfid.PowerOff();
        }

        private void RFID_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ProductHelper.SubmitTags(Tags))
            {
                pnSend.Visible = true;
                pnScan.Visible = false;
            }
            else
            {
                pnScan.Visible = false;
                pnError.Visible = true;
            }            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Tags.Clear();
            units.Items.Clear();
            btnClear.Enabled = false;
            btnSubmit.Enabled = false;
            lblNumOfItems.Text = "0";
        }

        private void btnTryAgain_Click(object sender, EventArgs e)
        {
            pnError.Visible = false;
            pnScan.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}