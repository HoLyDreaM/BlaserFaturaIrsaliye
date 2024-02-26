namespace Blaser_ÖTV_Fatura_Irsaliye.Ayarlar
{
    partial class LookUpKayitliIrsaliye_iadeFatura
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
            this.hesap_KoduTextBox = new System.Windows.Forms.TextBox();
            this.tblLookUpKayitliiadeIrsaliyeleriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1();
            this.Irsaliye_NoTextBox = new System.Windows.Forms.TextBox();
            this.tblLookUpKayitliiadeIrsaliyeleriTableAdapter = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.tblLookUpKayitliiadeIrsaliyeleriTableAdapter();
            this.tableAdapterManager = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.TableAdapterManager();
            this.grdKayitliIrsaliyeler = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEvrakSeriNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHesapKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblLookUpKayitliiadeIrsaliyeleriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKayitliIrsaliyeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // hesap_KoduTextBox
            // 
            this.hesap_KoduTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblLookUpKayitliiadeIrsaliyeleriBindingSource, "Hesap Kodu", true));
            this.hesap_KoduTextBox.Location = new System.Drawing.Point(176, 205);
            this.hesap_KoduTextBox.Name = "hesap_KoduTextBox";
            this.hesap_KoduTextBox.ReadOnly = true;
            this.hesap_KoduTextBox.Size = new System.Drawing.Size(10, 21);
            this.hesap_KoduTextBox.TabIndex = 9;
            // 
            // tblLookUpKayitliiadeIrsaliyeleriBindingSource
            // 
            this.tblLookUpKayitliiadeIrsaliyeleriBindingSource.DataMember = "tblLookUpKayitliiadeIrsaliyeleri";
            this.tblLookUpKayitliiadeIrsaliyeleriBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Irsaliye_NoTextBox
            // 
            this.Irsaliye_NoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblLookUpKayitliiadeIrsaliyeleriBindingSource, "Evrak Seri No", true));
            this.Irsaliye_NoTextBox.Location = new System.Drawing.Point(147, 205);
            this.Irsaliye_NoTextBox.Name = "Irsaliye_NoTextBox";
            this.Irsaliye_NoTextBox.ReadOnly = true;
            this.Irsaliye_NoTextBox.Size = new System.Drawing.Size(14, 21);
            this.Irsaliye_NoTextBox.TabIndex = 8;
            // 
            // tblLookUpKayitliiadeIrsaliyeleriTableAdapter
            // 
            this.tblLookUpKayitliiadeIrsaliyeleriTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.rapor_CariBilgilerTableAdapter = null;
            this.tableAdapterManager.tblEskiKayitIrsaliyeOnDegerleriTableAdapter = null;
            this.tableAdapterManager.tblEskiSiparisOnDegerleriTableAdapter = null;
            this.tableAdapterManager.tblEvrakNumaralariTableAdapter = null;
            this.tableAdapterManager.tblEvrakTanimlariTableAdapter = null;
            this.tableAdapterManager.tblFormKullanicilarTableAdapter = null;
            this.tableAdapterManager.tblKullanicilarTableAdapter = null;
            this.tableAdapterManager.tblLookUpKayitliFaturalarTableAdapter = null;
            this.tableAdapterManager.tblLookUpKayitliiadeFaturalariTableAdapter = null;
            this.tableAdapterManager.tblLookUpKullanicilarTableAdapter = null;
            this.tableAdapterManager.tblStokVeCariHareketKodlariTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // grdKayitliIrsaliyeler
            // 
            this.grdKayitliIrsaliyeler.DataSource = this.tblLookUpKayitliiadeIrsaliyeleriBindingSource;
            this.grdKayitliIrsaliyeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKayitliIrsaliyeler.Location = new System.Drawing.Point(0, 0);
            this.grdKayitliIrsaliyeler.MainView = this.gridView1;
            this.grdKayitliIrsaliyeler.Name = "grdKayitliIrsaliyeler";
            this.grdKayitliIrsaliyeler.Size = new System.Drawing.Size(332, 430);
            this.grdKayitliIrsaliyeler.TabIndex = 10;
            this.grdKayitliIrsaliyeler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdKayitliIrsaliyeler.DoubleClick += new System.EventHandler(this.grdKayitliIrsaliyeler_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEvrakSeriNo,
            this.colTarih,
            this.colHesapKodu,
            this.colTutar});
            this.gridView1.GridControl = this.grdKayitliIrsaliyeler;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyUp);
            // 
            // colEvrakSeriNo
            // 
            this.colEvrakSeriNo.FieldName = "Evrak Seri No";
            this.colEvrakSeriNo.Name = "colEvrakSeriNo";
            this.colEvrakSeriNo.Visible = true;
            this.colEvrakSeriNo.VisibleIndex = 0;
            // 
            // colTarih
            // 
            this.colTarih.FieldName = "Tarih";
            this.colTarih.Name = "colTarih";
            this.colTarih.OptionsColumn.ReadOnly = true;
            this.colTarih.Visible = true;
            this.colTarih.VisibleIndex = 1;
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
            this.colTutar.FieldName = "Tutar";
            this.colTutar.Name = "colTutar";
            this.colTutar.Visible = true;
            this.colTutar.VisibleIndex = 3;
            // 
            // LookUpKayitliIrsaliye_iadeFatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 430);
            this.Controls.Add(this.grdKayitliIrsaliyeler);
            this.Controls.Add(this.hesap_KoduTextBox);
            this.Controls.Add(this.Irsaliye_NoTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LookUpKayitliIrsaliye_iadeFatura";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kayıtlı Irsaliyeler";
            this.Load += new System.EventHandler(this.LookUpKayitliIrsaliye_iadeFatura_Load);
            this.DoubleClick += new System.EventHandler(this.LookUpKayitliIrsaliye_iadeFatura_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.tblLookUpKayitliiadeIrsaliyeleriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKayitliIrsaliyeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hesap_KoduTextBox;
        private System.Windows.Forms.TextBox Irsaliye_NoTextBox;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tblLookUpKayitliiadeIrsaliyeleriBindingSource;
        private DataSet1TableAdapters.tblLookUpKayitliiadeIrsaliyeleriTableAdapter tblLookUpKayitliiadeIrsaliyeleriTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl grdKayitliIrsaliyeler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colEvrakSeriNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTarih;
        private DevExpress.XtraGrid.Columns.GridColumn colHesapKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colTutar;
    }
}