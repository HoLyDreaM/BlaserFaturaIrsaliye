namespace Blaser_ÖTV_Fatura_Irsaliye.Ayarlar
{
    partial class LookUpSatisIrsaliyesiMalKodu
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
            this.grdMalKodlari = new DevExpress.XtraGrid.GridControl();
            this.tblLookUpStokKartlariBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMalKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMalAdı = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirim1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirim2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirim3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKafileBüyüklüğü = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGTIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGümrükOranı = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtvUygulamaSekli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtvOran = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtvBirim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirimFiyati = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tblLookUpStokKartlariTableAdapter = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.tblLookUpStokKartlariTableAdapter();
            this.listeler = new Blaser_ÖTV_Fatura_Irsaliye.Listeler();
            this.tblListeBirimFiyatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblListeBirimFiyatTableAdapter = new Blaser_ÖTV_Fatura_Irsaliye.ListelerTableAdapters.tblListeBirimFiyatTableAdapter();
            this.evrakNoSeriTableAdapter1 = new Blaser_ÖTV_Fatura_Irsaliye.DataSet2TableAdapters.EvrakNoSeriTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.grdMalKodlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLookUpStokKartlariBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblListeBirimFiyatBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMalKodlari
            // 
            this.grdMalKodlari.DataSource = this.tblLookUpStokKartlariBindingSource;
            this.grdMalKodlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMalKodlari.Location = new System.Drawing.Point(0, 0);
            this.grdMalKodlari.MainView = this.gridView1;
            this.grdMalKodlari.Name = "grdMalKodlari";
            this.grdMalKodlari.Size = new System.Drawing.Size(332, 430);
            this.grdMalKodlari.TabIndex = 1;
            this.grdMalKodlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdMalKodlari.DoubleClick += new System.EventHandler(this.grdMalKodlari_DoubleClick);
            // 
            // tblLookUpStokKartlariBindingSource
            // 
            this.tblLookUpStokKartlariBindingSource.DataMember = "tblLookUpStokKartlari";
            this.tblLookUpStokKartlariBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMalKodu,
            this.colMalAdı,
            this.colKDV,
            this.colBirim1,
            this.colBirim2,
            this.colBirim3,
            this.colKafileBüyüklüğü,
            this.colGTIP,
            this.colGümrükOranı,
            this.colOtvUygulamaSekli,
            this.colOtvOran,
            this.colOtvBirim,
            this.colBirimFiyati});
            this.gridView1.GridControl = this.grdMalKodlari;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyUp);
            // 
            // colMalKodu
            // 
            this.colMalKodu.FieldName = "Mal Kodu";
            this.colMalKodu.Name = "colMalKodu";
            this.colMalKodu.Visible = true;
            this.colMalKodu.VisibleIndex = 0;
            // 
            // colMalAdı
            // 
            this.colMalAdı.FieldName = "Mal Adı";
            this.colMalAdı.Name = "colMalAdı";
            this.colMalAdı.Visible = true;
            this.colMalAdı.VisibleIndex = 1;
            // 
            // colKDV
            // 
            this.colKDV.FieldName = "KDV";
            this.colKDV.Name = "colKDV";
            // 
            // colBirim1
            // 
            this.colBirim1.FieldName = "Birim 1";
            this.colBirim1.Name = "colBirim1";
            // 
            // colBirim2
            // 
            this.colBirim2.FieldName = "Birim 2";
            this.colBirim2.Name = "colBirim2";
            // 
            // colBirim3
            // 
            this.colBirim3.FieldName = "Birim 3";
            this.colBirim3.Name = "colBirim3";
            // 
            // colKafileBüyüklüğü
            // 
            this.colKafileBüyüklüğü.FieldName = "Kafile Büyüklüğü";
            this.colKafileBüyüklüğü.Name = "colKafileBüyüklüğü";
            // 
            // colGTIP
            // 
            this.colGTIP.FieldName = "GTIP";
            this.colGTIP.Name = "colGTIP";
            // 
            // colGümrükOranı
            // 
            this.colGümrükOranı.FieldName = "Gümrük Oranı";
            this.colGümrükOranı.Name = "colGümrükOranı";
            // 
            // colOtvUygulamaSekli
            // 
            this.colOtvUygulamaSekli.FieldName = "OtvUygulamaSekli";
            this.colOtvUygulamaSekli.Name = "colOtvUygulamaSekli";
            // 
            // colOtvOran
            // 
            this.colOtvOran.FieldName = "OtvOran";
            this.colOtvOran.Name = "colOtvOran";
            // 
            // colOtvBirim
            // 
            this.colOtvBirim.FieldName = "OtvBirim";
            this.colOtvBirim.Name = "colOtvBirim";
            // 
            // colBirimFiyati
            // 
            this.colBirimFiyati.FieldName = "BirimFiyati";
            this.colBirimFiyati.Name = "colBirimFiyati";
            this.colBirimFiyati.OptionsColumn.ReadOnly = true;
            // 
            // tblLookUpStokKartlariTableAdapter
            // 
            this.tblLookUpStokKartlariTableAdapter.ClearBeforeFill = true;
            // 
            // listeler
            // 
            this.listeler.DataSetName = "Listeler";
            this.listeler.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblListeBirimFiyatBindingSource
            // 
            this.tblListeBirimFiyatBindingSource.DataMember = "tblListeBirimFiyat";
            this.tblListeBirimFiyatBindingSource.DataSource = this.listeler;
            // 
            // tblListeBirimFiyatTableAdapter
            // 
            this.tblListeBirimFiyatTableAdapter.ClearBeforeFill = true;
            // 
            // LookUpSatisIrsaliyesiMalKodu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 430);
            this.Controls.Add(this.grdMalKodlari);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LookUpSatisIrsaliyesiMalKodu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mal Kodları";
            this.Load += new System.EventHandler(this.LookUpSatisIrsaliyesiMalKodu_Load);
            this.DoubleClick += new System.EventHandler(this.LookUpSatisIrsaliyesiMalKodu_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.grdMalKodlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLookUpStokKartlariBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblListeBirimFiyatBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdMalKodlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMalKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colMalAdı;
        private DevExpress.XtraGrid.Columns.GridColumn colKDV;
        private DevExpress.XtraGrid.Columns.GridColumn colBirim1;
        private DevExpress.XtraGrid.Columns.GridColumn colBirim2;
        private DevExpress.XtraGrid.Columns.GridColumn colBirim3;
        private DevExpress.XtraGrid.Columns.GridColumn colKafileBüyüklüğü;
        private DevExpress.XtraGrid.Columns.GridColumn colGTIP;
        private DevExpress.XtraGrid.Columns.GridColumn colGümrükOranı;
        private DevExpress.XtraGrid.Columns.GridColumn colOtvUygulamaSekli;
        private DevExpress.XtraGrid.Columns.GridColumn colOtvOran;
        private DevExpress.XtraGrid.Columns.GridColumn colOtvBirim;
        private DevExpress.XtraGrid.Columns.GridColumn colBirimFiyati;
        private System.Windows.Forms.BindingSource tblLookUpStokKartlariBindingSource;
        private DataSet1 dataSet1;
        private DataSet1TableAdapters.tblLookUpStokKartlariTableAdapter tblLookUpStokKartlariTableAdapter;
        private Listeler listeler;
        private System.Windows.Forms.BindingSource tblListeBirimFiyatBindingSource;
        private ListelerTableAdapters.tblListeBirimFiyatTableAdapter tblListeBirimFiyatTableAdapter;
        private DataSet2TableAdapters.EvrakNoSeriTableAdapter evrakNoSeriTableAdapter1;
    }
}