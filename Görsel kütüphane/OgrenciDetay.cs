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
    public partial class OgrenciDetay : Form
    {
        int ogrenciId;

        public OgrenciDetay(int id)
        {
            InitializeComponent();
            ogrenciId = id;
            Doldur();
        }

        List<EntityOgrenci> ogrenciListesi = LogicOgrenci.LogicOgrenciList();
        List<EntityKiralama> kiralamaListesi = LogicKiralama.LogicKiralamaList();

        public void Doldur()
        {

            foreach (var item in ogrenciListesi)
            {
                if (item.Id == ogrenciId)
                {
                    txtOgrenciAdi.Text = item.OgrenciAdi;
                    txtOgrenciSoyadi.Text = item.OgrenciSoyadi;
                    txtTc.Text = item.OgrenciTc.ToString();
                    txtOgrenciNo.Text = item.OgrenciNumarasi.ToString();
                    txtCeza.Text = item.Cezasi.ToString();

                    dataGridView1.DataSource = DalKiralama.OgrenciKitapBilgileri(kiralamaListesi, ogrenciId);


                }
            }
        }

        public void Kontrol()
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(dr.Cells[1].Value);
                TimeSpan time = DateTime.Now.Subtract(dt);
                TimeSpan span = new TimeSpan(-2, 0, 0, 0, 0);
                TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, 0);
                //bool check = Convert.ToBoolean(dr.Cells[4].Value);


                if (time > timeSpan)
                {
                    dr.Cells[1].Style.BackColor = Color.Red;
                }

                if (time < timeSpan && time > span)
                {
                    dr.Cells[1].Style.BackColor = Color.Yellow;
                }
            }
        }


        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            EntityOgrenci entityOgrenci = new EntityOgrenci();
            entityOgrenci.Id = ogrenciId;
            entityOgrenci.OgrenciAdi = txtOgrenciAdi.Text;
            entityOgrenci.OgrenciSoyadi = txtOgrenciSoyadi.Text;
            entityOgrenci.OgrenciNumarasi = int.Parse(txtOgrenciNo.Text);
            entityOgrenci.OgrenciTc = int.Parse(txtTc.Text);
            entityOgrenci.Cezasi = float.Parse(txtCeza.Text);
            LogicOgrenci.LogicOgrenciGuncelle(entityOgrenci);
            MessageBox.Show("Güncellendi");
        }

        private void btnKontrol_Click(object sender, EventArgs e)
        {
            Kontrol();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            LogicOgrenci.LogicOgrenciSil(ogrenciId);
            MessageBox.Show("Silindi");
            this.Close();
        }
    }
}
