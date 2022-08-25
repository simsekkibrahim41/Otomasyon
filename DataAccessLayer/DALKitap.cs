using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.OleDb;
using System.Data;


namespace DataAccessLayer
{
    public class  DALKitap
    {


        public static int kitapEkle(EntityKitap entityKitap)
        {
            OleDbCommand bagla = new OleDbCommand("Insert Into Kitap (KitapAdi,YazarAdi,SayfaSayisi,KiralamaSuresi,BasimYili) VALUES (@P1,@P2,@P3,@P4,@P5)", Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }


            bagla.Parameters.AddWithValue("@P1", entityKitap.KitapAdi);
            bagla.Parameters.AddWithValue("@P2", entityKitap.YazarAdi);
            bagla.Parameters.AddWithValue("@P3", entityKitap.SayfaSayisi);
            bagla.Parameters.AddWithValue("@P4", entityKitap.KiralamaSüresi);
            bagla.Parameters.AddWithValue("@P5", entityKitap.BasimYili);

            return bagla.ExecuteNonQuery();

        }

        public static bool kitapSil(int Id)
        {
            OleDbCommand bagla = new OleDbCommand("Delete from Kitap WHERE Id=" + Id, Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }

            return bagla.ExecuteNonQuery() > 0;
        }

        public static bool kitapGuncelle(EntityKitap entityKitap)
        {

            OleDbCommand bagla = new OleDbCommand("Update Kitap Set KitapAdi=@P1,YazarAdi=@P2," +
                                                "SayfaSayisi=@P3,KiralamaSuresi=@P4,BasimYili=@P5 WHERE Id=@P6", Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }
            bagla.Parameters.AddWithValue("@P1", entityKitap.KitapAdi);
            bagla.Parameters.AddWithValue("@P2", entityKitap.YazarAdi);
            bagla.Parameters.AddWithValue("@P3", entityKitap.SayfaSayisi);
            bagla.Parameters.AddWithValue("@P4", entityKitap.KiralamaSüresi);
            bagla.Parameters.AddWithValue("@P5", entityKitap.BasimYili);
            bagla.Parameters.AddWithValue("@P6", entityKitap.Id);
            return bagla.ExecuteNonQuery() > 0;
        }

        public static List<EntityKitap> kitapListele()
        {
            List<EntityKitap> values = new List<EntityKitap>();
            OleDbCommand bagla = new OleDbCommand("SELECT * FROM Kitap ", Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }
            OleDbDataReader oku = bagla.ExecuteReader();
            while (oku.Read())
            {
                EntityKitap entB = new EntityKitap();
                entB.Id = int.Parse(oku["Id"].ToString());
                entB.KitapAdi = oku["KitapAdi"].ToString();
                entB.YazarAdi = oku["YazarAdi"].ToString();
                entB.SayfaSayisi = int.Parse(oku["SayfaSayisi"].ToString());
                entB.KiralamaSüresi = int.Parse(oku["KiralamaSuresi"].ToString());
                entB.BasimYili = oku["BasimYili"].ToString();
                values.Add(entB);
            }
            oku.Close();
            return values;
        }

        public static EntityKitap IdKitap(int Id)
        {
            OleDbCommand bagla = new OleDbCommand("Select * from Kitap WHERE Id=" + Id, Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }
            OleDbDataReader oku = bagla.ExecuteReader();
            EntityKitap entityKitap = new EntityKitap();
            while (oku.Read())
            {
                entityKitap.Id = int.Parse(oku["Id"].ToString());
                entityKitap.KitapAdi = oku["KitapAdi"].ToString();
                entityKitap.YazarAdi = oku["YazarAdi"].ToString();
                entityKitap.SayfaSayisi = int.Parse(oku["SayfaSayisi"].ToString());
                entityKitap.KiralamaSüresi = int.Parse(oku["KiralamaSuresi"].ToString());
                entityKitap.BasimYili = oku["BasimYili"].ToString();
            }

            oku.Close();
            return entityKitap;
        }




    }
}
