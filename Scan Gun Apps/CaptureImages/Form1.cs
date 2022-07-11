using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NBarcodeApi;

namespace CaptureImages
{
    public partial class Form1 : Form
    {
        #region  ########## Play_Sound ##########
        [DllImport("coredll.dll", EntryPoint = "PlaySound", SetLastError = true)]
        private static extern int _PlaySound(string szSound, IntPtr hModule, int flags);

        [DllImport("coredll.dll", EntryPoint = "PlaySound", SetLastError = true)]
        private static extern int _PlaySound(byte[] szSound, IntPtr hModule, int flags);

        private enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0,     // play synchronously (default)
            SND_ASYNC = 0x1,    // play asynchronously
            SND_NODEFAULT = 0x2,    // silence (!default) if sound not found
            SND_MEMORY = 0x4,       // pszSound points to a memory file
            SND_LOOP = 0x8,     // loop the sound until next sndPlaySound
            SND_NOSTOP = 0x10,      // don't stop any currently playing sound
            SND_NOWAIT = 0x2000,    // don't wait if the driver is busy
            SND_ALIAS = 0x10000,    // name is a registry alias
            SND_ALIAS_ID = 0x110000,// alias is a predefined ID
            SND_FILENAME = 0x20000, // name is file name
            SND_RESOURCE = 0x40004, // name is resource name or atom
        };

        public static void PlaySound(string fileName)
        {
            _PlaySound(fileName, IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC | PlaySoundFlags.SND_NOSTOP));
        }
        public static void PlaySound(byte[] szSound)
        {
            _PlaySound(szSound, IntPtr.Zero, (int)(PlaySoundFlags.SND_ASYNC | PlaySoundFlags.SND_NOSTOP | PlaySoundFlags.SND_MEMORY));
        }
        #endregion

        bool bDoPreview = false;
        BarcodeApi barcode = null;

        public Form1()
        {
            InitializeComponent();

            barcode = new BarcodeApi();

            Cursor.Current = Cursors.WaitCursor;
            BARCODE_RESULT result = barcode.Open();
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                MessageBox.Show("Open : " + result.ToString());
                Application.Exit();
            }

            result = barcode.InitCapture();
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                MessageBox.Show("InitCapture : " + result.ToString());
                barcode.Close();
                Application.Exit();
            }

            result = barcode.SetPreviewHwnd(label1.Handle);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                MessageBox.Show("SetPreviewHWnd : " + result.ToString());
                barcode.DeinitCapture();
                barcode.Close();
                Application.Exit();
            }
            Cursor.Current = Cursors.Default;
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (bDoPreview)
            {
                barcode.StopPreview();
            }

            barcode.DeinitCapture();
            barcode.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bDoPreview)
                return;

            BARCODE_RESULT result = barcode.StartPreview();
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                MessageBox.Show("StartPreview : " + result.ToString());
            else
                bDoPreview = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!bDoPreview)
                return;

            BARCODE_RESULT result = barcode.StopPreview();
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                MessageBox.Show("StopPreview : " + result.ToString());
            else
            {
                bDoPreview = false;
                label1.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BARCODE_RESULT result = BARCODE_RESULT.BARCODE_RESULT_FAILURE;

            BARCODECAPTUREPARAMS para = new BARCODECAPTUREPARAMS();
            para.ImgFormat = (byte)IMAGE_FORMAT.IMG_FORMAT_JPEG;
            para.ImgSize = (byte)IMAGE_SIZE.CAP_IMG_VGA;
            para.sFilePath = @"\Flash Disk\Test.jpg";

            result = barcode.DoCapture(ref para);
            if (result == BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                PlaySound(@"\Windows\Success.wav");
                if (bDoPreview)
                    barcode.StartPreview();
            }
            else
            {
                PlaySound(@"\Windows\Fail.wav");
                MessageBox.Show("DoCapture : " + result.ToString());
            }
        }
    }
}