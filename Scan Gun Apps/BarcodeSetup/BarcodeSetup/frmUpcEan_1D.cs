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
    public partial class frmUpcEan_1D : Form
    {
        private NBarcodeApi.N1DSymbols.CONFIG_1D_UPCEAN cfgUpcEan;
        private NBarcodeApi.SYMBOL_CONFIG SymConfig;

        public frmUpcEan_1D()
        {
            InitializeComponent();
            this.Text = "EPC/EAN Setup";

            listView1.Items.Add(new ListViewItem("UPC-A"));
            listView1.Items.Add(new ListViewItem("UPC-E"));
            listView1.Items.Add(new ListViewItem("UPC-E1"));
            listView1.Items.Add(new ListViewItem("EAN-8"));
            listView1.Items.Add(new ListViewItem("EAN-13"));
            listView1.Items.Add(new ListViewItem("Bookland"));
            listView1.Items.Add(new ListViewItem("UCCEAN 128"));
            listView1.Items.Add(new ListViewItem("UCC Coupon Extended"));
            listView1.Items.Add(new ListViewItem("EAN Zero Extend"));
            listView1.Items.Add(new ListViewItem("Xmit UPC-A Check Digit"));
            listView1.Items.Add(new ListViewItem("Xmit UPC-E Check Digit"));
            listView1.Items.Add(new ListViewItem("Xmit UPC-E1 Check Digit"));
            listView1.Items.Add(new ListViewItem("Convert UPC-E to UPC-A"));
            listView1.Items.Add(new ListViewItem("Convert UPC-E1 to UPC-A"));
            listView1.Items.Add(new ListViewItem("Convert EAN-8 to EAN-13"));

            comboBox1.Items.Add("Ignore");
            comboBox1.Items.Add("Docode");
            comboBox1.Items.Add("Autodiscriminate");
            comboBox1.Items.Add("Smart");
            comboBox1.Items.Add("378/379");
            comboBox1.Items.Add("978");

            textBox1.Text = "0";

            comboBox3.Items.Add("Lvl0");
            comboBox3.Items.Add("Lvl1");
            comboBox3.Items.Add("Lvl2");
            comboBox3.Items.Add("Lvl3");

            comboBox4.Items.Add("No");
            comboBox4.Items.Add("SysChar");
            comboBox4.Items.Add("Sys&Country");

            comboBox5.Items.Add("No");
            comboBox5.Items.Add("SysChar");
            comboBox5.Items.Add("Sys&Country");

            comboBox6.Items.Add("No");
            comboBox6.Items.Add("SysChar");
            comboBox6.Items.Add("Sys&Country");

            LoadConfig();
        }

        private void SaveConfig()
        {
            SymConfig = new NBarcodeApi.SYMBOL_CONFIG();
            SymConfig.Symbol = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_UPCA;

            cfgUpcEan.bUPCAEnabled = listView1.Items[0].Checked;
            cfgUpcEan.bUPCEEnabled = listView1.Items[1].Checked;
            cfgUpcEan.bUPCE1Enabled = listView1.Items[2].Checked;
            cfgUpcEan.bEAN8Enabled = listView1.Items[3].Checked;
            cfgUpcEan.bEAN13Eanbled = listView1.Items[4].Checked;
            cfgUpcEan.bBooklandEnabled = listView1.Items[5].Checked;
            cfgUpcEan.bUCCEAN128Enabled = listView1.Items[6].Checked;
            cfgUpcEan.bUCCCouponExtendedCode = listView1.Items[7].Checked;
            cfgUpcEan.bEANZeroExtend = listView1.Items[8].Checked;
            cfgUpcEan.bXmitUPCACheckChar = listView1.Items[9].Checked;
            cfgUpcEan.bXmitUPCECheckChar = listView1.Items[10].Checked;
            cfgUpcEan.bXmitUPCE1CheckChar = listView1.Items[11].Checked;
            cfgUpcEan.bConvertUPCEToUPCA = listView1.Items[12].Checked;
            cfgUpcEan.bConvertUPCE1ToUPCA = listView1.Items[13].Checked;
            cfgUpcEan.bConvertEAN8ToEAN13 = listView1.Items[14].Checked;

            cfgUpcEan.nDecodeUPCEANSupplemental = (short)comboBox1.SelectedIndex;
            cfgUpcEan.nDecodeUPCEANSupplementalRedundancy = Convert.ToInt16(textBox1.Text);
            cfgUpcEan.nUPCEANSecurityLevel = (short)comboBox3.SelectedIndex;
            cfgUpcEan.nUPCAPreamble = (short)comboBox4.SelectedIndex;
            cfgUpcEan.nUPCEPreamble = (short)comboBox5.SelectedIndex;
            cfgUpcEan.nUPCE1Preamble = (short)comboBox6.SelectedIndex;

            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgUpcEan));
            Marshal.StructureToPtr(cfgUpcEan, SymConfig.pConfigData, false);

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
            cfgUpcEan = new NBarcodeApi.N1DSymbols.CONFIG_1D_UPCEAN();

            SymConfig.Symbol = (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.SYMBOL_1D_UPCA;
            SymConfig.pConfigData = Marshal.AllocHGlobal(Marshal.SizeOf(cfgUpcEan));

            BARCODE_RESULT result = frmMain.barcode.GetSymbologyConfig(ref SymConfig);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                Marshal.FreeHGlobal(SymConfig.pConfigData);
                MessageBox.Show("GetSymbologyConfig: " + result.ToString());
                return;
            }

            cfgUpcEan = (NBarcodeApi.N1DSymbols.CONFIG_1D_UPCEAN)Marshal.PtrToStructure(SymConfig.pConfigData, typeof(NBarcodeApi.N1DSymbols.CONFIG_1D_UPCEAN));

            //checkBox1.Checked = cfgUpcEan.bXmitUPCACheckChar;
            //checkBox2.Checked = cfgUpcEan.bXmitUPCECheckChar;
            //checkBox3.Checked = cfgUpcEan.bXmitUPCE1CheckChar;
            //checkBox4.Checked = cfgUpcEan.bConvertUPCEToUPCA;
            //checkBox5.Checked = cfgUpcEan.bConvertUPCE1ToUPCA;
            //checkBox6.Checked = cfgUpcEan.bEANZeroExtend;
            //checkBox7.Checked = cfgUpcEan.bConvertEAN8ToEAN13;
            //checkBox8.Checked = cfgUpcEan.bUCCCouponExtendedCode;
            //checkBox9.Checked = cfgUpcEan.bUCCEAN128Enabled;
            //checkBox10.Checked = cfgUpcEan.bBooklandEnabled;
            listView1.Items[0].Checked = cfgUpcEan.bUPCAEnabled;
            listView1.Items[1].Checked = cfgUpcEan.bUPCEEnabled;
            listView1.Items[2].Checked = cfgUpcEan.bUPCE1Enabled;
            listView1.Items[3].Checked = cfgUpcEan.bEAN8Enabled;
            listView1.Items[4].Checked = cfgUpcEan.bEAN13Eanbled;
            listView1.Items[5].Checked = cfgUpcEan.bBooklandEnabled;
            listView1.Items[6].Checked = cfgUpcEan.bUCCEAN128Enabled;
            listView1.Items[7].Checked = cfgUpcEan.bUCCCouponExtendedCode;
            listView1.Items[8].Checked = cfgUpcEan.bEANZeroExtend;
            listView1.Items[9].Checked = cfgUpcEan.bXmitUPCACheckChar;
            listView1.Items[10].Checked = cfgUpcEan.bXmitUPCECheckChar;
            listView1.Items[11].Checked = cfgUpcEan.bXmitUPCE1CheckChar;
            listView1.Items[12].Checked = cfgUpcEan.bConvertUPCEToUPCA;
            listView1.Items[13].Checked = cfgUpcEan.bConvertUPCE1ToUPCA;
            listView1.Items[14].Checked = cfgUpcEan.bConvertEAN8ToEAN13;

            comboBox1.SelectedIndex = (int)cfgUpcEan.nDecodeUPCEANSupplemental;
            textBox1.Text = cfgUpcEan.nDecodeUPCEANSupplementalRedundancy.ToString();
            comboBox3.SelectedIndex = (int)cfgUpcEan.nUPCEANSecurityLevel;
            comboBox4.SelectedIndex = (int)cfgUpcEan.nUPCAPreamble;
            comboBox5.SelectedIndex = (int)cfgUpcEan.nUPCEPreamble;
            comboBox6.SelectedIndex = (int)cfgUpcEan.nUPCE1Preamble;

            

            Marshal.FreeHGlobal(SymConfig.pConfigData);
            SymConfig.pConfigData = IntPtr.Zero;

            UnmanagedAPI.PlaySound(@"\Windows\Success.wav");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string temp = textBox1.Text.Trim();
            foreach(char ch in temp)
            {
                if (!Char.IsDigit(ch))
                {
                    textBox1.Focus();
                    textBox1.SelectAll();
                    return;
                }
            }

            SaveConfig();
        }
    }
}