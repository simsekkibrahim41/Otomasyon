using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DalKiralama
    {

        public static int kiralıkKitapEkle(EntityKiralama entityKiralama)
        {
            OleDbCommand bagla = new OleDbCommand("Insert Into Kiralama (OgrenciId,KitapId,KiraladigiTarih,DonmesiGerekenTarih) VALUES (@P1,@P2,@P3,@P4)", Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }


            bagla.Parameters.AddWithValue("@P1", entityKiralama.OgrenciId);
            bagla.Parameters.AddWithValue("@P2", entityKiralama.KitapId);
            bagla.Parameters.AddWithValue("@P3", entityKiralama.KiraladigiTarih);
            bagla.Parameters.AddWithValue("@P4", entityKiralama.DonmesiGerekenTarih);
            return bagla.ExecuteNonQuery();

        }

        public static bool kiralıkKitapSil(int Id)
        {
            OleDbCommand bagla = new OleDbCommand("Delete from RentedBooks WHERE Id=" + Id, Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }

            return bagla.ExecuteNonQuery() > 0;
        }

        public static List<EntityKiralama> kiralıkListesi()
        {
            List<EntityKiralama> values = new List<EntityKiralama>();

            OleDbCommand bagla = new OleDbCommand("SELECT * FROM Kiralama ", Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }
            OleDbDataReader oku = bagla.ExecuteReader();
            while (oku.Read())
            {
                EntityKiralama entityK = new EntityKiralama();
                entityK.Id = int.Parse(oku["Id"].ToString());
                entityK.OgrenciId = int.Parse(oku["OgrenciId"].ToString());
                entityK.KitapId = int.Parse(oku["KitapId"].ToString());
                entityK.KiraladigiTarih = oku["KiraladigiTarih"].ToString();
                entityK.DonmesiGerekenTarih = oku["DonmesiGerekenTarih"].ToString();
                values.Add(entityK);
            }
            oku.Close();
            return values;
        }

        public static List<KitapOgrenciBilgi> KitapOgrenciBilgileri(List<EntityKiralama> entityKiralamas, int kitapId)
        {
            List<KitapOgrenciBilgi> kitapOgrenci = new List<KitapOgrenciBilgi>();

            foreach (var item in entityKiralamas)
            {

                if (kitapId == item.KitapId)
                {
                    KitapOgrenciBilgi bdto = new KitapOgrenciBilgi();
                    bdto.Ismi = DALOgrenci.IdOgrenci(DalKiralama.IdKiralama(item.Id).OgrenciId).OgrenciAdi + " " + DALOgrenci.IdOgrenci(DalKiralama.IdKiralama(item.Id).OgrenciId).OgrenciSoyadi;
                    bdto.KiralamaTarih = DalKiralama.IdKiralama(item.Id).KiraladigiTarih;
                    bdto.DonusTarih = DalKiralama.IdKiralama(item.Id).DonmesiGerekenTarih;

                    kitapOgrenci.Add(bdto);
                }
            }
            return kitapOgrenci;
        }

        public static List<KitapOgrenciBilgi> OgrenciKitapBilgileri(List<EntityKiralama> entityKiralamas, int ogrenciId)
        {
            List<KitapOgrenciBilgi> kitapOgrenci = new List<KitapOgrenciBilgi>();

            foreach (var item in entityKiralamas)
            {

                if (ogrenciId == item.OgrenciId)
                {
                    KitapOgrenciBilgi bdto = new KitapOgrenciBilgi();
                    bdto.Ismi = DALKitap.IdKitap(DalKiralama.IdKiralama(item.Id).KitapId).KitapAdi;
                    bdto.KiralamaTarih = DalKiralama.IdKiralama(item.Id).KiraladigiTarih;
                    bdto.DonusTarih = DalKiralama.IdKiralama(item.Id).DonmesiGerekenTarih;

                    kitapOgrenci.Add(bdto);
                }
            }
            return kitapOgrenci;
        }

        public static List<KiralıkKitapListe> KiralıkKitapListesi(List<EntityKiralama> kiralıkKitaps)
        {
            List<KiralıkKitapListe> kitapListesi = new List<KiralıkKitapListe>();

            foreach (var item in kiralıkKitaps)
            {
                KiralıkKitapListe bdto = new KiralıkKitapListe();
                bdto.KitapAdi = DALKitap.IdKitap(item.KitapId).KitapAdi;
                bdto.OgrenciAdi = DALOgrenci.IdOgrenci(item.OgrenciId).OgrenciAdi + " " + DALOgrenci.IdOgrenci(item.OgrenciId).OgrenciAdi;
                bdto.KiralamaTarihi = item.KiraladigiTarih;
                bdto.DonusTarihi = item.DonmesiGerekenTarih;

                kitapListesi.Add(bdto);
            }
            return kitapListesi;
        }


        public static EntityKiralama IdKiralama(int Id)
        {
            OleDbCommand bagla = new OleDbCommand("Select * from Kiralama WHERE Id=" + Id, Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }
            OleDbDataReader oku = bagla.ExecuteReader();
            EntityKiralama entityKiralama = new EntityKiralama();
            while (oku.Read())
            {
                entityKiralama.Id = int.Parse(oku["Id"].ToString());
                entityKiralama.OgrenciId = int.Parse(oku["OgrenciId"].ToString());
                entityKiralama.KitapId = int.Parse(oku["KitapId"].ToString());
                entityKiralama.KiraladigiTarih = (oku["KiraladigiTarih"].ToString());
                entityKiralama.DonmesiGerekenTarih = (oku["DonmesiGerekenTarih"].ToString());
            }

            oku.Close();
            return entityKiralama;
        }



    }
}
