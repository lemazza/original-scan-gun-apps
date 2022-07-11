using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using NRfidApi;

namespace Rfid_Demo
{
    public partial class Form1 : Form
    {
        ArrayList Tags;
        RfidApi rfid;
        Point PanelLocationShow;
        Point PanelLocationHide;

        #region  ########## Play_Sound ##########
        [DllImport("coredll.dll")]
        private static extern int PlaySound(string szSound, IntPtr hModule, int flags);

        private enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0,         // play synchronously (default)
            SND_ASYNC = 0x1,        // play asynchronously
            SND_NODEFAULT = 0x2,    // silence (!default) if sound not found
            SND_MEMORY = 0x4,       // pszSound points to a memory file
            SND_LOOP = 0x8,         // loop the sound until next sndPlaySound
            SND_NOSTOP = 0x10,      // don't stop any currently playing sound
            SND_NOWAIT = 0x2000,    // don't wait if the driver is busy
            SND_ALIAS = 0x10000,    // name is a registry alias
            SND_ALIAS_ID = 0x110000,// alias is a predefined ID
            SND_FILENAME = 0x20000, // name is file name
            SND_RESOURCE = 0x40004, // name is resource name or atom
        };
        public void Play_Sound(string fileName)
        {
           PlaySound(fileName, IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC));
        }
        public void Play_Sound_NOSTOP(string fileName)
        {
            PlaySound(fileName, IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC | PlaySoundFlags.SND_NOSTOP));
        }
        #endregion

        int[] KeyValues = { 0xD3, // "SCAN" key
                            0xD2, // Gun trigger
                            0xEF, // "F7" key
                            0xF0  // "F8" key
                          };

      // Inventory
        public void InventoryProc(string Msg, RFID_CALLBACK_TYPE Type)
        {
            // Memory modules of the Data from the tags and read through it runs so Callback delegate.
            if (Type == RFID_CALLBACK_TYPE.RFIDCALLBACKTYPE_DATA)
            {
                if (Tags.Contains(Msg))
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[0].Text.Equals(Msg))
                        {
                            item.SubItems[1].Text = Convert.ToString(Convert.ToInt32(item.SubItems[1].Text) + 1);
                            break;
                        }
                    }
                }
                else
                {
                    ListViewItem item = new ListViewItem(Msg);
                    item.SubItems.Add("1");
                    int count = listView1.Items.Count;
                    if (count == 0 || count % 2 == 0)
                        item.BackColor = Color.LightCyan;
                    else
                        item.BackColor = Color.AntiqueWhite;
                    listView1.Items.Add(item);
                    Tags.Add(Msg);
                    label1.Text = Tags.Count.ToString();
                }

                Play_Sound_NOSTOP(@"\Windows\Success.wav");
            }
            // Run from the command module to receive the results of running Callback delegate.
            else if (Type == RFID_CALLBACK_TYPE.RFIDCALLBACKTYPE_REPLY)
            {
                if (Msg.Equals("OK") || Msg.Equals("Multi Read Stop") || Msg.Equals(""))
                {
                    button1.Text = "Start";
                }
                else
                {
                    MessageBox.Show(Msg);
                    button1.Text = "Start";
                }
            }
        }

        // Read/Write
        public void ReadWriteProc(string Msg, RFID_CALLBACK_TYPE Type)
        {
            if (Type == RFID_CALLBACK_TYPE.RFIDCALLBACKTYPE_DATA)
            {
                textBox2.Text = Msg;
                Play_Sound_NOSTOP(@"\Windows\Success.wav");
            }
            else
            {
                if (!Msg.Equals("OK"))
                {
                    MessageBox.Show(Msg, "Error");
                }
            }
        }

        // Lock/Kill
        public void LockKillProc(string Msg, RFID_CALLBACK_TYPE Type)
        {

        }

        // Callback function registered by the application,
        public void CallbackProc(RFIDCALLBACKDATA CallbackData)
        {
            string Msg = new string(new char[512]);

            // Data GetResult function and read the values separated by a CallbackType Reply to the reporting process.
            rfid.GetResult(Msg, CallbackData.CallbackType, CallbackData.wParam, CallbackData.lParam);
            Msg = Msg.Substring(0, Msg.IndexOf("\0"));

            switch (tabControl1.SelectedIndex)
            {
                case 0: // Inventory
                    InventoryProc(Msg, CallbackData.CallbackType);
                    break;
                case 1: // Read/Write
                    ReadWriteProc(Msg, CallbackData.CallbackType);
                    break;
                case 2: // Lock/Kill
                    LockKillProc(Msg, CallbackData.CallbackType);
                    break;
                case 3: // Configuration
                    break;
                default:
                    break;
            }

        }


        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.WindowState = FormWindowState.Maximized;
            PanelLocationShow = panel1.Location;
            PanelLocationHide = panel2.Location;

            comboBox1.SelectedIndex = 0;
            Tags = new ArrayList();

            rfid = new RfidApi();

            // RFID reader module to apply power to. 
            rfid.PowerOn();

            // RFID reader module for communication with the port is open.
            if (rfid.Open() == RFID_RESULT.RFID_RESULT_SUCCESS)
            {
                //===============================================================================
                //  RFID reader tag data read by the application at the end to register 
                // callback fuction is called.
                rfid.SetCallback(new RfidCallbackProc(CallbackProc));
            }
            else
            {
                //  RFID reader module to an authorized power is removed.
                rfid.PowerOff();
                MessageBox.Show("RFID Open Failed");

                this.Close();
            }
        }
        
        // trigger KeyDown
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (Array.IndexOf(KeyValues, e.KeyValue) > -1)
                {
                    if (button1.Text.Equals("Start"))
                        button1_Click(null, null);
                }
            }
            base.OnKeyDown(e);
        }

        // trigger KeyUp
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (Array.IndexOf(KeyValues, e.KeyValue) > -1)
                {
                    if (button1.Text.Equals("Stop"))
                        button1_Click(null, null);
                }
            }
            base.OnKeyUp(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
     // Tag reading on the type of tag(ISO-1800-6B or ISO-18000-6C[GEN2]) can be read by specifying a UID.
            RFID_READ_TYPE ReadType;

            if (button1.Text.Equals("Start"))
            {
                button1.Text = "Stop";

                if (comboBox1.SelectedIndex == 0)
                    ReadType = RFID_READ_TYPE.EPC_GEN2_ONE_TAG;
                else
                    ReadType = RFID_READ_TYPE.EPC_GEN2_MULTI_TAG;
                
                // RFID tag reads from the EPC data.
                rfid.ReadEpc(false, ReadType, String.Empty);
            }
            else
            {
                rfid.Stop();
            }
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
     // RFID reader module, open a port for communication with the close.
            rfid.Close();
            rfid.PowerOff();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Tags.Clear();
            label1.Text = "0";
            listView1.Items.Clear();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rfid.Stop();

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    //============================================================================
                    // module reads the command of execution time. Seconds (sec) units, and perform 
                    // complete or the user from 0 to stop the command will wait until it receives.
                    rfid.OperationTime = 0;
                    break;
                case 1:
                    if (listView1.SelectedIndices.Count > 0)
                    {
                        textBox1.Text = listView1.Items[listView1.SelectedIndices[0]].Text;
                        checkBoxUseMask.Checked = true;
                    }
                    else
                    {
                        textBox1.Text = String.Empty;
                        checkBoxUseMask.Checked = false;
                    }
                    comboOperationType.SelectedIndex = 1;
                    comboMaskMemBank.SelectedIndex = 1;
                    comboReadMemBank.SelectedIndex = 1;
                    comboCmdType.SelectedIndex = 0;
                    comboWriteMemBank.SelectedIndex = 1;
                    comboPermalock.SelectedIndex = 1;
                    numericUpDown1.Value = 2;
                    numericUpDown2.Value = 6;
                    numericUpDown3.Value = (decimal)rfid.OperationTime;
                    break;
                #region xxx
                //case 2:
                //    textBox4.Text = rfid.ProtocolVersion;
                //    textBox16.Text = rfid.HoppingMode.ToString();
                //    numericUpDown5.Value = rfid.OperationTime;
                //    switch (rfid.Session)
                //    {
                //        case SESSION_TYPE.SESSION_0:
                //            radioButton1.Checked = true;
                //            break;
                //        case SESSION_TYPE.SESSION_1:
                //            radioButton2.Checked = true;
                //            break;
                //        case SESSION_TYPE.SESSION_2:
                //            radioButton3.Checked = true;
                //            break;
                //        case SESSION_TYPE.SESSION_3:
                //            radioButton4.Checked = true;
                //            break;
                //    }
                //    numericUpDown6.Value = rfid.PowerLevel;
                //    break;
                #endregion
                case 3:
                    break;
                default:
                    break;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rfid.PowerLevel = (uint)numericUpDown19.Value;
            
            switch (comboCmdType.SelectedIndex)
            {
                case 0:// RFID tag or block from a particular memory bank to read the data unit.
                    CmdReadMemBank();
                    break;
                case 1:// RFID tag in the memory bank of a particular word (2Bytes) units will record data.
                    CmdWriteMemBank();
                    break;
                case 2:
                case 3:// Parameters from field to field is set to true, lock, unlock the.
                    CmdLockUnlockField();
                    break;
                case 4:// Secured state parameters of a given field will not be changed permanently.
                    CmdPermalock();
                    break;
                case 5:// RFID tag does not respond to commands from the reader to kill. Been killed once again unable recover the tag.
                    CmdTagKill();
                    break;
                default:
                    break;
            }
        }

        public RFIDMASKPARAMS GetMaskParams()
        {
           // Tag for the command to perform when called to respond only tags that meet the criteria to be used.
            RFIDMASKPARAMS Mask;

            Mask = new RFIDMASKPARAMS();
            switch (comboMaskMemBank.SelectedIndex)
            {
                case 0: Mask.MemBank = MEM_BANK.RESERVED; break;    // tag kill or access password is stored memory.
                case 1: Mask.MemBank = MEM_BANK.EPC; break;         // StoredCRC, EPC, XPC information is stored by memory.
                case 2: Mask.MemBank = MEM_BANK.TID; break;         // ISO/IEC 15963 allocation class identifier, Tag and serial number are stored.
                case 3: Mask.MemBank = MEM_BANK.USER; break;        // user specific data storage.
                default: break;
            }

            // Of the selected Memory Bank nibble offset.
            Mask.nOffSet = (uint)numericUpDown4.Value;
            // Specified by 4bit mask pattern string.
            Mask.MaskPattern = textBox1.Text.Trim();

            return Mask;
        }

        // RFID tag or block from a particular memory bank to read the data unit.
        public void CmdReadMemBank()
        {
          MEM_BANK MemBank = new MEM_BANK();
            uint nWordPtr, nWordCount;
            string AccessPassword;
            string ReadMemBankData;
            bool isSyncMode = comboOperationType.SelectedIndex == 0 ? true : false;

            textBox2.Text = String.Empty;

            switch (comboReadMemBank.SelectedIndex)
            {
                case 0:
                    MemBank = MEM_BANK.RESERVED;
                    break;
                case 1:
                    MemBank = MEM_BANK.EPC;
                    break;
                case 2:
                    MemBank = MEM_BANK.TID;
                    break;
                case 3:
                    MemBank = MEM_BANK.USER;
                    break;
                default:
                    break;
            }

            nWordPtr = (uint)numericUpDown1.Value;
            nWordCount = (uint)numericUpDown2.Value;

            AccessPassword = textBox14.Text.Trim();

            if (checkBoxUseMask.Checked)
            {
                RFIDMASKPARAMS Mask = GetMaskParams();

                if (isSyncMode)
                {
                    ReadMemBankData = new string(new char[512]);
                    rfid.OperationTime = (uint)numericUpDown3.Value;
                    //===============================================================
                    // isSyncMode       =  TRUE if the synchronously, FALSE if the reading data asynchronously.
                    // MemBank          =  read the memory bank type.
                    // nWordptr         =  started to read my bank offset.
                    // nWordCount       =  size of data read.
                    // bContinuous      =  When a synchronous mode must be set to FALSE.
                    // AccessPassword   =  memory bank at stake when using the lock, NULL if you disable access password.
                    // Mask             =  Mask == NULL if the mask data read without conditions. 
                    //                     Mask != NULL if the mask pattern and a tag match for only perform this function.
                    // ReadMemBankData  =  the synchronous mode(isSyncMode the TRUE) Data is stored in a String variable when the read.
                    RFID_RESULT result = rfid.ReadMemBank(isSyncMode, MemBank, nWordPtr, nWordCount, false, AccessPassword, ref Mask, ReadMemBankData);
                    if (result == RFID_RESULT.RFID_RESULT_SUCCESS)
                        textBox2.Text = ReadMemBankData;
                    else
                        MessageBox.Show(result.ToString(), "Error");
                }
                else
                {
                    rfid.ReadMemBank(isSyncMode, MemBank, nWordPtr, nWordCount, false, AccessPassword, ref Mask, string.Empty);
                }
            }
            else
            {
                if (isSyncMode)
                {
                    ReadMemBankData = new string(new char[512]);
                    rfid.OperationTime = (uint)numericUpDown3.Value;
                    RFID_RESULT result = rfid.ReadMemBank(isSyncMode, MemBank, nWordPtr, nWordCount, false, AccessPassword, ReadMemBankData);
                    if (result == RFID_RESULT.RFID_RESULT_SUCCESS)
                        textBox2.Text = ReadMemBankData;
                    else
                        MessageBox.Show(result.ToString(), "Error");
                }
                else
                {
                    rfid.ReadMemBank(isSyncMode, MemBank, nWordPtr, nWordCount, false, AccessPassword, string.Empty);
                }
            }
        }

        public void CmdWriteMemBank()
        {
             MEM_BANK MemBank = new MEM_BANK();
            uint nWordPtr;
            string AccessPassword;
            bool isSyncMode = comboOperationType.SelectedIndex == 0 ? true : false;
            string WriteData = textBox15.Text.Trim();

            textBox2.Text = String.Empty;

            switch (comboReadMemBank.SelectedIndex)
            {
                case 0:
                    MemBank = MEM_BANK.RESERVED;
                    break;
                case 1:
                    MemBank = MEM_BANK.EPC;
                    break;
                case 2:
                    MemBank = MEM_BANK.TID;
                    break;
                case 3:
                    MemBank = MEM_BANK.USER;
                    break;
                default:
                    break;
            }

            nWordPtr = (uint)numericUpDown1.Value;
            AccessPassword = textBox14.Text.Trim();

            if (checkBoxUseMask.Checked)
            {
                RFIDMASKPARAMS Mask = GetMaskParams();
                if (isSyncMode)
                {
                    rfid.OperationTime = (uint)numericUpDown3.Value;
                    //======================================================================================
                    // isSyncMode       =  TRUE if the data recorded synchronously, FALSE if the data write operations asynchronously.
                    // MemBank          =  write memory bank type.
                    // nWordPtr         =  started to write my bank offset.
                    // WriteData        =  memory bank data on the record.
                    // bContinuous      =  When a synchronous mode must be set to FALSE.
                    // AccessPassword   =  memory bank at stake when using the lock, NULL if you disable access password.
                    // Mask             =  Apply mask pattern, mask pattern matching is performed only on the tag.
                    //                     if NULL, do not use the mask pattern.
                    RFID_RESULT result = rfid.WriteMemBank(isSyncMode, MemBank, nWordPtr, WriteData, false, AccessPassword, ref Mask);
                    MessageBox.Show(result.ToString());
                }
                else
                {
                    rfid.WriteMemBank(isSyncMode, MemBank, nWordPtr, WriteData, false, AccessPassword, ref Mask);
                }
            }
            else
            {
                if (isSyncMode)
                {
                    rfid.OperationTime = (uint)numericUpDown3.Value;
                    RFID_RESULT result = rfid.WriteMemBank(isSyncMode, MemBank, nWordPtr, WriteData, false, AccessPassword);
                }
                else
                {
                    rfid.WriteMemBank(isSyncMode, MemBank, nWordPtr, WriteData, false, AccessPassword);
                }
            }
        }

        // Parameters from field to field is set to true, lock, unlock the.
        public void CmdLockUnlockField()
        {
              string AccessPassword;
            bool isSyncMode = comboOperationType.SelectedIndex == 0 ? true : false;
            bool isLock = true;
            LOCKUNLOCKFIELD LockParams = new LOCKUNLOCKFIELD();

            AccessPassword = textBox14.Text.Trim();

            LockParams.bAccessPassword = bAccessPwd.Checked;
            LockParams.bKillPassword = bKillPwd.Checked;
            LockParams.bEPC = bEpc.Checked;
            LockParams.bTID = bTid.Checked;
            LockParams.bUSER = bUser.Checked;

            if (comboCmdType.SelectedIndex == 2)
                isLock = true;
            else if (comboCmdType.SelectedIndex == 3)
                isLock = true;

            if (isLock) // LockField
            {
                if (checkBoxUseMask.Checked)
                {
                    RFIDMASKPARAMS Mask = GetMaskParams();
                    if (isSyncMode)
                    {
                        rfid.OperationTime = (uint)numericUpDown3.Value;
                        //======================================================================
                        // isSyncMode       = TRUE if the lock field is in sync. FALSE if the lock operation asynchronously.
                        // LockParams       = lock applied field.
                        // bContinuous      = When a synchronous mode must be set to FALSE.
                        // AccessPassword   = memory bank at stake when using the lock, NULL if you disable access password.
                        // Mask             =  Apply mask pattern, mask pattern matching is performed only on the tag.
                        //                     if NULL, do not use the mask pattern.
                        RFID_RESULT result = rfid.LockField(isSyncMode, ref LockParams, false, AccessPassword, ref Mask);
                        MessageBox.Show(result.ToString());
                    }
                    else
                    {
                        rfid.LockField(isSyncMode, ref LockParams, false, AccessPassword, ref Mask);
                    }
                }
                else
                {
                    if (isSyncMode)
                    {
                        rfid.OperationTime = (uint)numericUpDown3.Value;
                        RFID_RESULT result = rfid.LockField(isSyncMode, ref LockParams, false, AccessPassword);
                        MessageBox.Show(result.ToString());
                    }
                    else
                    {
                        rfid.LockField(isSyncMode, ref LockParams, false, AccessPassword);
                    }
                }
            }
            else // UnLockField
            {
                if (checkBoxUseMask.Checked)
                {
                    RFIDMASKPARAMS Mask = GetMaskParams();
                    if (isSyncMode)
                    {
                        rfid.OperationTime = (uint)numericUpDown3.Value;
                        //======================================================================
                        // isSyncMode       = TRUE if the lock field is in sync. FALSE if the lock operation asynchronously.
                        // LockParams       = unlock applied field.
                        // bContinuous      = When a synchronous mode must be set to FALSE.
                        // AccessPassword   = memory bank at stake when using the lock, NULL if you disable access password.
                        // Mask             =  Apply mask pattern, mask pattern matching is performed only on the tag.
                        //                     if NULL, do not use the mask pattern.
                        RFID_RESULT result = rfid.UnLockField(isSyncMode, ref LockParams, false, AccessPassword, ref Mask);
                        MessageBox.Show(result.ToString());
                    }
                    else
                    {
                        rfid.UnLockField(isSyncMode, ref LockParams, false, AccessPassword, ref Mask);
                    }
                }
                else
                {
                    if (isSyncMode)
                    {
                        rfid.OperationTime = (uint)numericUpDown3.Value;
                        RFID_RESULT result = rfid.UnLockField(isSyncMode, ref LockParams, false, AccessPassword);
                        MessageBox.Show(result.ToString());
                    }
                    else
                    {
                        rfid.UnLockField(isSyncMode, ref LockParams, false, AccessPassword);
                    }
                }
            }
        }

        // Secured state parameters of a given field will not be changed permanently.
        public void CmdPermalock()
        {
           string AccessPassword;
            bool isSyncMode = comboOperationType.SelectedIndex == 0 ? true : false;
            PERMALOCK_FIELD PermalockField = new PERMALOCK_FIELD();

            AccessPassword = textBox14.Text.Trim();

            switch (comboPermalock.SelectedIndex)
            {
                case 0:
                    PermalockField = PERMALOCK_FIELD.ACCESS_PASSWORD;
                    break;
                case 1:
                    PermalockField = PERMALOCK_FIELD.KILL_PASSWORD;
                    break;
                case 2:
                    PermalockField = PERMALOCK_FIELD.EPC;
                    break;
                case 3:
                    PermalockField = PERMALOCK_FIELD.TID;
                    break;
                case 4:
                    PermalockField = PERMALOCK_FIELD.USER;
                    break;
                default:
                    break;
            }

            if (checkBoxUseMask.Checked)
            {
                RFIDMASKPARAMS Mask = GetMaskParams();
                if (isSyncMode)
                {
                    rfid.OperationTime = (uint)numericUpDown3.Value;
                    //=========================================================================================
                    // isSyncMode               = Permalock synchronously with the field is TRUE. if FALSE Permalock operations asynchronously.
                    // PermalockField           = Permalock applied field.
                    // checkBoxSecured.Checked  = If you have permanent access password access to true, False if you are permanently accessible without access password
                    // bContinuous              = When a synchronous mode must be set to FALSE.
                    // AccessPassword           = Used when Permalock access password, the value of this tag must be pre-populated with.
                    // Mask                     = Apply mask pattern, mask pattern matching is performed only on the tag.
                    //                            if NULL, do not use the mask pattern.
                    RFID_RESULT result = rfid.Permalock(isSyncMode, PermalockField, checkBoxSecured.Checked, false, AccessPassword, ref Mask);
                    MessageBox.Show(result.ToString());
                }
                else
                {
                    rfid.Permalock(isSyncMode, PermalockField, checkBoxSecured.Checked, false, AccessPassword, ref Mask);
                }
            }
            else
            {
                if (isSyncMode)
                {
                    rfid.OperationTime = (uint)numericUpDown3.Value;
                    RFID_RESULT result = rfid.Permalock(isSyncMode, PermalockField, checkBoxSecured.Checked, false, AccessPassword);
                    MessageBox.Show(result.ToString());
                }
                else
                {
                    rfid.Permalock(isSyncMode, PermalockField, checkBoxSecured.Checked, false, AccessPassword);
                }
            }
        }

        // RFID tag does not respond to commands from the reader to kill. Been killed once again unable recover the tag.
        public void CmdTagKill()
        {
               string KillPassword = textBox3.Text.Trim();
            bool isSyncMode = comboOperationType.SelectedIndex == 0 ? true : false;

            if (checkBoxUseMask.Checked)
            {
                RFIDMASKPARAMS Mask = GetMaskParams();
                if (isSyncMode)
                {
                    rfid.OperationTime = (uint)numericUpDown3.Value;
                    //===================================================================
                    // isSyncMode   = Apply mask pattern, mask pattern matching is Performed only on the tag, if NULL, do not use the mask pattern.
                    // KillPassword = Kill when you use the kill password.
                    // bContinuous  = When a synchronous mode must be set to FALSE.
                    // Mask         = Apply mask pattern, mask pattern matching is performed only on the tag.
                    //                if NULL, do not use the mask pattern.
                    RFID_RESULT result = rfid.KillTag(isSyncMode, KillPassword, false, ref Mask);
                    MessageBox.Show(result.ToString());
                }
                else
                {
                    rfid.KillTag(isSyncMode, KillPassword, false, ref Mask);
                }
            }
            else
            {
                RFIDMASKPARAMS Mask = GetMaskParams();
                if (isSyncMode)
                {
                    rfid.OperationTime = (uint)numericUpDown3.Value;
                    RFID_RESULT result = rfid.KillTag(isSyncMode, KillPassword, false);
                    MessageBox.Show(result.ToString());
                }
                else
                {
                    rfid.KillTag(isSyncMode, KillPassword, false);
                }
            }
        }

        private void comboOperationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboOperationType.SelectedIndex == 0)
            {
                numericUpDown3.Value = 3;
                numericUpDown3.Enabled = true;
            }
            else
                numericUpDown3.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            rfid.Stop();
        }

        private void comboCmdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboCmdType.SelectedIndex)
            {
                case 0:
                    panel1.Location = PanelLocationShow;
                    panel2.Location = PanelLocationHide;
                    panel3.Location = PanelLocationHide;
                    panel4.Location = PanelLocationHide;
                    panel5.Location = PanelLocationHide;
                    break;
                case 1:
                    panel2.Location = PanelLocationShow;
                    panel1.Location = PanelLocationHide;
                    panel3.Location = PanelLocationHide;
                    panel4.Location = PanelLocationHide;
                    panel5.Location = PanelLocationHide;
                    break;
                case 2:
                case 3:
                    panel3.Location = PanelLocationShow;
                    panel1.Location = PanelLocationHide;
                    panel2.Location = PanelLocationHide;
                    panel4.Location = PanelLocationHide;
                    panel5.Location = PanelLocationHide;
                    break;
                case 4:
                    panel4.Location = PanelLocationShow;
                    panel1.Location = PanelLocationHide;
                    panel2.Location = PanelLocationHide;
                    panel3.Location = PanelLocationHide;
                    panel5.Location = PanelLocationHide;
                    break;
                case 5:
                    panel5.Location = PanelLocationShow;
                    panel1.Location = PanelLocationHide;
                    panel2.Location = PanelLocationHide;
                    panel3.Location = PanelLocationHide;
                    panel4.Location = PanelLocationHide;
                    break;
                default:
                    break;
            }
        }
    
    }
}