using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NBarcodeApi;

namespace BarcodeSetup
{
    public partial class frmCode11_1D : Form
    {
        private NBarcodeApi.N1DSymbols.CONIFG_1D_CODE11 cfgCode11;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmCode11_1D()
        {
            InitializeComponent();
            this.Text = "Code 11 Setup";

            SetLength(0, int.MaxValue);
            LoadConfig();
        }

        private void SetLength(int nMin, int nMax)
        {
            numericUpDown1.Minimum = nMin;
            numericUpDown1.Maximum = nMax;

            numericUpDown2.Minimum = nMin;
            numericUpDown2.Maximum = nMax;
        }

        private void SaveConfig()
        {
            SymConfig = new NBarcodeApi.SYMBOL_CONFIG();
            SymConfig.Symbol = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE11;

            cfgCode11.bEnabled = checkBox1.Checked;
            cfgCode11.bCheckDigitVerify = checkBox2.Checked;
            cfgCode11.bXmitCheckDigit = checkBox3.Checked;

            cfgCode11.nMinLength = (short)numericUpDown1.Value;
            cfgCode11.nMaxLength = (short)numericUpDown2.Value;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode11));
            Marshal.StructureToPtr(cfgCode11, SymConfig.pConfigData, false);

            Cursor.Current = Cursors.WaitCursor;
            BARCODE_RESULT result = frmMain.barcode.SetSymbologyConfig(SymConfig);
            Cursor.Current = Cursors.Default;
            Marshal.FreeHGlobal(SymConfig.pConfigData);
            SymConfig.pConfigData = IntPtr.Zero;
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                MessageBox.Show("SetSymbologyConfig: " + result.ToString());
            }
            else
                UnmanagedAPI.PlaySound(@"\Windows\Success.wav");
        }

        private void LoadConfig()
        {
            SymConfig = new SYMBOL_CONFIG();
            cfgCode11 = new NBarcodeApi.N1DSymbols.CONIFG_1D_CODE11();

            SymConfig.Symbol = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE11;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode11));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgCode11 = (NBarcodeApi.N1DSymbols.CONIFG_1D_CODE11)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N1DSymbols.CONIFG_1D_CODE11));

            checkBox1.Checked = cfgCode11.bEnabled;
            checkBox2.Checked = cfgCode11.bCheckDigitVerify;
            checkBox3.Checked = cfgCode11.bXmitCheckDigit;

            numericUpDown1.Value = cfgCode11.nMinLength;
            numericUpDown2.Value = cfgCode11.nMaxLength;

            SetLength(2, 55);

            Marshal.FreeHGlobal(SymConfig.pConfigData);
            SymConfig.pConfigData = IntPtr.Zero;

            UnmanagedAPI.PlaySound(@"\Windows\Success.wav");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }
    }
}