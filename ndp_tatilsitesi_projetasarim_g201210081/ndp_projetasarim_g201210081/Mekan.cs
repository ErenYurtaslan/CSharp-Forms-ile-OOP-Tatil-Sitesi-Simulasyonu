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
    public class Mekan
    {
        public string Tur { get; set; }
        public string Ad { get; set; }

        public Mekan(string tur, string ad)
        {
            Tur = tur;
            Ad = ad;
        }
    }

    public class Daire : Mekan
    {
        public Daire(string ad) : base("Daire", ad) { }
    }

    public class Fitness : Mekan
    {
        public Fitness(string ad) : base("Fitness", ad) { }
    }

    public class Havuz : Mekan
    {
        public Havuz(string ad) : base("Havuz", ad) { }
    }
} 