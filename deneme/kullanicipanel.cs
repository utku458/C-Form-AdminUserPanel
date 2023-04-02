using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace deneme
{
    public partial class kullanicipanel : Form
    {
        public kullanicipanel()
        {
            InitializeComponent();



        }
        public string gelenUrunAdi = "";
        public string gelenUrunFiyat = "";

        private void iphonechk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pcsonuc.Text = (Int32.Parse(pcsonuc.Text) + 1).ToString();

        }

        private void kullanicipanel_Load(object sender, EventArgs e)
        {

        }

        private void kullanicipanel_FormClosing(object sender, FormClosingEventArgs e)
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

        private void smstopla_Click(object sender, EventArgs e)
        {


            smssonuc.Text = (Int32.Parse(smssonuc.Text) + 1).ToString();
        }

        private void smscikar_Click(object sender, EventArgs e)
        {

            if (Int32.Parse(smssonuc.Text) <= 0)
            {

                MessageBox.Show("Daha fazla azaltamazsin!!");
            }
            else
            {
                smssonuc.Text = (Int32.Parse(smssonuc.Text) - 1).ToString();
            }

        }

        private void iphcikar_Click(object sender, EventArgs e)
        {

            if (Int32.Parse(iphsonuc.Text) <= 0)
            {

                MessageBox.Show("Daha fazla azaltamazsin!!");
            }
            else
            {
                iphsonuc.Text = (Int32.Parse(iphsonuc.Text) - 1).ToString();
            }

        }

        private void iphtopla_Click(object sender, EventArgs e)
        {
            iphsonuc.Text = (Int32.Parse(iphsonuc.Text) + 1).ToString();

        }

        private void pccikar_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(pcsonuc.Text) <= 0)
            {

                MessageBox.Show("Daha fazla azaltamazsin!!");
            }
            else
            {
                pcsonuc.Text = (Int32.Parse(pcsonuc.Text) - 1).ToString();
            }
        }

        private void laptopckr_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(laptopsnc.Text) <= 0)
            {

                MessageBox.Show("Daha fazla azaltamazsin!!");
            }
            else
            {
                laptopsnc.Text = (Int32.Parse(laptopsnc.Text) - 1).ToString();
            }
        }

        private void laptoptpl_Click(object sender, EventArgs e)
        {
            laptopsnc.Text = (Int32.Parse(laptopsnc.Text) + 1).ToString();
        }

        private void smssonuc_TextChanged(object sender, EventArgs e)
        {
            toplamsnc.Text = (Int32.Parse(smssonuc.Text) + Int32.Parse(iphsonuc.Text) + Int32.Parse(laptopsnc.Text) + Int32.Parse(pcsonuc.Text)).ToString();
        }

        public void check(string check)
        {


            XDocument doc = XDocument.Load(Application.StartupPath.ToString() + @"../../../urunler.xml");

            var selected_user = from x in doc.Descendants("urun").Where(x => (string)x.Element("urun_adi") == check)
                                select new
                                {

                                    XMLprice = x.Element("urun_fiyati").Value
                                };
            foreach (var x in selected_user)
            {

                gelenUrunFiyat = x.XMLprice;

            }
        }

        private void hesaplabtn_Click(object sender, EventArgs e)
        {
            int toplam = 0;

            richTextBox1.Text = "-----URUN ADI ------- ADET -------FIYAT";

            if (samsungchk.Checked == true)
            {
                check(samsungchk.Text);
                toplam += Int32.Parse(gelenUrunFiyat) * Int32.Parse(smssonuc.Text);


                richTextBox1.Text += "\n Samsung Telefon-" + smssonuc.Text + " ------------" + Int32.Parse(gelenUrunFiyat) * Int32.Parse(smssonuc.Text);
            }
            if (iphonechk.Checked == true)
            {


                check(iphonechk.Text);
                toplam += Int32.Parse(gelenUrunFiyat) * Int32.Parse(iphsonuc.Text);
                richTextBox1.Text += "\n Iphone Telefon -- " + iphsonuc.Text + " ------------" + Int32.Parse(gelenUrunFiyat) * Int32.Parse(iphsonuc.Text);

            }
            if (pcchk.Checked == true)
            {
                check(pcchk.Text);
                toplam += Int32.Parse(gelenUrunFiyat) * Int32.Parse(pcsonuc.Text);
                richTextBox1.Text += "\n Masausutu PC --- " + pcsonuc.Text + " ------------" + Int32.Parse(gelenUrunFiyat) * Int32.Parse(pcsonuc.Text);

            }
            if (laptopchk.Checked == true)
            {
                check(laptopchk.Text);
                toplam += Int32.Parse(gelenUrunFiyat) * Int32.Parse(laptopsnc.Text);
                richTextBox1.Text += "\n Laptop --------------- " + laptopsnc.Text + " ----------" + Int32.Parse(gelenUrunFiyat) * Int32.Parse(laptopsnc.Text);

            }
            richTextBox1.Text += "\n Toplam Fiyat  ----------------- " + toplam.ToString();


        } 
        //PrintDialog PRD = new PrintDialog();
        private void yazdirbtn_Click(object sender, EventArgs e)
        {

            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();

            }


        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {


            Font baslikFonttipi = new Font("Microsoft YaHei UI", 20, FontStyle.Bold);
            Brush baslikfontrenk = Brushes.Red;
            PointF baslikFontNoktasi = new PointF(100, 100);
            e.Graphics.DrawString("----------------TUTAR----------------", baslikFonttipi, baslikfontrenk, baslikFontNoktasi);




            Font fontTipi = new Font("Microsoft YaHei UI", 20, FontStyle.Bold);
            Brush fontRenk = Brushes.Orange;
            PointF fontNoktasi = new PointF(150, 300);
            e.Graphics.DrawString(richTextBox1.Text, fontTipi, fontRenk, fontNoktasi);
           

        }

        private void temizlebtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            toplamsnc.Text = "0";
            smssonuc.Text = "0";
            iphsonuc.Text = "0";
            laptopsnc.Text = "0";
            pcsonuc.Text="0";


            samsungchk.Checked = false;
            iphonechk.Checked= false;
            pcchk.Checked= false;
            laptopchk.Checked=false;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
