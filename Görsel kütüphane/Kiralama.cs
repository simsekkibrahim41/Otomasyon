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
    public partial class Kiralama : Form
    {
        public Kiralama()
        {
            InitializeComponent();
            KiralamaBaslangic();
            KiralamaListele();
        }

        List<EntityOgrenci> OgrenciListesi = LogicOgrenci.LogicOgrenciList();
        List<EntityKitap> KitapListesi = LogicKitap.LogicKitapList();
        List<EntityKiralama> KiralanmısListesi = LogicKiralama.LogicKiralamaList();
        int ogrenciId, kitapId;

        public void KiralamaBaslangic()
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
            lblDonusTarih.Text = dtKiralama.Value.Date.ToShortDateString();

        }

        public void KiralamaListele()
        {
            KiralanmısListesi = LogicKiralama.LogicKiralamaList();
            dataGridView1.DataSource = DalKiralama.KiralıkKitapListesi(KiralanmısListesi);
        }

        public void KiralamaBilgileri()
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
        }

        

        private void btnKirala_Click(object sender, EventArgs e)
        {
            KiralamaBilgileri();
            EntityKiralama entityKiralama = new EntityKiralama();
            entityKiralama.OgrenciId = ogrenciId;
            entityKiralama.KitapId = kitapId;
            entityKiralama.KiraladigiTarih = dtKiralama.Value.Date.ToShortDateString();
            entityKiralama.DonmesiGerekenTarih = lblDonusTarih.Text;
            LogicKiralama.LogicKiralamaEkle(entityKiralama);
            KiralamaListele();
        }

        private void dtKiralama_ValueChanged(object sender, EventArgs e)
        {

            lblDonusTarih.Text = dtKiralama.Value.AddDays(30).ToShortDateString();

        }

        private void btnKontrol_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                DateTime dt = new DateTime();
                DateTime drTime = new DateTime();
                dt = Convert.ToDateTime(dr.Cells[3].Value);
                drTime = Convert.ToDateTime(DateTime.Now);
                TimeSpan time = drTime.Subtract(dt);
                TimeSpan span = new TimeSpan(-2, 0, 0, 0, 0);
                TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, 0);


                if (time > timeSpan)
                {
                    dr.Cells[3].Style.BackColor = Color.Red;
                }
                else if (time < timeSpan && time > span)
                {
                    dr.Cells[3].Style.BackColor = Color.Yellow;
                }
                else
                {
                    dr.Cells[3].Style.BackColor = Color.Green;
                }
            }
        }








    }
}
