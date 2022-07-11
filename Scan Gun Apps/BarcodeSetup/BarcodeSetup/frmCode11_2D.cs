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
    public partial class frmCode11_2D : Form
    {
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE11 cfgCode11;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmCode11_2D()
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
            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE11;

            cfgCode11.bEnabled = checkBox1.Checked;
            cfgCode11.bTwoCheckDigits = checkBox2.Checked;
            cfgCode11.nMinLength = (short)numericUpDown1.Value;
            cfgCode11.nMaxLength = (short)numericUpDown2.Value;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode11));
            Marshal.StructureToPtr(cfgCode11, SymConfig.pConfigData, false);

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
            cfgCode11 = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE11();

            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE11;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode11));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgCode11 = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE11)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE11));
            checkBox1.Checked = cfgCode11.bEnabled;
            checkBox2.Checked = cfgCode11.bTwoCheckDigits;
            

            numericUpDown1.Value = cfgCode11.nMinLength;
            numericUpDown2.Value = cfgCode11.nMaxLength;

            SetLength(1, 80);

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