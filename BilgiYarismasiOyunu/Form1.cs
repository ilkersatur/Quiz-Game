using BilgiYarismasiOyunu.DAL;
using BilgiYarismasiOyunu.Model;

namespace BilgiYarismasiOyunu
{
    public partial class Form1 : Form
    {
        int sayac = 0;
        public Form1()
        {
            InitializeComponent();
            Sound sound = new Sound();
            sound.IntroStart();
        }

        private void btnOyun_Click(object sender, EventArgs e)
        {
            Sound sound = new Sound();
            sound.IntroStop();
            timer1.Stop();
            Oyun oyun = new Oyun();
            this.Hide();
            oyun.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Sound sound = new Sound();
            timer1.Interval = 1000;
            sayac++;
            if (sayac==33)
            {
                sound.IntroStop();
                timer1.Stop();
            }
        }
    }
}