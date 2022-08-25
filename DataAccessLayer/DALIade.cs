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
    public class DALIade
    {


        public static int iadeKitapEkle(EntityIade entityIade)
        {
            OleDbCommand bagla = new OleDbCommand("Insert Into Iade (OgrenciId,KitapId,DonduguTarih,DonmesiGerekenTarih) VALUES (@P1,@P2,@P3,@P4)", Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }


            bagla.Parameters.AddWithValue("@P1", entityIade.OgrenciId);
            bagla.Parameters.AddWithValue("@P2", entityIade.KitapId);
            bagla.Parameters.AddWithValue("@P3", entityIade.DonduguTarih);
            bagla.Parameters.AddWithValue("@P4", entityIade.DonmesiGerekenTarih);
            return bagla.ExecuteNonQuery();

        }

        public static bool iadeKitapSil(int Id)
        {
            OleDbCommand bagla = new OleDbCommand("Delete from Iade WHERE Id=" + Id, Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }

            return bagla.ExecuteNonQuery() > 0;
        }

        public static List<IadeEdilmisListe> IadeEdilmisListesi(List<EntityIade> entityIades)
        {
            List<IadeEdilmisListe> iadeEdilmis = new List<IadeEdilmisListe>();
            int kiraId = 0;
            foreach (var item in entityIades)
            {
                IadeEdilmisListe bdto = new IadeEdilmisListe();

                List<EntityKiralama> entityKiralamas = new List<EntityKiralama>();
                entityKiralamas = DalKiralama.kiralıkListesi();

                foreach (var item1 in entityKiralamas)
                {

                    if (item1.OgrenciId == item.OgrenciId && item1.KitapId == item.KitapId)
                    {
                        kiraId = item1.Id;
                    }
                }
                bdto.KitapAdi = DALKitap.IdKitap(DalKiralama.IdKiralama(kiraId).KitapId).KitapAdi;
                bdto.OgrenciAdi = DALOgrenci.IdOgrenci(DalKiralama.IdKiralama(kiraId).OgrenciId).OgrenciAdi + " " + DALOgrenci.IdOgrenci(DalKiralama.IdKiralama(item.Id).OgrenciId).OgrenciSoyadi;
                bdto.DonduguTarih = item.DonduguTarih;
                bdto.DonmesiGerekenTarih = DalKiralama.IdKiralama(kiraId).DonmesiGerekenTarih;
                bdto.CezaGunu = item.CezaGunu;
                iadeEdilmis.Add(bdto);
            }
            return iadeEdilmis;
        }

        public static List<EntityIade> IadeListesi()
        {
            List<EntityIade> values = new List<EntityIade>();

            OleDbCommand bagla = new OleDbCommand("SELECT * FROM Iade ", Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }
            OleDbDataReader oku = bagla.ExecuteReader();
            while (oku.Read())
            {
                EntityIade entityI = new EntityIade();
                entityI.Id = int.Parse(oku["Id"].ToString());
                entityI.OgrenciId = int.Parse(oku["OgrenciId"].ToString());
                entityI.KitapId = int.Parse(oku["KitapId"].ToString());
                entityI.DonduguTarih = oku["DonduguTarih"].ToString();
                entityI.DonmesiGerekenTarih = oku["DonmesiGerekenTarih"].ToString();
                entityI.CezaGunu = int.Parse(oku["CezaGunu"].ToString());
                values.Add(entityI);
            }
            oku.Close();
            return values;
        }

        public static EntityIade IdIade(int Id)
        {
            OleDbCommand bagla = new OleDbCommand("Select * from Iade WHERE Id=" + Id, Baglanti.bag);
            if (bagla.Connection.State != ConnectionState.Open)
            {
                bagla.Connection.Open();
            }
            OleDbDataReader oku = bagla.ExecuteReader();
            EntityIade entityI = new EntityIade();
            while (oku.Read())
            {
                entityI.Id = int.Parse(oku["Id"].ToString());
                entityI.OgrenciId = int.Parse(oku["OgrenciId"].ToString());
                entityI.KitapId = int.Parse(oku["KitapId"].ToString());
                entityI.DonduguTarih = oku["DonduguTarih"].ToString();
                entityI.DonmesiGerekenTarih = oku["DonmesiGerekenTarih"].ToString();
                entityI.CezaGunu = int.Parse(oku["CezaGunu"].ToString());
            }

            oku.Close();
            return entityI;
        }




    }
}
