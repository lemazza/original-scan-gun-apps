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
    public partial class frmEnableOnly : Form
    {
        private NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D SYMBOL_1D;
        private NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD SYMBOL_2D;

        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        private NBarcodeApi.N1DSymbols.CONFIG_1D_CODE128 cfgCode128;
        private NBarcodeApi.N1DSymbols.CONFIG_1D_ISBT128 cfgISBT128;
        private NBarcodeApi.N1DSymbols.CONFIG_1D_CHINESE25 cfgChinese25;

        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_ISBT cfgISBT;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_BPO cfgBPO;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CANPOST cfgCANPost;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_JAPOST cfgJAPost;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_DUTCHPOST cfgDutchPost;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_TLC39 cfgTLCode39;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_TRIOPTIC cfgTrioptic;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE32 cfgCode32;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_COUPONCODE cfgCuponCode;
        private NBarcodeApi.N2DSymbols.CONFIG_2DSWD_AUSPOST cfgAUSPost;

        public frmEnableOnly(int Idx)
        {
            InitializeComponent();

            if (frmMain.Enable2DFunctions)
            {
                this.SYMBOL_2D = (NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD)Idx;
                this.Text = String.Format("{0} Setup", (string)frmMain.ht2DSymbolName[SYMBOL_2D]);
                //LoadConfig();
            }
            else
            {
                this.SYMBOL_1D = (NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D)Idx;
                this.Text = String.Format("{0} Setup", (string)frmMain.ht1DSymbolName[SYMBOL_1D]);
                //LoadConfig();
            }

            LoadConfig();
        }

        private void SaveConfig()
        {
            SymConfig = new NBarcodeApi.SYMBOL_CONFIG();

            if (frmMain.Enable2DFunctions)
            {
                SymConfig.Symbol = (int)this.SYMBOL_2D;
                switch (this.SYMBOL_2D)
                {
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_ISBT:
                        cfgISBT.bEnabled = checkBox1.Checked;

                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgISBT));
                        Marshal.StructureToPtr(cfgISBT, SymConfig.pConfigData, false);
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_BPO:
                        cfgBPO.bEnabled = checkBox1.Checked;

                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgBPO));
                        Marshal.StructureToPtr(cfgBPO, SymConfig.pConfigData, false);
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CANPOST:
                        cfgCANPost.bEnabled = checkBox1.Checked;

                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCANPost));
                        Marshal.StructureToPtr(cfgCANPost, SymConfig.pConfigData, false);
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_JAPOST:
                        cfgJAPost.bEnabled = checkBox1.Checked;

                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgJAPost));
                        Marshal.StructureToPtr(cfgJAPost, SymConfig.pConfigData, false);
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_DUTCHPOST:
                        cfgDutchPost.bEnabled = checkBox1.Checked;

                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgDutchPost));
                        Marshal.StructureToPtr(cfgDutchPost, SymConfig.pConfigData, false);
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_TLCODE39:
                        cfgTLCode39.bEnabled = checkBox1.Checked;

                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgTLCode39));
                        Marshal.StructureToPtr(cfgTLCode39, SymConfig.pConfigData, false);
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_TRIOPTIC:
                        cfgTrioptic.bEnabled = checkBox1.Checked;

                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgTrioptic));
                        Marshal.StructureToPtr(cfgTrioptic, SymConfig.pConfigData, false);
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE32:
                        cfgCode32.bEnabled = checkBox1.Checked;

                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode32));
                        Marshal.StructureToPtr(cfgCode32, SymConfig.pConfigData, false);
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_COUPONCODE:
                        cfgCuponCode.bEnabled = checkBox1.Checked;

                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCuponCode));
                        Marshal.StructureToPtr(cfgCuponCode, SymConfig.pConfigData, false);
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_AUSPOST:
                        cfgAUSPost.bEnabled = checkBox1.Checked;

                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgAUSPost));
                        Marshal.StructureToPtr(cfgAUSPost, SymConfig.pConfigData, false);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                SymConfig.Symbol = (int)this.SYMBOL_1D;
                switch (this.SYMBOL_1D)
                {
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE128:
                        cfgCode128.bEnabled = checkBox1.Checked;
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode128));
                        Marshal.StructureToPtr(cfgCode128, SymConfig.pConfigData, false);
                        break;
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_ISBT128:
                        cfgISBT128.bEnabled = checkBox1.Checked;
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgISBT128));
                        Marshal.StructureToPtr(cfgISBT128, SymConfig.pConfigData, false);
                        break;
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CHINESE25:
                        cfgChinese25.bEnabled = checkBox1.Checked;
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgChinese25));
                        Marshal.StructureToPtr(cfgChinese25, SymConfig.pConfigData, false);
                        break;
                }
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
            if (frmMain.Enable2DFunctions)
            {
                SymConfig = new NBarcodeApi.SYMBOL_CONFIG();
                SymConfig.Symbol = (int)this.SYMBOL_2D;

                switch (this.SYMBOL_2D)
                {
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_ISBT:
                        //SetLength(1, 3750);
                        cfgISBT = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_ISBT();
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgISBT));
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_BPO:
                        //SetLength(0, 80);
                        cfgBPO = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_BPO();
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgBPO));
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CANPOST:
                        //SetLength(1, 81);
                        cfgCANPost = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CANPOST();
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCANPost));
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_JAPOST:
                        //SetLength(0, 80);
                        cfgJAPost = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_JAPOST();
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgJAPost));
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_DUTCHPOST:
                        //SetLength(1, 1500);
                        cfgDutchPost = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_DUTCHPOST();
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgDutchPost));
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_TLCODE39:
                        //SetLength(1, 366);
                        cfgTLCode39 = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_TLC39();
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgTLCode39));
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_TRIOPTIC:
                        //SetLength(1, 2750);
                        cfgTrioptic = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_TRIOPTIC();
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgTrioptic));
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE32:
                        //SetLength(1, 3500);
                        cfgCode32 = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE32();
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode32));
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_COUPONCODE:
                        //SetLength(4, 74);
                        cfgCuponCode = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_COUPONCODE();
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCuponCode));
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_AUSPOST:
                        //SetLength(1, 48);
                        cfgAUSPost = new NBarcodeApi.N2DSymbols.CONFIG_2DSWD_AUSPOST();
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgAUSPost));
                        break;
                }
            }
            else
            {
                SymConfig = new NBarcodeApi.SYMBOL_CONFIG();
                SymConfig.Symbol = (int)this.SYMBOL_1D;

                switch (this.SYMBOL_1D)
                {
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE128:
                        cfgCode128 = new NBarcodeApi.N1DSymbols.CONFIG_1D_CODE128();
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgCode128));
                        break;
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_ISBT128:
                        cfgISBT128 = new NBarcodeApi.N1DSymbols.CONFIG_1D_ISBT128();
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgISBT128));
                        break;
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CHINESE25:
                        cfgChinese25 = new NBarcodeApi.N1DSymbols.CONFIG_1D_CHINESE25();
                        SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgChinese25));
                        break;
                }
            }

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            if (frmMain.Enable2DFunctions)
            {
                switch (this.SYMBOL_2D)
                {
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_ISBT:
                        cfgISBT = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_ISBT)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_ISBT));
                        checkBox1.Checked = cfgISBT.bEnabled;
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_BPO:
                        cfgBPO = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_BPO)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_BPO));
                        checkBox1.Checked = cfgBPO.bEnabled;
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CANPOST:
                        cfgCANPost = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CANPOST)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CANPOST));
                        checkBox1.Checked = cfgCANPost.bEnabled;
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_JAPOST:
                        cfgJAPost = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_JAPOST)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_JAPOST));
                        checkBox1.Checked = cfgJAPost.bEnabled;
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_DUTCHPOST:
                        cfgDutchPost = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_DUTCHPOST)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_DUTCHPOST));
                        checkBox1.Checked = cfgDutchPost.bEnabled;
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_TLCODE39:
                        cfgTLCode39 = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_TLC39)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_TLC39));
                        checkBox1.Checked = cfgTLCode39.bEnabled;
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_TRIOPTIC:
                        cfgTrioptic = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_TRIOPTIC)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_TRIOPTIC));
                        checkBox1.Checked = cfgTrioptic.bEnabled;
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_CODE32:
                        cfgCode32 = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE32)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_CODE32));
                        checkBox1.Checked = cfgCode32.bEnabled;
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_COUPONCODE:
                        cfgCuponCode = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_COUPONCODE)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_COUPONCODE));
                        checkBox1.Checked = cfgCuponCode.bEnabled;
                        break;
                    case NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.SYMBOL_2DSWD_AUSPOST:
                        cfgAUSPost = (NBarcodeApi.N2DSymbols.CONFIG_2DSWD_AUSPOST)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N2DSymbols.CONFIG_2DSWD_AUSPOST));
                        checkBox1.Checked = cfgAUSPost.bEnabled;
                        break;
                }
            }
            else
            {
                switch (this.SYMBOL_1D)
                {
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CODE128:
                        cfgCode128 = (NBarcodeApi.N1DSymbols.CONFIG_1D_CODE128)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N1DSymbols.CONFIG_1D_CODE128));
                        checkBox1.Checked = cfgCode128.bEnabled;
                        break;
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_ISBT128:
                        cfgISBT128 = (NBarcodeApi.N1DSymbols.CONFIG_1D_ISBT128)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N1DSymbols.CONFIG_1D_ISBT128));
                        checkBox1.Checked = cfgISBT128.bEnabled;
                        break;
                    case NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_CHINESE25:
                        cfgChinese25 = (NBarcodeApi.N1DSymbols.CONFIG_1D_CHINESE25)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N1DSymbols.CONFIG_1D_CHINESE25));
                        checkBox1.Checked = cfgChinese25.bEnabled;
                        break;
                }
            }

            Marshal.FreeHGlobal(SymConfig.pConfigData);
            SymConfig.pConfigData = IntPtr.Zero;
            UnmanagedAPI.PlaySound(@"\Windows\Success.wav");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if(frmMain.Enable2DFunctions)
                SaveConfig();
        }
    }
}