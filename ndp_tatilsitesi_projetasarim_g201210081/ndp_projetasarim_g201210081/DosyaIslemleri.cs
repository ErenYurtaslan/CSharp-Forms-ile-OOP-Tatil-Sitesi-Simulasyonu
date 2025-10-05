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
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace ndp_projetasarim_g201210081
{
    public static class DosyaIslemleri
    {
        // Mekan işlemleri
        public static List<Mekan> MekanlariOku(string dosyaYolu)
        {
            dosyaYolu = System.IO.Path.Combine(Application.StartupPath, dosyaYolu);
            if (!File.Exists(dosyaYolu)) File.Create(dosyaYolu).Close();
            var mekanlar = new List<Mekan>();
            var satirlar = File.ReadAllLines(dosyaYolu);
            foreach (var satir in satirlar)
            {
                var parca = satir.Split(',');
                if (parca.Length >= 2)
                    mekanlar.Add(new Mekan(parca[0].Trim(), parca[1].Trim()));
            }
            return mekanlar;
        }
        public static void MekanEkle(string dosyaYolu, Mekan mekan)
        {
            dosyaYolu = System.IO.Path.Combine(Application.StartupPath, dosyaYolu);
            if (!File.Exists(dosyaYolu)) File.Create(dosyaYolu).Close();
            File.AppendAllText(dosyaYolu, $"{mekan.Tur},{mekan.Ad}\n");
        }
        public static void MekanSil(string dosyaYolu, string mekanAdi)
        {
            dosyaYolu = System.IO.Path.Combine(Application.StartupPath, dosyaYolu);
            if (!File.Exists(dosyaYolu)) File.Create(dosyaYolu).Close();
            var mekanlar = MekanlariOku(dosyaYolu);
            mekanlar.RemoveAll(m => m.Ad == mekanAdi);
            File.WriteAllLines(dosyaYolu, mekanlar.ConvertAll(m => $"{m.Tur},{m.Ad}"));
        }
        public static void MekanGuncelle(string dosyaYolu, string eskiAd, string yeniAd)
        {
            dosyaYolu = System.IO.Path.Combine(Application.StartupPath, dosyaYolu);
            if (!File.Exists(dosyaYolu)) File.Create(dosyaYolu).Close();
            var mekanlar = MekanlariOku(dosyaYolu);
            foreach (var m in mekanlar)
                if (m.Ad == eskiAd) m.Ad = yeniAd;
            File.WriteAllLines(dosyaYolu, mekanlar.ConvertAll(m => $"{m.Tur},{m.Ad}"));
        }

        // Oturan işlemleri
        public static List<Oturan> OturanlariOku(string dosyaYolu)
        {
            dosyaYolu = System.IO.Path.Combine(Application.StartupPath, dosyaYolu);
            if (!File.Exists(dosyaYolu)) File.Create(dosyaYolu).Close();
            var oturanlar = new List<Oturan>();
            var satirlar = File.ReadAllLines(dosyaYolu);
            foreach (var satir in satirlar)
            {
                var parca = satir.Split(',');
                if (parca[0].Trim() == "AileReisi" && parca.Length >= 4)
                    oturanlar.Add(new AileReisi(parca[1].Trim(), int.Parse(parca[2].Trim()), parca[3].Trim()));
                else if (parca[0].Trim() == "Misafir" && parca.Length >= 3)
                    oturanlar.Add(new Misafir(parca[1].Trim(), int.Parse(parca[2].Trim())));
            }
            return oturanlar;
        }
        public static void OturanEkle(string dosyaYolu, Oturan oturan)
        {
            dosyaYolu = System.IO.Path.Combine(Application.StartupPath, dosyaYolu);
            if (!File.Exists(dosyaYolu)) File.Create(dosyaYolu).Close();
            if (oturan is AileReisi ar)
                File.AppendAllText(dosyaYolu, $"AileReisi,{ar.AdSoyad},{ar.Borc},{ar.DaireNo}\n");
            else if (oturan is Misafir m)
                File.AppendAllText(dosyaYolu, $"Misafir,{m.AdSoyad},{m.Borc},\n");
        }
        public static void OturanSil(string dosyaYolu, string adSoyad, string daireNo = "")
        {
            dosyaYolu = System.IO.Path.Combine(Application.StartupPath, dosyaYolu);
            if (!File.Exists(dosyaYolu)) File.Create(dosyaYolu).Close();
            var oturanlar = OturanlariOku(dosyaYolu);
            oturanlar.RemoveAll(o => {
                AileReisi ar = o as AileReisi;
                return o.AdSoyad == adSoyad && (ar != null ? ar.DaireNo == daireNo : true);
            });
            File.WriteAllLines(dosyaYolu, oturanlar.ConvertAll(o => {
                AileReisi ar = o as AileReisi;
                return ar != null ? $"AileReisi,{ar.AdSoyad},{ar.Borc},{ar.DaireNo}" : $"Misafir,{o.AdSoyad},{o.Borc},";
            }));
        }
        public static void OturanGuncelle(string dosyaYolu, string eskiAdSoyad, string yeniAdSoyad, int yeniBorc, string yeniTip, string yeniDaireNo)
        {
            dosyaYolu = System.IO.Path.Combine(Application.StartupPath, dosyaYolu);
            if (!File.Exists(dosyaYolu)) File.Create(dosyaYolu).Close();
            var oturanlar = OturanlariOku(dosyaYolu);
            // Eski kaydı sil
            oturanlar.RemoveAll(o => o.AdSoyad == eskiAdSoyad);
            // Yeni kaydı ekle
            if (yeniTip == "AileReisi")
                oturanlar.Add(new AileReisi(yeniAdSoyad, yeniBorc, yeniDaireNo));
            else
                oturanlar.Add(new Misafir(yeniAdSoyad, 0));
            File.WriteAllLines(dosyaYolu, oturanlar.ConvertAll(o => {
                AileReisi ar = o as AileReisi;
                return ar != null ? $"AileReisi,{ar.AdSoyad},{ar.Borc},{ar.DaireNo}" : $"Misafir,{o.AdSoyad},{o.Borc},";
            }));
            // Kişi adı veya daire değiştiyse kullanım kayıtlarında da güncelle
            if (eskiAdSoyad != yeniAdSoyad || !string.IsNullOrEmpty(yeniDaireNo))
            {
                string[] dosyalar = { "Fitness.txt", "HavuzKul.txt" };
                foreach (var dosya in dosyalar)
                {
                    string path = System.IO.Path.Combine(Application.StartupPath, dosya);
                    if (!System.IO.File.Exists(path)) continue;
                    var satirlar = System.IO.File.ReadAllLines(path);
                    for (int i = 0; i < satirlar.Length; i++)
                    {
                        var parca = satirlar[i].Split(',');
                        // Ad ve daire karşılaştırmasını büyük/küçük harf ve Türkçe karakter duyarsız yap
                        bool adEslesme = parca.Length >= 1 && string.Equals(parca[0].Trim(), eskiAdSoyad.Trim(), System.StringComparison.InvariantCultureIgnoreCase);
                        bool daireEslesme = parca.Length >= 2 && (!string.IsNullOrEmpty(yeniDaireNo) ? string.Equals(parca[1].Trim(), yeniDaireNo.Trim(), System.StringComparison.InvariantCultureIgnoreCase) : false);
                        if (adEslesme)
                            parca[0] = yeniAdSoyad;
                        if (daireEslesme)
                            parca[1] = yeniDaireNo;
                        satirlar[i] = string.Join(",", parca);
                    }
                    System.IO.File.WriteAllLines(path, satirlar);
                }
            }
        }

        // Odeme işlemleri
        public static List<Odeme> OdemeleriOku(string dosyaYolu)
        {
            dosyaYolu = System.IO.Path.Combine(Application.StartupPath, dosyaYolu);
            if (!File.Exists(dosyaYolu)) File.Create(dosyaYolu).Close();
            var odemeler = new List<Odeme>();
            var satirlar = File.ReadAllLines(dosyaYolu);
            foreach (var satir in satirlar)
            {
                var parca = satir.Split(',');
                if (parca.Length >= 2)
                    odemeler.Add(new Odeme(parca[0].Trim(), int.Parse(parca[1].Trim()), parca.Length > 2 ? parca[2].Trim() : ""));
            }
            return odemeler;
        }
        public static void OdemeEkle(string dosyaYolu, Odeme odeme)
        {
            dosyaYolu = System.IO.Path.Combine(Application.StartupPath, dosyaYolu);
            if (!File.Exists(dosyaYolu)) File.Create(dosyaYolu).Close();
            File.AppendAllText(dosyaYolu, $"{odeme.AdSoyad},{odeme.Tutar},{odeme.DaireNo}\n");
        }
        public static void OdemeSil(string dosyaYolu, string adSoyad, string daireNo = "")
        {
            dosyaYolu = System.IO.Path.Combine(Application.StartupPath, dosyaYolu);
            if (!File.Exists(dosyaYolu)) File.Create(dosyaYolu).Close();
            var odemeler = OdemeleriOku(dosyaYolu);
            odemeler.RemoveAll(o => o.AdSoyad == adSoyad && o.DaireNo == daireNo);
            File.WriteAllLines(dosyaYolu, odemeler.ConvertAll(o => $"{o.AdSoyad},{o.Tutar},{o.DaireNo}"));
        }
        public static void OdemeGuncelle(string dosyaYolu, string adSoyad, int yeniTutar, string daireNo = "")
        {
            dosyaYolu = System.IO.Path.Combine(Application.StartupPath, dosyaYolu);
            if (!File.Exists(dosyaYolu)) File.Create(dosyaYolu).Close();
            var odemeler = OdemeleriOku(dosyaYolu);
            foreach (var o in odemeler)
                if (o.AdSoyad == adSoyad && o.DaireNo == daireNo)
                    o.Tutar = yeniTutar;
            File.WriteAllLines(dosyaYolu, odemeler.ConvertAll(o => $"{o.AdSoyad},{o.Tutar},{o.DaireNo}"));
        }

        // KullanimKaydi işlemleri (Havuz/Fitness)
        public static List<KullanimKaydi> KullanimKayitlariniOku(string dosyaYolu)
        {
            dosyaYolu = System.IO.Path.Combine(Application.StartupPath, dosyaYolu);
            if (!File.Exists(dosyaYolu)) File.Create(dosyaYolu).Close();
            var kayitlar = new List<KullanimKaydi>();
            var satirlar = File.ReadAllLines(dosyaYolu);
            foreach (var satir in satirlar)
            {
                var parca = satir.Split(',');
                if (parca.Length >= 5)
                    kayitlar.Add(new KullanimKaydi(parca[0].Trim(), parca[1].Trim(), parca[2].Trim(), parca[3].Trim(), parca[4].Trim()));
                else if (parca.Length == 4)
                    kayitlar.Add(new KullanimKaydi(parca[0].Trim(), parca[1].Trim(), parca[2].Trim(), parca[3].Trim(), ""));
            }
            return kayitlar;
        }
        public static void KullanimKaydiEkle(string dosyaYolu, KullanimKaydi kayit)
        {
            dosyaYolu = System.IO.Path.Combine(Application.StartupPath, dosyaYolu);
            if (!File.Exists(dosyaYolu)) File.Create(dosyaYolu).Close();
            File.AppendAllText(dosyaYolu, $"{kayit.AdSoyad},{kayit.DaireNo},{kayit.KullaniciTipi},{kayit.MekanAdi},{kayit.Sonuc}\n");
        }
        // Borç kontrolü
        public static bool BorcuVarMi(string adSoyad, string daireNo, string dataDosya, string odemeDosya)
        {
            var oturanlar = OturanlariOku(dataDosya);
            var odemeler = OdemeleriOku(odemeDosya);
            var oturan = oturanlar.Find(o => o.AdSoyad == adSoyad && (o is AileReisi ar ? ar.DaireNo == daireNo : true));
            if (oturan == null) return false;
            var odeme = odemeler.Find(o => o.AdSoyad == adSoyad && o.DaireNo == daireNo);
            return oturan.Borc > 0 || (odeme != null && odeme.Tutar > 0);
        }
    }
} 