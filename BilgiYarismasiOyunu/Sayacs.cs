using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYarismasiOyunu
{
    internal class Sayacs
    {
        public int SoruIndex { get; set; } = 0;
        public List<int> Indexs { get; set; } = new List<int>() { 0 };
        public int SoruSayisi { get; set; } = 1;
        public int OdulSayac { get; set; } = -1;
        public int Sure { get; set; } = 0;
        public int MaxSure { get; set; } = 40;
        public bool ButonDurum { get; set; } = true;
        public List<Label> Labels { get; set; } = new List<Label>();
    }
}
