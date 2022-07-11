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
    public partial class frmCode93 : Form
    {
        private NBarcodeApi.N1DSymbols.CONFIG_1D_CODE93 cfgCode93;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmCode93()
        {
            InitializeComponent();
            this.Text = "Code 93 Setup";

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
            SymConfig.Symbol = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE93;

            cfgCode93.bEnabled = checkBox1.Checked;

            cfgCode93.nMinLength = (short)numericUpDown1.Value;
            cfgCode93.nMaxLength = (short)numericUpDown2.Value;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode93));
            Marshal.StructureToPtr(cfgCode93, SymConfig.pConfigData, false);

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
            cfgCode93 = new NBarcodeApi.N1DSymbols.CONFIG_1D_CODE93();

            SymConfig.Symbol = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE93;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode93));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgCode93 = (NBarcodeApi.N1DSymbols.CONFIG_1D_CODE93)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N1DSymbols.CONFIG_1D_CODE93));

            checkBox1.Checked = cfgCode93.bEnabled;

            numericUpDown1.Value = cfgCode93.nMinLength;
            numericUpDown2.Value = cfgCode93.nMaxLength;

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