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
    public partial class frmRSS : Form
    {
        private NBarcodeApi.N1DSymbols.CONFIG_1D_RSS cfgRSS;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;


        public frmRSS()
        {
            InitializeComponent();
            this.Text = "RSS Setup";

            LoadConfig();
        }

        private void SaveConfig()
        {
            SymConfig = new NBarcodeApi.SYMBOL_CONFIG();
            SymConfig.Symbol = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_RSS14;

            cfgRSS.bRSS14Enabled = checkBox1.Checked;
            cfgRSS.bRSSLimitedEnabled = checkBox2.Checked;
            cfgRSS.bRSSExpandedEnabled = checkBox3.Checked;
            cfgRSS.bConvertRSSToUPCEAN = checkBox4.Checked;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgRSS));
            Marshal.StructureToPtr(cfgRSS, SymConfig.pConfigData, false);

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
            cfgRSS = new NBarcodeApi.N1DSymbols.CONFIG_1D_RSS();

            SymConfig.Symbol = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_RSS14;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgRSS));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgRSS = (NBarcodeApi.N1DSymbols.CONFIG_1D_RSS)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N1DSymbols.CONFIG_1D_RSS));

            checkBox1.Checked = cfgRSS.bRSS14Enabled;
            checkBox2.Checked = cfgRSS.bRSSLimitedEnabled;
            checkBox3.Checked = cfgRSS.bRSSExpandedEnabled;
            checkBox4.Checked = cfgRSS.bConvertRSSToUPCEAN;

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