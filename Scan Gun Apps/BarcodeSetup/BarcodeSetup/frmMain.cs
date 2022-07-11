using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using NBarcodeApi;

namespace BarcodeSetup
{
    public partial class frmMain : Form
    {
        public static string WindowsName = "BarcodeSetup";
        public static BarcodeApi barcode = null;
        public static bool Enable2DFunctions = false;
        public static Hashtable ht1DSymbolName = null;
        public static Hashtable ht2DSymbolName = null;

        private Timer timerInit = null;
        public frmMain()
        {
            InitializeComponent();
            this.Text = WindowsName;
            this.KeyPreview = true;

            timerInit = new Timer();
            timerInit.Interval = 10;
            timerInit.Tick += new EventHandler(timerInit_Tick);
            timerInit.Enabled = true;
        }

        void Init1DSymbolName()
        {
            ht1DSymbolName = new Hashtable();
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_UPCA]                = "UPC-A";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_UPCE]                = "UPC-E";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_UPCE1]               = "UPC-E1";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_EAN8]                = "EAN-8";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_EAN13]               = "EAN-13";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_BOOKLAND]            = "Bookland";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE128]             = "Code 128";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_UCCEAN128]           = "UCCEAN 128";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_ISBT128]             = "ISBT 128";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE39]              = "Code 39";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_TRIOPTIC39]          = "Trioptic 39";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE93]              = "Code 93";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE11]              = "Code 11";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_INTERLEAVED25]       = "Interleaved 2 of 5";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_DISCRETE25]          = "Discrete 2 of 5";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CHINESE25]           = "Chinese 2 of 5";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODABAR]             = "Codabar";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_MSI]                 = "MSI";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_RSS14]               = "RSS-14";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_RSSLIMITED]          = "RSS Limited";
            ht1DSymbolName[NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_RSSEXPANDED]         = "RSS Expanded";
            
        }

        void Init2DSymbolName()
        {
            ht2DSymbolName = new Hashtable();
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_AZTEC]         = "Aztec";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MESA]          = "Aztec Mesa";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODABAR]       = "Codabar";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE11]        = "Code 11";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE128]       = "Code 128";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE39]        = "Code 39";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE49]        = "Code 49";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE93]        = "Code 93";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_COMPOSITE]     = "Composite Codes";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_DATAMATRIX]    = "Data Matrix";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_EAN8]          = "EAN-8";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_EAN13]         = "EAN-13";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_INT25]         = "Interleaved 2 of 5";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MAXICODE]      = "MaxiCode";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MICROPDF]      = "Micro PDF";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_OCR]           = "OCR-A, OCR-B, US Currency";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_PDF417]        = "PDF 417";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_POSTNET]       = "US Postnet";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_QR]            = "QR Code";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_RSS]           = "Reduced Space Symbology";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_UPCA]          = "UPC-A";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_UPCE0]         = "UPC-E";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_UPCE1]         = "UPC-E1";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_ISBT]          = "ISBT";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_BPO]           = "British Post";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CANPOST]       = "Canada Post";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_AUSPOST]       = "Australian Post";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_IATA25]        = "IATA 2 of 5";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODABLOCK]     = "Codablock F";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_JAPOST]        = "Japanese Post";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_PLANET]        = "US Planet";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_DUTCHPOST]     = "KIX (Netherlands) Post";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MSI]           = "MSI";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_TLCODE39]      = "TCIF Linked Code 39";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_TRIOPTIC]      = "Trioptic Code";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE32]        = "Code 32 (Italian Pharmacy)";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_STRT25]        = "Code 2 of 5";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MATRIX25]      = "Matrix 2 of 5";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_PLESSEY]       = "Plessey Code";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CHINAPOST]     = "China Post";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_KOREAPOST]     = "Korean Post";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_TELEPEN]       = "Telepen Code";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE16K]       = "Code 16k";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_POSICODE]      = "PosiCode";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_COUPONCODE]    = "UPC-E/EAN-13 Coupon Code";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_USPS4CB]       = "UPU 4 State Customer Code";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_IDTAG]         = "UPU 4 State Id Tag";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_GEN_CODE128]   = "GEN Code 128";
            ht2DSymbolName[NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_GS1_128]       = "GS1 128";
        }

        void timerInit_Tick(object sender, EventArgs e)
        {
            BARCODE_RESULT result = BARCODE_RESULT.BARCODE_RESULT_FAILURE;
            timerInit.Enabled = false;

            if (barcode == null)
            {
                Cursor.Current = Cursors.WaitCursor;
                this.Enabled = false;

                //Init2DSymbolName();

                barcode = new BarcodeApi();
                result = barcode.Open();
                if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
                {
                    string errMsg = string.Empty;
                    switch (result)
                    {
                        case BARCODE_RESULT.BARCODE_RESULT_CAM_SELECTED:
                            errMsg = "CAM already turned on!!\r\nTry again after turn off CAM";
                            break;
                        case BARCODE_RESULT.BARCODE_RESULT_ALREADY_BARCODE_SELECTED:
                            errMsg = "Other barcode application already running!!";
                            break;
                        case BARCODE_RESULT.BARCODE_RESULT_ALREADY_OPENED:
                            errMsg = "Already opened";
                            break;
                        default:
                            errMsg = result.ToString();
                            break;
                    }
                    MessageBox.Show(errMsg);
                    Application.Exit();
                }

                barcode.SetCallback(new BarcodeApi.BARCODECALLBACK(BarcodeCallback));

                GENERAL_CONFIG config = new GENERAL_CONFIG();
                result = barcode.GetGeneralConfig(ref config);
                if (result == BARCODE_RESULT.BARCODE_RESULT_UNSUPPORTED)
                {
                    // 2D Scanner
                    Enable2DFunctions = true;
                    Init2DSymbolName();
                    Load2DSymbologies();
                    button5.Visible = false;
                }
                else
                {
                    // 1D Scanner
                    Enable2DFunctions = false;
                    Init1DSymbolName();
                    Load1DSymbologies();
                }

                System.Diagnostics.Debug.WriteLine(String.Format("Enable2DFunctions: {0}", Enable2DFunctions ? "True" : "False"));
                //System.Diagnostics.Debug.WriteLine("GetGeneralConfig : " + result.ToString());
                this.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        void Load1DSymbologies()
        {
            int max = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.NUM_OF_1D_SYMBOLOGIES;
            for (int i = 0; i < max; i++)
            {
                NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D symbol = (NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D)i;
                comboBox1.Items.Add((string)ht1DSymbolName[symbol]);
            }
        }

        void Load2DSymbologies()
        {
            int max = (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.NUM_OF_2DSWD_SYMBOLOGIES;
            for (int i = 0; i < max; i++)
            {
                NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD symbol = (NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD)i;
                comboBox1.Items.Add((string)ht2DSymbolName[symbol]);
            }
        }

        void BarcodeCallback()
        {
            //string BarValue = new string(new char[4096]);
            //string BarName = new string(new char[128]);
            //string BarID = new string(new char[5]);

            //barcode.GetBarcodeData(ref BarValue, ref BarName, ref BarID);

            //System.Diagnostics.Debug.WriteLine("Data: " + BarValue);
        }

        private void frmMain_Closing(object sender, CancelEventArgs e)
        {
            if (barcode != null && barcode.IsOpened())
            {
                barcode.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            new frmEnableStatus().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BARCODE_RESULT result = barcode.SetDefaultSymbol();
            Cursor.Current = Cursors.Default;
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                MessageBox.Show(result.ToString());
            }
            else
            {
                UnmanagedAPI.PlaySound(@"\Windows\Success.wav");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BARCODE_RESULT result = barcode.EnableSymbologiesAll(false);
            Cursor.Current = Cursors.Default;
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                MessageBox.Show(result.ToString());
            }
            else
            {
                UnmanagedAPI.PlaySound(@"\Windows\Success.wav");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BARCODE_RESULT result = barcode.EnableSymbologiesAll(true);
            Cursor.Current = Cursors.Default;
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                MessageBox.Show(result.ToString());
            }
            else
            {
                UnmanagedAPI.PlaySound(@"\Windows\Success.wav");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = comboBox1.SelectedIndex;
            string SymName = String.Empty;//comboBox1.Items[idx].ToString();

            if (Enable2DFunctions)
            {                
                SymName = (string)ht2DSymbolName[idx];
                System.Diagnostics.Debug.WriteLine(String.Format("idx:{0}, name:{1}", idx, SymName));
                switch ((NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD)idx)
                {
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_AZTEC:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE128:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE49:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE93:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_DATAMATRIX:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MICROPDF:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_PDF417:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_QR:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_RSS:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_IATA25:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODABLOCK:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MAXICODE:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MATRIX25:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_KOREAPOST:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_STRT25:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_PLESSEY:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CHINAPOST:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE16K:
                        new frmAztec(SymName, idx).ShowDialog();
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_ISBT:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_BPO:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CANPOST:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_JAPOST:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_DUTCHPOST:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_TLCODE39:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_TRIOPTIC:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE32:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_COUPONCODE:
                    //case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_USPS4CB:
                    //case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_IDTAG:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_AUSPOST:
                        new frmEnableOnly(idx).ShowDialog();
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODABAR:
                        new frmCodabar_2D().ShowDialog();
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE11:
                        new frmCode11_2D().ShowDialog();
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE39:
                        new frmCode39_2D().ShowDialog();
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_COMPOSITE:
                        new frmComposite().ShowDialog();
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_EAN8:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_EAN13:
                        new frmEan8_13(idx).ShowDialog();
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_INT25:
                        new frmIT2of5_2D().ShowDialog();
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_OCR:
                        new frmOCR().ShowDialog();
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_POSTNET:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_PLANET:
                        new frmPostNet(idx).ShowDialog();
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_UPCA:
                        new frmUPCA().ShowDialog();
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_UPCE0:
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_UPCE1:
                        new frmUPCE(idx).ShowDialog();
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_MSI:
                        new frmMSI_2D().ShowDialog();
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_TELEPEN:
                        new frmTelepen(idx).ShowDialog();
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_POSICODE:
                        new frmPosiCode(idx).ShowDialog();
                        break;
                    default:
                        break;
                }
                
            }
            else
            {
                SymName = (string)ht1DSymbolName[idx];
                System.Diagnostics.Debug.WriteLine(String.Format("idx:{0}, name:{1}", idx, SymName));
                switch ((NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D)idx)
                {
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_UPCA:
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_UPCE:
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_UPCE1:
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_EAN8:
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_EAN13:
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_UCCEAN128:
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_BOOKLAND:
                        // UPC/EAN
                        new frmUpcEan_1D().ShowDialog();
                        break;
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE128:
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_ISBT128:
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CHINESE25:
                        // enable
                        new frmEnableOnly(idx).ShowDialog();
                        break;
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE93:
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_DISCRETE25:
                        new frmCode93().ShowDialog();
                        // enable, length
                        break;
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE39:
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_TRIOPTIC39:
                        new frmCode39_1D().ShowDialog();
                        break;
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE11:
                        new frmCode11_1D().ShowDialog();
                        break;
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_INTERLEAVED25:
                        new frmIT2of5_1D().ShowDialog();
                        break;
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODABAR:
                        new frmCodabar_1D().ShowDialog();
                        break;
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_MSI:
                        new frmMSI_1D().ShowDialog();
                        break;
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_RSS14:
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_RSSEXPANDED:
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_RSSLIMITED:
                        new frmRSS().ShowDialog();
                        break;
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                barcode.Start();
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                barcode.Stop();
            base.OnKeyUp(e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new frmGeneral().ShowDialog();
        }
    }
}