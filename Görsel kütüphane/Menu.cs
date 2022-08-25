using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Görsel_kütüphane
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnOgrenci_Click(object sender, EventArgs e)
        {
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.ShowDialog();
        }

        private void btnKitap_Click(object sender, EventArgs e)
        {
            Kitap kitap = new Kitap();
            kitap.ShowDialog();
        }

        private void btnKiralama_Click(object sender, EventArgs e)
        {
            Kiralama kiralama = new Kiralama();
            kiralama.ShowDialog();
        }

        private void btnIade_Click(object sender, EventArgs e)
        {
            Iade iade = new Iade();
            iade.ShowDialog();
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            Grafik grafik = new Grafik();
            grafik.ShowDialog();
        }
    }
}
