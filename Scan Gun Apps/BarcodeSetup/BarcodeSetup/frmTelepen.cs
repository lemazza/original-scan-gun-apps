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
    public partial class frmTelepen : Form
    {
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_TELEPEN cfgTelepen;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmTelepen(int idx)
        {
            InitializeComponent();
            NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD SYMBOL_2D = (NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD)idx;
            this.Text = String.Format("{0} Setup", (string)frmMain.ht2DSymbolName[SYMBOL_2D]);

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
            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_TELEPEN;

            cfgTelepen.bEnabled = checkBox1.Checked;
            cfgTelepen.bOldStyle = checkBox2.Checked;
            cfgTelepen.nMinLength = (short)numericUpDown1.Value;
            cfgTelepen.nMaxLength = (short)numericUpDown2.Value;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgTelepen));
            Marshal.StructureToPtr(cfgTelepen, SymConfig.pConfigData, false);

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
            cfgTelepen = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_TELEPEN();

            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_TELEPEN;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgTelepen));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgTelepen = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_TELEPEN)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_TELEPEN));
            checkBox1.Checked = cfgTelepen.bEnabled;
            checkBox2.Checked = cfgTelepen.bOldStyle;


            numericUpDown1.Value = cfgTelepen.nMinLength;
            numericUpDown2.Value = cfgTelepen.nMaxLength;

            SetLength(1, 60);

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