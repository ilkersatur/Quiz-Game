using BilgiYarismasiOyunu.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYarismasiOyunu.DAL
{
    internal class CevapYonetici : ICRUD<Cevaplar>
    {
        public List<Cevaplar> Ara(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Sorular.SoruID,Sorular.Soru,Sorular.A,Sorular.B,Sorular.C,Sorular.D,Sorular.Cevap,Cevaplar.Cevap,Sorular.SoruTipi,SoruTipleri.Tip\r\nFROM     Cevaplar INNER JOIN\r\n                  Sorular ON Cevaplar.CevapID = Sorular.Cevap INNER JOIN\r\n                  SoruTipleri ON Sorular.SoruTipi = SoruTipleri.TipID";
            cmd.Connection = OyunDB._conn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Cevaplar> cevaplar = new List<Cevaplar>();
            while (reader.Read())
            {
                Cevaplar cevap = new Cevaplar();
                cevap.Cevap = reader.GetString(id);
                cevaplar.Add(cevap);
            }
            OyunDB._conn.Close();
            return cevaplar;
        }

        public List<Cevaplar> AListele()
        {
            OyunDB._conn.Open();
            return Ara(2);
        }


        public List<Cevaplar> BListele()
        {
            OyunDB._conn.Open();
            return Ara(3);
        }

        public List<Cevaplar> CListele()
        {
            OyunDB._conn.Open();
            return Ara(4);
        }

        public List<Cevaplar> DListele()
        {
            OyunDB._conn.Open();
            return Ara(5);
        }

        public void Ekle(Cevaplar entity)
        {
            throw new NotImplementedException();
        }

        public List<Cevaplar> SoruListele()
        {
            OyunDB._conn.Open();
            return Ara(9);
        }

        public List<Cevaplar> CevapListele()
        {
            OyunDB._conn.Open();
            return Ara(7);
        }
        public void Sayacs(int s)
        {
            Sorular sorular = new Sorular();
            SoruYonetici soruYonetici = new SoruYonetici();
            sorular.Soru= soruYonetici.SoruListele()[s].ToString();
            sorular.A = AListele()[s].ToString();
            sorular.B = BListele()[s].ToString();
            sorular.C = CListele()[s].ToString();
            sorular.D = DListele()[s].ToString();
        }
    }
}
