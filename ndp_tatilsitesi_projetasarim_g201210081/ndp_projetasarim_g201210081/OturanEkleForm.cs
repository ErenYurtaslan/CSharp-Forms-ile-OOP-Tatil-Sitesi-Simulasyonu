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
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace ndp_projetasarim_g201210081
{
    public class OturanEkleForm : Form
    {
        public Oturan Oturan { get; private set; }
        private ComboBox cmbTip, cmbDaireNo;
        private TextBox txtAdSoyad;
        private NumericUpDown nudBorc;
        private Button btnTamam, btnIptal;
        public OturanEkleForm(string mevcutAd = "", string mevcutDaire = "")
        {
            this.Text = "Oturan Ekle/Güncelle";
            this.Size = new Size(400, 270);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = ColorTranslator.FromHtml("#EDE6D6");
            Label lblTip = new Label { Text = "Tip:", Location = new Point(30, 30), AutoSize = true };
            cmbTip = new ComboBox { Location = new Point(120, 25), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbTip.Items.AddRange(new string[] { "AileReisi", "Misafir" });
            Label lblAd = new Label { Text = "Ad Soyad:", Location = new Point(30, 70), AutoSize = true };
            txtAdSoyad = new TextBox { Location = new Point(120, 65), Width = 220, Text = mevcutAd };
            Label lblBorc = new Label { Text = "Borç:", Location = new Point(30, 110), AutoSize = true };
            nudBorc = new NumericUpDown { Location = new Point(120, 105), Width = 220, Minimum = 0, Maximum = 100000 };
            Label lblDaire = new Label { Text = "Daire No:", Location = new Point(30, 150), AutoSize = true };
            cmbDaireNo = new ComboBox { Location = new Point(120, 145), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
            // Daireleri yükle
            var dairelerPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Daireler.txt");
            if (!System.IO.File.Exists(dairelerPath)) System.IO.File.Create(dairelerPath).Close();
            var daireler = System.IO.File.ReadAllLines(dairelerPath).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
            var dataPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Data.txt");
            if (!System.IO.File.Exists(dataPath)) System.IO.File.Create(dataPath).Close();
            var doluDaireler = System.IO.File.ReadAllLines(dataPath).Select(l => l.Split(',')).Where(p => p.Length >= 4 && p[0] == "AileReisi").Select(p => p[3].Trim()).ToList();
            foreach (var d in daireler)
            {
                bool dolu = doluDaireler.Contains(d);
                cmbDaireNo.Items.Add(new { Text = d, Enabled = !dolu || d == mevcutDaire });
            }
            cmbDaireNo.DrawMode = DrawMode.OwnerDrawFixed;
            cmbDaireNo.DrawItem += (s, e) => {
                if (e.Index < 0) return;
                dynamic item = cmbDaireNo.Items[e.Index];
                e.DrawBackground();
                using (var brush = new SolidBrush(item.Enabled ? Color.Black : Color.Gray))
                    e.Graphics.DrawString(item.Text, cmbDaireNo.Font, brush, e.Bounds);
                e.DrawFocusRectangle();
            };
            cmbDaireNo.SelectedIndexChanged += (s, e) => {
                if (cmbDaireNo.SelectedIndex >= 0 && !((dynamic)cmbDaireNo.SelectedItem).Enabled)
                    cmbDaireNo.SelectedIndex = -1;
            };
            // Mevcut değerleri ata (güncelleme için)
            if (!string.IsNullOrWhiteSpace(mevcutAd))
            {
                var oturanlar = System.IO.File.ReadAllLines(dataPath).Select(l => l.Split(','));
                var mevcut = oturanlar.FirstOrDefault(p => p.Length >= 2 && p[1].Trim() == mevcutAd);
                if (mevcut != null)
                {
                    if (mevcut[0] == "AileReisi")
                    {
                        cmbTip.SelectedItem = "AileReisi";
                        nudBorc.Value = int.TryParse(mevcut[2], out int b) ? b : 0;
                        if (!string.IsNullOrWhiteSpace(mevcut[3]))
                        {
                            for (int i = 0; i < cmbDaireNo.Items.Count; i++)
                            {
                                dynamic item = cmbDaireNo.Items[i];
                                if (item.Text == mevcut[3].Trim())
                                {
                                    cmbDaireNo.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        cmbTip.SelectedItem = "Misafir";
                        nudBorc.Value = 0;
                        cmbDaireNo.SelectedIndex = -1;
                    }
                }
            }
            else
            {
                cmbTip.SelectedIndex = 0;
                nudBorc.Value = 0;
                cmbDaireNo.SelectedIndex = -1;
            }
            cmbTip.SelectedIndexChanged += (s, e) => {
                bool aileReisi = cmbTip.SelectedItem != null && cmbTip.SelectedItem.ToString() == "AileReisi";
                cmbDaireNo.Enabled = aileReisi;
                nudBorc.Enabled = aileReisi;
                if (!aileReisi)
                {
                    nudBorc.Value = 0;
                    cmbDaireNo.SelectedIndex = -1;
                }
            };
            btnTamam = new Button { Text = "Tamam", Location = new Point(90, 190), BackColor = ColorTranslator.FromHtml("#A7A28F"), DialogResult = DialogResult.OK };
            btnIptal = new Button { Text = "İptal", Location = new Point(210, 190), BackColor = ColorTranslator.FromHtml("#CFC1B2"), DialogResult = DialogResult.Cancel };
            btnTamam.Click += BtnTamam_Click;
            this.Controls.AddRange(new Control[] { lblTip, cmbTip, lblAd, txtAdSoyad, lblBorc, nudBorc, lblDaire, cmbDaireNo, btnTamam, btnIptal });
            this.AcceptButton = btnTamam;
            this.CancelButton = btnIptal;
        }
        private void BtnTamam_Click(object sender, EventArgs e)
        {
            if (cmbTip.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtAdSoyad.Text) || (cmbTip.SelectedItem.ToString() == "AileReisi" && (cmbDaireNo.SelectedIndex == -1 || !((dynamic)cmbDaireNo.SelectedItem).Enabled)))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            if (cmbTip.SelectedItem.ToString() == "AileReisi")
                Oturan = new AileReisi(txtAdSoyad.Text.Trim(), (int)nudBorc.Value, ((dynamic)cmbDaireNo.SelectedItem).Text);
            else
                Oturan = new Misafir(txtAdSoyad.Text.Trim(), 0);
        }
    }
} 