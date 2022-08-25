using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityOgrenci
    {

        private int id;
        private string ogrenciAdi;
        private string ogrenciSoyadi;
        private int ogrenciTc;
        private int ogrenciNumarasi;
        private float cezasi;

        public int Id { get => id; set => id = value; }
        public string OgrenciAdi { get => ogrenciAdi; set => ogrenciAdi = value; }
        public string OgrenciSoyadi { get => ogrenciSoyadi; set => ogrenciSoyadi = value; }
        public int OgrenciTc { get => ogrenciTc; set => ogrenciTc = value; }
        public int OgrenciNumarasi { get => ogrenciNumarasi; set => ogrenciNumarasi = value; }
        public float Cezasi { get => cezasi; set => cezasi = value; }


    }
}
