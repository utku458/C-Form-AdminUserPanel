using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace deneme
{
    public partial class adminpanel : Form
    {
        public adminpanel()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            kullanicieklemepaneli kullanicieklepnl = new kullanicieklemepaneli();

            kullanicieklepnl.ShowDialog();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Kullanicisilme

            kullanicisil kullanicisilpnl = new kullanicisil();

            kullanicisilpnl.ShowDialog();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            fiyatguncelle fiyatguncellepnl= new fiyatguncelle();

            fiyatguncellepnl.ShowDialog();
        }

        private void adminpanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult reuslt = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (reuslt == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            if (reuslt == DialogResult.Yes)
            {

                System.Environment.Exit(0);
                
            }
        }
    }
}
