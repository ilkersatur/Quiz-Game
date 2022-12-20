using BilgiYarismasiOyunu.DAL;
using BilgiYarismasiOyunu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
namespace BilgiYarismasiOyunu
{
    public partial class Oyun : Form
    {
        OyunDB db = new OyunDB();
        CevapYonetici cevapYonetici = new CevapYonetici();
        Sayacs sayacs = new Sayacs();
        DialogResult dialog = new DialogResult();
        Sound sound = new Sound();
        public Oyun()
        {
            InitializeComponent();
        }
        public void LabelText()
        {
            while (true)
            {
                sayacs.SoruIndex = new Random().Next(1, 50);
                if ("Kolay" == cevapYonetici.SoruListele()[sayacs.SoruIndex].ToString() && sayacs.SoruSayisi < 6)
                {
                    if (!sayacs.Indexs.Contains(sayacs.SoruIndex))
                    {
                        MessageBox.Show("Tebriker doğru cevap verdiniz!\nSonraki soruya geç");
                        sayacs.Indexs.Add(sayacs.SoruIndex);
                        cevapYonetici.Sayacs(sayacs.SoruIndex);
                        sayacs.SoruSayisi++;
                        lblSoru.Text = db.Sorular.SoruListele()[sayacs.SoruIndex].ToString();
                        lblA.Text = db.Cevaplar.AListele()[sayacs.SoruIndex].ToString();
                        lblB.Text = db.Cevaplar.BListele()[sayacs.SoruIndex].ToString();
                        lblC.Text = db.Cevaplar.CListele()[sayacs.SoruIndex].ToString();
                        lblD.Text = db.Cevaplar.DListele()[sayacs.SoruIndex].ToString();
                        sayacs.OdulSayac++;
                        sayacs.Sure = 0;
                        progressBar1.Value = 0;
                        break;
                    }
                }
                if ("Zor" == cevapYonetici.SoruListele()[sayacs.SoruIndex].ToString() && sayacs.SoruSayisi > 5)
                {
                    sayacs.MaxSure = 120;
                    progressBar1.Maximum = 121;
                    if (!sayacs.Indexs.Contains(sayacs.SoruIndex))
                    {
                        MessageBox.Show("Tebriker doğru cevap verdiniz!\nSonraki soruya geç");
                        sayacs.Indexs.Add(sayacs.SoruIndex);
                        cevapYonetici.Sayacs(sayacs.SoruIndex);
                        sayacs.SoruSayisi++;
                        lblSoru.Text = db.Sorular.SoruListele()[sayacs.SoruIndex].ToString();
                        lblA.Text = db.Cevaplar.AListele()[sayacs.SoruIndex].ToString();
                        lblB.Text = db.Cevaplar.BListele()[sayacs.SoruIndex].ToString();
                        lblC.Text = db.Cevaplar.CListele()[sayacs.SoruIndex].ToString();
                        lblD.Text = db.Cevaplar.DListele()[sayacs.SoruIndex].ToString();
                        sayacs.OdulSayac++;
                        sayacs.Sure = 0;
                        progressBar1.Value = 0;
                        break;
                    }
                    if (sayacs.SoruSayisi == 10)
                    {
                        MessageBox.Show("Tebriklerrr 500.000 TL kazandınız!!!");
                        this.Close();
                        Form1 form = new Form1();
                        form.ShowDialog();
                        break;
                    }
                }
            }
        }
        public void Odul()
        {
            sayacs.Labels.Add(lblOdul1);
            sayacs.Labels.Add(lblOdul2);
            sayacs.Labels.Add(lblOdul3);
            sayacs.Labels.Add(lblOdul4);
            sayacs.Labels.Add(lblOdul5);
            sayacs.Labels.Add(lblOdul6);
            sayacs.Labels.Add(lblOdul7);
            sayacs.Labels.Add(lblOdul8);
            sayacs.Labels.Add(lblOdul9);
            sayacs.Labels.Add(lblOdul10);
            sayacs.Labels[sayacs.OdulSayac].BackColor = Color.Blue;
            sayacs.Sure = 0;
            progressBar1.Value = 0;
        }
        public void Yanlis()
        {
            if (sayacs.SoruSayisi < 3)
            {
                MessageBox.Show("Kazanılan Ödül\n0 TL", "Yanlıç Cevap", MessageBoxButtons.OK);
            }
            else if (sayacs.SoruSayisi >= 3 && sayacs.SoruSayisi < 6)
            {
                MessageBox.Show("Kazanılan Ödül\n1000 TL", "Yanlış Cevap", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Kazanılan Ödül\n10000 TL", "Yanlış Cevap", MessageBoxButtons.OK);
            }
            sayacs.Sure = 0;
            progressBar1.Value = 0;
            Form1 form = new Form1();
            form.ShowDialog();
            Close();
        }

        private void Oyun_Load(object sender, EventArgs e)
        {
            lblSoru.Text = db.Sorular.SoruListele()[sayacs.SoruIndex].ToString();
            lblA.Text = db.Cevaplar.AListele()[sayacs.SoruIndex].ToString();
            lblB.Text = db.Cevaplar.BListele()[sayacs.SoruIndex].ToString();
            lblC.Text = db.Cevaplar.CListele()[sayacs.SoruIndex].ToString();
            lblD.Text = db.Cevaplar.DListele()[sayacs.SoruIndex].ToString();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 40;
            timer1.Start();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show($"Emin misin?", "Çekil", MessageBoxButtons.YesNo);
            if (sayacs.OdulSayac == -1 && dialog == DialogResult.Yes)
            {
                Form1 form = new Form1();
                form.ShowDialog();
                Close();
            }
            else if (sayacs.OdulSayac != -1 && dialog == DialogResult.Yes)
            {
                MessageBox.Show($"Kazanılan Ödül\n{sayacs.Labels[sayacs.OdulSayac].Text}");
                Form1 form = new Form1();
                form.ShowDialog();
                Close();
            }
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show($"Emin misin?", "A", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                if ("A" == cevapYonetici.CevapListele()[sayacs.SoruIndex].ToString())
                {
                    Thread.Sleep(2000);
                    sound.DogruCevap();
                    LabelText();
                    Odul();

                }
                else
                {
                    Thread.Sleep(3000);
                    sound.YanlisCevap();
                    Yanlis();
                }
            }
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show($"Emin misin?", "B", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if ("B" == cevapYonetici.CevapListele()[sayacs.SoruIndex].ToString())
                {
                    Thread.Sleep(2000);
                    sound.DogruCevap();
                    LabelText();
                    Odul();
                }
                else
                {
                    Thread.Sleep(3000);
                    sound.YanlisCevap();
                    Yanlis();
                }
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show($"Emin misin?", "C", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if ("C" == cevapYonetici.CevapListele()[sayacs.SoruIndex].ToString())
                {
                    Thread.Sleep(2000);
                    sound.DogruCevap();
                    LabelText();
                    Odul();
                }
                else
                {
                    Thread.Sleep(3000);
                    sound.YanlisCevap();
                    Yanlis();
                }
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show($"Emin misin?", "D", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if ("D" == cevapYonetici.CevapListele()[sayacs.SoruIndex].ToString())
                {
                    Thread.Sleep(2000);
                    sound.DogruCevap();
                    LabelText();
                    Odul();
                }
                else
                {
                    Thread.Sleep(3000);
                    sound.YanlisCevap();
                    Yanlis();
                }
            }
        }

        private void lblOdul2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            sayacs.Sure++;
            progressBar1.Value++;
            if (sayacs.Sure == sayacs.MaxSure && sayacs.OdulSayac != -1)
            {
                sound.ZamanDoldu();
                Thread.Sleep(2000);
                sound.ZamanDoldu();
                timer1.Stop();
                progressBar1.Value = 0;
                MessageBox.Show($"Kazanılan Ödül\n{sayacs.Labels[sayacs.OdulSayac].Text}", "Süre Bitti");
                Form1 form = new Form1();
                form.ShowDialog();
                Close();
            }
            else if (sayacs.Sure == sayacs.MaxSure && sayacs.OdulSayac == -1)
            {
                sound.ZamanDoldu();
                Thread.Sleep(2000);
                sound.ZamanDoldu();
                timer1.Stop();
                progressBar1.Value = 0;
                MessageBox.Show($"Kazanılan Ödül\n{0}", "Süre Bitti");
                Form1 form = new Form1();
                form.ShowDialog();
                Close();
            }
        }

        private void lblSoru_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sayacs.ButonDurum)
            {
                MessageBox.Show($"Cevap {cevapYonetici.CevapListele()[sayacs.SoruIndex]} olabilir.");
                sayacs.ButonDurum = false;
            }
            else
            {
                MessageBox.Show("İki defa kullanılmaz!");
            }
        }
    }
}