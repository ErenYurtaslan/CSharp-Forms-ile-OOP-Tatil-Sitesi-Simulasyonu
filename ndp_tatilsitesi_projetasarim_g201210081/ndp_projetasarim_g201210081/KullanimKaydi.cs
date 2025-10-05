
using System;

namespace ndp_projetasarim_g201210081
{
    public class KullanimKaydi
    {
        public string AdSoyad { get; set; }
        public string DaireNo { get; set; } // Misafir için boş olabilir
        public string KullaniciTipi { get; set; } // AileReisi veya Misafir
        public string MekanAdi { get; set; } // Hangi havuz/fitness salonu
        public string Sonuc { get; set; } // Kullandirildi, Kullandirilamadi (Borc Var) vb.

        public KullanimKaydi(string adSoyad, string daireNo, string kullaniciTipi, string mekanAdi, string sonuc)
        {
            AdSoyad = adSoyad;
            DaireNo = daireNo;
            KullaniciTipi = kullaniciTipi;
            MekanAdi = mekanAdi;
            Sonuc = sonuc;
        }
        public KullanimKaydi() { }
    }
} 
