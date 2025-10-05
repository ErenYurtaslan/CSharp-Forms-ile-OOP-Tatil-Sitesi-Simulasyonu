
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ndp_projetasarim_g201210081
{
    public class MekanEkleForm : Form
    {
        public Mekan Mekan { get; private set; }
        private ComboBox cmbTur;
        private TextBox txtAd;
        private Button btnTamam, btnIptal;
        public MekanEkleForm(string mevcutAd = "")
        {
            this.Text = "Mekan Ekle/Güncelle";
            this.Size = new Size(350, 220);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = ColorTranslator.FromHtml("#EDE6D6");
            Label lblTur = new Label { Text = "Mekan Türü:", Location = new Point(20, 30), AutoSize = true };
            cmbTur = new ComboBox { Location = new Point(120, 25), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbTur.Items.AddRange(new string[] { "Daire", "Fitness", "Havuz" });
            Label lblAd = new Label { Text = "Mekan Adı:", Location = new Point(20, 70), AutoSize = true };
            txtAd = new TextBox { Location = new Point(120, 65), Width = 180, Text = mevcutAd };
            btnTamam = new Button { Text = "Tamam", Location = new Point(70, 120), BackColor = ColorTranslator.FromHtml("#A7A28F"), DialogResult = DialogResult.OK };
            btnIptal = new Button { Text = "İptal", Location = new Point(170, 120), BackColor = ColorTranslator.FromHtml("#CFC1B2"), DialogResult = DialogResult.Cancel };
            btnTamam.Click += BtnTamam_Click;
            this.Controls.AddRange(new Control[] { lblTur, cmbTur, lblAd, txtAd, btnTamam, btnIptal });
            this.AcceptButton = btnTamam;
            this.CancelButton = btnIptal;
        }
        private void BtnTamam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || cmbTur.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            Mekan = new Mekan(cmbTur.SelectedItem.ToString(), txtAd.Text.Trim());
        }
    }
} 
