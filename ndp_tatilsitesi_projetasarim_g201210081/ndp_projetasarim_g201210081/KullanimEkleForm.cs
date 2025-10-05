
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;

namespace ndp_projetasarim_g201210081
{
    public class KullanimEkleForm : Form
    {
        public KullanimKaydi Kayit { get; private set; }
        public string KayitTipi { get; private set; } // Havuz veya Fitness
        private ComboBox cmbTip, cmbMekanAdi, cmbAdSoyad;
        private Button btnTamam, btnIptal;
        public KullanimEkleForm()
        {
            this.Text = "Kullanım Kaydı Ekle";
            this.Size = new Size(400, 320);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = ColorTranslator.FromHtml("#EDE6D6");
            Label lblTip = new Label { Text = "Kayıt Tipi:", Location = new Point(20, 30), AutoSize = true };
            cmbTip = new ComboBox { Location = new Point(120, 25), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbTip.Items.AddRange(new string[] { "Havuz", "Fitness" });
            Label lblMekanAdi = new Label { Text = "Mekan Adı:", Location = new Point(20, 70), AutoSize = true };
            cmbMekanAdi = new ComboBox { Location = new Point(120, 65), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
            Label lblAd = new Label { Text = "Ad Soyad:", Location = new Point(20, 110), AutoSize = true };
            cmbAdSoyad = new ComboBox { Location = new Point(120, 105), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
            // Data.txt'den isimleri yükle
            var dataPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Data.txt");
            if (System.IO.File.Exists(dataPath))
            {
                foreach (var line in System.IO.File.ReadAllLines(dataPath))
                {
                    var parca = line.Trim().Split(',');
                    if (parca.Length >= 2 && !string.IsNullOrWhiteSpace(parca[1]))
                        cmbAdSoyad.Items.Add(parca[1].Trim());
                }
            }
            btnTamam = new Button { Text = "Tamam", Location = new Point(90, 200), BackColor = ColorTranslator.FromHtml("#A7A28F"), DialogResult = DialogResult.OK };
            btnIptal = new Button { Text = "İptal", Location = new Point(210, 200), BackColor = ColorTranslator.FromHtml("#CFC1B2"), DialogResult = DialogResult.Cancel };
            btnTamam.Click += BtnTamam_Click;
            this.Controls.AddRange(new Control[] { lblTip, cmbTip, lblMekanAdi, cmbMekanAdi, lblAd, cmbAdSoyad, btnTamam, btnIptal });
            this.AcceptButton = btnTamam;
            this.CancelButton = btnIptal;
            cmbTip.SelectedIndexChanged += (s, e) => {
                cmbMekanAdi.Items.Clear();
                string path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, cmbTip.SelectedItem.ToString() == "Havuz" ? "Havuzlar.txt" : "FitnessSalonlari.txt");
                if (!System.IO.File.Exists(path)) System.IO.File.Create(path).Close();
                foreach (var line in System.IO.File.ReadAllLines(path))
                {
                    var trimmed = line.Trim();
                    if (!string.IsNullOrWhiteSpace(trimmed))
                        cmbMekanAdi.Items.Add(trimmed);
                }
            };
        }
        private void BtnTamam_Click(object sender, EventArgs e)
        {
            if (cmbTip.SelectedIndex == -1 || cmbMekanAdi.SelectedIndex == -1 || cmbAdSoyad.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            var dataPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Data.txt");
            var oturanlar = DosyaIslemleri.OturanlariOku(dataPath);
            var oturan = oturanlar.FirstOrDefault(o => o.AdSoyad == cmbAdSoyad.SelectedItem.ToString());
            if (oturan == null)
            {
                MessageBox.Show("Bu isimde bir oturan bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sonuc;
            string daireNo;
            string kullaniciTipi;
            AileReisi ar = oturan as AileReisi;
            if (ar != null && ar.Borc > 0)
            {
                // Özel hata formu
                Form hataForm = new Form();
                hataForm.Text = "Borç Uyarısı";
                hataForm.Size = new Size(350, 180);
                hataForm.StartPosition = FormStartPosition.CenterParent;
                hataForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                hataForm.BackColor = ColorTranslator.FromHtml("#F5E6E6");
                Label lbl = new Label { Text = $"{ar.AdSoyad} için {ar.Borc} TL borç bulunmaktadır.\nKullanım reddedildi.\n\nLütfen ödemeler sayfasını kontrol ediniz.", AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = Color.DarkRed };
                hataForm.Controls.Add(lbl);
                Button btn = new Button { Text = "Tamam", DialogResult = DialogResult.OK, Dock = DockStyle.Bottom, Height = 40 };
                hataForm.Controls.Add(btn);
                hataForm.AcceptButton = btn;
                hataForm.ShowDialog();
                sonuc = "Kullandırılamadı (Borc Var)";
                daireNo = ar.DaireNo;
                kullaniciTipi = "AileReisi";
                Kayit = new KullanimKaydi(
                    oturan.AdSoyad,
                    daireNo,
                    kullaniciTipi,
                    cmbMekanAdi.SelectedItem.ToString(),
                    sonuc
                );
                KayitTipi = cmbTip.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
                return;
            }
            sonuc = "Kullandırıldı";
            daireNo = ar != null ? ar.DaireNo : "";
            kullaniciTipi = (oturan is AileReisi) ? "AileReisi" : "Misafir";
            Kayit = new KullanimKaydi(
                oturan.AdSoyad,
                daireNo,
                kullaniciTipi,
                cmbMekanAdi.SelectedItem.ToString(),
                sonuc
            );
            KayitTipi = cmbTip.SelectedItem.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
} 
