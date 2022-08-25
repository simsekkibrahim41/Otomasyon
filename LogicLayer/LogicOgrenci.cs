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
    public class LogicOgrenci
    {

        public static List<EntityOgrenci> LogicOgrenciList()
        {
            return DALOgrenci.ogrenciListele();
        }

        public static int LogicOgrenciEkle(EntityOgrenci entityOgrenci)
        {
            return DALOgrenci.ogrenciEkle(entityOgrenci);
        }

        public static bool LogicOgrenciSil(int p)
        {
            if (p >= 1)
            {
                return DALOgrenci.ogrenciSil(p);
            }
            else
            {
                Debug.WriteLine("Hata Logic Ogrenci Sil");
                return false;
            }
        }

        public static bool LogicOgrenciGuncelle(EntityOgrenci entityOgrenci)
        {
            return DALOgrenci.ogrenciGuncelle(entityOgrenci);
        }

        public static bool LogicOgrenciCeza(EntityOgrenci entityOgrenci)
        {

            return DALOgrenci.OgrenciCeza(entityOgrenci);

        }


    }
}
