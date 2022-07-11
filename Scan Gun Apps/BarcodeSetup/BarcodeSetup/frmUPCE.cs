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
    public partial class frmUPCE : Form
    {
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_UPCE cfgUPCE;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;
        private NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD SYMBOL_2D;
        private bool isE0Enabled;
        private bool isE1Enabled;

        public frmUPCE(int idx)
        {
            InitializeComponent();
            SYMBOL_2D = (NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD)idx;
            this.Text = String.Format("{0} Setup", frmMain.ht2DSymbolName[SYMBOL_2D]);

            LoadConfig();
        }

        private void SaveConfig()
        {
            SymConfig = new NBarcodeApi.SYMBOL_CONFIG();
            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_UPCE0;

            if (SYMBOL_2D == NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_UPCE0)
            {
                cfgUPCE.bE0Enabled = checkBox1.Checked;
                cfgUPCE.bE1Enabled = isE1Enabled;
            }
            else
            {
                cfgUPCE.bE0Enabled = isE0Enabled;
                cfgUPCE.bE1Enabled = checkBox1.Checked;
            }
            cfgUPCE.bXmitCheckDigit = checkBox2.Checked;
            cfgUPCE.bExpandVersionE = checkBox3.Checked;
            cfgUPCE.bAddenda2Digit = checkBox4.Checked;
            cfgUPCE.bAddenda5Digit = checkBox5.Checked;
            cfgUPCE.bAddendaReq = checkBox6.Checked;
            cfgUPCE.bAddendaSeparator = checkBox7.Checked;
            cfgUPCE.bXmitNumSys = checkBox8.Checked;


            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgUPCE));
            Marshal.StructureToPtr(cfgUPCE, SymConfig.pConfigData, false);

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
            cfgUPCE = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_UPCE();

            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_UPCE0;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgUPCE));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgUPCE = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_UPCE)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_UPCE));

            isE0Enabled = cfgUPCE.bE0Enabled;
            isE1Enabled = cfgUPCE.bE1Enabled;

            if (SYMBOL_2D == NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_UPCE0)
                checkBox1.Checked = cfgUPCE.bE0Enabled;
            else
                checkBox1.Checked = cfgUPCE.bE1Enabled;
            checkBox2.Checked = cfgUPCE.bXmitCheckDigit;
            checkBox3.Checked = cfgUPCE.bExpandVersionE;
            checkBox4.Checked = cfgUPCE.bAddenda2Digit;
            checkBox5.Checked = cfgUPCE.bAddenda5Digit;
            checkBox6.Checked = cfgUPCE.bAddendaReq;
            checkBox7.Checked = cfgUPCE.bAddendaSeparator;
            checkBox8.Checked = cfgUPCE.bXmitNumSys;

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