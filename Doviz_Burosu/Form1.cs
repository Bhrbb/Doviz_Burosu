using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Doviz_Burosu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya=new XmlDocument();
            xmldosya.Load(bugun);
            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lbldolaralis.Text = dolaralis;


            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lbldolarsatis.Text = dolarsatis;

            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lbleuroalis.Text = euroalis;

            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lbleurosatis.Text = eurosatis;





        }

        private void btnsatisyap_Click(object sender, EventArgs e)
        {
            double kur= Convert.ToDouble(txtkur.Text);
            double miktar= Convert.ToDouble(txtmiktar.Text);
            double tutar = kur * miktar;
            txttoplam.Text = tutar.ToString();
        }

        private void btndolaral_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbldolaralis.Text;
        }

        private void btndolarsat_Click(object sender, EventArgs e)
        {
            txtkur.Text=lbldolarsatis.Text;
        }

        private void btneuroal_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbleuroalis.Text;

        }

        private void btneurosat_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbleurosatis.Text;
        }

        private void txtkur_TextChanged(object sender, EventArgs e)
        {
            txtkur.Text = lbldolarsatis.Text.Replace(".", ",");
        }

        private void btnsat_Click(object sender, EventArgs e)
        {
            double kur= Convert.ToDouble(txtkur.Text);
            double miktar= Convert.ToDouble (txtmiktar.Text);
            int tutar =Convert.ToInt32( miktar / kur);
            txttoplam.Text = tutar.ToString();
            //int tutar2= Convert.ToInt32(kur*tutar);
            double kalan;
            kalan = miktar % kur;
            
            txtkalan.Text = kalan.ToString();
        }
    }
}
