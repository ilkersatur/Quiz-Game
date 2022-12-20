using BilgiYarismasiOyunu.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYarismasiOyunu.DAL
{
    internal class OyunDB
    {
        public static SqlConnection _conn;
        public OyunDB()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            Sorular = new SoruYonetici();
            Cevaplar = new CevapYonetici();
        }
        public CevapYonetici Cevaplar { get; set; }
        public SoruYonetici Sorular { get; set; }
        public TipYonetici tipler { get; set; }
    }
}
