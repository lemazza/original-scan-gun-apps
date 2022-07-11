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
    public partial class frmCode39_2D : Form
    {
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE39 cfgCode39;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmCode39_2D()
        {
            InitializeComponent();
            this.Text = "Code 39 Setup";

            //SetLength(0, int.MaxValue);

            //LoadConfig();
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
            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE39;

            cfgCode39.bEnabled = checkBox1.Checked;
            cfgCode39.bSSXmit = checkBox2.Checked;
            if (radioButton1.Checked)
            {
                cfgCode39.bCheckCharOn = false;
                cfgCode39.bXmitCheckChar = false;
            }
            else
            {
                if (radioButton3.Checked)
                    cfgCode39.bXmitCheckChar = true;
                else
                    cfgCode39.bXmitCheckChar = false;

                cfgCode39.bCheckCharOn = true;
            }
            cfgCode39.nMinLength = (short)numericUpDown1.Value;
            cfgCode39.nMaxLength = (short)numericUpDown2.Value;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode39));
            Marshal.StructureToPtr(cfgCode39, SymConfig.pConfigData, false);

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
            cfgCode39 = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE39();

            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE39;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode39));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgCode39 = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE39)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE39));
            checkBox1.Checked = cfgCode39.bEnabled;
            checkBox2.Checked = cfgCode39.bSSXmit;
            checkBox3.Checked = cfgCode39.bFullAscii;
            checkBox4.Checked = cfgCode39.bAppend;
            if (cfgCode39.bCheckCharOn)
            {
                if (cfgCode39.bXmitCheckChar)
                    radioButton3.Checked = true;
                else
                    radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }

            numericUpDown1.Value = cfgCode39.nMinLength;
            numericUpDown2.Value = cfgCode39.nMaxLength;

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