using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string gelenAd = "";
        public string gelenSifre = "";

        private void Form1_Load(object sender, EventArgs e)
        {



        }


        private string path = Application.StartupPath.ToString() + @"../../../admin.xml";
        private string path2 = Application.StartupPath.ToString() + @"../../../users.xml";
        private void kayitbtn_Click(object sender, EventArgs e)
        {

        }

        private void sifregosterbtn_Click(object sender, EventArgs e)
        {
           
        }

        private void kayitbtn_Click_1(object sender, EventArgs e)
        {

           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            XmlDocument xmlDocument = new XmlDocument();
            //  XmlDocument xmlDocument2 = new XmlDocument();
            xmlDocument.Load(Application.StartupPath.ToString() + @"../../../admin.xml");
            // xmlDocument2.Load(path2);
            String adminadi = xmlDocument.GetElementsByTagName("username")[0].InnerText;
            String adminsifre = xmlDocument.GetElementsByTagName("password")[0].InnerText;

            XDocument doc = XDocument.Load(Application.StartupPath.ToString() + @"../../../users.xml");

            var selected_user = from x in doc.Descendants("user").Where(x => (string)x.Element("username") == kullaniciadi.Text)
                                select new
                                {
                                    XMLuser = x.Element("username").Value,
                                    XMLpassword = x.Element("password").Value
                                };
            foreach (var x in selected_user)
            {
                gelenAd = x.XMLuser;
                gelenSifre = x.XMLpassword;
            }



            String kullanici = kullaniciadi.Text;
            String parola = sifre.Text;

            if (kullanici.Equals(adminadi) && parola.Equals(adminsifre))
            {

                adminpanel adminpnl = new adminpanel();

                adminpnl.ShowDialog();
                this.Hide();



            }
            else if (kullanici.Equals(gelenAd) && parola.Equals(gelenSifre))
            {
                kullanicipanel kullanicipnl = new kullanicipanel();

                kullanicipnl.ShowDialog();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatali giris");

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (sifre.PasswordChar == '*')
            {
                sifre.PasswordChar = '\0';
            }
            else sifre.PasswordChar = '*';
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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
