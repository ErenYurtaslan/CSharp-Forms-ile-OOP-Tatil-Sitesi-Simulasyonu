/******************************************************************************
**
**        SAKARYA ÜNİVERSİTESİ
**        BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**        BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**        NESNEYE DAYALI PROGRAMLAMA DERSİ
**        2024-2025 BAHAR DÖNEMİ
**
**        ÖDEV NUMARASI........: 3
**        ÖĞRENCİ ADI..........: Abdulkadir Eren Yurtaslan
**        ÖĞRENCİ NUMARASI.....: g201210081
**        DERSİN ALINDIĞI GRUP.: 2/A
******************************************************************************/
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