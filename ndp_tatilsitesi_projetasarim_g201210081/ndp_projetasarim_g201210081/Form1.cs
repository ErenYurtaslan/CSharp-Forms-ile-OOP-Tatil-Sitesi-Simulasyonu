using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ndp_projetasarim_g201210081
{
    public partial class Form1 : Form
    {
        string mekanDosya = "Mekan.txt";
        string oturanDosya = "Data.txt";
        string odemeDosya = "Odeme.txt";
        string havuzDosya = "HavuzKul.txt";
        string fitnessDosya = "Fitness.txt";

        public Form1()
        {
            InitializeComponent();
            SenkronizeMekanTxtleri();
            // TXT dosyalarını düzelt
            FixMekanTxt("FitnessSalonlari.txt");
            FixMekanTxt("Havuzlar.txt");
            FixMekanTxt("Daireler.txt");
            // Mekan
            btnMekanListele.Click += (s, e) => MekanlariYukle();
            btnMekanEkle.Click += (s, e) => MekanEkle();
            btnMekanSil.Click += (s, e) => MekanSil();
            btnMekanGuncelle.Click += (s, e) => MekanGuncelle();
            // Oturan
            btnOturanListele.Click += (s, e) => OturanlariYukle();
            btnOturanEkle.Click += (s, e) => OturanEkle();
            btnOturanSil.Click += (s, e) => OturanSil();
            btnOturanGuncelle.Click += (s, e) => OturanGuncelle();
            // Odeme
            btnOdemeListele.Click += (s, e) => OdemeleriYukle();
            btnOdemeEkle.Click += (s, e) => OdemeEkle();
            btnOdemeSil.Click += (s, e) => OdemeSil();
            // Kullanim
            btnKullanimListele.Click += (s, e) => KullanimKayitlariniYukle();
            btnKullanimEkle.Click += (s, e) => KullanimKaydiEkle();
            btnBorcOde.Click += (s, e) => BorcOde();
            btnKullanimSil.Click += (s, e) => KullanimKaydiSil();
        }

        private void FixMekanTxt(string fileName)
        {
            string path = System.IO.Path.Combine(Application.StartupPath, fileName);
            if (!System.IO.File.Exists(path)) return;
            var lines = System.IO.File.ReadAllLines(path)
                .SelectMany(l => l.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToList();
            System.IO.File.WriteAllLines(path, lines);
        }

        private void SenkronizeMekanTxtleri()
        {
            string mekanPath = System.IO.Path.Combine(Application.StartupPath, "Mekan.txt");
            string fitnessPath = System.IO.Path.Combine(Application.StartupPath, "FitnessSalonlari.txt");
            string havuzPath = System.IO.Path.Combine(Application.StartupPath, "Havuzlar.txt");

            var mekanlar = System.IO.File.Exists(mekanPath)
                ? System.IO.File.ReadAllLines(mekanPath)
                : new string[0];

            var fitnessList = mekanlar
                .Select(l => l.Split(','))
                .Where(p => p.Length == 2 && p[0].Trim() == "Fitness")
                .Select(p => p[1].Trim())
                .Distinct()
                .ToList();

            var havuzList = mekanlar
                .Select(l => l.Split(','))
                .Where(p => p.Length == 2 && p[0].Trim() == "Havuz")
                .Select(p => p[1].Trim())
                .Distinct()
                .ToList();

            System.IO.File.WriteAllLines(fitnessPath, fitnessList);
            System.IO.File.WriteAllLines(havuzPath, havuzList);
        }

        private void SenkronizeDaireleriMekana()
        {
            string dairelerPath = System.IO.Path.Combine(Application.StartupPath, "Daireler.txt");
            string mekanPath = System.IO.Path.Combine(Application.StartupPath, "Mekan.txt");

            var daireler = System.IO.File.Exists(dairelerPath)
                ? System.IO.File.ReadAllLines(dairelerPath).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList()
                : new List<string>();

            var mekanlar = System.IO.File.Exists(mekanPath)
                ? System.IO.File.ReadAllLines(mekanPath).ToList()
                : new List<string>();

            var mevcutDaireler = mekanlar
                .Where(l => l.StartsWith("Daire,"))
                .Select(l => l.Split(',')[1].Trim())
                .ToHashSet();

            bool degisiklik = false;
            foreach (var daire in daireler)
            {
                if (!mevcutDaireler.Contains(daire))
                {
                    mekanlar.Add($"Daire,{daire}");
                    degisiklik = true;
                }
            }
            if (degisiklik)
                System.IO.File.WriteAllLines(mekanPath, mekanlar);
        }

        // Mekan işlemleri
        private void MekanlariYukle()
        {
            dgvMekan.DataSource = null;
            dgvMekan.DataSource = DosyaIslemleri.MekanlariOku(mekanDosya);
            dgvMekan.AutoGenerateColumns = true;
            if (dgvMekan.Columns["Tur"] != null) dgvMekan.Columns["Tur"].HeaderText = "Tür";
            if (dgvMekan.Columns["Ad"] != null) dgvMekan.Columns["Ad"].HeaderText = "Ad";
        }
        private void MekanEkle()
        {
            var frm = new MekanEkleForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DosyaIslemleri.MekanEkle(mekanDosya, frm.Mekan);
                SenkronizeMekanTxtleri();
                SenkronizeDaireleriMekana();
                MekanlariYukle();
            }
        }
        private void MekanSil()
        {
            if (dgvMekan.CurrentRow != null)
            {
                string ad = dgvMekan.CurrentRow.Cells["Ad"].Value.ToString();
                DosyaIslemleri.MekanSil(mekanDosya, ad);
                SenkronizeDaireleriMekana();
                MekanlariYukle();
            }
        }
        private void MekanGuncelle()
        {
            if (dgvMekan.CurrentRow != null)
            {
                string eskiAd = dgvMekan.CurrentRow.Cells["Ad"].Value.ToString();
                var frm = new MekanEkleForm(eskiAd);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DosyaIslemleri.MekanGuncelle(mekanDosya, eskiAd, frm.Mekan.Ad);
                    // Kullanım kayıtlarında mekan adını güncelle
                    GuncelleKullanimKayitlarindaMekanAdi(eskiAd, frm.Mekan.Ad);
                    SenkronizeMekanTxtleri();
                    SenkronizeDaireleriMekana();
                    MekanlariYukle();
                }
            }
        }
        private void GuncelleKullanimKayitlarindaMekanAdi(string eskiAd, string yeniAd)
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
                    if (parca.Length >= 4 && parca[3].Trim() == eskiAd)
                        parca[3] = yeniAd;
                    satirlar[i] = string.Join(",", parca);
                }
                System.IO.File.WriteAllLines(path, satirlar);
            }
        }
        // Oturan işlemleri
        private void OturanlariYukle()
        {
            var oturanlar = DosyaIslemleri.OturanlariOku(oturanDosya);
            var liste = oturanlar.Select(o => new
            {
                Tip = (o is AileReisi) ? "AileReisi" : "Misafir",
                AdSoyad = o.AdSoyad,
                Borc = o.Borc,
                DaireNo = (o is AileReisi ar) ? ar.DaireNo : ""
            }).ToList();
            dgvOturan.DataSource = null;
            dgvOturan.DataSource = liste;
            dgvOturan.AutoGenerateColumns = true;
            if (dgvOturan.Columns["Tip"] != null) dgvOturan.Columns["Tip"].HeaderText = "Kullanıcı Tipi";
            if (dgvOturan.Columns["AdSoyad"] != null) dgvOturan.Columns["AdSoyad"].HeaderText = "Ad Soyad";
            if (dgvOturan.Columns["Borc"] != null) dgvOturan.Columns["Borc"].HeaderText = "Borç";
            if (dgvOturan.Columns["DaireNo"] != null) dgvOturan.Columns["DaireNo"].HeaderText = "Daire No";
        }
        private void OturanEkle()
        {
            var frm = new OturanEkleForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DosyaIslemleri.OturanEkle(oturanDosya, frm.Oturan);
                OturanlariYukle();
            }
        }
        private void OturanSil()
        {
            if (dgvOturan.CurrentRow != null)
            {
                string ad = dgvOturan.CurrentRow.Cells["AdSoyad"].Value.ToString();
                string daire = dgvOturan.Columns["DaireNo"] != null && dgvOturan.CurrentRow.Cells["DaireNo"].Value != null
                    ? dgvOturan.CurrentRow.Cells["DaireNo"].Value.ToString()
                    : "";
                DosyaIslemleri.OturanSil(oturanDosya, ad, daire);
                OturanlariYukle();
            }
        }
        private void OturanGuncelle()
        {
            if (dgvOturan.CurrentRow != null)
            {
                string eskiAd = dgvOturan.CurrentRow.Cells["AdSoyad"].Value.ToString();
                string eskiDaire = dgvOturan.Columns["DaireNo"] != null && dgvOturan.CurrentRow.Cells["DaireNo"].Value != null
                    ? dgvOturan.CurrentRow.Cells["DaireNo"].Value.ToString()
                    : "";
                var frm = new OturanEkleForm(eskiAd, eskiDaire);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string yeniTip = (frm.Oturan is AileReisi) ? "AileReisi" : "Misafir";
                    string yeniDaire = (frm.Oturan is AileReisi ar) ? ar.DaireNo : "";
                    DosyaIslemleri.OturanGuncelle(oturanDosya, eskiAd, frm.Oturan.AdSoyad, frm.Oturan.Borc, yeniTip, yeniDaire);
                    OturanlariYukle();
                }
            }
        }
        // Odeme işlemleri
        private void OdemeleriYukle()
        {
            var dataPath = System.IO.Path.Combine(Application.StartupPath, "Data.txt");
            var oturanlar = DosyaIslemleri.OturanlariOku(dataPath);
            var odemeList = oturanlar.Select(o => new
            {
                Tip = (o is AileReisi) ? "AileReisi" : "Misafir",
                AdSoyad = o.AdSoyad,
                Tutar = o.Borc,
                DaireNo = (o is AileReisi ar) ? ar.DaireNo : ""
            }).ToList();
            dgvOdeme.DataSource = null;
            dgvOdeme.DataSource = odemeList;
            dgvOdeme.AutoGenerateColumns = true;
            if (dgvOdeme.Columns["Tip"] != null) dgvOdeme.Columns["Tip"].HeaderText = "Kullanıcı Tipi";
            if (dgvOdeme.Columns["AdSoyad"] != null) dgvOdeme.Columns["AdSoyad"].HeaderText = "Ad Soyad";
            if (dgvOdeme.Columns["Tutar"] != null) dgvOdeme.Columns["Tutar"].HeaderText = "Tutar";
            if (dgvOdeme.Columns["DaireNo"] != null) dgvOdeme.Columns["DaireNo"].HeaderText = "Daire No";
        }
        private void OdemeEkle()
        {
            var frm = new OdemeEkleForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DosyaIslemleri.OdemeEkle(odemeDosya, frm.Odeme);
                OdemeleriYukle();
            }
        }
        private void OdemeSil()
        {
            if (dgvOdeme.CurrentRow != null)
            {
                string ad = dgvOdeme.CurrentRow.Cells["AdSoyad"].Value.ToString();
                string daire = dgvOdeme.CurrentRow.Cells["DaireNo"].Value.ToString();
                DosyaIslemleri.OdemeSil(odemeDosya, ad, daire);
                OdemeleriYukle();
            }
        }
        // Kullanim işlemleri
        private List<KullanimKaydi> FiltreliKullanimKayitlari(List<KullanimKaydi> tumKayitlar)
        {
            var sonuc = new List<KullanimKaydi>();
            var basariliKayitlar = new HashSet<string>(); // key: ad+daire+mekan+tip
            foreach (var kayit in tumKayitlar)
            {
                string key = kayit.AdSoyad.Trim().ToLowerInvariant() + "|" + kayit.DaireNo.Trim().ToLowerInvariant() + "|" + kayit.MekanAdi.Trim().ToLowerInvariant() + "|" + kayit.KullaniciTipi.Trim().ToLowerInvariant();
                if (basariliKayitlar.Contains(key))
                {
                    // Bu kullanıcı-mekan-daire için zaten başarılı kayıt var, yenisini ekleme
                    continue;
                }
                sonuc.Add(kayit);
                if (kayit.Sonuc == "Kullandırıldı")
                    basariliKayitlar.Add(key);
            }
            return sonuc;
        }

        private void KullanimKayitlariniYukle()
        {
            // Hem havuz hem fitness kayıtlarını oku ve birleştir, ekleme olmasa bile göster
            var havuz = DosyaIslemleri.KullanimKayitlariniOku(havuzDosya);
            var fitness = DosyaIslemleri.KullanimKayitlariniOku(fitnessDosya);
            var tum = new List<KullanimKaydi>();
            tum.AddRange(havuz);
            tum.AddRange(fitness);
            // Data.txt'deki en güncel ad, daire ve kullanıcı tipiyle eşleştir
            var oturanlar = DosyaIslemleri.OturanlariOku(oturanDosya);
            foreach (var kayit in tum)
            {
                var oturan = oturanlar.FirstOrDefault(o => string.Equals(Normalize(o.AdSoyad), Normalize(kayit.AdSoyad), StringComparison.OrdinalIgnoreCase));
                if (oturan != null)
                {
                    kayit.AdSoyad = oturan.AdSoyad; // Güncel adı ata
                    if (oturan is AileReisi ar)
                    {
                        kayit.DaireNo = ar.DaireNo; // Güncel daireyi ata
                        kayit.KullaniciTipi = "AileReisi";
                    }
                    else
                    {
                        kayit.DaireNo = "";
                        kayit.KullaniciTipi = "Misafir";
                    }
                }
                if (string.IsNullOrWhiteSpace(kayit.Sonuc))
                {
                    AileReisi ar2 = oturan as AileReisi;
                    if (ar2 != null && ar2.Borc > 0)
                        kayit.Sonuc = "Kullandirilamadi (Borc Var)";
                    else
                        kayit.Sonuc = "Kullandirildi";
                }
            }
            var filtreli = FiltreliKullanimKayitlari(tum);
            dgvKullanim.DataSource = null;
            dgvKullanim.DataSource = filtreli;
            dgvKullanim.AutoGenerateColumns = true;
            dgvKullanim.Refresh();
            if (dgvKullanim.Columns["AdSoyad"] != null)
                dgvKullanim.Columns["AdSoyad"].HeaderText = "Ad Soyad";
            if (dgvKullanim.Columns["DaireNo"] != null)
                dgvKullanim.Columns["DaireNo"].HeaderText = "Daire No";
            if (dgvKullanim.Columns["KullaniciTipi"] != null)
            {
                dgvKullanim.Columns["KullaniciTipi"].HeaderText = "Kullanıcı Tipi";
                dgvKullanim.Columns["KullaniciTipi"].Visible = true;
            }
            if (dgvKullanim.Columns["Sonuc"] != null)
            {
                dgvKullanim.Columns["Sonuc"].HeaderText = "Sonuç";
                dgvKullanim.Columns["Sonuc"].Visible = true;
                dgvKullanim.Columns["Sonuc"].DefaultCellStyle.ForeColor = Color.Black;
                dgvKullanim.Columns["Sonuc"].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }
            if (dgvKullanim.Columns["MekanAdi"] != null)
            {
                dgvKullanim.Columns["MekanAdi"].HeaderText = "Mekan Adı";
                dgvKullanim.Columns["MekanAdi"].Visible = true;
            }
        }
        private void KullanimKaydiEkle()
        {
            // Kayıt Yaptır butonu ile açılır
            var frm = new KullanimEkleForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Her deneme ayrı satır olarak kaydedilsin
                DosyaIslemleri.KullanimKaydiEkle(frm.KayitTipi == "Havuz" ? havuzDosya : fitnessDosya, frm.Kayit);
                // Kayıtları güncelle
                var havuz = DosyaIslemleri.KullanimKayitlariniOku(havuzDosya);
                var fitness = DosyaIslemleri.KullanimKayitlariniOku(fitnessDosya);
                var tum = new List<KullanimKaydi>();
                tum.AddRange(havuz);
                tum.AddRange(fitness);
                // Sonuçları ve güncel bilgileri algoritmadan üret
                var oturanlar = DosyaIslemleri.OturanlariOku(oturanDosya);
                foreach (var kayit in tum)
                {
                    var oturan = oturanlar.FirstOrDefault(o => string.Equals(Normalize(o.AdSoyad), Normalize(kayit.AdSoyad), StringComparison.OrdinalIgnoreCase));
                    if (oturan != null)
                    {
                        kayit.AdSoyad = oturan.AdSoyad;
                        if (oturan is AileReisi ar)
                        {
                            kayit.DaireNo = ar.DaireNo;
                            kayit.KullaniciTipi = "AileReisi";
                        }
                        else
                        {
                            kayit.DaireNo = "";
                            kayit.KullaniciTipi = "Misafir";
                        }
                    }
                    if (string.IsNullOrWhiteSpace(kayit.Sonuc))
                    {
                        AileReisi ar2 = oturan as AileReisi;
                        if (ar2 != null && ar2.Borc > 0)
                            kayit.Sonuc = "Kullandirilamadi (Borc Var)";
                        else
                            kayit.Sonuc = "Kullandirildi";
                    }
                }
                var filtreli = FiltreliKullanimKayitlari(tum);
                dgvKullanim.DataSource = null;
                dgvKullanim.DataSource = filtreli;
                dgvKullanim.AutoGenerateColumns = true;
                dgvKullanim.Refresh();
                if (dgvKullanim.Columns["AdSoyad"] != null)
                    dgvKullanim.Columns["AdSoyad"].HeaderText = "Ad Soyad";
                if (dgvKullanim.Columns["DaireNo"] != null)
                    dgvKullanim.Columns["DaireNo"].HeaderText = "Daire No";
                if (dgvKullanim.Columns["KullaniciTipi"] != null)
                {
                    dgvKullanim.Columns["KullaniciTipi"].HeaderText = "Kullanıcı Tipi";
                    dgvKullanim.Columns["KullaniciTipi"].Visible = true;
                }
                if (dgvKullanim.Columns["Sonuc"] != null)
                {
                    dgvKullanim.Columns["Sonuc"].HeaderText = "Sonuç";
                    dgvKullanim.Columns["Sonuc"].Visible = true;
                    dgvKullanim.Columns["Sonuc"].DefaultCellStyle.ForeColor = Color.Black;
                    dgvKullanim.Columns["Sonuc"].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
                if (dgvKullanim.Columns["MekanAdi"] != null)
                {
                    dgvKullanim.Columns["MekanAdi"].HeaderText = "Mekan Adı";
                    dgvKullanim.Columns["MekanAdi"].Visible = true;
                }
            }
        }
        private void KullanimKaydiSil()
        {
            if (dgvKullanim.CurrentRow == null) { MessageBox.Show("Lütfen bir kayıt seçin."); return; }
            string ad = dgvKullanim.CurrentRow.Cells["AdSoyad"].Value.ToString();
            string mekanAdi = dgvKullanim.CurrentRow.Cells["MekanAdi"] != null ? dgvKullanim.CurrentRow.Cells["MekanAdi"].Value?.ToString() : "";
            string kullaniciTipi = dgvKullanim.CurrentRow.Cells["KullaniciTipi"] != null ? dgvKullanim.CurrentRow.Cells["KullaniciTipi"].Value?.ToString() : "";
            // Hem havuz hem fitness dosyasında sil
            SilKullanimKaydiDosya(havuzDosya, ad, mekanAdi, kullaniciTipi);
            SilKullanimKaydiDosya(fitnessDosya, ad, mekanAdi, kullaniciTipi);
            KullanimKayitlariniYukle();
        }
        private void SilKullanimKaydiDosya(string dosya, string ad, string mekanAdi, string kullaniciTipi)
        {
            var kayitlar = DosyaIslemleri.KullanimKayitlariniOku(dosya);
            kayitlar.RemoveAll(k => k.AdSoyad == ad && k.MekanAdi == mekanAdi && k.KullaniciTipi == kullaniciTipi);
            System.IO.File.WriteAllLines(System.IO.Path.Combine(Application.StartupPath, dosya), kayitlar.Select(k => $"{k.AdSoyad},{k.DaireNo},{k.KullaniciTipi},{k.MekanAdi},{k.Sonuc}"));
        }
        private void BorcOde()
        {
            if (dgvOdeme.CurrentRow == null) { MessageBox.Show("Lütfen bir kişi seçin."); return; }
            string ad = dgvOdeme.CurrentRow.Cells["AdSoyad"].Value.ToString();
            string daire = dgvOdeme.CurrentRow.Cells["DaireNo"].Value.ToString();
            // Data.txt'den borcu bul
            var dataPath = System.IO.Path.Combine(Application.StartupPath, "Data.txt");
            var oturanlar = DosyaIslemleri.OturanlariOku(dataPath);
            var oturan = oturanlar.FirstOrDefault(o => o.AdSoyad == ad);
            AileReisi ar = oturan as AileReisi;
            if (oturan == null || (ar != null && ar.DaireNo != daire)) { MessageBox.Show("Kişi bulunamadı."); return; }
            if (oturan.Borc == 0) { MessageBox.Show("Bu kişinin borcu yok."); return; }
            // Borç ödeme formu
            Form frm = new Form();
            frm.Text = "Borç Öde";
            frm.Size = new Size(350, 180);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.BackColor = ColorTranslator.FromHtml("#F5F5F5");
            Label lbl = new Label { Text = $"{ad} için mevcut borç: {oturan.Borc} TL\nÖdemek istediğiniz tutarı girin:", AutoSize = false, Dock = DockStyle.Top, Height = 50, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 11F, FontStyle.Bold) };
            NumericUpDown nud = new NumericUpDown { Minimum = 1, Maximum = oturan.Borc, Value = oturan.Borc, Location = new Point(100, 60), Width = 120, Font = new Font("Segoe UI", 12F) };
            Button btn = new Button { Text = "Öde", DialogResult = DialogResult.OK, Dock = DockStyle.Bottom, Height = 40 };
            frm.Controls.Add(lbl);
            frm.Controls.Add(nud);
            frm.Controls.Add(btn);
            nud.Top = 70; nud.Left = (frm.ClientSize.Width - nud.Width) / 2;
            frm.AcceptButton = btn;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int odeme = (int)nud.Value;
                oturan.Borc -= odeme;
                string tip = (oturan is AileReisi) ? "AileReisi" : "Misafir";
                string daireNo = (oturan is AileReisi ar2) ? ar2.DaireNo : "";
                // Data.txt'yi güncelle
                DosyaIslemleri.OturanGuncelle("Data.txt", oturan.AdSoyad, oturan.AdSoyad, oturan.Borc, tip, daireNo);
                // Odeme.txt'yi de güncelle
                DosyaIslemleri.OdemeGuncelle("Odeme.txt", oturan.AdSoyad, oturan.Borc, daireNo);
                MessageBox.Show($"Kalan borç: {oturan.Borc} TL", "Borç Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OdemeleriYukle();
                OturanlariYukle();
            }
        }
        private string Normalize(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";
            string normalized = input.ToLowerInvariant();
            normalized = normalized.Replace('ı', 'i').Replace('İ', 'i')
                .Replace('ç', 'c').Replace('Ç', 'c')
                .Replace('ğ', 'g').Replace('Ğ', 'g')
                .Replace('ö', 'o').Replace('Ö', 'o')
                .Replace('ş', 's').Replace('Ş', 's')
                .Replace('ü', 'u').Replace('Ü', 'u');
            return normalized;
        }
    }
}
