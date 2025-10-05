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