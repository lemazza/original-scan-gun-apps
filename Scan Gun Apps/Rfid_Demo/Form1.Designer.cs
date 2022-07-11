namespace Rfid_Demo
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form

        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.numericUpDown19 = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBoxSecured = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboPermalock = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bUser = new System.Windows.Forms.CheckBox();
            this.bTid = new System.Windows.Forms.CheckBox();
            this.bEpc = new System.Windows.Forms.CheckBox();
            this.bAccessPwd = new System.Windows.Forms.CheckBox();
            this.bKillPwd = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDown20 = new System.Windows.Forms.NumericUpDown();
            this.label83 = new System.Windows.Forms.Label();
            this.comboWriteMemBank = new System.Windows.Forms.ComboBox();
            this.label85 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label82 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboReadMemBank = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboCmdType = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.comboMaskMemBank = new System.Windows.Forms.ComboBox();
            this.comboOperationType = new System.Windows.Forms.ComboBox();
            this.checkBoxUseMask = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(493, 282);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(485, 253);
            this.tabPage1.Text = "Inventory";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlText;
            this.label1.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(6, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 58);
            this.label1.Text = "0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.Items.Add("Single Read");
            this.comboBox1.Items.Add("Multi Read");
            this.comboBox1.Location = new System.Drawing.Point(99, 190);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(128, 23);
            this.comboBox1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(163, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Clear";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(98, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(485, 169);
            this.listView1.TabIndex = 0;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Data";
            this.columnHeader1.Width = 182;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cout";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 45;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.numericUpDown19);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.textBox14);
            this.tabPage2.Controls.Add(this.label82);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.comboCmdType);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.numericUpDown4);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.numericUpDown3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.comboMaskMemBank);
            this.tabPage2.Controls.Add(this.comboOperationType);
            this.tabPage2.Controls.Add(this.checkBoxUseMask);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(485, 253);
            this.tabPage2.Text = "Read/Write/Lock/Kill";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(168, 154);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(54, 20);
            this.button7.TabIndex = 65;
            this.button7.Text = "Stop";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // numericUpDown19
            // 
            this.numericUpDown19.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDown19.Location = new System.Drawing.Point(152, 27);
            this.numericUpDown19.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericUpDown19.Name = "numericUpDown19";
            this.numericUpDown19.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown19.TabIndex = 64;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label24.Location = new System.Drawing.Point(146, 13);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 16);
            this.label24.Text = "Power Level";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.textBox3);
            this.panel5.Location = new System.Drawing.Point(265, 207);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(217, 43);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label17.Location = new System.Drawing.Point(87, 4);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 12);
            this.label17.Text = "Kill Pwd";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBox3.Location = new System.Drawing.Point(57, 19);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(103, 19);
            this.textBox3.TabIndex = 48;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkBoxSecured);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.comboPermalock);
            this.panel4.Location = new System.Drawing.Point(265, 140);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(217, 64);
            // 
            // checkBoxSecured
            // 
            this.checkBoxSecured.Location = new System.Drawing.Point(21, 39);
            this.checkBoxSecured.Name = "checkBoxSecured";
            this.checkBoxSecured.Size = new System.Drawing.Size(104, 22);
            this.checkBoxSecured.TabIndex = 1;
            this.checkBoxSecured.Text = "Secured";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label16.Location = new System.Drawing.Point(142, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 12);
            this.label16.Text = "Action Field";
            // 
            // comboPermalock
            // 
            this.comboPermalock.Items.Add("Access Password");
            this.comboPermalock.Items.Add("Kill Password");
            this.comboPermalock.Items.Add("EPC");
            this.comboPermalock.Items.Add("TID");
            this.comboPermalock.Items.Add("USER");
            this.comboPermalock.Location = new System.Drawing.Point(21, 12);
            this.comboPermalock.Name = "comboPermalock";
            this.comboPermalock.Size = new System.Drawing.Size(117, 23);
            this.comboPermalock.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bUser);
            this.panel3.Controls.Add(this.bTid);
            this.panel3.Controls.Add(this.bEpc);
            this.panel3.Controls.Add(this.bAccessPwd);
            this.panel3.Controls.Add(this.bKillPwd);
            this.panel3.Location = new System.Drawing.Point(265, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(217, 64);
            // 
            // bUser
            // 
            this.bUser.Location = new System.Drawing.Point(150, 35);
            this.bUser.Name = "bUser";
            this.bUser.Size = new System.Drawing.Size(62, 17);
            this.bUser.TabIndex = 4;
            this.bUser.Text = "USER";
            // 
            // bTid
            // 
            this.bTid.Location = new System.Drawing.Point(87, 35);
            this.bTid.Name = "bTid";
            this.bTid.Size = new System.Drawing.Size(51, 17);
            this.bTid.TabIndex = 3;
            this.bTid.Text = "TID";
            // 
            // bEpc
            // 
            this.bEpc.Location = new System.Drawing.Point(10, 35);
            this.bEpc.Name = "bEpc";
            this.bEpc.Size = new System.Drawing.Size(51, 17);
            this.bEpc.TabIndex = 2;
            this.bEpc.Text = "EPC";
            // 
            // bAccessPwd
            // 
            this.bAccessPwd.Location = new System.Drawing.Point(87, 6);
            this.bAccessPwd.Name = "bAccessPwd";
            this.bAccessPwd.Size = new System.Drawing.Size(98, 17);
            this.bAccessPwd.TabIndex = 1;
            this.bAccessPwd.Text = "Access Pwd";
            // 
            // bKillPwd
            // 
            this.bKillPwd.Location = new System.Drawing.Point(10, 5);
            this.bKillPwd.Name = "bKillPwd";
            this.bKillPwd.Size = new System.Drawing.Size(77, 17);
            this.bKillPwd.TabIndex = 0;
            this.bKillPwd.Text = "Kill Pwd";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numericUpDown20);
            this.panel2.Controls.Add(this.label83);
            this.panel2.Controls.Add(this.comboWriteMemBank);
            this.panel2.Controls.Add(this.label85);
            this.panel2.Controls.Add(this.textBox15);
            this.panel2.Location = new System.Drawing.Point(265, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 64);
            // 
            // numericUpDown20
            // 
            this.numericUpDown20.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDown20.Location = new System.Drawing.Point(84, 16);
            this.numericUpDown20.Name = "numericUpDown20";
            this.numericUpDown20.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown20.TabIndex = 4;
            // 
            // label83
            // 
            this.label83.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label83.Location = new System.Drawing.Point(83, 1);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(44, 12);
            this.label83.Text = "WordPtr";
            // 
            // comboWriteMemBank
            // 
            this.comboWriteMemBank.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboWriteMemBank.Items.Add("RESERVED");
            this.comboWriteMemBank.Items.Add("EPC");
            this.comboWriteMemBank.Items.Add("TID");
            this.comboWriteMemBank.Items.Add("USER");
            this.comboWriteMemBank.Location = new System.Drawing.Point(11, 16);
            this.comboWriteMemBank.Name = "comboWriteMemBank";
            this.comboWriteMemBank.Size = new System.Drawing.Size(67, 19);
            this.comboWriteMemBank.TabIndex = 32;
            // 
            // label85
            // 
            this.label85.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label85.Location = new System.Drawing.Point(15, 2);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(51, 12);
            this.label85.Text = "MemBank";
            // 
            // textBox15
            // 
            this.textBox15.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBox15.Location = new System.Drawing.Point(11, 41);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(193, 19);
            this.textBox15.TabIndex = 34;
            // 
            // textBox14
            // 
            this.textBox14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBox14.Location = new System.Drawing.Point(63, 155);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(103, 19);
            this.textBox14.TabIndex = 47;
            // 
            // label82
            // 
            this.label82.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label82.Location = new System.Drawing.Point(4, 158);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(63, 12);
            this.label82.Text = "Access Pwd";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboReadMemBank);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Location = new System.Drawing.Point(5, 177);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 64);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDown2.Location = new System.Drawing.Point(134, 16);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(39, 20);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDown1.Location = new System.Drawing.Point(84, 16);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(83, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.Text = "WordPtr";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(131, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 12);
            this.label3.Text = "WordCnt";
            // 
            // comboReadMemBank
            // 
            this.comboReadMemBank.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboReadMemBank.Items.Add("RESERVED");
            this.comboReadMemBank.Items.Add("EPC");
            this.comboReadMemBank.Items.Add("TID");
            this.comboReadMemBank.Items.Add("USER");
            this.comboReadMemBank.Location = new System.Drawing.Point(11, 16);
            this.comboReadMemBank.Name = "comboReadMemBank";
            this.comboReadMemBank.Size = new System.Drawing.Size(67, 19);
            this.comboReadMemBank.TabIndex = 32;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label15.Location = new System.Drawing.Point(15, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 12);
            this.label15.Text = "MemBank";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBox2.Location = new System.Drawing.Point(11, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(193, 19);
            this.textBox2.TabIndex = 34;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label18.Location = new System.Drawing.Point(8, 136);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.Text = "Cmd Type";
            // 
            // comboCmdType
            // 
            this.comboCmdType.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboCmdType.Items.Add("ReadMemBank");
            this.comboCmdType.Items.Add("WriteMemBank");
            this.comboCmdType.Items.Add("LockField");
            this.comboCmdType.Items.Add("UnlockField");
            this.comboCmdType.Items.Add("Permalock");
            this.comboCmdType.Items.Add("KillTag");
            this.comboCmdType.Location = new System.Drawing.Point(63, 133);
            this.comboCmdType.Name = "comboCmdType";
            this.comboCmdType.Size = new System.Drawing.Size(102, 19);
            this.comboCmdType.TabIndex = 42;
            this.comboCmdType.SelectedIndexChanged += new System.EventHandler(this.comboCmdType_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(168, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 20);
            this.button3.TabIndex = 40;
            this.button3.Text = "Start";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(20, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 17);
            this.label13.Text = "Command";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(7, 123);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(216, 2);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label12.Location = new System.Drawing.Point(133, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 12);
            this.label12.Text = "Mask Pattern";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(20, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 17);
            this.label10.Text = "Mask Parameters";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(7, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(216, 2);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(20, -1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.Text = "Operation";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(7, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(216, 2);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(64, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.Text = "NybOffSet";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDown4.Location = new System.Drawing.Point(73, 94);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(39, 20);
            this.numericUpDown4.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(37, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 12);
            this.label6.Text = "Type";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(91, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 12);
            this.label5.Text = "Seconds";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDown3.Location = new System.Drawing.Point(93, 27);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown3.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(5, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 12);
            this.label4.Text = "MemBank";
            // 
            // comboMaskMemBank
            // 
            this.comboMaskMemBank.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboMaskMemBank.Items.Add("RESERVED");
            this.comboMaskMemBank.Items.Add("EPC");
            this.comboMaskMemBank.Items.Add("TID");
            this.comboMaskMemBank.Items.Add("USER");
            this.comboMaskMemBank.Location = new System.Drawing.Point(5, 94);
            this.comboMaskMemBank.Name = "comboMaskMemBank";
            this.comboMaskMemBank.Size = new System.Drawing.Size(67, 19);
            this.comboMaskMemBank.TabIndex = 3;
            // 
            // comboOperationType
            // 
            this.comboOperationType.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboOperationType.Items.Add("Sync");
            this.comboOperationType.Items.Add("Async");
            this.comboOperationType.Location = new System.Drawing.Point(22, 27);
            this.comboOperationType.Name = "comboOperationType";
            this.comboOperationType.Size = new System.Drawing.Size(69, 19);
            this.comboOperationType.TabIndex = 2;
            this.comboOperationType.SelectedIndexChanged += new System.EventHandler(this.comboOperationType_SelectedIndexChanged);
            // 
            // checkBoxUseMask
            // 
            this.checkBoxUseMask.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.checkBoxUseMask.Location = new System.Drawing.Point(8, 64);
            this.checkBoxUseMask.Name = "checkBoxUseMask";
            this.checkBoxUseMask.Size = new System.Drawing.Size(115, 18);
            this.checkBoxUseMask.TabIndex = 1;
            this.checkBoxUseMask.Text = "Use Mask Pattern";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBox1.Location = new System.Drawing.Point(114, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 19);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "textBox1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(493, 308);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Rfid_Demo";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.NumericUpDown numericUpDown19;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox checkBoxSecured;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboPermalock;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox bUser;
        private System.Windows.Forms.CheckBox bTid;
        private System.Windows.Forms.CheckBox bEpc;
        private System.Windows.Forms.CheckBox bAccessPwd;
        private System.Windows.Forms.CheckBox bKillPwd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDown20;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.ComboBox comboWriteMemBank;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboReadMemBank;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboCmdType;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboMaskMemBank;
        private System.Windows.Forms.ComboBox comboOperationType;
        private System.Windows.Forms.CheckBox checkBoxUseMask;
        private System.Windows.Forms.TextBox textBox1;
    }
}

