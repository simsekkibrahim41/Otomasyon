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
    public class  DALOgrenci
    {


        public static int ogrenciEkle(EntityOgrenci entityOgrenci)
        {
            OleDbCommand bagla = new OleDbCommand("Insert Into Ogrenci (OgrenciAdi,OgrenciSoyadi,OgrenciTc,OgrenciNumarasi,Cezasi) VALUES (@P1,@P2,@P3,@P4,@P5)", Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }


            bagla.Parameters.AddWithValue("@P1", entityOgrenci.OgrenciAdi);
            bagla.Parameters.AddWithValue("@P2", entityOgrenci.OgrenciSoyadi);
            bagla.Parameters.AddWithValue("@P3", entityOgrenci.OgrenciTc);
            bagla.Parameters.AddWithValue("@P4", entityOgrenci.OgrenciNumarasi);
            bagla.Parameters.AddWithValue("@P5", entityOgrenci.Cezasi);

            return bagla.ExecuteNonQuery();

        }

        public static bool OgrenciCeza(EntityOgrenci p)
        {

            OleDbCommand com4 = new OleDbCommand("Update Ogrenci Set Cezasi=@P1 WHERE Id=@P2", Baglanti.bag);
            if (com4.Connection.State != ConnectionState.Open)
            {
                com4.Connection.Open();
            }
            com4.Parameters.AddWithValue("@P1", p.Cezasi);
            com4.Parameters.AddWithValue("@P2", p.Id);
            return com4.ExecuteNonQuery() > 0;
        }

        public static bool ogrenciSil(int Id)
        {
            OleDbCommand bagla = new OleDbCommand("Delete from Ogrenci WHERE Id=" + Id, Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }

            return bagla.ExecuteNonQuery() > 0;
        }

        public static bool ogrenciGuncelle(EntityOgrenci entityOgrenci)
        {

            OleDbCommand bagla = new OleDbCommand("Update Ogrenci Set OgrenciAdi=@P1,OgrenciSoyadi=@P2," +
                                                "OgrenciTc=@P3,OgrenciNumarasi=@P4,Cezasi=@P5 WHERE Id=@P6", Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }
            bagla.Parameters.AddWithValue("@P1", entityOgrenci.OgrenciAdi);
            bagla.Parameters.AddWithValue("@P2", entityOgrenci.OgrenciSoyadi);
            bagla.Parameters.AddWithValue("@P3", entityOgrenci.OgrenciTc);
            bagla.Parameters.AddWithValue("@P4", entityOgrenci.OgrenciNumarasi);
            bagla.Parameters.AddWithValue("@P5", entityOgrenci.Cezasi);
            bagla.Parameters.AddWithValue("@P6", entityOgrenci.Id);
            return bagla.ExecuteNonQuery() > 0;
        }

        public static List<EntityOgrenci> ogrenciListele()
        {
            List<EntityOgrenci> values = new List<EntityOgrenci>();
            OleDbCommand bagla = new OleDbCommand("SELECT * FROM Ogrenci ", Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }
            OleDbDataReader oku = bagla.ExecuteReader();
            while (oku.Read())
            {
                EntityOgrenci entityO = new EntityOgrenci();
                entityO.Id = int.Parse(oku["Id"].ToString());
                entityO.OgrenciAdi = oku["OgrenciAdi"].ToString();
                entityO.OgrenciSoyadi = oku["OgrenciSoyadi"].ToString();
                entityO.OgrenciTc = int.Parse(oku["OgrenciTc"].ToString());
                entityO.OgrenciNumarasi = int.Parse(oku["OgrenciNumarasi"].ToString());
                entityO.Cezasi = float.Parse(oku["Cezasi"].ToString());
                values.Add(entityO);
            }
            oku.Close();
            return values;
        }

        public static EntityOgrenci IdOgrenci(int Id)
        {
            OleDbCommand bagla = new OleDbCommand("Select * from Ogrenci WHERE Id=" + Id, Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }
            OleDbDataReader oku = bagla.ExecuteReader();
            EntityOgrenci entityOgrenci = new EntityOgrenci();
            while (oku.Read())
            {
                entityOgrenci.Id = int.Parse(oku["Id"].ToString());
                entityOgrenci.OgrenciAdi = oku["OgrenciAdi"].ToString();
                entityOgrenci.OgrenciSoyadi = oku["OgrenciSoyadi"].ToString();
                entityOgrenci.OgrenciNumarasi = int.Parse(oku["OgrenciNumarasi"].ToString());
                entityOgrenci.OgrenciTc = int.Parse(oku["OgrenciTc"].ToString());
                entityOgrenci.Cezasi = float.Parse(oku["Cezasi"].ToString());
            }

            oku.Close();
            return entityOgrenci;
        }




    }
}
