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
    public partial class frmIT2of5_1D : Form
    {
        private NBarcodeApi.N1DSymbols.CONFIG_1D_INTERLEAVED25 cfgIT2of5;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmIT2of5_1D()
        {
            InitializeComponent();
            this.Text = "Interleaved 2 of 5 Setup";

            comboBox1.Items.Add("Disable");
            comboBox1.Items.Add("OPCC");
            comboBox1.Items.Add("USS");

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
            SymConfig.Symbol = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_INTERLEAVED25;

            cfgIT2of5.bEnabled = checkBox1.Checked;
            cfgIT2of5.bXmitCheckDigit = checkBox2.Checked;
            cfgIT2of5.bConvertI2of5ToEAN13 = checkBox3.Checked;

            cfgIT2of5.nCheckDigitVerify = (short)comboBox1.SelectedIndex;

            cfgIT2of5.nMinLength = (short)numericUpDown1.Value;
            cfgIT2of5.nMaxLength = (short)numericUpDown2.Value;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgIT2of5));
            Marshal.StructureToPtr(cfgIT2of5, SymConfig.pConfigData, false);

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
            cfgIT2of5 = new NBarcodeApi.N1DSymbols.CONFIG_1D_INTERLEAVED25();

            SymConfig.Symbol = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_INTERLEAVED25;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgIT2of5));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgIT2of5 = (NBarcodeApi.N1DSymbols.CONFIG_1D_INTERLEAVED25)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N1DSymbols.CONFIG_1D_INTERLEAVED25));

            checkBox1.Checked = cfgIT2of5.bEnabled;
            checkBox2.Checked = cfgIT2of5.bXmitCheckDigit;
            checkBox3.Checked = cfgIT2of5.bConvertI2of5ToEAN13;

            comboBox1.SelectedIndex = (int)cfgIT2of5.nCheckDigitVerify;

            numericUpDown1.Value = cfgIT2of5.nMinLength;
            numericUpDown2.Value = cfgIT2of5.nMaxLength;

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