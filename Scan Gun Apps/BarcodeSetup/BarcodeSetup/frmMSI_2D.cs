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
    public partial class frmMSI_2D : Form
    {
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MSI cfgMSI;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmMSI_2D()
        {
            InitializeComponent();
            this.Text = "MSI Setup";

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
            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MSI;

            cfgMSI.bEnabled = checkBox1.Checked;
            cfgMSI.bXmitCheckChar = checkBox2.Checked;
            cfgMSI.nMinLength = (short)numericUpDown1.Value;
            cfgMSI.nMaxLength = (short)numericUpDown2.Value;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgMSI));
            Marshal.StructureToPtr(cfgMSI, SymConfig.pConfigData, false);

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
            cfgMSI = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MSI();

            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MSI;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgMSI));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgMSI = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MSI)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MSI));
            checkBox1.Checked = cfgMSI.bEnabled;
            checkBox2.Checked = cfgMSI.bXmitCheckChar;


            numericUpDown1.Value = cfgMSI.nMinLength;
            numericUpDown2.Value = cfgMSI.nMaxLength;

            SetLength(4, 48);

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