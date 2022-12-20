using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYarismasiOyunu.DAL
{
    internal interface ICRUD<T> where T : class
    {
        void Ekle(T entity);
        List<T> SoruListele();
        List<T> AListele();
        List<T> BListele();
        List<T> CListele();
        List<T> DListele();
        List<T> Ara(int id);
    }
}
