using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityKitap
    {

        private int id;
        private string kitapAdi;
        private string yazarAdi;
        private int sayfaSayisi;
        private int kiralamaSüresi;
        private string basimYili;
        public int Id { get => id; set => id = value; }

        public string KitapAdi { get => kitapAdi; set => kitapAdi = value; }
        public string YazarAdi { get => yazarAdi; set => yazarAdi = value; }
        public int SayfaSayisi { get => sayfaSayisi; set => sayfaSayisi = value; }
        public int KiralamaSüresi { get => kiralamaSüresi; set => kiralamaSüresi = value; }
        public string BasimYili { get => basimYili; set => basimYili = value; }


    }
}
