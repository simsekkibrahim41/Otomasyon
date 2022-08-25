using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityKiralama
    {


        private int id;
        private int ogrenciId;
        private int kitapId;
        private string kiraladigiTarih;
        private string donmesiGerekenTarih;

        public int Id { get => id; set => id = value; }
        public int OgrenciId { get => ogrenciId; set => ogrenciId = value; }
        public int KitapId { get => kitapId; set => kitapId = value; }
        public string KiraladigiTarih { get => kiraladigiTarih; set => kiraladigiTarih = value; }
        public string DonmesiGerekenTarih { get => donmesiGerekenTarih; set => donmesiGerekenTarih = value; }


    }

    public class KiralıkKitapListe
    {
        private string kitapAdi;
        private string ogrenciAdi;
        private string kiralamaTarihi;
        private string donusTarihi;

        public string KitapAdi { get => kitapAdi; set => kitapAdi = value; }
        public string OgrenciAdi { get => ogrenciAdi; set => ogrenciAdi = value; }
        public string KiralamaTarihi { get => kiralamaTarihi; set => kiralamaTarihi = value; }
        public string DonusTarihi { get => donusTarihi; set => donusTarihi = value; }
    }

    public class KitapOgrenciBilgi
    {
        private string ismi;
        private string kiralamaTarih;
        private string donusTarih;
        public string Ismi { get => ismi; set => ismi = value; }
        public string KiralamaTarih { get => kiralamaTarih; set => kiralamaTarih = value; }
        public string DonusTarih { get => donusTarih; set => donusTarih = value; }
    }


}
