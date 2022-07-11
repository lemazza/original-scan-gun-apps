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
    public partial class frmUPCA : Form
    {
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_UPCA cfgUPCA;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmUPCA()
        {
            InitializeComponent();
            this.Text = "UPC-A Setup";

            LoadConfig();
        }

        private void SaveConfig()
        {
            SymConfig = new NBarcodeApi.SYMBOL_CONFIG();
            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_UPCA;

            cfgUPCA.bEnabled = checkBox1.Checked;
            cfgUPCA.bXmitCheckDigit = checkBox2.Checked;
            cfgUPCA.bXmitNumSys = checkBox3.Checked;
            cfgUPCA.bAddenda2Digit = checkBox4.Checked;
            cfgUPCA.bAddenda5Digit = checkBox5.Checked;
            cfgUPCA.bAddendaReq = checkBox6.Checked;
            cfgUPCA.bAddendaSeparator = checkBox7.Checked;
            

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgUPCA));
            Marshal.StructureToPtr(cfgUPCA, SymConfig.pConfigData, false);

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
            cfgUPCA = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_UPCA();

            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_UPCA;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgUPCA));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgUPCA = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_UPCA)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_UPCA));
            checkBox1.Checked = cfgUPCA.bEnabled;
            checkBox2.Checked = cfgUPCA.bXmitCheckDigit;
            checkBox3.Checked = cfgUPCA.bXmitNumSys;
            checkBox4.Checked = cfgUPCA.bAddenda2Digit;
            checkBox5.Checked = cfgUPCA.bAddenda5Digit;
            checkBox6.Checked = cfgUPCA.bAddendaReq;
            checkBox7.Checked = cfgUPCA.bAddendaSeparator;

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