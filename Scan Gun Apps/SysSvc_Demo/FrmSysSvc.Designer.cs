namespace SysSvc_Demo
{
    partial class FrmSysSvc
    {
        private System.ComponentModel.IContainer components = null;

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
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnResetSleepNotification = new System.Windows.Forms.Button();
            this.btnSetSleepNotification = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDown6.Location = new System.Drawing.Point(85, 177);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown6.TabIndex = 27;
            this.numericUpDown6.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // comboBox8
            // 
            this.comboBox8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboBox8.Items.Add("AC");
            this.comboBox8.Items.Add("Battery");
            this.comboBox8.Location = new System.Drawing.Point(7, 178);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(74, 19);
            this.comboBox8.TabIndex = 26;
            this.comboBox8.SelectedIndexChanged += new System.EventHandler(this.comboBox8_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label17.Location = new System.Drawing.Point(7, 159);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(147, 16);
            this.label17.Text = "Backlight Timeout(Seconds)";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDown5.Location = new System.Drawing.Point(85, 134);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown5.TabIndex = 24;
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // comboBox7
            // 
            this.comboBox7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboBox7.Items.Add("");
            this.comboBox7.Items.Add("AC");
            this.comboBox7.Items.Add("Battery");
            this.comboBox7.Location = new System.Drawing.Point(7, 135);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(74, 19);
            this.comboBox7.TabIndex = 8;
            this.comboBox7.SelectedIndexChanged += new System.EventHandler(this.comboBox7_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label16.Location = new System.Drawing.Point(7, 119);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(143, 16);
            this.label16.Text = "Backlight Brightness(0~25)";
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboBox3.Items.Add("ON");
            this.comboBox3.Items.Add("OFF");
            this.comboBox3.Location = new System.Drawing.Point(182, 135);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(46, 19);
            this.comboBox3.TabIndex = 18;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(135, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 12);
            this.label6.Text = "Vibrator";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboBox2.Items.Add("ON");
            this.comboBox2.Items.Add("OFF");
            this.comboBox2.Location = new System.Drawing.Point(63, 95);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(58, 19);
            this.comboBox2.TabIndex = 13;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.Text = "WLAN Pwr";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDown1.Location = new System.Drawing.Point(86, 70);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboBox1.Items.Add("AC");
            this.comboBox1.Items.Add("Battery");
            this.comboBox1.Location = new System.Drawing.Point(7, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(74, 19);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(5, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.Text = "Suspend Timeout(Seconds)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBox2.Location = new System.Drawing.Point(61, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(127, 19);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "textBox2";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(7, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 14);
            this.label2.Text = "UUID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBox1.Location = new System.Drawing.Point(61, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "textBox1";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.Text = "DeviceID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 24);
            this.button1.TabIndex = 35;
            this.button1.Text = "SoftReset";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // comboBox4
            // 
            this.comboBox4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboBox4.Items.Add("ON");
            this.comboBox4.Items.Add("OFF");
            this.comboBox4.Location = new System.Drawing.Point(182, 95);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(46, 19);
            this.comboBox4.TabIndex = 37;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(123, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.Text = "FlashLight";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(109, 236);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 24);
            this.button2.TabIndex = 39;
            this.button2.Text = "Go Suspend State";
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnResetSleepNotification
            // 
            this.btnResetSleepNotification.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnResetSleepNotification.Location = new System.Drawing.Point(186, 202);
            this.btnResetSleepNotification.Name = "btnResetSleepNotification";
            this.btnResetSleepNotification.Size = new System.Drawing.Size(42, 19);
            this.btnResetSleepNotification.TabIndex = 50;
            this.btnResetSleepNotification.Text = "Reset";
            this.btnResetSleepNotification.Click += new System.EventHandler(this.btnResetSleepNotification_Click);
            // 
            // btnSetSleepNotification
            // 
            this.btnSetSleepNotification.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnSetSleepNotification.Location = new System.Drawing.Point(143, 202);
            this.btnSetSleepNotification.Name = "btnSetSleepNotification";
            this.btnSetSleepNotification.Size = new System.Drawing.Size(42, 19);
            this.btnSetSleepNotification.TabIndex = 49;
            this.btnSetSleepNotification.Text = "Set";
            this.btnSetSleepNotification.Click += new System.EventHandler(this.btnSetSleepNotification_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(7, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 12);
            this.label10.Text = "Sleep/Wakeup Notification";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmSysSvc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.btnResetSleepNotification);
            this.Controls.Add(this.btnSetSleepNotification);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.numericUpDown6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox8);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.numericUpDown5);
            this.Controls.Add(this.comboBox7);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label6);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "FrmSysSvc";
            this.Text = "SysSvc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmSysSvc_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnResetSleepNotification;
        private System.Windows.Forms.Button btnSetSleepNotification;
        private System.Windows.Forms.Label label10;



    }
}

