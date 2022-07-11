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
    public partial class frmGeneral : Form
    {
        private NBarcodeApi.GENERAL_CONFIG cfgGeneral;

        public frmGeneral()
        {
            InitializeComponent();
            this.Text = "General Configuration";

            comboBox1.Items.Add("Linear Security Levle1");
            comboBox1.Items.Add("Linear Security Levle2");
            comboBox1.Items.Add("Linear Security Levle3");
            comboBox1.Items.Add("Linear Security Levle4");

            comboBox2.Items.Add("Narrow");
            comboBox2.Items.Add("Wide");

            cfgGeneral = new NBarcodeApi.GENERAL_CONFIG();
            BARCODE_RESULT result = frmMain.barcode.GetGeneralConfig(ref cfgGeneral);
            System.Diagnostics.Debug.WriteLine("result: " + result.ToString());
            System.Diagnostics.Debug.WriteLine(String.Format("SecurityLevel:{0}, Bi-directional:{1}", cfgGeneral.nLinearCodeSecurityLevel, cfgGeneral.bBiDirectionalRedundancy.ToString()));
            System.Diagnostics.Debug.WriteLine("Angle: " + cfgGeneral.nAngle);

            comboBox1.SelectedIndex = (cfgGeneral.nLinearCodeSecurityLevel - 1);
            checkBox1.Checked = cfgGeneral.bBiDirectionalRedundancy;
            if (cfgGeneral.nAngle == 5)
                comboBox2.SelectedIndex = 0;
            else if (cfgGeneral.nAngle == 6)
                comboBox2.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int SecLevel = 0;
            bool Bi_directional_redundancy = false;
            int ScanAngle = 0;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    SecLevel = 1;
                    break;
                case 1:
                    SecLevel = 2;
                    break;
                case 2:
                    SecLevel = 3;
                    break;
                case 3:
                    SecLevel = 4;
                    break;
            }

            Bi_directional_redundancy = checkBox1.Checked;

            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    ScanAngle = 5;
                    break;
                case 1:
                    ScanAngle = 6;
                    break;
            }

            cfgGeneral.nLinearCodeSecurityLevel = SecLevel;
            cfgGeneral.bBiDirectionalRedundancy = Bi_directional_redundancy;
            cfgGeneral.nAngle = ScanAngle;

            Cursor.Current = Cursors.WaitCursor;
            BARCODE_RESULT result = frmMain.barcode.SetGeneralConfig(cfgGeneral);
            Cursor.Current = Cursors.Default;
            if (result == BARCODE_RESULT.BARCODE_RESULT_SUCCESS)
            {
                UnmanagedAPI.PlaySound(@"\Windows\Success.wav");
            }
            else
            {
                UnmanagedAPI.PlaySound(@"\Windows\Fail.wav");
                MessageBox.Show("SetGeneralCofig: " + result.ToString());
            }
        }
    }
}