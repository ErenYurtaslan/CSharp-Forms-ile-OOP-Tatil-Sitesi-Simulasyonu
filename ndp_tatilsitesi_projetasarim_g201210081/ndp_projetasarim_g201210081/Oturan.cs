
using System;

namespace ndp_projetasarim_g201210081
{
    public abstract class Oturan
    {
        public string AdSoyad { get; set; }
        public int Borc { get; set; }

        public Oturan(string adSoyad, int borc)
        {
            AdSoyad = adSoyad;
            Borc = borc;
        }
    }

    public class AileReisi : Oturan
    {
        public string DaireNo { get; set; }
        public AileReisi(string adSoyad, int borc, string daireNo) : base(adSoyad, borc)
        {
            DaireNo = daireNo;
        }
    }

    public class Misafir : Oturan
    {
        public Misafir(string adSoyad, int borc) : base(adSoyad, borc) { }
    }
} 
