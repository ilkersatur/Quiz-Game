using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace BilgiYarismasiOyunu
{
    internal class Sound
    {
        public SoundPlayer intro { get; set; }=new SoundPlayer();
        public string path { get; set; }
        public void IntroStart()
        {
            path = "C:\\Users\\SABAH YAZILIM\\Desktop\\C# NOTE\\Proje\\BilgiYarismasiOyunu\\BilgiYarismasiOyunu\\BilgiYarismasiOyunu\\bin\\Debug\\intro.wav";
            intro.SoundLocation = path;
            intro.Play();
        }
        public void IntroStop()
        {
            intro.Stop();
        }
        public void DogruCevap()
        {
            path = "C:\\Users\\SABAH YAZILIM\\Desktop\\C# NOTE\\Proje\\BilgiYarismasiOyunu\\BilgiYarismasiOyunu\\BilgiYarismasiOyunu\\bin\\Debug\\correct.wav";
            intro.SoundLocation = path;
            intro.Play();
        }
        public void YanlisCevap()
        {
            path = "C:\\Users\\SABAH YAZILIM\\Desktop\\C# NOTE\\Proje\\BilgiYarismasiOyunu\\BilgiYarismasiOyunu\\BilgiYarismasiOyunu\\bin\\Debug\\wrong.wav";
            intro.SoundLocation = path;
            intro.Play();
        }
        public void ZamanDoldu()
        {
            path = "C:\\Users\\SABAH YAZILIM\\Desktop\\C# NOTE\\Proje\\BilgiYarismasiOyunu\\BilgiYarismasiOyunu\\BilgiYarismasiOyunu\\bin\\Debug\\timesup.wav";
            intro.SoundLocation = path;
            intro.Play();
        }
    }
}
