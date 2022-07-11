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
    public partial class frmCodabar_2D : Form
    {
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODABAR cfgCodabar;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmCodabar_2D()
        {
            InitializeComponent();
            this.Text = "Codabar Setup";

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
            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODABAR;

            cfgCodabar.bEnabled = checkBox1.Checked;
            cfgCodabar.bSSXmit = checkBox2.Checked;
            if (radioButton1.Checked)
            {
                cfgCodabar.bCheckCharOn = false;
                cfgCodabar.bXmitCheckChar = false;
            }
            else
            {
                if (radioButton3.Checked)
                    cfgCodabar.bXmitCheckChar = true;
                else
                    cfgCodabar.bXmitCheckChar = false;

                cfgCodabar.bCheckCharOn = true;
            }
            cfgCodabar.nMinLength = (short)numericUpDown1.Value;
            cfgCodabar.nMaxLength = (short)numericUpDown2.Value;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCodabar));
            Marshal.StructureToPtr(cfgCodabar, SymConfig.pConfigData, false);

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
            cfgCodabar = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODABAR();

            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODABAR;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCodabar));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgCodabar = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODABAR)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODABAR));
            checkBox1.Checked = cfgCodabar.bEnabled;
            checkBox2.Checked = cfgCodabar.bSSXmit;
            if (cfgCodabar.bCheckCharOn)
            {
                if (cfgCodabar.bXmitCheckChar)
                    radioButton3.Checked = true;
                else
                    radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }

            numericUpDown1.Value = cfgCodabar.nMinLength;
            numericUpDown2.Value = cfgCodabar.nMaxLength;

            SetLength(2, 60);

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