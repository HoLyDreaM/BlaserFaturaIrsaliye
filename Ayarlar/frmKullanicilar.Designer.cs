namespace Blaser_ÖTV_Fatura_Irsaliye.Ayarlar
{
    partial class frmKullanicilar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKullanicilar));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnYeni = new DevExpress.XtraBars.BarButtonItem();
            this.btnKaydet = new DevExpress.XtraBars.BarButtonItem();
            this.btnVazgec = new DevExpress.XtraBars.BarButtonItem();
            this.btnSil = new DevExpress.XtraBars.BarButtonItem();
            this.btnYenile = new DevExpress.XtraBars.BarButtonItem();
            this.btnDegisiklik = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.MenuImages = new DevExpress.Utils.ImageCollection(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblFormKullanicilarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdiSoyadi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKullaniciAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSifre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGuncelleme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtKulAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAdiSoyadi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tblFormKullanicilarTableAdapter = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.tblFormKullanicilarTableAdapter();
            this.tableAdapterManager1 = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFormKullanicilarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKulAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdiSoyadi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.MenuImages;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnYeni,
            this.btnKaydet,
            this.btnVazgec,
            this.btnSil,
            this.btnYenile,
            this.btnDegisiklik});
            this.barManager1.MaxItemId = 6;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnYeni, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnKaydet, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnVazgec, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSil, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnYenile, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDegisiklik, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnYeni
            // 
            this.btnYeni.Caption = "Yeni";
            this.btnYeni.Id = 0;
            this.btnYeni.ImageIndex = 4;
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnYeni_ItemClick);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Caption = "Kaydet";
            this.btnKaydet.Id = 1;
            this.btnKaydet.ImageIndex = 3;
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKaydet_ItemClick);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Caption = "Vazgec";
            this.btnVazgec.Id = 2;
            this.btnVazgec.ImageIndex = 5;
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVazgec_ItemClick);
            // 
            // btnSil
            // 
            this.btnSil.Caption = "Sil";
            this.btnSil.Id = 3;
            this.btnSil.ImageIndex = 1;
            this.btnSil.Name = "btnSil";
            this.btnSil.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSil_ItemClick);
            // 
            // btnYenile
            // 
            this.btnYenile.Caption = "Yenile";
            this.btnYenile.Id = 4;
            this.btnYenile.ImageIndex = 2;
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnYenile_ItemClick);
            // 
            // btnDegisiklik
            // 
            this.btnDegisiklik.Caption = "Değişiklikleri Uygula";
            this.btnDegisiklik.Id = 5;
            this.btnDegisiklik.ImageIndex = 0;
            this.btnDegisiklik.Name = "btnDegisiklik";
            this.btnDegisiklik.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDegisiklik_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(847, 39);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 487);
            this.barDockControlBottom.Size = new System.Drawing.Size(847, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 39);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 448);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(847, 39);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 448);
            // 
            // MenuImages
            // 
            this.MenuImages.ImageSize = new System.Drawing.Size(24, 24);
            this.MenuImages.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("MenuImages.ImageStream")));
            this.MenuImages.Images.SetKeyName(0, "database_accept.png");
            this.MenuImages.Images.SetKeyName(1, "Delete.png");
            this.MenuImages.Images.SetKeyName(2, "Refresh.png");
            this.MenuImages.Images.SetKeyName(3, "Save.png");
            this.MenuImages.Images.SetKeyName(4, "guncelleme.png");
            this.MenuImages.Images.SetKeyName(5, "vazgec.png");
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 39);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(847, 448);
            this.splitContainerControl1.SplitterPosition = 372;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblFormKullanicilarBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(372, 448);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblFormKullanicilarBindingSource
            // 
            this.tblFormKullanicilarBindingSource.DataMember = "tblFormKullanicilar";
            this.tblFormKullanicilarBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colAdiSoyadi,
            this.colKullaniciAdi,
            this.colSifre,
            this.colGuncelleme});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ReadOnly = true;
            this.colID.Width = 31;
            // 
            // colAdiSoyadi
            // 
            this.colAdiSoyadi.Caption = "Adı Soyadı";
            this.colAdiSoyadi.FieldName = "AdiSoyadi";
            this.colAdiSoyadi.Name = "colAdiSoyadi";
            this.colAdiSoyadi.OptionsColumn.ReadOnly = true;
            this.colAdiSoyadi.Visible = true;
            this.colAdiSoyadi.VisibleIndex = 0;
            this.colAdiSoyadi.Width = 89;
            // 
            // colKullaniciAdi
            // 
            this.colKullaniciAdi.Caption = "Kullanıcı Adı";
            this.colKullaniciAdi.FieldName = "KullaniciAdi";
            this.colKullaniciAdi.Name = "colKullaniciAdi";
            this.colKullaniciAdi.OptionsColumn.ReadOnly = true;
            this.colKullaniciAdi.Visible = true;
            this.colKullaniciAdi.VisibleIndex = 1;
            this.colKullaniciAdi.Width = 99;
            // 
            // colSifre
            // 
            this.colSifre.Caption = "Şifre";
            this.colSifre.FieldName = "Sifre";
            this.colSifre.Name = "colSifre";
            this.colSifre.OptionsColumn.ReadOnly = true;
            this.colSifre.Visible = true;
            this.colSifre.VisibleIndex = 2;
            this.colSifre.Width = 87;
            // 
            // colGuncelleme
            // 
            this.colGuncelleme.Caption = "Güncelleme";
            this.colGuncelleme.FieldName = "Guncelleme";
            this.colGuncelleme.Name = "colGuncelleme";
            this.colGuncelleme.Visible = true;
            this.colGuncelleme.VisibleIndex = 3;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(470, 448);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.txtSifre);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.txtKulAdi);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.txtAdiSoyadi);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(464, 420);
            this.xtraTabPage1.Text = "Kullanıcı Ayarları";
            // 
            // txtSifre
            // 
            this.txtSifre.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblFormKullanicilarBindingSource, "Sifre", true));
            this.txtSifre.Location = new System.Drawing.Point(136, 68);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(153, 20);
            this.txtSifre.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl3.Location = new System.Drawing.Point(21, 68);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(115, 20);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Şifre";
            // 
            // txtKulAdi
            // 
            this.txtKulAdi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblFormKullanicilarBindingSource, "KullaniciAdi", true));
            this.txtKulAdi.Location = new System.Drawing.Point(136, 42);
            this.txtKulAdi.Name = "txtKulAdi";
            this.txtKulAdi.Size = new System.Drawing.Size(153, 20);
            this.txtKulAdi.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl2.Location = new System.Drawing.Point(21, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(115, 20);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Kullanıcı Adı";
            // 
            // txtAdiSoyadi
            // 
            this.txtAdiSoyadi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblFormKullanicilarBindingSource, "AdiSoyadi", true));
            this.txtAdiSoyadi.Location = new System.Drawing.Point(136, 16);
            this.txtAdiSoyadi.Name = "txtAdiSoyadi";
            this.txtAdiSoyadi.Size = new System.Drawing.Size(153, 20);
            this.txtAdiSoyadi.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl1.Location = new System.Drawing.Point(21, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(115, 20);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Adı && Soyadı";
            // 
            // tblFormKullanicilarTableAdapter
            // 
            this.tblFormKullanicilarTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.tblEskiKayitIrsaliyeOnDegerleriTableAdapter = null;
            this.tableAdapterManager1.tblEskiSiparisOnDegerleriTableAdapter = null;
            this.tableAdapterManager1.tblEvrakNumaralariTableAdapter = null;
            this.tableAdapterManager1.tblFormKullanicilarTableAdapter = this.tblFormKullanicilarTableAdapter;
            this.tableAdapterManager1.tblKullanicilarTableAdapter = null;
            this.tableAdapterManager1.tblLookUpKayitliFaturalarTableAdapter = null;
            this.tableAdapterManager1.tblLookUpKullanicilarTableAdapter = null;
            this.tableAdapterManager1.tblStokVeCariHareketKodlariTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frmKullanicilar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 487);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmKullanicilar";
            this.Text = "Kullanıcılar";
            this.Load += new System.EventHandler(this.frmKullanicilar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFormKullanicilarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKulAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdiSoyadi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tblFormKullanicilarBindingSource;
        private DataSet1TableAdapters.tblFormKullanicilarTableAdapter tblFormKullanicilarTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colAdiSoyadi;
        private DevExpress.XtraGrid.Columns.GridColumn colKullaniciAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colSifre;
        private DevExpress.XtraBars.BarButtonItem btnYeni;
        private DevExpress.XtraBars.BarButtonItem btnKaydet;
        private DevExpress.XtraBars.BarButtonItem btnVazgec;
        private DevExpress.XtraBars.BarButtonItem btnSil;
        private DevExpress.XtraBars.BarButtonItem btnYenile;
        private DevExpress.XtraBars.BarButtonItem btnDegisiklik;
        public DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit txtKulAdi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtAdiSoyadi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager1;
        private DevExpress.XtraGrid.Columns.GridColumn colGuncelleme;
        private DevExpress.Utils.ImageCollection MenuImages;
    }
}