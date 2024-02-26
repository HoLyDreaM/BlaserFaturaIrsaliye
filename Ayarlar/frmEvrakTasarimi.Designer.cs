namespace Blaser_ÖTV_Fatura_Irsaliye.Ayarlar
{
    partial class frmEvrakTasarimi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvrakTasarimi));
            this.report1 = new FastReport.Report();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnYenile = new DevExpress.XtraBars.BarButtonItem();
            this.btnYeniTasarim = new DevExpress.XtraBars.BarButtonItem();
            this.btnDuzenle = new DevExpress.XtraBars.BarButtonItem();
            this.btnSil = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.MenuResimleri = new DevExpress.Utils.ImageCollection(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.dataSet11 = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuResimleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            this.SuspendLayout();
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.FullRowSelect = true;
            this.treeView1.LineColor = System.Drawing.Color.Firebrick;
            this.treeView1.Location = new System.Drawing.Point(0, 39);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(242, 421);
            this.treeView1.TabIndex = 11;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.MenuResimleri;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnYeniTasarim,
            this.btnDuzenle,
            this.btnSil,
            this.btnYenile});
            this.barManager1.MaxItemId = 4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnYenile, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnYeniTasarim, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDuzenle, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSil, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnYenile
            // 
            this.btnYenile.Caption = "Yenile";
            this.btnYenile.Id = 3;
            this.btnYenile.ImageIndex = 3;
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnYenile_ItemClick);
            // 
            // btnYeniTasarim
            // 
            this.btnYeniTasarim.Caption = "Yeni Tasarım";
            this.btnYeniTasarim.Id = 0;
            this.btnYeniTasarim.ImageIndex = 0;
            this.btnYeniTasarim.Name = "btnYeniTasarim";
            this.btnYeniTasarim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnYeniTasarim_ItemClick);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Caption = "Düzenle";
            this.btnDuzenle.Id = 1;
            this.btnDuzenle.ImageIndex = 2;
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDuzenle_ItemClick);
            // 
            // btnSil
            // 
            this.btnSil.Caption = "Sil";
            this.btnSil.Id = 2;
            this.btnSil.ImageIndex = 1;
            this.btnSil.Name = "btnSil";
            this.btnSil.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSil_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(728, 39);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 460);
            this.barDockControlBottom.Size = new System.Drawing.Size(728, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 39);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 421);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(728, 39);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 421);
            // 
            // MenuResimleri
            // 
            this.MenuResimleri.ImageSize = new System.Drawing.Size(24, 24);
            this.MenuResimleri.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("MenuResimleri.ImageStream")));
            this.MenuResimleri.Images.SetKeyName(0, "1374516388_document-new.png");
            this.MenuResimleri.Images.SetKeyName(1, "1374516517_delete-file.png");
            this.MenuResimleri.Images.SetKeyName(2, "1374516521_edit-file.png");
            this.MenuResimleri.Images.SetKeyName(3, "Refresh.png");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmEvrakTasarimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 460);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmEvrakTasarimi";
            this.Text = "Evrak Tasarımı";
            this.Load += new System.EventHandler(this.frmEvrakTasarimi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuResimleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastReport.Report report1;
        private System.Windows.Forms.TreeView treeView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnYeniTasarim;
        private DevExpress.XtraBars.BarButtonItem btnDuzenle;
        private DevExpress.XtraBars.BarButtonItem btnSil;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnYenile;
        private System.Windows.Forms.Button button1;
        private DevExpress.Utils.ImageCollection MenuResimleri;
        private DataSet1 dataSet11;
    }
}