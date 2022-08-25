using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using LogicLayer;

namespace Görsel_kütüphane
{
    public partial class Iade : Form
    {
        public Iade()
        {
            InitializeComponent();
            IadeBaslangic();
            Listele();
        }

        List<EntityOgrenci> OgrenciListesi = LogicOgrenci.LogicOgrenciList();
        List<EntityKitap> KitapListesi = LogicKitap.LogicKitapList();
        List<EntityIade> IadeListesi = LogicIade.LogicıadeList();
        List<EntityKiralama> KiralanmısListesi = LogicKiralama.LogicKiralamaList();
        int ogrenciId, kitapId, kiraId;


        public void Listele()
        {
            IadeListesi = LogicIade.LogicıadeList();
            dataGridView1.DataSource = DALIade.IadeEdilmisListesi(IadeListesi);
        }

        public void IadeBaslangic()
        {
            foreach (var item in OgrenciListesi)
            {
                cbOgrenci.Items.Add(item.OgrenciAdi + " " + item.OgrenciSoyadi);
            }
            foreach (var item in KitapListesi)
            {
                cbKitap.Items.Add(item.KitapAdi);
            }
            cbKitap.SelectedIndex = 0;
            cbOgrenci.SelectedIndex = 0;
        }

        private void btnKontrol_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                DateTime dt = new DateTime();
                DateTime drTime = new DateTime();
                dt = Convert.ToDateTime(dr.Cells[2].Value);
                drTime = Convert.ToDateTime(dr.Cells[3].Value);
                TimeSpan time = drTime.Subtract(dt);
                TimeSpan span = new TimeSpan(2, 0, 0, 0, 0);
                TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, 0);


                if (time < timeSpan)
                {
                    dr.Cells[2].Style.BackColor = Color.Red;
                }
                else if (time > timeSpan && time < span)
                {
                    dr.Cells[2].Style.BackColor = Color.Yellow;
                }
                else
                {
                    dr.Cells[2].Style.BackColor = Color.Green;
                }
            }
        }

        public void IadeBilgileri()
        {
            foreach (var item in OgrenciListesi)
            {
                if (cbOgrenci.SelectedItem.ToString() == item.OgrenciAdi + " " + item.OgrenciSoyadi)
                {
                    ogrenciId = item.Id;
                }
            }
            foreach (var item in KitapListesi)
            {
                if (cbKitap.SelectedItem.ToString() == item.KitapAdi)
                {
                    kitapId = item.Id;
                }
            }
            foreach (var item in KiralanmısListesi)
            {
                if (item.OgrenciId == ogrenciId && item.KitapId == kitapId)
                {
                    kiraId = item.Id;
                }
            }
        }

        private void btnIade_Click(object sender, EventArgs e)
        {

            IadeBilgileri();
            EntityOgrenci entityOgrenci = new EntityOgrenci();
            entityOgrenci.Id = ogrenciId;
            EntityIade entityIade = new EntityIade();
            entityIade.OgrenciId = ogrenciId;
            entityIade.KitapId = kitapId;
            entityIade.DonduguTarih = dtIade.Value.ToShortDateString();
            entityIade.DonmesiGerekenTarih = DalKiralama.IdKiralama(kiraId).DonmesiGerekenTarih;
            if (CezaKontrol(dtIade.Value) == true)
            {
                TimeSpan time = DateTime.Now.Subtract(dtIade.Value.Date);
                int x = (int)time.TotalMinutes;
                entityIade.CezaGunu = -(x / 60) / 24;
                entityOgrenci.Cezasi += -(x / 60) / 24;
            }
            else
            {
                entityIade.CezaGunu = 0;
            }
            LogicIade.LogicIadeEkle(entityIade);
            LogicOgrenci.LogicOgrenciCeza(entityOgrenci);
            Listele();
        }

        private void cbOgrenci_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbKitap.Items.Clear();
            foreach (var item in KiralanmısListesi)
            {
                if (cbOgrenci.SelectedItem.ToString() == DALOgrenci.IdOgrenci(item.OgrenciId).OgrenciAdi + " " + DALOgrenci.IdOgrenci(item.OgrenciId).OgrenciSoyadi)
                {
                    ogrenciId = DALOgrenci.IdOgrenci(item.OgrenciId).Id;
                    if (item.OgrenciId == ogrenciId)
                    {
                        cbKitap.Items.Add(DALKitap.IdKitap(item.KitapId).KitapAdi);
                    }
                }
            }
        }

        public bool CezaKontrol(DateTime zaman)
        {
            TimeSpan time = DateTime.Now.Subtract(zaman);
            TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, 0);

            if (time < timeSpan)
            {
                return true;
            }
            else
            {
                return false;
            }
        }







    }
}
