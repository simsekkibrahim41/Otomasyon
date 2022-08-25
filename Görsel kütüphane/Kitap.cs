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
    public partial class Kitap : Form
    {
        public Kitap()
        {
            InitializeComponent();
            OgrenciListele();
        }

        List<EntityKitap> KitapListesi = LogicKitap.LogicKitapList();
        int kitapId;


        public void OgrenciListele()
        {
            KitapListesi = LogicKitap.LogicKitapList();
            dataGridView1.DataSource = KitapListesi;
            this.dataGridView1.Columns["Id"].Visible = false;

        }


        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            EntityKitap entityKitap = new EntityKitap();
            entityKitap.KitapAdi = txtKitapAdi.Text;
            entityKitap.YazarAdi = txtYazarAdı.Text;
            entityKitap.SayfaSayisi = int.Parse(txtSayfa.Text);
            entityKitap.KiralamaSüresi = int.Parse(txtSure.Text);
            entityKitap.BasimYili = txtBasimYili.Text;
            LogicKitap.LogicKitapEkle(entityKitap);
            OgrenciListele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            kitapId = KitapListesi[e.RowIndex].Id;
            KitapDetay kitapDetay = new KitapDetay(kitapId);
            kitapDetay.Show();
        }

        private void Kitap_Load(object sender, EventArgs e)
        {

        }
    }
}
