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
    public partial class frmCode39_1D : Form
    {
        private NBarcodeApi.N1DSymbols.CONFIG_1D_CODE39 cfgCode39;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmCode39_1D()
        {
            InitializeComponent();
            this.Text = "Code 39 Setup";

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
            SymConfig.Symbol = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE39;

            cfgCode39.bEnabled = checkBox1.Checked;
            cfgCode39.bConvertCode39ToCode32 = checkBox2.Checked;
            cfgCode39.bCode32Prefix = checkBox3.Checked;
            cfgCode39.bCheckDigitVerify = checkBox4.Checked;
            cfgCode39.bXmitCheckDigit = checkBox5.Checked;
            cfgCode39.bFullAscii = checkBox6.Checked;
            cfgCode39.bEnableTriopticCode39 = checkBox7.Checked;

            cfgCode39.nMinLength = (short)numericUpDown1.Value;
            cfgCode39.nMaxLength = (short)numericUpDown2.Value;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode39));
            Marshal.StructureToPtr(cfgCode39, SymConfig.pConfigData, false);

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
            cfgCode39 = new NBarcodeApi.N1DSymbols.CONFIG_1D_CODE39();

            SymConfig.Symbol = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE39;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode39));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgCode39 = (NBarcodeApi.N1DSymbols.CONFIG_1D_CODE39)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N1DSymbols.CONFIG_1D_CODE39));

            checkBox1.Checked = cfgCode39.bEnabled;
            checkBox2.Checked = cfgCode39.bConvertCode39ToCode32;
            checkBox3.Checked = cfgCode39.bCode32Prefix;
            checkBox4.Checked = cfgCode39.bCheckDigitVerify;
            checkBox5.Checked = cfgCode39.bXmitCheckDigit;
            checkBox6.Checked = cfgCode39.bFullAscii;
            checkBox7.Checked = cfgCode39.bEnableTriopticCode39;

            numericUpDown1.Value = cfgCode39.nMinLength;
            numericUpDown2.Value = cfgCode39.nMaxLength;

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