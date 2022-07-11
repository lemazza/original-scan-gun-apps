namespace BarcodeSetup
{
    partial class frmEan8_13
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
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 29);
            this.button1.TabIndex = 16;
            this.button1.Text = "Set Configuration";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(19, 52);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(218, 23);
            this.checkBox2.TabIndex = 18;
            this.checkBox2.Text = "Transmit Check Char";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(19, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 23);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Symbology Enabled";
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(19, 76);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(218, 23);
            this.checkBox3.TabIndex = 19;
            this.checkBox3.Text = "2 Digit Addenda Enabled";
            // 
            // checkBox4
            // 
            this.checkBox4.Location = new System.Drawing.Point(19, 100);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(218, 23);
            this.checkBox4.TabIndex = 20;
            this.checkBox4.Text = "5 Digit Addenda Enabled";
            // 
            // checkBox5
            // 
            this.checkBox5.Location = new System.Drawing.Point(19, 124);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(218, 23);
            this.checkBox5.TabIndex = 21;
            this.checkBox5.Text = "Addenda Required";
            // 
            // checkBox6
            // 
            this.checkBox6.Location = new System.Drawing.Point(19, 148);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(218, 23);
            this.checkBox6.TabIndex = 22;
            this.checkBox6.Text = "Include Addenda Separator";
            // 
            // frmEan8_13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Menu = this.mainMenu1;
            this.Name = "frmEan8_13";
            this.Text = "frmEan8_13";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
    }
}