using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;
using System.Diagnostics;

namespace LogicLayer
{
    public class LogicKiralama
    {

        public static List<EntityKiralama> LogicKiralamaList()
        {
            return DalKiralama.kiralıkListesi();
        }

        public static int LogicKiralamaEkle(EntityKiralama entityKiralama)
        {
            return DalKiralama.kiralıkKitapEkle(entityKiralama);
        }

        public static bool LogicKiralıkSil(int p)
        {
            if (p >= 1)
            {
                return DalKiralama.kiralıkKitapSil(p);
            }
            else
            {
                Debug.WriteLine("Hata Logic Ogrenci Sil");
                return false;
            }
        }




    }
}
