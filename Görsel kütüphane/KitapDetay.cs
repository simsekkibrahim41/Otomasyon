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
    public partial class KitapDetay : Form
    {
        int kitapId;

        public KitapDetay(int id)
        {
            kitapId = id;
            InitializeComponent();
            Doldur();
            dataGridView1.Columns[1].Name = "Öğrenci Adı";


        }

        List<EntityKitap> kitapListesi = LogicKitap.LogicKitapList();
        List<EntityKiralama> kiralamaListesi = LogicKiralama.LogicKiralamaList();
        public void Doldur()
        {

            foreach (var item in kitapListesi)
            {
                if (item.Id == kitapId)
                {
                    txtKitapAdi.Text = item.KitapAdi;
                    txtYazarAdi.Text = item.YazarAdi;
                    txtSayfa.Text = item.SayfaSayisi.ToString();
                    txtSure.Text = item.KiralamaSüresi.ToString();
                    txtYil.Text = item.BasimYili;
                    dataGridView1.DataSource = DalKiralama.KitapOgrenciBilgileri(kiralamaListesi, kitapId);
                }
            }

        }





        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            EntityKitap entityKitap = new EntityKitap();
            entityKitap.Id = kitapId;
            entityKitap.KitapAdi = txtKitapAdi.Text;
            entityKitap.YazarAdi = txtYazarAdi.Text;
            entityKitap.SayfaSayisi = int.Parse(txtSayfa.Text);
            entityKitap.KiralamaSüresi = int.Parse(txtSure.Text);
            entityKitap.BasimYili = txtYil.Text;

            LogicKitap.LogicKitapGuncelle(entityKitap);
            MessageBox.Show("Güncellendi");

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            LogicKitap.LogicKitapSil(kitapId);
            MessageBox.Show("Silindi");
            this.Close();
        }
    }
}
