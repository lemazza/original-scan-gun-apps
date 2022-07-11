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
    public partial class frmPostNet : Form
    {
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_POSTNET cfgPostnet;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_PLANET cfgPlanet;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;
        private NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD SYMBOL_2D;

        public frmPostNet(int idx)
        {
            InitializeComponent();
            SYMBOL_2D = (NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD)idx;

            this.Text = String.Format("{0} Setup", (string)frmMain.ht2DSymbolName[SYMBOL_2D]);

            LoadConfig();
        }

        private void SaveConfig()
        {
            SymConfig = new NBarcodeApi.SYMBOL_CONFIG();
            if (SYMBOL_2D == NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_POSTNET)
            {
                System.Diagnostics.Debug.WriteLine(String.Format("Save {0}", (string)frmMain.ht2DSymbolName[SYMBOL_2D]));
                SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_POSTNET;

                cfgPostnet.bEnabled = checkBox1.Checked;
                cfgPostnet.bXmitCheckDigit = checkBox2.Checked;

                SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgPostnet));
                Marshal.StructureToPtr(cfgPostnet, SymConfig.pConfigData, false);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(String.Format("Save {0}", (string)frmMain.ht2DSymbolName[SYMBOL_2D]));
                SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_PLANET;

                cfgPlanet.bEnabled = checkBox1.Checked;
                cfgPlanet.bXmitCheckDigit = checkBox2.Checked;

                SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgPlanet));
                Marshal.StructureToPtr(cfgPlanet, SymConfig.pConfigData, false);
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
            if (SYMBOL_2D == NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_POSTNET)
            {
                System.Diagnostics.Debug.WriteLine(String.Format("Load {0}", (string)frmMain.ht2DSymbolName[SYMBOL_2D]));
                cfgPostnet = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_POSTNET();

                SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_POSTNET;
                SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgPostnet));

                BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
                if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                {
                    UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                    Marshal.FreeHGlobal(SymConfig.pConfigData);
                    MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                    return;
                }

                cfgPostnet = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_POSTNET)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_POSTNET));
                checkBox1.Checked = cfgPostnet.bEnabled;
                checkBox2.Checked = cfgPostnet.bXmitCheckDigit;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(String.Format("Load {0}", (string)frmMain.ht2DSymbolName[SYMBOL_2D]));
                cfgPlanet = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_PLANET();

                SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_PLANET;
                SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgPlanet));

                BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
                if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                {
                    UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                    Marshal.FreeHGlobal(SymConfig.pConfigData);
                    MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                    return;
                }

                cfgPlanet = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_PLANET)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_PLANET));
                checkBox1.Checked = cfgPlanet.bEnabled;
                checkBox2.Checked = cfgPlanet.bXmitCheckDigit;
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