using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace deneme
{
    public partial class kullanicieklemepaneli : Form
    {
        public kullanicieklemepaneli()
        {
            InitializeComponent();
        }
        public string alinanKullaniciAdi = "";
        public string alinanSifre = "";

        private void kullaniciadiekletxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            XDocument doc = XDocument.Load(Application.StartupPath.ToString() + @"../../../users.xml");


            var selected_user = from x in doc.Descendants("user").Where(x => (string)x.Element("username") == kullaniciadiekletxt.Text)
                                select new
                                {
                                    XMLuser = x.Element("username").Value,
                                    XMLpwd = x.Element("password").Value
                                };
            foreach (var x in selected_user)
            {
                alinanKullaniciAdi = x.XMLuser;
                alinanSifre = x.XMLpwd;

            }

            String kullanici = kullaniciadiekletxt.Text;
            String parola = kullanicisifreekletxt.Text;

            if (kullanici.Equals(alinanKullaniciAdi))
            {

                MessageBox.Show("Zaten Boyle bir kullanici var");
            }
            else if (kullanici.Equals("admin"))
            {
                MessageBox.Show("Admin kullanici adini ekleyemezsin");
            }
            else
            {
                XDocument xdosya = XDocument.Load(Application.StartupPath.ToString() + @"../../../users.xml");
                XElement rootelement = xdosya.Root;
                XElement newE = new XElement("user");
                XElement kAdiE = new XElement("username", kullanici);
                XElement kSifreE = new XElement("password", parola);
                newE.Add(kAdiE,kSifreE);
                rootelement.Add(newE);
                xdosya.Save(Application.StartupPath.ToString() + @"../../../users.xml");
                MessageBox.Show("Kayit Basarili");


            }

        }
    }
}
