
using System;

namespace ndp_projetasarim_g201210081
{
    public class Odeme
    {
        public string AdSoyad { get; set; }
        public int Tutar { get; set; }
        public string DaireNo { get; set; } // Misafir için boş olabilir

        public Odeme(string adSoyad, int tutar, string daireNo)
        {
            AdSoyad = adSoyad;
            Tutar = tutar;
            DaireNo = daireNo;
        }
    }
} 
