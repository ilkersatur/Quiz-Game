using BilgiYarismasiOyunu.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYarismasiOyunu.DAL
{
    internal class SoruYonetici : ICRUD<Sorular>
    {
        public List<Sorular> Ara(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Sorular.SoruID,Sorular.Soru,Sorular.A,Sorular.B,Sorular.C,Sorular.D,Sorular.Cevap,Cevaplar.Cevap,Sorular.SoruTipi,SoruTipleri.Tip\r\nFROM     Cevaplar INNER JOIN\r\n                  Sorular ON Cevaplar.CevapID = Sorular.Cevap INNER JOIN\r\n                  SoruTipleri ON Sorular.SoruTipi = SoruTipleri.TipID";
            cmd.Connection = OyunDB._conn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Sorular> sorular = new List<Sorular>();
            while (reader.Read())
            {
                Sorular soru = new Sorular();
                soru.Soru = reader.GetString(id);
                sorular.Add(soru);
            }
            OyunDB._conn.Close();
            return sorular;
        }

        public List<Sorular> SoruListele()
        {
            OyunDB._conn.Open();
            return Ara(1);
        }

        public List<Sorular> AListele()
        {
            throw new NotImplementedException();
        }

        public List<Sorular> BListele()
        {
            throw new NotImplementedException();
        }

        public List<Sorular> CListele()
        {
            throw new NotImplementedException();
        }

        public List<Sorular> DListele()
        {
            throw new NotImplementedException();
        }

        public void Ekle(Sorular entity)
        {
            throw new NotImplementedException();
        }
    }
}

