namespace Lucky_Chicken_Productions
{
    partial class Barcodes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Barcodes));
            this.pnScan = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.units = new System.Windows.Forms.ListBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.lblNumOfItems = new System.Windows.Forms.Label();
            this.pnSend = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pbSending = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnError = new System.Windows.Forms.Panel();
            this.btnTryAgain = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.pnScan.SuspendLayout();
            this.pnSend.SuspendLayout();
            this.pnError.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnScan
            // 
            this.pnScan.BackColor = System.Drawing.Color.Black;
            this.pnScan.Controls.Add(this.btnExit);
            this.pnScan.Controls.Add(this.pictureBox2);
            this.pnScan.Controls.Add(this.label1);
            this.pnScan.Controls.Add(this.btnClear);
            this.pnScan.Controls.Add(this.btnSubmit);
            this.pnScan.Controls.Add(this.units);
            this.pnScan.Controls.Add(this.btnScan);
            this.pnScan.Controls.Add(this.lblNumOfItems);
            this.pnScan.Location = new System.Drawing.Point(0, 0);
            this.pnScan.Name = "pnScan";
            this.pnScan.Size = new System.Drawing.Size(240, 302);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(10, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 34);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(44, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.Text = "Barcode Units";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(83, 258);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(72, 25);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Green;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(161, 258);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(72, 25);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // units
            // 
            this.units.Location = new System.Drawing.Point(7, 51);
            this.units.Name = "units";
            this.units.Size = new System.Drawing.Size(226, 170);
            this.units.TabIndex = 2;
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.White;
            this.btnScan.Location = new System.Drawing.Point(7, 225);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(72, 25);
            this.btnScan.TabIndex = 3;
            this.btnScan.Text = "Scan";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lblNumOfItems
            // 
            this.lblNumOfItems.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNumOfItems.BackColor = System.Drawing.Color.Orange;
            this.lblNumOfItems.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblNumOfItems.Location = new System.Drawing.Point(139, 225);
            this.lblNumOfItems.Name = "lblNumOfItems";
            this.lblNumOfItems.Size = new System.Drawing.Size(93, 25);
            this.lblNumOfItems.Text = "0";
            this.lblNumOfItems.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnSend
            // 
            this.pnSend.Controls.Add(this.btnDone);
            this.pnSend.Controls.Add(this.label3);
            this.pnSend.Controls.Add(this.pbSending);
            this.pnSend.Controls.Add(this.label2);
            this.pnSend.Location = new System.Drawing.Point(0, 0);
            this.pnSend.Name = "pnSend";
            this.pnSend.Size = new System.Drawing.Size(240, 294);
            this.pnSend.Visible = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 48);
            this.label3.Text = "Please continue on http://www.luckychickenproductions.com";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbSending
            // 
            this.pbSending.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbSending.Image = ((System.Drawing.Image)(resources.GetObject("pbSending.Image")));
            this.pbSending.Location = new System.Drawing.Point(100, 82);
            this.pbSending.Name = "pbSending";
            this.pbSending.Size = new System.Drawing.Size(50, 57);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(74, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Sent!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnError
            // 
            this.pnError.Controls.Add(this.btnTryAgain);
            this.pnError.Controls.Add(this.pictureBox1);
            this.pnError.Controls.Add(this.pictureBox3);
            this.pnError.Controls.Add(this.label4);
            this.pnError.Location = new System.Drawing.Point(0, 0);
            this.pnError.Name = "pnError";
            this.pnError.Size = new System.Drawing.Size(240, 294);
            this.pnError.Visible = false;
            // 
            // btnTryAgain
            // 
            this.btnTryAgain.BackColor = System.Drawing.Color.Green;
            this.btnTryAgain.ForeColor = System.Drawing.Color.White;
            this.btnTryAgain.Location = new System.Drawing.Point(90, 200);
            this.btnTryAgain.Name = "btnTryAgain";
            this.btnTryAgain.Size = new System.Drawing.Size(70, 25);
            this.btnTryAgain.TabIndex = 4;
            this.btnTryAgain.Text = "OK";
            this.btnTryAgain.Click += new System.EventHandler(this.btnTryAgain_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 37);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(100, 82);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(17, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 20);
            this.label4.Text = "Oops. Please try again.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(6, 257);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 25);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(85, 227);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(72, 25);
            this.btnDone.TabIndex = 3;
            this.btnDone.Text = "Done";
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // Barcodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.pnScan);
            this.Controls.Add(this.pnError);
            this.Controls.Add(this.pnSend);
            this.Name = "Barcodes";
            this.Text = "Barcodes";
            this.Deactivate += new System.EventHandler(this.Barcodes_Deactivate);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Barcodes_Closing);
            this.pnScan.ResumeLayout(false);
            this.pnSend.ResumeLayout(false);
            this.pnError.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnScan;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ListBox units;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label lblNumOfItems;
        private System.Windows.Forms.Panel pnSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbSending;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnError;
        private System.Windows.Forms.Button btnTryAgain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDone;
    }
}