namespace AlienBlockReadLockTest
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.chkPwd = new System.Windows.Forms.CheckBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBlock8 = new System.Windows.Forms.CheckBox();
            this.cbBlock7 = new System.Windows.Forms.CheckBox();
            this.cbBlock6 = new System.Windows.Forms.CheckBox();
            this.cbBlock5 = new System.Windows.Forms.CheckBox();
            this.cbBlock4 = new System.Windows.Forms.CheckBox();
            this.cbBlock3 = new System.Windows.Forms.CheckBox();
            this.cbBlock2 = new System.Windows.Forms.CheckBox();
            this.cbBlock1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.listBox1.Location = new System.Drawing.Point(4, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(229, 67);
            this.listBox1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 20);
            this.button2.TabIndex = 2;
            this.button2.Text = "Stop";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(4, 97);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(229, 20);
            this.button5.TabIndex = 6;
            this.button5.Text = "Read-lock the 1st and 3rd blocks";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // chkPwd
            // 
            this.chkPwd.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkPwd.Location = new System.Drawing.Point(164, 187);
            this.chkPwd.Name = "chkPwd";
            this.chkPwd.Size = new System.Drawing.Size(71, 20);
            this.chkPwd.TabIndex = 10;
            this.chkPwd.Text = "with pwd";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(4, 121);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(229, 20);
            this.button10.TabIndex = 12;
            this.button10.Text = "Reveal the hidden blocks";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(4, 145);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(229, 20);
            this.button11.TabIndex = 13;
            this.button11.Text = "Permalock these blocks:";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(10, 211);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(62, 23);
            this.comboBox1.TabIndex = 14;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(76, 211);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 24);
            this.numericUpDown1.TabIndex = 15;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(123, 211);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(43, 24);
            this.numericUpDown2.TabIndex = 16;
            this.numericUpDown2.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 239);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 23);
            this.textBox1.TabIndex = 17;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(185, 203);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(47, 20);
            this.button12.TabIndex = 18;
            this.button12.Text = "Read";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(186, 225);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(47, 20);
            this.button13.TabIndex = 19;
            this.button13.Text = "Write";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.Text = "MemBank";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(81, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.Text = "Ptr";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(124, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 16);
            this.label3.Text = "Cnt";
            // 
            // cbBlock8
            // 
            this.cbBlock8.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular);
            this.cbBlock8.Location = new System.Drawing.Point(204, 169);
            this.cbBlock8.Name = "cbBlock8";
            this.cbBlock8.Size = new System.Drawing.Size(34, 20);
            this.cbBlock8.TabIndex = 35;
            this.cbBlock8.Text = "8";
            // 
            // cbBlock7
            // 
            this.cbBlock7.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular);
            this.cbBlock7.Location = new System.Drawing.Point(174, 169);
            this.cbBlock7.Name = "cbBlock7";
            this.cbBlock7.Size = new System.Drawing.Size(34, 20);
            this.cbBlock7.TabIndex = 34;
            this.cbBlock7.Text = "7";
            // 
            // cbBlock6
            // 
            this.cbBlock6.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular);
            this.cbBlock6.Location = new System.Drawing.Point(144, 169);
            this.cbBlock6.Name = "cbBlock6";
            this.cbBlock6.Size = new System.Drawing.Size(34, 20);
            this.cbBlock6.TabIndex = 33;
            this.cbBlock6.Text = "6";
            // 
            // cbBlock5
            // 
            this.cbBlock5.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular);
            this.cbBlock5.Location = new System.Drawing.Point(114, 169);
            this.cbBlock5.Name = "cbBlock5";
            this.cbBlock5.Size = new System.Drawing.Size(34, 20);
            this.cbBlock5.TabIndex = 32;
            this.cbBlock5.Text = "5";
            // 
            // cbBlock4
            // 
            this.cbBlock4.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular);
            this.cbBlock4.Location = new System.Drawing.Point(85, 169);
            this.cbBlock4.Name = "cbBlock4";
            this.cbBlock4.Size = new System.Drawing.Size(34, 20);
            this.cbBlock4.TabIndex = 31;
            this.cbBlock4.Text = "4";
            // 
            // cbBlock3
            // 
            this.cbBlock3.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular);
            this.cbBlock3.Location = new System.Drawing.Point(57, 169);
            this.cbBlock3.Name = "cbBlock3";
            this.cbBlock3.Size = new System.Drawing.Size(34, 20);
            this.cbBlock3.TabIndex = 30;
            this.cbBlock3.Text = "3";
            // 
            // cbBlock2
            // 
            this.cbBlock2.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular);
            this.cbBlock2.Location = new System.Drawing.Point(29, 169);
            this.cbBlock2.Name = "cbBlock2";
            this.cbBlock2.Size = new System.Drawing.Size(34, 20);
            this.cbBlock2.TabIndex = 29;
            this.cbBlock2.Text = "2";
            // 
            // cbBlock1
            // 
            this.cbBlock1.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular);
            this.cbBlock1.Location = new System.Drawing.Point(1, 169);
            this.cbBlock1.Name = "cbBlock1";
            this.cbBlock1.Size = new System.Drawing.Size(34, 20);
            this.cbBlock1.TabIndex = 28;
            this.cbBlock1.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.cbBlock8);
            this.Controls.Add(this.cbBlock7);
            this.Controls.Add(this.cbBlock6);
            this.Controls.Add(this.cbBlock5);
            this.Controls.Add(this.cbBlock4);
            this.Controls.Add(this.cbBlock3);
            this.Controls.Add(this.cbBlock2);
            this.Controls.Add(this.cbBlock1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.chkPwd);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "AlienBlockReadLockTest";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox chkPwd;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbBlock8;
        private System.Windows.Forms.CheckBox cbBlock7;
        private System.Windows.Forms.CheckBox cbBlock6;
        private System.Windows.Forms.CheckBox cbBlock5;
        private System.Windows.Forms.CheckBox cbBlock4;
        private System.Windows.Forms.CheckBox cbBlock3;
        private System.Windows.Forms.CheckBox cbBlock2;
        private System.Windows.Forms.CheckBox cbBlock1;
    }
}

