namespace Blaser_ÖTV_Fatura_Irsaliye
{
    partial class GirisFormu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisFormu));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnBaglan = new DevExpress.XtraEditors.SimpleButton();
            this.conCs = new System.Data.SqlClient.SqlConnection();
            this.conMaster = new System.Data.SqlClient.SqlConnection();
            this.txtServer = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtKullanici = new DevExpress.XtraEditors.ButtonEdit();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.dataSet11 = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1();
            this.tblKullanicilarTableAdapter1 = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.tblKullanicilarTableAdapter();
            this.conBlaser = new System.Data.SqlClient.SqlConnection();
            this.txtSirket = new DevExpress.XtraEditors.TextEdit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullanici.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSirket.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl1.Location = new System.Drawing.Point(9, 155);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(115, 20);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Server Adı";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl2.Location = new System.Drawing.Point(9, 181);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(115, 20);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Şirket Adı";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDurum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 309);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDurum
            // 
            this.lblDurum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDurum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(0, 17);
            // 
            // btnBaglan
            // 
            this.btnBaglan.Location = new System.Drawing.Point(8, 255);
            this.btnBaglan.Name = "btnBaglan";
            this.btnBaglan.Size = new System.Drawing.Size(268, 25);
            this.btnBaglan.TabIndex = 4;
            this.btnBaglan.Text = "Bağlan";
            this.btnBaglan.Click += new System.EventHandler(this.btnBaglan_Click);
            // 
            // conCs
            // 
            this.conCs.FireInfoMessageEventOnUserErrors = false;
            // 
            // conMaster
            // 
            this.conMaster.FireInfoMessageEventOnUserErrors = false;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(124, 155);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(153, 20);
            this.txtServer.TabIndex = 0;
            this.txtServer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtServer_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl3.Location = new System.Drawing.Point(9, 230);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(115, 20);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Şifre";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl4.Location = new System.Drawing.Point(9, 205);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(115, 20);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Kulanıcı Adı";
            // 
            // txtKullanici
            // 
            this.txtKullanici.Location = new System.Drawing.Point(124, 205);
            this.txtKullanici.Name = "txtKullanici";
            this.txtKullanici.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtKullanici.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtKullanici_Properties_ButtonClick);
            this.txtKullanici.Size = new System.Drawing.Size(153, 20);
            this.txtKullanici.TabIndex = 2;
            this.txtKullanici.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKullanici_KeyDown);
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(124, 230);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.PasswordChar = '!';
            this.txtSifre.Size = new System.Drawing.Size(153, 20);
            this.txtSifre.TabIndex = 3;
            this.txtSifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSifre_KeyDown);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Blaser_ÖTV_Fatura_Irsaliye.Properties.Resources.BLS;
            this.pictureEdit1.Location = new System.Drawing.Point(8, 11);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.pictureEdit1.Size = new System.Drawing.Size(269, 136);
            this.pictureEdit1.TabIndex = 0;
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblKullanicilarTableAdapter1
            // 
            this.tblKullanicilarTableAdapter1.ClearBeforeFill = true;
            // 
            // conBlaser
            // 
            this.conBlaser.FireInfoMessageEventOnUserErrors = false;
            // 
            // txtSirket
            // 
            this.txtSirket.Location = new System.Drawing.Point(124, 181);
            this.txtSirket.Name = "txtSirket";
            this.txtSirket.Size = new System.Drawing.Size(153, 20);
            this.txtSirket.TabIndex = 1;
            this.txtSirket.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSirket_KeyDown);
            // 
            // GirisFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 331);
            this.Controls.Add(this.txtSirket);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKullanici);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.btnBaglan);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GirisFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Formu";
            this.Load += new System.EventHandler(this.GirisFormu_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullanici.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSirket.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDurum;
        private DevExpress.XtraEditors.SimpleButton btnBaglan;
        private System.Data.SqlClient.SqlConnection conCs;
        private System.Data.SqlClient.SqlConnection conMaster;
        public DevExpress.XtraEditors.TextEdit txtServer;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.ButtonEdit txtKullanici;
        public DevExpress.XtraEditors.TextEdit txtSifre;
        private DataSet1 dataSet11;
        private DataSet1TableAdapters.tblKullanicilarTableAdapter tblKullanicilarTableAdapter1;
        private System.Data.SqlClient.SqlConnection conBlaser;
        public DevExpress.XtraEditors.TextEdit txtSirket;
    }
}