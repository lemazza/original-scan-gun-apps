using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NRfidApi;

/* 
 * This demonstration requires the most recent firmware installed on the
 * internal RFID module. Handhelds produced after September, 2013 may
 * have the updated RFID firmware, but older units need to first have that
 * firmware update performed. You can query the RFID module for its
 * version number with the FirmwareVersion() command. If it reports 1.3.37
 * (1.3.87 for China/Japan/Europe), then it is updated.
 */
namespace AlienBlockReadLockTest
{
    public partial class Form1 : Form
    {
        RfidApi rfid = null;
        // This demo is designed to work with one single tag, so it sets a mask for a particular EPC.
        // The EPC of the tag should start with the value of EPC_HIGGS3:
        string EPC_HIGGS3 = "BBBB0042";

        // Some mask types require individual bytes to be specified:
        byte maskByte0 = 0xBB;          //   1st byte of mask,
        byte maskByte1 = 0xBB;          //   2nd byte of mask,
        byte maskByte2 = 0x00;          //   3rd byte of mask,
        byte maskByte3 = 0x42;          //   4th byte of mask.

        // Applying locks to a tag have no effect unless the tag's Access Password is also set.
        // Your tag should have this data already stored in the Access Password field:
        string ACCESS_PWD = "12345678";

        public Form1()
        {
            InitializeComponent();

            RFID_RESULT result = RFID_RESULT.RFID_RESULT_UNKNOWN;
            Cursor.Current = Cursors.WaitCursor;
            rfid = new RfidApi();
            result = rfid.PowerOn();
            if (result != RFID_RESULT.RFID_RESULT_SUCCESS)
            {
                MessageBox.Show(result.ToString());
                Application.Exit();
            }

            result = rfid.Open();
            if (result != RFID_RESULT.RFID_RESULT_SUCCESS)
            {
                rfid.PowerOff();
                MessageBox.Show(result.ToString());
                Application.Exit();
            }

            rfid.SetCallback(new RfidCallbackProc(myCallbackProc));

            comboBox1.Items.Add("RESERVED");
            comboBox1.Items.Add("EPC");
            comboBox1.Items.Add("TID");
            comboBox1.Items.Add("USER");
            comboBox1.SelectedIndex = 3;

            textBox1.Text = "F1F2F3F4F5F6F7F8";
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            rfid.Close();
            rfid.PowerOff();
        }

        public void myCallbackProc(RFIDCALLBACKDATA cbData)
        {
            string data = new string(new char[2048]);
            rfid.GetResult(data, cbData.CallbackType, cbData.wParam, cbData.lParam);

            data = data.Substring(0, data.IndexOf(Char.MinValue));
            listBox1.Items.Add(data);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rfid.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int maskType = 0;
            RFID_RESULT result = RFID_RESULT.RFID_RESULT_UNKNOWN;

            if (maskType == 2)
            {
                /// Version using MASKPARAMS
                RFIDMASKPARAMS mask = new RFIDMASKPARAMS();
                mask.MemBank = MEM_BANK.EPC;
                mask.nOffSet = 8;
                mask.MaskPattern = EPC_HIGGS3;
                result = rfid.AlienBlockReadLock(false, MEM_BANK.USER, 0xA0, false, ACCESS_PWD, ref mask);
            }
            else if (maskType == 1)
            {
                /// Version using SELMASKSPARAMS_EX
                rfid.Selects = 1;
                RFIDSELMASKPARAMS_EX[] mask = new RFIDSELMASKPARAMS_EX[1];
                mask[0].MemBank = MEM_BANK.EPC;
                mask[0].OffSet = 32;
                mask[0].Bits = 32;
                mask[0].MaskPattern = new byte[RfidApi.MAX_MASK_BYTES];
                mask[0].MaskPattern[0] = maskByte0;
                mask[0].MaskPattern[1] = maskByte1;
                mask[0].MaskPattern[2] = maskByte2;
                mask[0].MaskPattern[3] = maskByte3;
                mask[0].ActionCode = SELECT_ACTION.ACTION_0;
                mask[0].SelectTarget = SELECT_TARGET.S0;
                result = rfid.AlienBlockReadLockEx(true, MEM_BANK.USER, 0xA0, false, ACCESS_PWD, mask, 1);
            }
            else
            {
                /// Version using MASKPARAMS_EX
                RFIDMASKPARAMS_EX mask = new RFIDMASKPARAMS_EX();
                mask.MemBank = MEM_BANK.EPC;
                mask.nOffSet = 32;
                mask.nBits = 32;
                mask.MaskPattern = new byte[RfidApi.MAX_MASK_BYTES];
                mask.MaskPattern[0] = maskByte0;
                mask.MaskPattern[1] = maskByte1;
                mask.MaskPattern[2] = maskByte2;
                mask.MaskPattern[3] = maskByte3;
                result = rfid.AlienBlockReadLockEx(false, MEM_BANK.USER, 0xA0, false, ACCESS_PWD, ref mask);
            }

            // Display results
            listBox1.Items.Add(result.ToString());
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RFIDMASKPARAMS mask = new RFIDMASKPARAMS();
            mask.MemBank = MEM_BANK.EPC;
            mask.nOffSet = 8;
            mask.MaskPattern = EPC_HIGGS3;

            RFID_RESULT result = rfid.AlienBlockReadLock(false, MEM_BANK.USER, 0x00, false, ACCESS_PWD, ref mask);
            System.Diagnostics.Debug.WriteLine("[TEST] AlienBlockReadLock:" + result.ToString());
        }


        private UInt16 constructBlockMaskFromCheckboxes()
        {
            UInt16 blocks = 0x0000;
            blocks |= (ushort)((cbBlock1.Checked ? 1 : 0) << 15);
            blocks |= (ushort)((cbBlock2.Checked ? 1 : 0) << 14);
            blocks |= (ushort)((cbBlock3.Checked ? 1 : 0) << 13);
            blocks |= (ushort)((cbBlock4.Checked ? 1 : 0) << 12);
            blocks |= (ushort)((cbBlock5.Checked ? 1 : 0) << 11);
            blocks |= (ushort)((cbBlock6.Checked ? 1 : 0) << 10);
            blocks |= (ushort)((cbBlock7.Checked ? 1 : 0) << 9);
            blocks |= (ushort)((cbBlock8.Checked ? 1 : 0) << 8);

            return blocks;
        }


        /// AlienBlockPermalock
        private void button11_Click(object sender, EventArgs e)
        {
            RFID_RESULT result = RFID_RESULT.RFID_RESULT_UNKNOWN;
            int maskType = 3;
            bool useSingleBlockMask = false;
            UInt16 blockMask = constructBlockMaskFromCheckboxes();

            if (maskType == 1)
            {
                /// Version using MASKPARAMS
                RFIDMASKPARAMS mask = new RFIDMASKPARAMS();
                mask.MemBank = MEM_BANK.EPC;
                mask.nOffSet = 8;
                mask.MaskPattern = EPC_HIGGS3;
                if (useSingleBlockMask)
                {
                    // A single ushort for the block mask
                    result = rfid.BlockPermalock(false, 1, MEM_BANK.USER, 0, blockMask, false, ACCESS_PWD, ref mask);
                }
                else
                {
                    // An array of ushorts for a arbitrarily long block mask
                    UInt16[] BlockMask = new UInt16[1];
                    BlockMask[0] = blockMask;
                    result = rfid.BlockPermalock(false, 1, MEM_BANK.USER, 0, (byte)BlockMask.Length, BlockMask, false, ACCESS_PWD, ref mask);
                }
            }
            else if (maskType == 2)
            {
                /// Version using SELMASKPARAMS_EX
                rfid.Selects = 1;
                RFIDSELMASKPARAMS_EX[] mask = new RFIDSELMASKPARAMS_EX[1];
                mask[0].MemBank = MEM_BANK.EPC;
                mask[0].OffSet = 32;
                mask[0].Bits = 32;
                mask[0].MaskPattern = new byte[RfidApi.MAX_MASK_BYTES];
                mask[0].MaskPattern[0] = maskByte0;
                mask[0].MaskPattern[1] = maskByte1;
                mask[0].MaskPattern[2] = maskByte2;
                mask[0].MaskPattern[3] = maskByte3;
                mask[0].ActionCode = SELECT_ACTION.ACTION_0;
                mask[0].SelectTarget = SELECT_TARGET.S0;
                if (useSingleBlockMask)
                {
                    // A single ushort for the block mask
                    result = rfid.BlockPermalockEx(false, 1, MEM_BANK.USER, 0, blockMask, false, ACCESS_PWD, mask, 1);
                }
                else
                {
                    // An array of ushorts for a arbitrarily long block mask
                    UInt16[] BlockMask = new UInt16[1];
                    BlockMask[0] = blockMask;
                    result = rfid.BlockPermalockEx(false, 1, MEM_BANK.USER, 0, (byte)BlockMask.Length, BlockMask, false, ACCESS_PWD, mask, 1);
                }
            }
            else
            {
                /// Version using MASKPARAMS_EX
                RFIDMASKPARAMS_EX mask = new RFIDMASKPARAMS_EX();
                mask.MemBank = MEM_BANK.EPC;
                mask.nOffSet = 32;
                mask.nBits = 32;
                mask.MaskPattern = new byte[RfidApi.MAX_MASK_BYTES];
                mask.MaskPattern[0] = maskByte0;
                mask.MaskPattern[1] = maskByte1;
                mask.MaskPattern[2] = maskByte2;
                mask.MaskPattern[3] = maskByte3;
                if (useSingleBlockMask)
                {
                    // A single ushort for the block mask
                    result = rfid.BlockPermalockEx(false, 1, MEM_BANK.USER, 0, blockMask, false, ACCESS_PWD, ref mask);
                }
                else
                {
                    // An array of ushorts for a arbitrarily long block mask
                    UInt16[] BlockMask = new UInt16[1];
                    BlockMask[0] = blockMask;
                    result = rfid.BlockPermalockEx(false, 1, MEM_BANK.USER, 0, (byte)BlockMask.Length, BlockMask, false, ACCESS_PWD, ref mask);
                }
            }

            // Display results
            System.Diagnostics.Debug.WriteLine("[TEST] BlockPermalock:" + result.ToString());
            listBox1.Items.Add(result.ToString());
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MEM_BANK Bank = MEM_BANK.USER;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Bank = MEM_BANK.RESERVED;  break;
                case 1:
                    Bank = MEM_BANK.EPC;       break;
                case 2:
                    Bank = MEM_BANK.TID;       break;
                case 3:
                    Bank = MEM_BANK.USER;      break;
            }

            uint WordPtr = (uint)numericUpDown1.Value;
            uint WordCnt = (uint)numericUpDown2.Value;


            RFIDMASKPARAMS mask = new RFIDMASKPARAMS();
            mask.MemBank = MEM_BANK.EPC;
            mask.nOffSet = 8;
            mask.MaskPattern = EPC_HIGGS3;

            RFID_RESULT result = rfid.ReadMemBank(  false, Bank, WordPtr, WordCnt, false, 
                                                    chkPwd.Checked ? ACCESS_PWD : null, 
                                                    ref mask, 
                                                    null);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            string Data = textBox1.Text.Trim();
            foreach (char ch in Data)
            {
                char temp = Char.ToUpper(ch);
                if ((temp < '0' || temp > '9') && (temp < 'A' || temp > 'F'))
                {
                    MessageBox.Show("invalid data");
                    textBox1.Focus();
                    textBox1.SelectAll();
                    return;
                }
            }

            MEM_BANK Bank = MEM_BANK.USER;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Bank = MEM_BANK.RESERVED;  break;
                case 1:
                    Bank = MEM_BANK.EPC;       break;
                case 2:
                    Bank = MEM_BANK.TID;       break;
                case 3:
                    Bank = MEM_BANK.USER;      break;
            }

            uint WordPtr = (uint)numericUpDown1.Value;

            RFIDMASKPARAMS mask = new RFIDMASKPARAMS();
            mask.MemBank = MEM_BANK.EPC;
            mask.nOffSet = 8;
            mask.MaskPattern = EPC_HIGGS3;

            RFID_RESULT result = rfid.WriteMemBank(false, Bank, WordPtr, Data, false, chkPwd.Checked ? ACCESS_PWD : null, ref mask);
        }        
    }
}