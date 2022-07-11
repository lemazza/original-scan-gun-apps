using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Lucky_Chicken_Productions
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void btnRFID_Click(object sender, EventArgs e)
        {
            RFID rfidForm = new RFID();
            rfidForm.Show();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(new MemoryStream(Properties.Resources.LCp_chicken));
            audio.Play();            
        }

        private void btnBarcodes_Click(object sender, EventArgs e)
        {
            Barcodes barcodeForm = new Barcodes();
            barcodeForm.Show();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}