using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NBarcodeApi;

namespace BarcodeSetup
{
    public partial class frmEnableStatus : Form
    {
        public frmEnableStatus()
        {
            InitializeComponent();

            LoadEnableStatus();
        }

        public void LoadEnableStatus()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;

            int nMax = frmMain.Enable2DFunctions ? (int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.NUM_OF_2DSWD_SYMBOLOGIES :
                                                   (int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.NUM_OF_1D_SYMBOLOGIES;
            NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D Symbol1D;
            NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD Symbol2D;

            bool[] SymbolTable = new bool[nMax];
            BARCODE_RESULT result = frmMain.barcode.GetEnableStateAll(ref SymbolTable);
            System.Diagnostics.Debug.WriteLine(result.ToString());
            for (int i = 0; i < nMax; i++)
            {
                ListViewItem item = new ListViewItem();

                if (frmMain.Enable2DFunctions)
                {
                    Symbol2D = (NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD)i;
                    item.Text = (string)frmMain.ht2DSymbolName[Symbol2D];//Symbol2D.ToString().Replace("SYMBOL_2DSWD_", "");
                }
                else
                {
                    Symbol1D = (NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D)i;
                    item.Text = Symbol1D.ToString().Replace("SYMBOL_1D_", "");
                }

                item.Checked = SymbolTable[i];
                listView1.Items.Add(item);
            }

            this.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool[] EnabledSymbolTable = null;
            bool[] DisabledSymbolTable = null;
            int nIdx = 0;

            if (frmMain.Enable2DFunctions)
            {
                EnabledSymbolTable = new bool[(int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.NUM_OF_2DSWD_SYMBOLOGIES];
                DisabledSymbolTable = new bool[(int)NBarcodeApi.N2DSymbols.SYMBOLOGIES_2DSWD.NUM_OF_2DSWD_SYMBOLOGIES];
            }
            else
            {
                EnabledSymbolTable = new bool[(int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.NUM_OF_1D_SYMBOLOGIES];
                DisabledSymbolTable = new bool[(int)NBarcodeApi.N1DSymbols.SYMBOLOGIES_1D.NUM_OF_1D_SYMBOLOGIES];
            }

            foreach (ListViewItem item in listView1.Items)
            {               
                EnabledSymbolTable[nIdx] = item.Checked;
                DisabledSymbolTable[nIdx++] = !item.Checked;
            }

            Cursor.Current = Cursors.WaitCursor;
            BARCODE_RESULT result = frmMain.barcode.EnableSymbologies(EnabledSymbolTable);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                Cursor.Current = Cursors.Default;
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                MessageBox.Show("EnableSymbologies: " + result.ToString());
                return;
            }

            result = frmMain.barcode.DisableSymbologies(DisabledSymbolTable);
            if (result != BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                Cursor.Current = Cursors.Default;
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                MessageBox.Show("DisableSymbologies: " + result.ToString());
                return;
            }

            Cursor.Current = Cursors.Default;
            UnmanagedAPI.PlaySound(@"\Windows\Success.wav");
        }
    }
}