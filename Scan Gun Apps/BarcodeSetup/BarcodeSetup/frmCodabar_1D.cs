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
    public partial class frmCodabar_1D : Form
    {
        private NBarcodeApi.N1DSymbols.CONFIG_1D_CODABAR cfgCodabar;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmCodabar_1D()
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
            SymConfig.Symbol = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODABAR;

            cfgCodabar.bEnabled = checkBox1.Checked;
            cfgCodabar.bCLSIEditing = checkBox2.Checked;
            cfgCodabar.bNOTISEditing = checkBox3.Checked;

            cfgCodabar.nMinLength = (short)numericUpDown1.Value;
            cfgCodabar.nMaxLength = (short)numericUpDown2.Value;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCodabar));
            Marshal.StructureToPtr(cfgCodabar, SymConfig.pConfigData, false);

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
            cfgCodabar = new NBarcodeApi.N1DSymbols.CONFIG_1D_CODABAR();

            SymConfig.Symbol = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODABAR;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCodabar));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgCodabar = (NBarcodeApi.N1DSymbols.CONFIG_1D_CODABAR)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N1DSymbols.CONFIG_1D_CODABAR));

            checkBox1.Checked = cfgCodabar.bEnabled;
            checkBox2.Checked = cfgCodabar.bCLSIEditing;
            checkBox3.Checked = cfgCodabar.bNOTISEditing;

            numericUpDown1.Value = cfgCodabar.nMinLength;
            numericUpDown2.Value = cfgCodabar.nMaxLength;

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