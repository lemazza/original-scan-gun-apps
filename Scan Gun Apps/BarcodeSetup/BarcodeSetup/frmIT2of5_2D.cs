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
    public partial class frmIT2of5_2D : Form
    {
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_INT25 cfgInt25;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmIT2of5_2D()
        {
            InitializeComponent();
            this.Text = "Interleaved 2 of 5 Setup";

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
            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_INT25;

            cfgInt25.bEnabled = checkBox1.Checked;
            cfgInt25.bCheckDigitOn = checkBox2.Checked;
            cfgInt25.bXmitCheckDigit = checkBox3.Checked;
            cfgInt25.nMinLength = (short)numericUpDown1.Value;
            cfgInt25.nMaxLength = (short)numericUpDown2.Value;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgInt25));
            Marshal.StructureToPtr(cfgInt25, SymConfig.pConfigData, false);

            BARCODE_RESULT result = frmMain.barcode.SetSymbologyConfig(SymConfig);
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
            cfgInt25 = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_INT25();

            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_INT25;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgInt25));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgInt25 = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_INT25)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_INT25));
            checkBox1.Checked = cfgInt25.bEnabled;
            checkBox2.Checked = cfgInt25.bCheckDigitOn;
            checkBox3.Checked = cfgInt25.bXmitCheckDigit;


            numericUpDown1.Value = cfgInt25.nMinLength;
            numericUpDown2.Value = cfgInt25.nMaxLength;

            SetLength(2, 80);

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