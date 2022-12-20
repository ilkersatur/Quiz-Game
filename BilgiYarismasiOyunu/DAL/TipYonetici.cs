using BilgiYarismasiOyunu.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYarismasiOyunu.DAL
{
    internal class TipYonetici : ICRUD<SoruTipleri>
    {
        public List<SoruTipleri> AListele()
        {
            throw new NotImplementedException();
        }

        public List<SoruTipleri> Ara(int id)
        {
            throw new NotImplementedException();
        }

        public List<SoruTipleri> BListele()
        {
            throw new NotImplementedException();
        }

        public List<SoruTipleri> CListele()
        {
            throw new NotImplementedException();
        }

        public List<SoruTipleri> DListele()
        {
            throw new NotImplementedException();
        }

        public void Ekle(SoruTipleri entity)
        {
            throw new NotImplementedException();
        }

        public List<SoruTipleri> SoruListele()
        {
            throw new NotImplementedException();
        }
        public List<SoruTipleri> TipListele()
        {
            OyunDB._conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Sorular.SoruID,Sorular.Soru,Sorular.A,Sorular.B,Sorular.C,Sorular.D,Sorular.Cevap,Cevaplar.Cevap,Sorular.SoruTipi,SoruTipleri.Tip\r\nFROM     Cevaplar INNER JOIN\r\n                  Sorular ON Cevaplar.CevapID = Sorular.Cevap INNER JOIN\r\n                  SoruTipleri ON Sorular.SoruTipi = SoruTipleri.TipID";
            cmd.Connection = OyunDB._conn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<SoruTipleri> tipler = new List<SoruTipleri>();
            while (reader.Read())
            {
                SoruTipleri tip = new SoruTipleri();
                tip.Tip = reader.GetString(9).ToString();
                tipler.Add(tip);
            }
            OyunDB._conn.Close();
            return tipler;
        }
    }
}
