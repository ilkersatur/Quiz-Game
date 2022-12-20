using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYarismasiOyunu.Model
{
    internal class Sorular
    {
        public int SoruID { get; set; }
        public string Soru { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public int SoruTipi { get; set; }
        public int Cevap { get; set; }
        public override string ToString()
        {
            return Soru;
        }
    }
}
