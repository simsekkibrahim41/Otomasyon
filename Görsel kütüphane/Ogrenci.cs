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
    public partial class Ogrenci : Form
    {
        public Ogrenci()
        {
            InitializeComponent();
            OgrenciListele();
        }


        List<EntityOgrenci> OgrenciListesi = LogicOgrenci.LogicOgrenciList();
        int ogrenciId;

        public void OgrenciListele()
        {
            OgrenciListesi = LogicOgrenci.LogicOgrenciList();
            dataGridView1.DataSource = OgrenciListesi;
            this.dataGridView1.Columns["Id"].Visible = false;

        }

        private void btnOgrenciEkle_Click(object sender, EventArgs e)
        {
            EntityOgrenci entityOgrenci = new EntityOgrenci();
            entityOgrenci.OgrenciAdi = txtOgrenciAdi.Text;
            entityOgrenci.OgrenciSoyadi = txtOgrenciSoyadı.Text;
            entityOgrenci.OgrenciTc = int.Parse(txtOgrenciTc.Text);
            entityOgrenci.OgrenciNumarasi = int.Parse(txtOgrenciNo.Text);
            entityOgrenci.Cezasi = 0;
            LogicOgrenci.LogicOgrenciEkle(entityOgrenci);
            OgrenciListele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ogrenciId = OgrenciListesi[e.RowIndex].Id;
            OgrenciDetay ogrenciDetay = new OgrenciDetay(ogrenciId);
            ogrenciDetay.Show();
        }
    }
    }

