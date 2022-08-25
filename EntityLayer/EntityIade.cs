using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityIade
    {

        private int id;
        private int ogrenciId;
        private int kitapId;
        private string donduguTarih;
        private string donmesiGerekenTarih;
        private int cezaGunu;

        public int Id { get => id; set => id = value; }
        public int OgrenciId { get => ogrenciId; set => ogrenciId = value; }
        public int KitapId { get => kitapId; set => kitapId = value; }
        public string DonduguTarih { get => donduguTarih; set => donduguTarih = value; }
        public string DonmesiGerekenTarih { get => donmesiGerekenTarih; set => donmesiGerekenTarih = value; }
        public int CezaGunu { get => cezaGunu; set => cezaGunu = value; }

    }

    public class IadeEdilmisListe
    {
        private string kitapAdi;
        private string ogrenciAdi;
        private string donduguTarih;
        private string donmesiGerekenTarih;
        private int cezaGunu;


        public string KitapAdi { get => kitapAdi; set => kitapAdi = value; }
        public string OgrenciAdi { get => ogrenciAdi; set => ogrenciAdi = value; }
        public string DonduguTarih { get => donduguTarih; set => donduguTarih = value; }
        public string DonmesiGerekenTarih { get => donmesiGerekenTarih; set => donmesiGerekenTarih = value; }
        public int CezaGunu { get => cezaGunu; set => cezaGunu = value; }
    }

}
