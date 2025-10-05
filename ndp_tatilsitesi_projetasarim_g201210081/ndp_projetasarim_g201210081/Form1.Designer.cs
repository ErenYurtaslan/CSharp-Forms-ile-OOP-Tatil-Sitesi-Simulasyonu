namespace ndp_projetasarim_g201210081
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageMekan;
        private System.Windows.Forms.TabPage tabPageOturan;
        private System.Windows.Forms.TabPage tabPageOdeme;
        private System.Windows.Forms.TabPage tabPageKullanim;

        private System.Windows.Forms.DataGridView dgvMekan;
        private System.Windows.Forms.DataGridView dgvOturan;
        private System.Windows.Forms.DataGridView dgvOdeme;
        private System.Windows.Forms.DataGridView dgvKullanim;

        private System.Windows.Forms.Button btnMekanEkle;
        private System.Windows.Forms.Button btnMekanSil;
        private System.Windows.Forms.Button btnMekanGuncelle;
        private System.Windows.Forms.Button btnMekanListele;

        private System.Windows.Forms.Button btnOturanEkle;
        private System.Windows.Forms.Button btnOturanSil;
        private System.Windows.Forms.Button btnOturanGuncelle;
        private System.Windows.Forms.Button btnOturanListele;

        private System.Windows.Forms.Button btnOdemeEkle;
        private System.Windows.Forms.Button btnOdemeSil;
        private System.Windows.Forms.Button btnOdemeListele;

        private System.Windows.Forms.Button btnKullanimEkle;
        private System.Windows.Forms.Button btnKullanimListele;
        private System.Windows.Forms.Button btnKullanimSil;

        private System.Windows.Forms.Button btnBorcOde;

        private System.Windows.Forms.Label lblBaslik;

        private System.Windows.Forms.FlowLayoutPanel flowMekan;
        private System.Windows.Forms.FlowLayoutPanel flowOturan;
        private System.Windows.Forms.FlowLayoutPanel flowOdeme;
        private System.Windows.Forms.FlowLayoutPanel flowKullanim;

        private System.Windows.Forms.TableLayoutPanel tableMekan;
        private System.Windows.Forms.TableLayoutPanel tableOturan;
        private System.Windows.Forms.TableLayoutPanel tableOdeme;
        private System.Windows.Forms.TableLayoutPanel tableKullanim;

        private System.Windows.Forms.TableLayoutPanel tableMain;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Text = "Tatil Sitesi Yönetim Sistemi";
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#EDE6D6");
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBaslik = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMekan = new System.Windows.Forms.TabPage();
            this.tabPageOturan = new System.Windows.Forms.TabPage();
            this.tabPageOdeme = new System.Windows.Forms.TabPage();
            this.tabPageKullanim = new System.Windows.Forms.TabPage();
            this.dgvMekan = new System.Windows.Forms.DataGridView();
            this.dgvOturan = new System.Windows.Forms.DataGridView();
            this.dgvOdeme = new System.Windows.Forms.DataGridView();
            this.dgvKullanim = new System.Windows.Forms.DataGridView();
            this.btnMekanEkle = new System.Windows.Forms.Button();
            this.btnMekanSil = new System.Windows.Forms.Button();
            this.btnMekanGuncelle = new System.Windows.Forms.Button();
            this.btnMekanListele = new System.Windows.Forms.Button();
            this.btnOturanEkle = new System.Windows.Forms.Button();
            this.btnOturanSil = new System.Windows.Forms.Button();
            this.btnOturanGuncelle = new System.Windows.Forms.Button();
            this.btnOturanListele = new System.Windows.Forms.Button();
            this.btnOdemeEkle = new System.Windows.Forms.Button();
            this.btnOdemeSil = new System.Windows.Forms.Button();
            this.btnOdemeListele = new System.Windows.Forms.Button();
            this.btnKullanimEkle = new System.Windows.Forms.Button();
            this.btnKullanimListele = new System.Windows.Forms.Button();
            this.btnKullanimSil = new System.Windows.Forms.Button();
            this.btnBorcOde = new System.Windows.Forms.Button();
            this.lblBaslik.Text = "Tatil Sitesi Yönetim Sistemi";
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
            this.lblBaslik.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6B7B4B");
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Location = new System.Drawing.Point(320, 10);
            this.Controls.Add(this.lblBaslik);
            this.tabControlMain.Controls.Add(this.tabPageMekan);
            this.tabControlMain.Controls.Add(this.tabPageOturan);
            this.tabControlMain.Controls.Add(this.tabPageOdeme);
            this.tabControlMain.Controls.Add(this.tabPageKullanim);
            this.tabControlMain.Location = new System.Drawing.Point(30, 60);
            this.tabControlMain.Size = new System.Drawing.Size(940, 570);
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tabControlMain.SelectedIndex = 0;
            this.Controls.Add(this.tabControlMain);
            this.tabPageMekan.Text = "Mekan İşlemleri";
            this.tabPageMekan.BackColor = System.Drawing.ColorTranslator.FromHtml("#CFC1B2");
            this.tabPageMekan.Controls.Clear();
            this.tableMekan = new System.Windows.Forms.TableLayoutPanel();
            this.tableMekan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMekan.ColumnCount = 1;
            this.tableMekan.RowCount = 2;
            this.tableMekan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableMekan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.flowMekan = new System.Windows.Forms.FlowLayoutPanel();
            this.flowMekan.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowMekan.Height = 70;
            this.flowMekan.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.flowMekan.BackColor = System.Drawing.Color.Transparent;
            this.flowMekan.Controls.Add(this.btnMekanEkle);
            this.flowMekan.Controls.Add(this.btnMekanSil);
            this.flowMekan.Controls.Add(this.btnMekanGuncelle);
            this.flowMekan.Controls.Add(this.btnMekanListele);
            this.tableMekan.Controls.Add(this.flowMekan, 0, 0);
            this.dgvMekan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMekan.Controls.Add(this.dgvMekan, 0, 1);
            this.tabPageMekan.Controls.Add(this.tableMekan);
            this.tabPageOturan.Text = "Oturan İşlemleri";
            this.tabPageOturan.BackColor = System.Drawing.ColorTranslator.FromHtml("#EDE6D6");
            this.tabPageOturan.Controls.Clear();
            this.tableOturan = new System.Windows.Forms.TableLayoutPanel();
            this.tableOturan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableOturan.ColumnCount = 1;
            this.tableOturan.RowCount = 2;
            this.tableOturan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableOturan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.flowOturan = new System.Windows.Forms.FlowLayoutPanel();
            this.flowOturan.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowOturan.Height = 70;
            this.flowOturan.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.flowOturan.BackColor = System.Drawing.Color.Transparent;
            this.flowOturan.Controls.Add(this.btnOturanEkle);
            this.flowOturan.Controls.Add(this.btnOturanSil);
            this.flowOturan.Controls.Add(this.btnOturanGuncelle);
            this.flowOturan.Controls.Add(this.btnOturanListele);
            this.tableOturan.Controls.Add(this.flowOturan, 0, 0);
            this.dgvOturan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableOturan.Controls.Add(this.dgvOturan, 0, 1);
            this.tabPageOturan.Controls.Add(this.tableOturan);
            this.tabPageOdeme.Text = "Ödeme İşlemleri";
            this.tabPageOdeme.BackColor = System.Drawing.ColorTranslator.FromHtml("#A7A28F");
            this.tabPageOdeme.Controls.Clear();
            this.tableOdeme = new System.Windows.Forms.TableLayoutPanel();
            this.tableOdeme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableOdeme.ColumnCount = 1;
            this.tableOdeme.RowCount = 2;
            this.tableOdeme.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableOdeme.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.flowOdeme = new System.Windows.Forms.FlowLayoutPanel();
            this.flowOdeme.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowOdeme.Height = 70;
            this.flowOdeme.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.flowOdeme.BackColor = System.Drawing.Color.Transparent;
            this.flowOdeme.Controls.Add(this.btnOdemeListele);
            this.flowOdeme.Controls.Add(this.btnBorcOde);
            this.tableOdeme.Controls.Add(this.flowOdeme, 0, 0);
            this.dgvOdeme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableOdeme.Controls.Add(this.dgvOdeme, 0, 1);
            this.tabPageOdeme.Controls.Add(this.tableOdeme);
            this.tabPageKullanim.Text = "Havuz/Fitness Kullanımı";
            this.tabPageKullanim.BackColor = System.Drawing.ColorTranslator.FromHtml("#CFC1B2");
            this.tabPageKullanim.Controls.Clear();
            this.tableKullanim = new System.Windows.Forms.TableLayoutPanel();
            this.tableKullanim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableKullanim.ColumnCount = 1;
            this.tableKullanim.RowCount = 2;
            this.tableKullanim.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableKullanim.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.flowKullanim = new System.Windows.Forms.FlowLayoutPanel();
            this.flowKullanim.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowKullanim.Height = 70;
            this.flowKullanim.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.flowKullanim.BackColor = System.Drawing.Color.Transparent;
            this.flowKullanim.Controls.Add(this.btnKullanimEkle);
            this.flowKullanim.Controls.Add(this.btnKullanimListele);
            this.flowKullanim.Controls.Add(this.btnKullanimSil);
            this.tableKullanim.Controls.Add(this.flowKullanim, 0, 0);
            this.dgvKullanim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableKullanim.Controls.Add(this.dgvKullanim, 0, 1);
            this.tabPageKullanim.Controls.Add(this.tableKullanim);
            this.btnMekanEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMekanSil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMekanGuncelle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMekanListele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOturanEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOturanSil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOturanGuncelle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOturanListele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOdemeEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOdemeSil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOdemeListele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKullanimEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKullanimListele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKullanimSil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvOturan.Anchor = this.dgvMekan.Anchor;
            this.dgvOdeme.Anchor = this.dgvMekan.Anchor;
            this.dgvKullanim.Anchor = this.dgvMekan.Anchor;
            this.dgvOturan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOdeme.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKullanim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.btnMekanEkle.Text = "EKLE";
            this.btnMekanSil.Text = "SİL";
            this.btnMekanGuncelle.Text = "GÜNCELLE";
            this.btnMekanListele.Text = "LİSTELE";
            this.btnOturanEkle.Text = "EKLE";
            this.btnOturanSil.Text = "SİL";
            this.btnOturanGuncelle.Text = "GÜNCELLE";
            this.btnOturanListele.Text = "LİSTELE";
            this.btnOdemeEkle.Text = "EKLE";
            this.btnOdemeSil.Text = "SİL";
            this.btnOdemeListele.Text = "LİSTELE";
            this.btnKullanimEkle.Text = "EKLE";
            this.btnKullanimListele.Text = "LİSTELE";
            this.btnKullanimSil.Text = "SİL";
            this.btnKullanimSil.BackColor = System.Drawing.ColorTranslator.FromHtml("#A7A28F");
            this.btnKullanimSil.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnKullanimSil.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6B7B4B");
            this.btnKullanimSil.Width = 120;
            this.btnKullanimSil.Height = 44;
            this.btnKullanimSil.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnBorcOde.Text = "Borç Öde";
            this.btnBorcOde.BackColor = System.Drawing.ColorTranslator.FromHtml("#A7A28F");
            this.btnBorcOde.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnBorcOde.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6B7B4B");
            this.btnBorcOde.Width = 120;
            this.btnBorcOde.Height = 44;
            this.btnBorcOde.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            System.Drawing.Font btnFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            System.Drawing.Color btnBack = System.Drawing.ColorTranslator.FromHtml("#A7A28F");
            System.Drawing.Color btnFore = System.Drawing.ColorTranslator.FromHtml("#6B7B4B");
            foreach (var btn in new[] { btnMekanEkle, btnMekanSil, btnMekanGuncelle, btnMekanListele, btnOturanEkle, btnOturanSil, btnOturanGuncelle, btnOturanListele, btnOdemeEkle, btnOdemeSil, btnOdemeListele, btnKullanimEkle, btnKullanimListele })
            {
                btn.Font = btnFont;
                btn.BackColor = btnBack;
                btn.ForeColor = btnFore;
                btn.Width = 140;
                btn.Height = 50;
                btn.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            }
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dock = System.Windows.Forms.DockStyle.Fill;

            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.ColumnCount = 1;
            this.tableMain.RowCount = 2;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBaslik.AutoSize = false;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
            this.tableMain.Controls.Add(this.lblBaslik, 0, 0);
            this.tableMain.Controls.Add(this.tabControlMain, 0, 1);
            this.Controls.Clear();
            this.Controls.Add(this.tableMain);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.flowMekan.AutoScroll = true;
            this.flowOturan.AutoScroll = true;
            this.flowOdeme.AutoScroll = true;
            this.flowKullanim.AutoScroll = true;
            foreach (var btn in new[] { btnMekanEkle, btnMekanSil, btnMekanGuncelle, btnMekanListele, btnOturanEkle, btnOturanSil, btnOturanGuncelle, btnOturanListele, btnOdemeEkle, btnOdemeSil, btnOdemeListele, btnKullanimEkle, btnKullanimListele })
            {
                btn.Width = 120;
                btn.Height = 44;
                btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            }
            foreach (var dgv in new[] { dgvMekan, dgvOturan, dgvOdeme, dgvKullanim })
            {
                dgv.Margin = new System.Windows.Forms.Padding(0);
                dgv.Padding = new System.Windows.Forms.Padding(0);
                dgv.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
            }
        }

        #endregion
    }
}

