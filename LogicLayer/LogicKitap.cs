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
    public class  LogicKitap
    {

        public static List<EntityKitap> LogicKitapList()
        {
            return DALKitap.kitapListele();
        }

        public static int LogicKitapEkle(EntityKitap entityKitap)
        {
            return DALKitap.kitapEkle(entityKitap);
        }

        public static bool LogicKitapSil(int p)
        {
            if (p >= 1)
            {
                return DALKitap.kitapSil(p);
            }
            else
            {
                Debug.WriteLine("Hata Logic Kitap Sil");
                return false;
            }
        }

        public static bool LogicKitapGuncelle(EntityKitap entityKitap)
        {
            return DALKitap.kitapGuncelle(entityKitap);
        }


    }
}
