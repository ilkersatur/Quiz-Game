using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYarismasiOyunu.Model
{
    internal class Cevaplar
    {
        public int CevapID { get; set; }
        public string Cevap { get; set; }
        public override string ToString()
        {
            return Cevap;
        }
    }
}
