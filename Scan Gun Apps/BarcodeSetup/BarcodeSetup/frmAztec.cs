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
    public partial class frmAztec : Form
    {
        private NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D       SYMBOL_1D;
        private NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD    SYMBOL_2D;

        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_AZTEC cfgAztec;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE128 cfgCode128;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE49 cfgCode49;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE93 cfgCode93;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_DATAMATRIX cfgDatamatrix;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MICROPDF cfgMicroPdf;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_PDF417 cfgPdf417;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_QR cfgQr;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_RSS cfgRss;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_IATA25 cfgIata25;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODABLOCK cfgCodaBlock;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MAXICODE cfgMaxiCode;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MX25 cfgMatrix25;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_KOREAPOST cfgKoreaPost;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_STRT25 cfgStrt25;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_PLESSEY cfgPlessey;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CHINAPOST cfgChinaPost;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE16K cfgCode16k;

        public frmAztec(string SymName, int Idx)
        {
            InitializeComponent();

            //numericUpDown1.Minimum = 0;
            //numericUpDown1.Maximum = int.MaxValue;

            //numericUpDown2.Minimum = 0;
            //numericUpDown2.Maximum = int.MaxValue;
            SetLength(0, int.MaxValue);

            //this.Text = SymName;
            if (frmMain.Enable2DFunctions)
            {
                this.SYMBOL_2D = (NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD)Idx;
                this.Text = (string)frmMain.ht2DSymbolName[SYMBOL_2D] + "Setup";
                Load2DConfig();
            }
            else
            {
                this.SYMBOL_1D = (NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D)Idx;
            }
            
        }

        //private void SetMinValue(int nValue)
        //{
        //    numericUpDown1.Minimum = nValue;
        //    numericUpDown2.Minimum = nValue;
        //}
        //private void SetMaxValue(int nValue)
        //{
        //    numericUpDown1.Maximum = nValue;
        //    numericUpDown2.Maximum = nValue;
        //}
        private void SetLength(int nMin, int nMax)
        {
            numericUpDown1.Minimum = nMin;
            numericUpDown1.Maximum = nMax;

            numericUpDown2.Minimum = nMin;
            numericUpDown2.Maximum = nMax;
        }

        private void Save2DConfig()
        {
            SymConfig = new NBarcodeApi.SYMBOL_CONFIG();
            SymConfig.Symbol = (int)this.SYMBOL_2D;
            switch (this.SYMBOL_2D)
            {
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_AZTEC:
                    cfgAztec.bEnabled = checkBox1.Checked;
                    cfgAztec.nMinLength = (short)numericUpDown1.Value;
                    cfgAztec.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgAztec));
                    Marshal.StructureToPtr(cfgAztec, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE128:
                    cfgCode128.bEnabled = checkBox1.Checked;
                    cfgCode128.nMinLength = (short)numericUpDown1.Value;
                    cfgCode128.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode128));
                    Marshal.StructureToPtr(cfgCode128, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE49:
                    cfgCode49.bEnabled = checkBox1.Checked;
                    cfgCode49.nMinLength = (short)numericUpDown1.Value;
                    cfgCode49.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode49));
                    Marshal.StructureToPtr(cfgCode49, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE93:

                    cfgCode93.bEnabled = checkBox1.Checked;
                    cfgCode93.bEnabled = checkBox1.Checked;
                    cfgCode93.nMinLength = (short)numericUpDown1.Value;
                    cfgCode93.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode93));
                    Marshal.StructureToPtr(cfgCode93, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_DATAMATRIX:
                    //SetLength(1, 1500);
                    cfgDatamatrix.bEnabled = checkBox1.Checked;
                    cfgDatamatrix.nMinLength = (short)numericUpDown1.Value;
                    cfgDatamatrix.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgDatamatrix));
                    Marshal.StructureToPtr(cfgDatamatrix, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MICROPDF:
                    //SetLength(1, 366);
                    cfgMicroPdf.bEnabled = checkBox1.Checked;
                    cfgMicroPdf.nMinLength = (short)numericUpDown1.Value;
                    cfgMicroPdf.nMaxLength = (short)numericUpDown2.Value;
                    //SetLength(1, 366);

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgMicroPdf));
                    Marshal.StructureToPtr(cfgMicroPdf, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_PDF417:
                    //SetLength(1, 2750);
                    cfgPdf417.bEnabled = checkBox1.Checked;
                    cfgPdf417.nMinLength = (short)numericUpDown1.Value;
                    cfgPdf417.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgPdf417));
                    Marshal.StructureToPtr(cfgPdf417, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_QR:
                    //SetLength(1, 3500);
                    cfgQr.bEnabled = checkBox1.Checked;
                    cfgQr.nMinLength = (short)numericUpDown1.Value;
                    cfgQr.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgQr));
                    Marshal.StructureToPtr(cfgQr, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_RSS:
                    //SetLength(4, 74);
                    cfgRss.bEnabled = checkBox1.Checked;
                    cfgRss.nMinLength = (short)numericUpDown1.Value;
                    cfgRss.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgRss));
                    Marshal.StructureToPtr(cfgRss, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_IATA25:
                    //SetLength(1, 48);
                    cfgIata25.bEnabled = checkBox1.Checked;
                    cfgIata25.nMinLength = (short)numericUpDown1.Value;
                    cfgIata25.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgIata25));
                    Marshal.StructureToPtr(cfgIata25, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODABLOCK:
                    //SetLength(1, 2048);
                    cfgCodaBlock.bEnabled = checkBox1.Checked;
                    cfgCodaBlock.nMinLength = (short)numericUpDown1.Value;
                    cfgCodaBlock.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCodaBlock));
                    Marshal.StructureToPtr(cfgCodaBlock, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MAXICODE:
                    //SetLength(1, 150);
                    cfgMaxiCode.bEnabled = checkBox1.Checked;
                    cfgMaxiCode.nMinLength = (short)numericUpDown1.Value;
                    cfgMaxiCode.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgMaxiCode));
                    Marshal.StructureToPtr(cfgMaxiCode, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MATRIX25:
                    //SetLength(1, 80);
                    cfgMatrix25.bEnabled = checkBox1.Checked;
                    cfgMatrix25.nMinLength = (short)numericUpDown1.Value;
                    cfgMatrix25.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgMatrix25));
                    Marshal.StructureToPtr(cfgMatrix25, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_KOREAPOST:
                    //SetLength(2, 80);
                    cfgKoreaPost.bEnabled = checkBox1.Checked;
                    cfgKoreaPost.nMinLength = (short)numericUpDown1.Value;
                    cfgKoreaPost.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgKoreaPost));
                    Marshal.StructureToPtr(cfgKoreaPost, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_STRT25:
                    //SetLength(1, 48);
                    cfgStrt25.bEnabled = checkBox1.Checked;
                    cfgStrt25.nMinLength = (short)numericUpDown1.Value;
                    cfgStrt25.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgStrt25));
                    Marshal.StructureToPtr(cfgStrt25, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_PLESSEY:
                    //SetLength(4, 48);
                    cfgPlessey.bEnabled = checkBox1.Checked;
                    cfgPlessey.nMinLength = (short)numericUpDown1.Value;
                    cfgPlessey.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgPlessey));
                    Marshal.StructureToPtr(cfgPlessey, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CHINAPOST:
                    //SetLength(2, 80);
                    cfgChinaPost.bEnabled = checkBox1.Checked;
                    cfgChinaPost.nMinLength = (short)numericUpDown1.Value;
                    cfgChinaPost.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgChinaPost));
                    Marshal.StructureToPtr(cfgChinaPost, SymConfig.pConfigData, false);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE16K:
                    //SetLength(1, 160);
                    cfgCode16k.bEnabled = checkBox1.Checked;
                    cfgCode16k.nMinLength = (short)numericUpDown1.Value;
                    cfgCode16k.nMaxLength = (short)numericUpDown2.Value;

                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode16k));
                    Marshal.StructureToPtr(cfgCode16k, SymConfig.pConfigData, false);
                    break;
                default:
                    break;
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

        private void Load2DConfig()
        {
            SymConfig = new NBarcodeApi.SYMBOL_CONFIG();
            SymConfig.Symbol = (int)this.SYMBOL_2D;
            
            switch (this.SYMBOL_2D)
            {
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_AZTEC:
                    //SetLength(1, 3750);
                    cfgAztec = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_AZTEC();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgAztec));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE128:
                    //SetLength(0, 80);
                    cfgCode128 = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE128();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode128));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE49:
                    //SetLength(1, 81);
                    cfgCode49 = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE49();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode49));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE93:
                    //SetLength(0, 80);
                    cfgCode93 = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE93();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode93));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_DATAMATRIX:
                    //SetLength(1, 1500);
                    cfgDatamatrix = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_DATAMATRIX();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgDatamatrix));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MICROPDF:
                    //SetLength(1, 366);
                    cfgMicroPdf = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MICROPDF();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgMicroPdf));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_PDF417:
                    //SetLength(1, 2750);
                    cfgPdf417 = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_PDF417();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgPdf417));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_QR:
                    //SetLength(1, 3500);
                    cfgQr = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_QR();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgQr));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_RSS:
                    //SetLength(4, 74);
                    cfgRss = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_RSS();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgRss));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_IATA25:
                    //SetLength(1, 48);
                    cfgIata25 = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_IATA25();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgIata25));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODABLOCK:
                    //SetLength(1, 2048);
                    cfgCodaBlock = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODABLOCK();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCodaBlock));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MAXICODE:
                    //SetLength(1, 150);
                    cfgMaxiCode = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MAXICODE();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgMaxiCode));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MATRIX25:
                    //SetLength(1, 80);
                    cfgMatrix25 = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MX25();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgMatrix25));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_KOREAPOST:
                    //SetLength(2, 80);
                    cfgKoreaPost = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_KOREAPOST();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgKoreaPost));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_STRT25:
                    //SetLength(1, 48);
                    cfgStrt25 = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_STRT25();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgStrt25));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_PLESSEY:
                    //SetLength(4, 48);
                    cfgPlessey = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_PLESSEY();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgPlessey));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CHINAPOST:
                    //SetLength(2, 80);
                    cfgChinaPost = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CHINAPOST();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgChinaPost));
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE16K:
                    //SetLength(1, 160);
                    cfgCode16k = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE16K();
                    SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode16k));
                    break;
            }

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            switch (this.SYMBOL_2D)
            {
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_AZTEC:
                    cfgAztec = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_AZTEC)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_AZTEC));
                    checkBox1.Checked = cfgAztec.bEnabled;
                    numericUpDown1.Value = cfgAztec.nMinLength;
                    numericUpDown2.Value = cfgAztec.nMaxLength;
                    SetLength(1, 3750);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE128:
                    cfgCode128 = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE128)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE128));
                    checkBox1.Checked = cfgCode128.bEnabled;
                    numericUpDown1.Value = cfgCode128.nMinLength;
                    numericUpDown2.Value = cfgCode128.nMaxLength;
                    SetLength(0, 80);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE49:
                    cfgCode49 = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE49)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE49));
                    checkBox1.Checked = cfgCode49.bEnabled;
                    numericUpDown1.Value = cfgCode49.nMinLength;
                    numericUpDown2.Value = cfgCode49.nMaxLength;
                    SetLength(1, 81);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE93:
                    cfgCode93 = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE93)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE93));
                    checkBox1.Checked = cfgCode93.bEnabled;
                    numericUpDown1.Value = cfgCode93.nMinLength;
                    numericUpDown2.Value = cfgCode93.nMaxLength;
                    SetLength(0, 80);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_DATAMATRIX:
                    cfgDatamatrix = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_DATAMATRIX)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_DATAMATRIX));
                    checkBox1.Checked = cfgDatamatrix.bEnabled;
                    numericUpDown1.Value = cfgDatamatrix.nMinLength;
                    numericUpDown2.Value = cfgDatamatrix.nMaxLength;
                    SetLength(1, 1500);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MICROPDF:
                    cfgMicroPdf = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MICROPDF)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MICROPDF));
                    checkBox1.Checked = cfgMicroPdf.bEnabled;
                    numericUpDown1.Value = cfgMicroPdf.nMinLength;
                    numericUpDown2.Value = cfgMicroPdf.nMaxLength;
                    SetLength(1, 366);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_PDF417:
                    cfgPdf417 = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_PDF417)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_PDF417));
                    checkBox1.Checked = cfgPdf417.bEnabled;
                    numericUpDown1.Value = cfgPdf417.nMinLength;
                    numericUpDown2.Value = cfgPdf417.nMaxLength;
                    SetLength(1, 2750);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_QR:
                    cfgQr = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_QR)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_QR));
                    checkBox1.Checked = cfgQr.bEnabled;
                    numericUpDown1.Value = cfgQr.nMinLength;
                    numericUpDown2.Value = cfgQr.nMaxLength;
                    SetLength(1, 3500);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_RSS:
                    cfgRss = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_RSS)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_RSS));
                    checkBox1.Checked = cfgRss.bEnabled;
                    numericUpDown1.Value = cfgRss.nMinLength;
                    numericUpDown2.Value = cfgRss.nMaxLength;
                    SetLength(4, 74);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_IATA25:
                    cfgIata25 = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_IATA25)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_IATA25));
                    checkBox1.Checked = cfgIata25.bEnabled;
                    numericUpDown1.Value = cfgIata25.nMinLength;
                    numericUpDown2.Value = cfgIata25.nMaxLength;
                    SetLength(1, 48);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODABLOCK:
                    cfgCodaBlock = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODABLOCK)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODABLOCK));
                    checkBox1.Checked = cfgCodaBlock.bEnabled;
                    numericUpDown1.Value = cfgCodaBlock.nMinLength;
                    numericUpDown2.Value = cfgCodaBlock.nMaxLength;
                    SetLength(1, 2048);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MAXICODE:
                    cfgMaxiCode = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MAXICODE)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MAXICODE));
                    checkBox1.Checked = cfgMaxiCode.bEnabled;
                    numericUpDown1.Value = cfgMaxiCode.nMinLength;
                    numericUpDown2.Value = cfgMaxiCode.nMaxLength;
                    SetLength(1, 150);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MATRIX25:
                    cfgMatrix25 = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MX25)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_MX25));
                    checkBox1.Checked = cfgMatrix25.bEnabled;
                    numericUpDown1.Value = cfgMatrix25.nMinLength;
                    numericUpDown2.Value = cfgMatrix25.nMaxLength;
                    SetLength(1, 80);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_KOREAPOST:
                    cfgKoreaPost = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_KOREAPOST)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_KOREAPOST));
                    checkBox1.Checked = cfgKoreaPost.bEnabled;
                    numericUpDown1.Value = cfgKoreaPost.nMinLength;
                    numericUpDown2.Value = cfgKoreaPost.nMaxLength;
                    SetLength(2, 80);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_STRT25:
                    cfgStrt25 = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_STRT25)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_STRT25));
                    checkBox1.Checked = cfgStrt25.bEnabled;
                    numericUpDown1.Value = cfgStrt25.nMinLength;
                    numericUpDown2.Value = cfgStrt25.nMaxLength;
                    SetLength(1, 48);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_PLESSEY:
                    cfgPlessey = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_PLESSEY)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_PLESSEY));
                    checkBox1.Checked = cfgPlessey.bEnabled;
                    numericUpDown1.Value = cfgPlessey.nMinLength;
                    numericUpDown2.Value = cfgPlessey.nMaxLength;
                    SetLength(4, 48);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CHINAPOST:
                    cfgChinaPost = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CHINAPOST)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CHINAPOST));
                    checkBox1.Checked = cfgChinaPost.bEnabled;
                    numericUpDown1.Value = cfgChinaPost.nMinLength;
                    numericUpDown2.Value = cfgChinaPost.nMaxLength;
                    SetLength(2, 80);
                    break;
                case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE16K:
                    cfgCode16k = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE16K)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE16K));
                    checkBox1.Checked = cfgCode16k.bEnabled;
                    numericUpDown1.Value = cfgCode16k.nMinLength;
                    numericUpDown2.Value = cfgCode16k.nMaxLength;
                    SetLength(1, 160);
                    break;
            }

            Marshal.FreeHGlobal(SymConfig.pConfigData);
            SymConfig.pConfigData = IntPtr.Zero;
            UnmanagedAPI.PlaySound(@"\Windows\Success.wav");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(String.Format("Enable:{0}, Min:{1}, Max:{2}", checkBox1.Checked, numericUpDown1.Value, numericUpDown2.Value));
            if (frmMain.Enable2DFunctions)
                Save2DConfig();
        }
    }
}