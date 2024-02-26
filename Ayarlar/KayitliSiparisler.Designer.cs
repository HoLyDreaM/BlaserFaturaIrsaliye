namespace Blaser_ÖTV_Fatura_Irsaliye.Ayarlar
{
    partial class KayitliSiparisler
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
            this.SiparisEvrakNo_TextBox = new System.Windows.Forms.TextBox();
            this.tblKayitliSiparislerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new Blaser_ÖTV_Fatura_Irsaliye.DataSet2();
            this.tblKayitliSiparislerTableAdapter = new Blaser_ÖTV_Fatura_Irsaliye.DataSet2TableAdapters.tblKayitliSiparislerTableAdapter();
            this.tableAdapterManager = new Blaser_ÖTV_Fatura_Irsaliye.DataSet2TableAdapters.TableAdapterManager();
            this.tblKayitliSiparislerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.HesapKodu_TextBox = new System.Windows.Forms.TextBox();
            this.txtSiparisTarih = new System.Windows.Forms.TextBox();
            this.grdKayitliSiparisler = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEvrakNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHesapKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblKayitliSiparislerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKayitliSiparislerBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKayitliSiparisler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SiparisEvrakNo_TextBox
            // 
            this.SiparisEvrakNo_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblKayitliSiparislerBindingSource, "EvrakNo", true));
            this.SiparisEvrakNo_TextBox.Location = new System.Drawing.Point(159, 205);
            this.SiparisEvrakNo_TextBox.Name = "SiparisEvrakNo_TextBox";
            this.SiparisEvrakNo_TextBox.ReadOnly = true;
            this.SiparisEvrakNo_TextBox.Size = new System.Drawing.Size(14, 21);
            this.SiparisEvrakNo_TextBox.TabIndex = 6;
            // 
            // tblKayitliSiparislerBindingSource
            // 
            this.tblKayitliSiparislerBindingSource.DataMember = "tblKayitliSiparisler";
            this.tblKayitliSiparislerBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblKayitliSiparislerTableAdapter
            // 
            this.tblKayitliSiparislerTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.tblEskiKayitliSiparisDegerleriTableAdapter = null;
            //this.tableAdapterManager.tblEskiKayitOnDegerleriTableAdapter = null;
            this.tableAdapterManager.tblSatisIrsaliyesiStk004TableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Blaser_ÖTV_Fatura_Irsaliye.DataSet2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tblKayitliSiparislerBindingSource1
            // 
            this.tblKayitliSiparislerBindingSource1.DataMember = "tblKayitliSiparisler";
            this.tblKayitliSiparislerBindingSource1.DataSource = this.dataSet2;
            // 
            // HesapKodu_TextBox
            // 
            this.HesapKodu_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblKayitliSiparislerBindingSource, "HesapKodu", true));
            this.HesapKodu_TextBox.Location = new System.Drawing.Point(179, 205);
            this.HesapKodu_TextBox.Name = "HesapKodu_TextBox";
            this.HesapKodu_TextBox.ReadOnly = true;
            this.HesapKodu_TextBox.Size = new System.Drawing.Size(14, 21);
            this.HesapKodu_TextBox.TabIndex = 6;
            // 
            // txtSiparisTarih
            // 
            this.txtSiparisTarih.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblKayitliSiparislerBindingSource, "Tarih", true));
            this.txtSiparisTarih.Location = new System.Drawing.Point(199, 205);
            this.txtSiparisTarih.Name = "txtSiparisTarih";
            this.txtSiparisTarih.ReadOnly = true;
            this.txtSiparisTarih.Size = new System.Drawing.Size(14, 21);
            this.txtSiparisTarih.TabIndex = 6;
            // 
            // grdKayitliSiparisler
            // 
            this.grdKayitliSiparisler.DataSource = this.tblKayitliSiparislerBindingSource;
            this.grdKayitliSiparisler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKayitliSiparisler.Location = new System.Drawing.Point(0, 0);
            this.grdKayitliSiparisler.MainView = this.gridView1;
            this.grdKayitliSiparisler.Name = "grdKayitliSiparisler";
            this.grdKayitliSiparisler.Size = new System.Drawing.Size(377, 430);
            this.grdKayitliSiparisler.TabIndex = 10;
            this.grdKayitliSiparisler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdKayitliSiparisler.DoubleClick += new System.EventHandler(this.grdKayitliSiparisler_DoubleClick);
            this.grdKayitliSiparisler.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdKayitliSiparisler_KeyUp);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEvrakNo,
            this.colHesapKodu,
            this.colTarih,
            this.colMiktar,
            this.colTutar});
            this.gridView1.GridControl = this.grdKayitliSiparisler;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colEvrakNo
            // 
            this.colEvrakNo.FieldName = "EvrakNo";
            this.colEvrakNo.Name = "colEvrakNo";
            this.colEvrakNo.Visible = true;
            this.colEvrakNo.VisibleIndex = 0;
            // 
            // colHesapKodu
            // 
            this.colHesapKodu.FieldName = "HesapKodu";
            this.colHesapKodu.Name = "colHesapKodu";
            this.colHesapKodu.Visible = true;
            this.colHesapKodu.VisibleIndex = 1;
            // 
            // colTarih
            // 
            this.colTarih.FieldName = "Tarih";
            this.colTarih.Name = "colTarih";
            this.colTarih.OptionsColumn.ReadOnly = true;
            this.colTarih.Visible = true;
            this.colTarih.VisibleIndex = 2;
            // 
            // colMiktar
            // 
            this.colMiktar.FieldName = "Miktar";
            this.colMiktar.Name = "colMiktar";
            this.colMiktar.OptionsColumn.ReadOnly = true;
            this.colMiktar.Visible = true;
            this.colMiktar.VisibleIndex = 3;
            // 
            // colTutar
            // 
            this.colTutar.FieldName = "Tutar";
            this.colTutar.Name = "colTutar";
            this.colTutar.OptionsColumn.ReadOnly = true;
            this.colTutar.Visible = true;
            this.colTutar.VisibleIndex = 4;
            // 
            // KayitliSiparisler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 430);
            this.Controls.Add(this.grdKayitliSiparisler);
            this.Controls.Add(this.txtSiparisTarih);
            this.Controls.Add(this.HesapKodu_TextBox);
            this.Controls.Add(this.SiparisEvrakNo_TextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KayitliSiparisler";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kayıtlı Siparişler";
            this.Load += new System.EventHandler(this.KayitliSiparisler_Load);
            this.DoubleClick += new System.EventHandler(this.KayitliSiparisler_DoubleClick);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdKayitliSiparisler_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.tblKayitliSiparislerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKayitliSiparislerBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKayitliSiparisler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SiparisEvrakNo_TextBox;
        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource tblKayitliSiparislerBindingSource;
        private DataSet2TableAdapters.tblKayitliSiparislerTableAdapter tblKayitliSiparislerTableAdapter;
        private DataSet2TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource tblKayitliSiparislerBindingSource1;
        private System.Windows.Forms.TextBox HesapKodu_TextBox;
        private System.Windows.Forms.TextBox txtSiparisTarih;
        private DevExpress.XtraGrid.GridControl grdKayitliSiparisler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colEvrakNo;
        private DevExpress.XtraGrid.Columns.GridColumn colHesapKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colTarih;
        private DevExpress.XtraGrid.Columns.GridColumn colMiktar;
        private DevExpress.XtraGrid.Columns.GridColumn colTutar;
    }
}