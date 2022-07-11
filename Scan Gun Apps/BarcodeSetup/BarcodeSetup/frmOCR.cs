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
    public partial class frmOCR : Form
    {
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_OCR cfgOCR;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmOCR()
        {
            InitializeComponent();
            this.Text = "OCR Setup";

            LoadConfig();
        }

        private void SaveConfig()
        {
            SymConfig = new NBarcodeApi.SYMBOL_CONFIG();
            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_OCR;

            NBarcodeApi.N2DSymbols.OCRMode ocrMode = NBarcodeApi.N2DSymbols.OCRMode.OCRMODE_DISABLED;
            if (radioButton1.Checked)
                ocrMode = NBarcodeApi.N2DSymbols.OCRMode.OCRMODE_DISABLED;
            else if (radioButton2.Checked)
                ocrMode = NBarcodeApi.N2DSymbols.OCRMode.OCRMODE_A;
            else if (radioButton3.Checked)
                ocrMode = NBarcodeApi.N2DSymbols.OCRMode.OCRMODE_B;
            else if (radioButton4.Checked)
                ocrMode = NBarcodeApi.N2DSymbols.OCRMode.OCRMODE_MONEY;

            cfgOCR.nFont = ocrMode;
            cfgOCR.Template = textBox1.Text.Trim();
            cfgOCR.GroupG = textBox2.Text.Trim();
            cfgOCR.GroupH = textBox3.Text.Trim();
            cfgOCR.CheckChar = textBox4.Text.Trim();

            //cfgOCR.bEnabled = checkBox1.Checked;
            //cfgOCR.bSSXmit = checkBox2.Checked;
            //if (radioButton1.Checked)
            //{
            //    cfgOCR.bCheckCharOn = false;
            //    cfgOCR.bXmitCheckChar = false;
            //}
            //else
            //{
            //    if (radioButton3.Checked)
            //        cfgOCR.bXmitCheckChar = true;
            //    else
            //        cfgOCR.bXmitCheckChar = false;

            //    cfgOCR.bCheckCharOn = true;
            //}
            //cfgOCR.nMinLength = (short)numericUpDown1.Value;
            //cfgOCR.nMaxLength = (short)numericUpDown2.Value;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgOCR));
            Marshal.StructureToPtr(cfgOCR, SymConfig.pConfigData, false);

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
            cfgOCR = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_OCR();

            SymConfig.Symbol = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_OCR;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgOCR));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgOCR = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_OCR)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_OCR));

            if (cfgOCR.nFont == NBarcodeApi.N2DSymbols.OCRMode.OCRMODE_DISABLED)
            {
                radioButton1.Checked = true;
            }
            else if (cfgOCR.nFont == NBarcodeApi.N2DSymbols.OCRMode.OCRMODE_A)
            {
                radioButton2.Checked = true;
            }
            else if (cfgOCR.nFont == NBarcodeApi.N2DSymbols.OCRMode.OCRMODE_B)
            {
                radioButton3.Checked = true;
            }
            else if (cfgOCR.nFont == NBarcodeApi.N2DSymbols.OCRMode.OCRMODE_MONEY)
            {
                radioButton4.Checked = true;
            }

            textBox1.Text = cfgOCR.Template;
            textBox2.Text = cfgOCR.GroupG;
            textBox3.Text = cfgOCR.GroupH;
            textBox4.Text = cfgOCR.CheckChar;

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