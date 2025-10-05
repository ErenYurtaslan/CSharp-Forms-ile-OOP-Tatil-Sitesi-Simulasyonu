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