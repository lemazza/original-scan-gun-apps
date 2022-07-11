namespace Lucky_Chicken_Productions
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRFID = new System.Windows.Forms.Button();
            this.btnBarcodes = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Gold;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(100, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 55);
            // 
            // btnRFID
            // 
            this.btnRFID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRFID.BackColor = System.Drawing.Color.White;
            this.btnRFID.Location = new System.Drawing.Point(70, 165);
            this.btnRFID.Name = "btnRFID";
            this.btnRFID.Size = new System.Drawing.Size(100, 25);
            this.btnRFID.TabIndex = 1;
            this.btnRFID.Text = "RFID";
            this.btnRFID.Click += new System.EventHandler(this.btnRFID_Click);
            // 
            // btnBarcodes
            // 
            this.btnBarcodes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBarcodes.BackColor = System.Drawing.Color.White;
            this.btnBarcodes.Location = new System.Drawing.Point(70, 207);
            this.btnBarcodes.Name = "btnBarcodes";
            this.btnBarcodes.Size = new System.Drawing.Size(100, 25);
            this.btnBarcodes.TabIndex = 2;
            this.btnBarcodes.Text = "BARCODES";
            this.btnBarcodes.Click += new System.EventHandler(this.btnBarcodes_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQuit.BackColor = System.Drawing.Color.White;
            this.btnQuit.Location = new System.Drawing.Point(70, 248);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 25);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "EXIT";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnBarcodes);
            this.Controls.Add(this.btnRFID);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Start";
            this.Text = "Lucky Chicken Productions";
            this.Load += new System.EventHandler(this.Start_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRFID;
        private System.Windows.Forms.Button btnBarcodes;
        private System.Windows.Forms.Button btnQuit;
    }
}

