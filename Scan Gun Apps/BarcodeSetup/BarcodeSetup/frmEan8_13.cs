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
    public partial class frmEan8_13 : Form
    {
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_EAN8 cfgEan8;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_EAN13 cfgEan13;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;
        private NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD SYMBOL_2D;

        public frmEan8_13(int idx)
        {
            InitializeComponent();
            SYMBOL_2D = (NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD)idx;
            this.Text = String.Format("{0} Setup", (string)frmMain.ht2DSymbolName[SYMBOL_2D]);
            
            LoadConfig();
        }

        private void SaveConfig()
        {
            SymConfig = new NBarcodeApi.SYMBOL_CONFIG();
            if (SYMBOL_2D == NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_EAN8)
            {
                System.Diagnostics.Debug.WriteLine("Save EAN-8");
                SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_EAN8;

                cfgEan8.bEnabled = checkBox1.Checked;
                cfgEan8.bXmitCheckChar = checkBox2.Checked;
                cfgEan8.bAddenda2Digit = checkBox3.Checked;
                cfgEan8.bAddenda5Digit = checkBox4.Checked;
                cfgEan8.bAddendaReq = checkBox5.Checked;
                cfgEan8.bAddendaSeparator = checkBox6.Checked;

                SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgEan8));
                Marshal.StructureToPtr(cfgEan8, SymConfig.pConfigData, false);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Save EAN-13");
                SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_EAN13;

                cfgEan13.bEnabled = checkBox1.Checked;
                cfgEan13.bXmitCheckChar = checkBox2.Checked;
                cfgEan13.bAddenda2Digit = checkBox3.Checked;
                cfgEan13.bAddenda5Digit = checkBox4.Checked;
                cfgEan13.bAddendaReq = checkBox5.Checked;
                cfgEan13.bAddendaSeparator = checkBox6.Checked;

                SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgEan13));
                Marshal.StructureToPtr(cfgEan13, SymConfig.pConfigData, false);
            }
            

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
            if (SYMBOL_2D == NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_EAN8)
            {
                System.Diagnostics.Debug.WriteLine("Load EAN-8");
                cfgEan8 = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_EAN8();

                SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_EAN8;
                SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgEan8));

                BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
                if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                {
                    UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                    Marshal.FreeHGlobal(SymConfig.pConfigData);
                    MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                    return;
                }

                cfgEan8 = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_EAN8)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_EAN8));
                checkBox1.Checked = cfgEan8.bEnabled;
                checkBox2.Checked = cfgEan8.bXmitCheckChar;
                checkBox3.Checked = cfgEan8.bAddenda2Digit;
                checkBox4.Checked = cfgEan8.bAddenda5Digit;
                checkBox5.Checked = cfgEan8.bAddendaReq;
                checkBox6.Checked = cfgEan8.bAddendaSeparator;

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Load EAN-13");
                cfgEan13 = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_EAN13();

                SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_EAN13;
                SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgEan13));

                BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
                if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                {
                    UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                    Marshal.FreeHGlobal(SymConfig.pConfigData);
                    MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                    return;
                }

                cfgEan13 = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_EAN13)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_EAN13));
                checkBox1.Checked = cfgEan13.bEnabled;
                checkBox2.Checked = cfgEan13.bXmitCheckChar;
                checkBox3.Checked = cfgEan13.bAddenda2Digit;
                checkBox4.Checked = cfgEan13.bAddenda5Digit;
                checkBox5.Checked = cfgEan13.bAddendaReq;
                checkBox6.Checked = cfgEan13.bAddendaSeparator;
            }
            //SetLength(1, 2435);

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