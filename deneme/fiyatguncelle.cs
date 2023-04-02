using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace deneme
{
    public partial class fiyatguncelle : Form
    {
        public fiyatguncelle()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            XDocument xdosya = XDocument.Load(Application.StartupPath.ToString() + @"../../../urunler.xml");
            XElement element = xdosya.Element("urunler").Elements("urun").FirstOrDefault(x => x.Element("urun_adi").Value == comboBox1.Text);

            if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("Bos girilemez");
                return;
            }
            if (Int32.Parse(textBox2.Text)<0)
            {
                MessageBox.Show("Urun Fiyari 0 dan fazla olamaz");
                    return;
            }
            
            element.SetElementValue("urun_fiyati", textBox2.Text);

            xdosya.Save(Application.StartupPath.ToString() + @"../../../urunler.xml");
            MessageBox.Show("Kayıt güncellendi");
            XmlReader reader = XmlReader.Create(Application.StartupPath.ToString() + @"../../../urunler.xml", new XmlReaderSettings());
            ds.ReadXml(reader);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "urun_adi";
            reader.Close();
        }

        private void fiyatguncelle_Load(object sender, EventArgs e)
        {
            XmlReader reader = XmlReader.Create(Application.StartupPath.ToString() + @"../../../urunler.xml", new XmlReaderSettings());
            ds.ReadXml(reader);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "urun_adi";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
