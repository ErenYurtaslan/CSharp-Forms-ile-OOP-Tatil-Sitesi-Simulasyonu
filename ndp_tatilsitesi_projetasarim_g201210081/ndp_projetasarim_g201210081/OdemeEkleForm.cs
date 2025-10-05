
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ndp_projetasarim_g201210081
{
    public class OdemeEkleForm : Form
    {
        public Odeme Odeme { get; private set; }
        private TextBox txtAdSoyad, txtDaireNo;
        private NumericUpDown nudTutar;
        private Button btnTamam, btnIptal;
        public OdemeEkleForm(string mevcutAd = "", string mevcutDaire = "")
        {
            this.Text = "Ödeme Ekle";
            this.Size = new Size(350, 220);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = ColorTranslator.FromHtml("#EDE6D6");
            Label lblAd = new Label { Text = "Ad Soyad:", Location = new Point(20, 30), AutoSize = true };
            txtAdSoyad = new TextBox { Location = new Point(120, 25), Width = 180, Text = mevcutAd, ReadOnly = true };
            Label lblTutar = new Label { Text = "Tutar:", Location = new Point(20, 70), AutoSize = true };
            int borc = 0;
            if (!string.IsNullOrWhiteSpace(mevcutAd))
            {
                var oturanlar = System.IO.File.ReadAllLines("bin/Debug/Data.txt");
                foreach (var satir in oturanlar)
                {
                    var parca = satir.Split(',');
                    if (parca.Length >= 4 && parca[1].Trim() == mevcutAd)
                    {
                        int.TryParse(parca[2].Trim(), out borc);
                        break;
                    }
                }
            }
            nudTutar = new NumericUpDown { Location = new Point(120, 65), Width = 180, Minimum = 0, Maximum = borc, Value = borc };
            Label lblDaire = new Label { Text = "Daire No:", Location = new Point(20, 110), AutoSize = true };
            txtDaireNo = new TextBox { Location = new Point(120, 105), Width = 180, Text = mevcutDaire, ReadOnly = true };
            btnTamam = new Button { Text = "Tamam", Location = new Point(70, 150), BackColor = ColorTranslator.FromHtml("#A7A28F"), DialogResult = DialogResult.OK };
            btnIptal = new Button { Text = "İptal", Location = new Point(170, 150), BackColor = ColorTranslator.FromHtml("#CFC1B2"), DialogResult = DialogResult.Cancel };
            btnTamam.Click += BtnTamam_Click;
            this.Controls.AddRange(new Control[] { lblAd, txtAdSoyad, lblTutar, nudTutar, lblDaire, txtDaireNo, btnTamam, btnIptal });
            this.AcceptButton = btnTamam;
            this.CancelButton = btnIptal;
        }
        private void BtnTamam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text))
            {
                MessageBox.Show("Lütfen ad soyad bilgisini girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            if (nudTutar.Value < 0)
            {
                MessageBox.Show("Borç negatif olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            Odeme = new Odeme(txtAdSoyad.Text.Trim(), (int)nudTutar.Value, txtDaireNo.Text.Trim());
        }
    }
} 
