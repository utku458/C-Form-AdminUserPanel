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

namespace deneme
{
    public partial class kullanicisil : Form
    {
        public kullanicisil()
        {
            InitializeComponent();
            Kayit();
        }
        public string ad;
        public string sifre;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Silme islemi
            XDocument xdosya = XDocument.Load(Application.StartupPath.ToString() + @"../../../users.xml");
            XDocument doc = XDocument.Load(Application.StartupPath.ToString() + @"../../../users.xml");
            bool varmi = false;

            var selected_user = from x in doc.Descendants("user").Where(x => (string)x.Element("username") == textBox1.Text)
                                select new
                                {
                                    XMLuser = x.Element("username").Value,
                                    XMPassword = x.Element("password").Value,

                                };
            foreach (var x in selected_user)
            {
              
                varmi = true;
                ad = x.XMLuser;
                sifre = x.XMPassword;

            }
            if (varmi==false)
            {
                MessageBox.Show("Boyle bir kullanici yok");
            }
            else { 
            
          
           
           
            xdosya.Root.Elements().Where(x => x.Element("username").Value == textBox1.Text).Remove();

            textBox1.Text = ad;
            textBox2.Text = sifre;

            xdosya.Save(Application.StartupPath.ToString() + @"../../../users.xml");
            
           

            MessageBox.Show("Kayit silindi");
            Kayit();
                
            }
        }

        public void Kayit()
        {
            DataSet ds = new DataSet();
            XmlReader reader = XmlReader.Create(Application.StartupPath.ToString() + @"../../../users.xml", new XmlReaderSettings());
            ds.ReadXml(reader);
            dataGridView1.DataSource = ds.Tables[0];
            reader.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void kullanicisil_Load(object sender, EventArgs e)
        {

        }
    }
}
