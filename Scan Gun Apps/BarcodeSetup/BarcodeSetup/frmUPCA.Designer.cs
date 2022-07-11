namespace BarcodeSetup
{
    partial class frmUPCA
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
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBox6
            // 
            this.checkBox6.Location = new System.Drawing.Point(19, 148);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(218, 23);
            this.checkBox6.TabIndex = 29;
            this.checkBox6.Text = "Addenda Required";
            // 
            // checkBox5
            // 
            this.checkBox5.Location = new System.Drawing.Point(19, 124);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(218, 23);
            this.checkBox5.TabIndex = 28;
            this.checkBox5.Text = "5 Digit Addenda Enabled";
            // 
            // checkBox4
            // 
            this.checkBox4.Location = new System.Drawing.Point(19, 100);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(218, 23);
            this.checkBox4.TabIndex = 27;
            this.checkBox4.Text = "2 Digit Addenda Enabled";
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(19, 76);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(218, 23);
            this.checkBox3.TabIndex = 26;
            this.checkBox3.Text = "Return Numeric Digit";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(19, 52);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(218, 23);
            this.checkBox2.TabIndex = 25;
            this.checkBox2.Text = "Transmit Check Char";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(19, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 23);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Symbology Enabled";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 29);
            this.button1.TabIndex = 23;
            this.button1.Text = "Set Configuration";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox7
            // 
            this.checkBox7.Location = new System.Drawing.Point(19, 172);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(218, 23);
            this.checkBox7.TabIndex = 30;
            this.checkBox7.Text = "Include Addenda Separator";
            // 
            // frmUPCA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "frmUPCA";
            this.Text = "frmUPCA";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox7;
    }
}