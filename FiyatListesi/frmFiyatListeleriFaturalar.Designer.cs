namespace Blaser_ÖTV_Fatura_Irsaliye.FiyatListesi
{
    partial class frmFiyatListeleriFaturalar
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
            this.txtListeAdi = new System.Windows.Forms.TextBox();
            this.txtListeKodu = new System.Windows.Forms.TextBox();
            this.txtListeNo = new System.Windows.Forms.TextBox();
            this.listeler = new Blaser_ÖTV_Fatura_Irsaliye.Listeler();
            this.tblKayitliListelerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblKayitliListelerTableAdapter = new Blaser_ÖTV_Fatura_Irsaliye.ListelerTableAdapters.tblKayitliListelerTableAdapter();
            this.tableAdapterManager = new Blaser_ÖTV_Fatura_Irsaliye.ListelerTableAdapters.TableAdapterManager();
            this.grdKayitliListeler = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFiyatListeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiyatListeKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiyatListeAdı = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaşlangıçTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBitişTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.listeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKayitliListelerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKayitliListeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtListeAdi
            // 
            this.txtListeAdi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblKayitliListelerBindingSource, "Fiyat Liste Adı", true));
            this.txtListeAdi.Location = new System.Drawing.Point(329, 289);
            this.txtListeAdi.Name = "txtListeAdi";
            this.txtListeAdi.ReadOnly = true;
            this.txtListeAdi.Size = new System.Drawing.Size(100, 21);
            this.txtListeAdi.TabIndex = 1;
            // 
            // txtListeKodu
            // 
            this.txtListeKodu.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblKayitliListelerBindingSource, "Fiyat Liste Kodu", true));
            this.txtListeKodu.Location = new System.Drawing.Point(329, 262);
            this.txtListeKodu.Name = "txtListeKodu";
            this.txtListeKodu.ReadOnly = true;
            this.txtListeKodu.Size = new System.Drawing.Size(100, 21);
            this.txtListeKodu.TabIndex = 2;
            // 
            // txtListeNo
            // 
            this.txtListeNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblKayitliListelerBindingSource, "Fiyat Liste No", true));
            this.txtListeNo.Location = new System.Drawing.Point(329, 235);
            this.txtListeNo.Name = "txtListeNo";
            this.txtListeNo.ReadOnly = true;
            this.txtListeNo.Size = new System.Drawing.Size(100, 21);
            this.txtListeNo.TabIndex = 3;
            // 
            // listeler
            // 
            this.listeler.DataSetName = "Listeler";
            this.listeler.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblKayitliListelerBindingSource
            // 
            this.tblKayitliListelerBindingSource.DataMember = "tblKayitliListeler";
            this.tblKayitliListelerBindingSource.DataSource = this.listeler;
            // 
            // tblKayitliListelerTableAdapter
            // 
            this.tblKayitliListelerTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.tblFiyatListeleriTableAdapter = null;
            this.tableAdapterManager.tblListeCariHesaplariTableAdapter = null;
            this.tableAdapterManager.tblListeMalKodlariTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Blaser_ÖTV_Fatura_Irsaliye.ListelerTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // grdKayitliListeler
            // 
            this.grdKayitliListeler.DataSource = this.tblKayitliListelerBindingSource;
            this.grdKayitliListeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKayitliListeler.Location = new System.Drawing.Point(0, 0);
            this.grdKayitliListeler.MainView = this.gridView1;
            this.grdKayitliListeler.Name = "grdKayitliListeler";
            this.grdKayitliListeler.Size = new System.Drawing.Size(450, 430);
            this.grdKayitliListeler.TabIndex = 4;
            this.grdKayitliListeler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdKayitliListeler.DoubleClick += new System.EventHandler(this.grdKayitliListeler_DoubleClick);
            this.grdKayitliListeler.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdKayitliListeler_KeyUp);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFiyatListeNo,
            this.colFiyatListeKodu,
            this.colFiyatListeAdı,
            this.colBaşlangıçTarihi,
            this.colBitişTarihi});
            this.gridView1.GridControl = this.grdKayitliListeler;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colFiyatListeNo
            // 
            this.colFiyatListeNo.FieldName = "Fiyat Liste No";
            this.colFiyatListeNo.Name = "colFiyatListeNo";
            this.colFiyatListeNo.OptionsColumn.ReadOnly = true;
            this.colFiyatListeNo.Visible = true;
            this.colFiyatListeNo.VisibleIndex = 0;
            // 
            // colFiyatListeKodu
            // 
            this.colFiyatListeKodu.FieldName = "Fiyat Liste Kodu";
            this.colFiyatListeKodu.Name = "colFiyatListeKodu";
            this.colFiyatListeKodu.OptionsColumn.ReadOnly = true;
            this.colFiyatListeKodu.Visible = true;
            this.colFiyatListeKodu.VisibleIndex = 1;
            // 
            // colFiyatListeAdı
            // 
            this.colFiyatListeAdı.FieldName = "Fiyat Liste Adı";
            this.colFiyatListeAdı.Name = "colFiyatListeAdı";
            this.colFiyatListeAdı.OptionsColumn.ReadOnly = true;
            this.colFiyatListeAdı.Visible = true;
            this.colFiyatListeAdı.VisibleIndex = 2;
            // 
            // colBaşlangıçTarihi
            // 
            this.colBaşlangıçTarihi.FieldName = "Başlangıç Tarihi";
            this.colBaşlangıçTarihi.Name = "colBaşlangıçTarihi";
            this.colBaşlangıçTarihi.OptionsColumn.ReadOnly = true;
            this.colBaşlangıçTarihi.Visible = true;
            this.colBaşlangıçTarihi.VisibleIndex = 3;
            // 
            // colBitişTarihi
            // 
            this.colBitişTarihi.FieldName = "Bitiş Tarihi";
            this.colBitişTarihi.Name = "colBitişTarihi";
            this.colBitişTarihi.OptionsColumn.ReadOnly = true;
            this.colBitişTarihi.Visible = true;
            this.colBitişTarihi.VisibleIndex = 4;
            // 
            // frmFiyatListeleriFaturalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 430);
            this.Controls.Add(this.grdKayitliListeler);
            this.Controls.Add(this.txtListeAdi);
            this.Controls.Add(this.txtListeKodu);
            this.Controls.Add(this.txtListeNo);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFiyatListeleriFaturalar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiyat Listeleri";
            this.Load += new System.EventHandler(this.frmFiyatListeleriFaturalar_Load);
            this.DoubleClick += new System.EventHandler(this.frmFiyatListeleriFaturalar_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.listeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKayitliListelerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKayitliListeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtListeAdi;
        private System.Windows.Forms.TextBox txtListeKodu;
        private System.Windows.Forms.TextBox txtListeNo;
        private Listeler listeler;
        private System.Windows.Forms.BindingSource tblKayitliListelerBindingSource;
        private ListelerTableAdapters.tblKayitliListelerTableAdapter tblKayitliListelerTableAdapter;
        private ListelerTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl grdKayitliListeler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFiyatListeNo;
        private DevExpress.XtraGrid.Columns.GridColumn colFiyatListeKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colFiyatListeAdı;
        private DevExpress.XtraGrid.Columns.GridColumn colBaşlangıçTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colBitişTarihi;
    }
}