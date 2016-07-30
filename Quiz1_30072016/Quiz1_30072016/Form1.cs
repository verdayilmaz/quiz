using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz1_30072016
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private decimal toplamSiparisTutari = 0;
        List<Kahve> kahveler = new List<Kahve>();
        List<SicakIcecekler> sicakicecekler = new List<SicakIcecekler>();
        List<SogukIcecekler> sogukicecekler = new List<SogukIcecekler>();
        List<Icecekler> alinanicecekler = new List<Icecekler>();

        Kahve alinanKahve = new Kahve();
        SicakIcecekler alinanSicak = new SicakIcecekler();
        SogukIcecekler alinanSoguk = new SogukIcecekler();

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboboxDoldur();
        }

        private void ComboboxDoldur()
        {
            Kahve misto = new Kahve();
            misto.IcecekIsmı = "Misto";
            misto.mainMoney = 4.5m;
            kahveler.Add(misto);

            Kahve americano = new Kahve();
            americano.IcecekIsmı = "Americano";
            americano.mainMoney = 4.5m;
            kahveler.Add(americano);

            Kahve bianco = new Kahve();
            bianco.IcecekIsmı = "Bianco";
            bianco.mainMoney = 6;
            kahveler.Add(bianco);

            Kahve capp = new Kahve();
            capp.IcecekIsmı = "Cappucino";
            capp.mainMoney = 7.5m;
            kahveler.Add(capp);

            Kahve macc = new Kahve();
            macc.IcecekIsmı = "Macchiato";
            macc.mainMoney = 6.75m;
            kahveler.Add(macc);

            Kahve conpanna = new Kahve();
            conpanna.IcecekIsmı = "Con Panna";
            conpanna.mainMoney = 8m;
            kahveler.Add(conpanna);

            Kahve mocha = new Kahve();
            mocha.IcecekIsmı = "Mocha";
            mocha.mainMoney = 7.75m;
            kahveler.Add(mocha);

            foreach (Kahve item in kahveler)
            {
                cmbKahve.Items.Add(item);
            }

            SogukIcecekler kola = new SogukIcecekler();
            kola.IcecekIsmı = "Kola";
            kola.mainMoney = 5.5m;
            sogukicecekler.Add(kola);

            SogukIcecekler fanta = new SogukIcecekler();
            fanta.IcecekIsmı = "fanta";
            fanta.mainMoney = 5.5m;
            sogukicecekler.Add(fanta);

            foreach (SogukIcecekler item in sogukicecekler)
            {
                cmbSoguk.Items.Add(item);
            }

            SicakIcecekler cay = new SicakIcecekler();
            cay.IcecekIsmı = "Çay";
            cay.mainMoney = 4.5m;
            sicakicecekler.Add(cay);

            SicakIcecekler chai = new SicakIcecekler();
            chai.IcecekIsmı = "Chai tea latte";
            chai.mainMoney = 6.5m;
            sicakicecekler.Add(chai);

            foreach (SicakIcecekler item in sicakicecekler)
            {
                cmbSicak.Items.Add(item);
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            IcecekBoyutu ventin = new IcecekBoyutu();
            ventin.IcecekBoyutuIsmı = "Venti";
            IcecekBoyutu talln = new IcecekBoyutu();
            talln.IcecekBoyutuIsmı = "Tall";
            IcecekBoyutu granden = new IcecekBoyutu();
            granden.IcecekBoyutuIsmı = "Grande";

            if (cmbKahve.SelectedItem != null)
            {
                cmbSicak.SelectedItem = null;
                cmbSoguk.SelectedItem = null;

                alinanKahve = (Kahve)cmbKahve.SelectedItem;
                decimal shotparasi = 0.75m;
                if (checkBox1.Checked && checkBox2.Checked)
                {
                    shotparasi = shotparasi * 3;
                    alinanKahve.shot = "3x shot";
                }
                else if (checkBox1.Checked)
                {
                    shotparasi = 0.75m;
                    alinanKahve.shot = "1x shot";
                }
                else if (checkBox2.Checked)
                {
                    shotparasi = shotparasi * 2;
                    alinanKahve.shot = "2x shot"; 
                }
                else
                {
                    shotparasi = 0;
                }

                if (radioButton1.Checked)
                {
                    alinanKahve.SutCesidi = "Yagsiz";
                }
                else if (radioButton2.Checked)
                {
                    alinanKahve.SutCesidi = "Soya";
                }
                if (rdbVenti.Checked)
                {
                    alinanKahve.boyutu = ventin;
                }
                else if (rdbGrande.Checked)
                {
                    alinanKahve.boyutu = granden;
                }
                else if (rdbTall.Checked)
                {
                    alinanKahve.boyutu = talln;
                }
                alinanKahve.adet = Convert.ToInt32(numericUpDown1.Value);

                string all = alinanKahve.IcecekIsmı + ", " + alinanKahve.boyutu.IcecekBoyutuIsmı
                    + ", " + alinanKahve.SutCesidi + " Toplam Fiyat: " 
                    + alinanKahve.CalculateMoney(shotparasi).ToString();

                toplamSiparisTutari += alinanKahve.CalculateMoney(shotparasi);
                lblSonuc.Text = toplamSiparisTutari.ToString();
                listBox1.Items.Add(all);
                alinanicecekler.Add(alinanKahve);
            }

            if (cmbSoguk.SelectedItem != null)
            {
                alinanSoguk = (SogukIcecekler)cmbSoguk.SelectedItem;
                int adet = Convert.ToInt32(numericUpDown2.Value);
                alinanSoguk.adet = adet;
                decimal sum = alinanSoguk.mainMoney * alinanSoguk.adet;
                toplamSiparisTutari += sum;

                string all = alinanSoguk.IcecekIsmı + ", " + sum.ToString();
                listBox1.Items.Add(all);
                lblSonuc.Text = toplamSiparisTutari.ToString();
                alinanicecekler.Add(alinanSoguk);
            }

            if (cmbSicak.SelectedItem != null)
            {
                alinanSicak = (SicakIcecekler)cmbSicak.SelectedItem;
                int adet = Convert.ToInt32(numericUpDown3.Value);
                alinanSicak.adet = adet;
                decimal sum = alinanSicak.mainMoney * alinanSicak.adet;
                toplamSiparisTutari += sum;

                string all = alinanSicak.IcecekIsmı + ", " + sum.ToString();
                listBox1.Items.Add(all);
                lblSonuc.Text = toplamSiparisTutari.ToString();
                alinanicecekler.Add(alinanSicak);
            }
        }

        private void cmbSoguk_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbKahve.SelectedItem = null;
            cmbSicak.SelectedItem = null;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            rdbVenti.Checked = false;
            rdbTall.Checked = false;
            rdbGrande.Checked = false;
        }

        private void cmbSicak_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbKahve.SelectedItem = null;
            cmbSoguk.SelectedItem = null;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            rdbVenti.Checked = false;
            rdbTall.Checked = false;
            rdbGrande.Checked = false;
        }

        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sepetinizdeki ürün sayısı " + listBox1.Items.Count.ToString()
            + "Toplam Tutar " + toplamSiparisTutari);
        }
    }
}
