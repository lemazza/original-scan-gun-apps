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
    public partial class frmPosiCode : Form
    {
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_POSICODE cfgPosiCode;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmPosiCode(int idx)
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
            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODABAR;

            cfgPosiCode.bEnabled = checkBox1.Checked;

            short nValue = 0;
            if (radioButton1.Checked)
                nValue = 0;

            if (radioButton2.Checked)
                nValue = 1;

            if (radioButton2.Checked)
                nValue = 2;

            cfgPosiCode.wLimited = nValue;
            cfgPosiCode.nMinLength = (short)numericUpDown1.Value;
            cfgPosiCode.nMaxLength = (short)numericUpDown2.Value;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgPosiCode));
            Marshal.StructureToPtr(cfgPosiCode, SymConfig.pConfigData, false);

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
            cfgPosiCode = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_POSICODE();

            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_POSICODE;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgPosiCode));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgPosiCode = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_POSICODE)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_POSICODE));
            checkBox1.Checked = cfgPosiCode.bEnabled;
            short nValue = cfgPosiCode.wLimited;
            if (nValue == 0)
                radioButton1.Checked = true;
            else if (nValue == 1)
                radioButton2.Checked = true;
            else if (nValue == 2)
                radioButton3.Checked = true;

            numericUpDown1.Value = cfgPosiCode.nMinLength;
            numericUpDown2.Value = cfgPosiCode.nMaxLength;

            SetLength(2, 48);

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