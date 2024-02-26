namespace Blaser_ÖTV_Fatura_Irsaliye.Ayarlar
{
    partial class LookUpKayitlikFaturalar_OtvFatura
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
            this.tblLookUpKayitliFaturalarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1();
            this.tblLookUpKayitliFaturalarTableAdapter = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.tblLookUpKayitliFaturalarTableAdapter();
            this.tableAdapterManager = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.TableAdapterManager();
            this.fatura_NoTextBox = new System.Windows.Forms.TextBox();
            this.hesap_KoduTextBox = new System.Windows.Forms.TextBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFaturaNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaturaTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHesapKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblLookUpKayitliFaturalarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tblLookUpKayitliFaturalarBindingSource
            // 
            this.tblLookUpKayitliFaturalarBindingSource.DataMember = "tblLookUpKayitliFaturalar";
            this.tblLookUpKayitliFaturalarBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblLookUpKayitliFaturalarTableAdapter
            // 
            this.tblLookUpKayitliFaturalarTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.rapor_CariBilgilerTableAdapter = null;
            this.tableAdapterManager.tblEskiKayitIrsaliyeOnDegerleriTableAdapter = null;
            this.tableAdapterManager.tblEskiSiparisOnDegerleriTableAdapter = null;
            this.tableAdapterManager.tblEvrakNumaralariTableAdapter = null;
            this.tableAdapterManager.tblEvrakTanimlariTableAdapter = null;
            this.tableAdapterManager.tblFormKullanicilarTableAdapter = null;
            this.tableAdapterManager.tblKullanicilarTableAdapter = null;
            this.tableAdapterManager.tblLookUpKayitliFaturalarTableAdapter = this.tblLookUpKayitliFaturalarTableAdapter;
            this.tableAdapterManager.tblLookUpKayitliiadeFaturalariTableAdapter = null;
            this.tableAdapterManager.tblLookUpKullanicilarTableAdapter = null;
            this.tableAdapterManager.tblStokVeCariHareketKodlariTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // fatura_NoTextBox
            // 
            this.fatura_NoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblLookUpKayitliFaturalarBindingSource, "Fatura No", true));
            this.fatura_NoTextBox.Location = new System.Drawing.Point(43, 386);
            this.fatura_NoTextBox.Name = "fatura_NoTextBox";
            this.fatura_NoTextBox.ReadOnly = true;
            this.fatura_NoTextBox.Size = new System.Drawing.Size(14, 21);
            this.fatura_NoTextBox.TabIndex = 2;
            // 
            // hesap_KoduTextBox
            // 
            this.hesap_KoduTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblLookUpKayitliFaturalarBindingSource, "Hesap Kodu", true));
            this.hesap_KoduTextBox.Location = new System.Drawing.Point(63, 386);
            this.hesap_KoduTextBox.Name = "hesap_KoduTextBox";
            this.hesap_KoduTextBox.ReadOnly = true;
            this.hesap_KoduTextBox.Size = new System.Drawing.Size(10, 21);
            this.hesap_KoduTextBox.TabIndex = 4;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblLookUpKayitliFaturalarBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(331, 430);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFaturaNo,
            this.colFaturaTarihi,
            this.colHesapKodu,
            this.colTutar});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colFaturaNo
            // 
            this.colFaturaNo.FieldName = "Fatura No";
            this.colFaturaNo.Name = "colFaturaNo";
            this.colFaturaNo.Visible = true;
            this.colFaturaNo.VisibleIndex = 0;
            // 
            // colFaturaTarihi
            // 
            this.colFaturaTarihi.FieldName = "Fatura Tarihi";
            this.colFaturaTarihi.Name = "colFaturaTarihi";
            this.colFaturaTarihi.OptionsColumn.ReadOnly = true;
            this.colFaturaTarihi.Visible = true;
            this.colFaturaTarihi.VisibleIndex = 1;
            // 
            // colHesapKodu
            // 
            this.colHesapKodu.FieldName = "Hesap Kodu";
            this.colHesapKodu.Name = "colHesapKodu";
            this.colHesapKodu.Visible = true;
            this.colHesapKodu.VisibleIndex = 2;
            // 
            // colTutar
            // 
            this.colTutar.DisplayFormat.FormatString = "n2";
            this.colTutar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTutar.FieldName = "Tutar";
            this.colTutar.Name = "colTutar";
            this.colTutar.Visible = true;
            this.colTutar.VisibleIndex = 3;
            // 
            // LookUpKayitlikFaturalar_OtvFatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 430);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.hesap_KoduTextBox);
            this.Controls.Add(this.fatura_NoTextBox);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LookUpKayitlikFaturalar_OtvFatura";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kayıtlı Faturalar";
            this.Load += new System.EventHandler(this.LookUpKayitlikFaturalar_OtvFatura_Load);
            this.DoubleClick += new System.EventHandler(this.LookUpKayitlikFaturalar_OtvFatura_DoubleClick);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridControl1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.tblLookUpKayitliFaturalarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tblLookUpKayitliFaturalarBindingSource;
        private DataSet1TableAdapters.tblLookUpKayitliFaturalarTableAdapter tblLookUpKayitliFaturalarTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox fatura_NoTextBox;
        private System.Windows.Forms.TextBox hesap_KoduTextBox;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaNo;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colHesapKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colTutar;
    }
}