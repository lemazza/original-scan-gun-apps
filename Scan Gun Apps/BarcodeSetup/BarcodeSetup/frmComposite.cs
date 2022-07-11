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
    public partial class frmComposite : Form
    {
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_COMPOSITE cfgComposite;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmComposite()
        {
            InitializeComponent();
            this.Text = "Composite Codes Setup";

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
            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_COMPOSITE;

            cfgComposite.bEnabled = checkBox1.Checked;
            cfgComposite.bCompositeOnUpcEan = checkBox2.Checked;
            cfgComposite.nMinLength = (short)numericUpDown1.Value;
            cfgComposite.nMaxLength = (short)numericUpDown2.Value;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgComposite));
            Marshal.StructureToPtr(cfgComposite, SymConfig.pConfigData, false);

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
            cfgComposite = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_COMPOSITE();

            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_COMPOSITE;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgComposite));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgComposite = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_COMPOSITE)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_COMPOSITE));
            checkBox1.Checked = cfgComposite.bEnabled;
            checkBox2.Checked = cfgComposite.bCompositeOnUpcEan;


            numericUpDown1.Value = cfgComposite.nMinLength;
            numericUpDown2.Value = cfgComposite.nMaxLength;

            SetLength(1, 2435);

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