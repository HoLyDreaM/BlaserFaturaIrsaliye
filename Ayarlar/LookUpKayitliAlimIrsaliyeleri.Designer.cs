namespace Blaser_ÖTV_Fatura_Irsaliye.Ayarlar
{
    partial class LookUpKayitliAlimIrsaliyeleri
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
            this.Irsaliye_NoTextBox = new System.Windows.Forms.TextBox();
            this.tblKayitliAlimIrsaliyeleriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new Blaser_ÖTV_Fatura_Irsaliye.DataSet2();
            this.hesap_KoduTextBox = new System.Windows.Forms.TextBox();
            this.tblKayitliAlimIrsaliyeleriTableAdapter = new Blaser_ÖTV_Fatura_Irsaliye.DataSet2TableAdapters.tblKayitliAlimIrsaliyeleriTableAdapter();
            this.tableAdapterManager = new Blaser_ÖTV_Fatura_Irsaliye.DataSet2TableAdapters.TableAdapterManager();
            this.grdKayitliIrsaliyeler = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEvrakSeriNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHesapKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblKayitliAlimIrsaliyeleriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKayitliIrsaliyeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Irsaliye_NoTextBox
            // 
            this.Irsaliye_NoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblKayitliAlimIrsaliyeleriBindingSource, "EvrakSeriNo", true));
            this.Irsaliye_NoTextBox.Location = new System.Drawing.Point(277, 334);
            this.Irsaliye_NoTextBox.Name = "Irsaliye_NoTextBox";
            this.Irsaliye_NoTextBox.ReadOnly = true;
            this.Irsaliye_NoTextBox.Size = new System.Drawing.Size(14, 21);
            this.Irsaliye_NoTextBox.TabIndex = 6;
            // 
            // tblKayitliAlimIrsaliyeleriBindingSource
            // 
            this.tblKayitliAlimIrsaliyeleriBindingSource.DataMember = "tblKayitliAlimIrsaliyeleri";
            this.tblKayitliAlimIrsaliyeleriBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hesap_KoduTextBox
            // 
            this.hesap_KoduTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblKayitliAlimIrsaliyeleriBindingSource, "HesapKodu", true));
            this.hesap_KoduTextBox.Location = new System.Drawing.Point(310, 334);
            this.hesap_KoduTextBox.Name = "hesap_KoduTextBox";
            this.hesap_KoduTextBox.ReadOnly = true;
            this.hesap_KoduTextBox.Size = new System.Drawing.Size(10, 21);
            this.hesap_KoduTextBox.TabIndex = 7;
            // 
            // tblKayitliAlimIrsaliyeleriTableAdapter
            // 
            this.tblKayitliAlimIrsaliyeleriTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.tblEskiKayitliSiparisDegerleriTableAdapter = null;
            this.tableAdapterManager.tblGtipNoTableAdapter = null;
            this.tableAdapterManager.tblSatisIrsaliyesiStk004TableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Blaser_ÖTV_Fatura_Irsaliye.DataSet2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // grdKayitliIrsaliyeler
            // 
            this.grdKayitliIrsaliyeler.DataSource = this.tblKayitliAlimIrsaliyeleriBindingSource;
            this.grdKayitliIrsaliyeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKayitliIrsaliyeler.Location = new System.Drawing.Point(0, 0);
            this.grdKayitliIrsaliyeler.MainView = this.gridView1;
            this.grdKayitliIrsaliyeler.Name = "grdKayitliIrsaliyeler";
            this.grdKayitliIrsaliyeler.Size = new System.Drawing.Size(332, 430);
            this.grdKayitliIrsaliyeler.TabIndex = 8;
            this.grdKayitliIrsaliyeler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdKayitliIrsaliyeler.DoubleClick += new System.EventHandler(this.grdKayitliIrsaliyeler_DoubleClick);
            this.grdKayitliIrsaliyeler.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdKayitliIrsaliyeler_KeyUp);
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
            // 
            // colEvrakSeriNo
            // 
            this.colEvrakSeriNo.FieldName = "EvrakSeriNo";
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
            this.colHesapKodu.FieldName = "HesapKodu";
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
            // LookUpKayitliAlimIrsaliyeleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 430);
            this.Controls.Add(this.grdKayitliIrsaliyeler);
            this.Controls.Add(this.hesap_KoduTextBox);
            this.Controls.Add(this.Irsaliye_NoTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LookUpKayitliAlimIrsaliyeleri";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kayıtlı Irsaliyeler";
            this.Load += new System.EventHandler(this.LookUpKayitliAlimIrsaliyeleri_Load);
            this.DoubleClick += new System.EventHandler(this.LookUpKayitliAlimIrsaliyeleri_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.tblKayitliAlimIrsaliyeleriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKayitliIrsaliyeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Irsaliye_NoTextBox;
        private System.Windows.Forms.TextBox hesap_KoduTextBox;
        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource tblKayitliAlimIrsaliyeleriBindingSource;
        private DataSet2TableAdapters.tblKayitliAlimIrsaliyeleriTableAdapter tblKayitliAlimIrsaliyeleriTableAdapter;
        private DataSet2TableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl grdKayitliIrsaliyeler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colEvrakSeriNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTarih;
        private DevExpress.XtraGrid.Columns.GridColumn colHesapKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colTutar;
    }
}