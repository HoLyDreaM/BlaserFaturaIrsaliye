namespace Blaser_ÖTV_Fatura_Irsaliye.Ayarlar
{
    partial class LookUpFormMalSeriNo
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblLookUpStokMiktarlariBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMalKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMalSeriNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGirenMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCikanMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKalanMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tblLookUpStokMiktarlariTableAdapter = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.tblLookUpStokMiktarlariTableAdapter();
            this.tableAdapterManager = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.TableAdapterManager();
            this.malSeriNoTextBox = new System.Windows.Forms.TextBox();
            this.kalanMiktarTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLookUpStokMiktarlariBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblLookUpStokMiktarlariBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(343, 395);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            this.gridControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridControl1_KeyUp);
            // 
            // tblLookUpStokMiktarlariBindingSource
            // 
            this.tblLookUpStokMiktarlariBindingSource.DataMember = "tblLookUpStokMiktarlari";
            this.tblLookUpStokMiktarlariBindingSource.DataSource = this.dataSet1;
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
            this.colMalSeriNo,
            this.colGirenMiktar,
            this.colCikanMiktar,
            this.colKalanMiktar});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colMalKodu
            // 
            this.colMalKodu.FieldName = "MalKodu";
            this.colMalKodu.Name = "colMalKodu";
            this.colMalKodu.Width = 84;
            // 
            // colMalSeriNo
            // 
            this.colMalSeriNo.FieldName = "MalSeriNo";
            this.colMalSeriNo.Name = "colMalSeriNo";
            this.colMalSeriNo.Visible = true;
            this.colMalSeriNo.VisibleIndex = 0;
            this.colMalSeriNo.Width = 108;
            // 
            // colGirenMiktar
            // 
            this.colGirenMiktar.FieldName = "GirenMiktar";
            this.colGirenMiktar.Name = "colGirenMiktar";
            this.colGirenMiktar.OptionsColumn.ReadOnly = true;
            this.colGirenMiktar.Visible = true;
            this.colGirenMiktar.VisibleIndex = 1;
            this.colGirenMiktar.Width = 65;
            // 
            // colCikanMiktar
            // 
            this.colCikanMiktar.FieldName = "CikanMiktar";
            this.colCikanMiktar.Name = "colCikanMiktar";
            this.colCikanMiktar.Visible = true;
            this.colCikanMiktar.VisibleIndex = 2;
            this.colCikanMiktar.Width = 66;
            // 
            // colKalanMiktar
            // 
            this.colKalanMiktar.FieldName = "KalanMiktar";
            this.colKalanMiktar.Name = "colKalanMiktar";
            this.colKalanMiktar.OptionsColumn.ReadOnly = true;
            this.colKalanMiktar.Visible = true;
            this.colKalanMiktar.VisibleIndex = 3;
            this.colKalanMiktar.Width = 65;
            // 
            // tblLookUpStokMiktarlariTableAdapter
            // 
            this.tblLookUpStokMiktarlariTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
//            this.tableAdapterManager.tblFormKullanicilarTableAdapter = null;
            this.tableAdapterManager.tblKullanicilarTableAdapter = null;
            this.tableAdapterManager.tblLookUpKayitliFaturalarTableAdapter = null;
            this.tableAdapterManager.tblLookUpKullanicilarTableAdapter = null;
            this.tableAdapterManager.tblStokVeCariHareketKodlariTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // malSeriNoTextBox
            // 
            this.malSeriNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblLookUpStokMiktarlariBindingSource, "MalSeriNo", true));
            this.malSeriNoTextBox.Location = new System.Drawing.Point(88, 297);
            this.malSeriNoTextBox.Name = "malSeriNoTextBox";
            this.malSeriNoTextBox.ReadOnly = true;
            this.malSeriNoTextBox.Size = new System.Drawing.Size(49, 21);
            this.malSeriNoTextBox.TabIndex = 2;
            // 
            // kalanMiktarTextBox
            // 
            this.kalanMiktarTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblLookUpStokMiktarlariBindingSource, "KalanMiktar", true));
            this.kalanMiktarTextBox.Location = new System.Drawing.Point(88, 324);
            this.kalanMiktarTextBox.Name = "kalanMiktarTextBox";
            this.kalanMiktarTextBox.ReadOnly = true;
            this.kalanMiktarTextBox.Size = new System.Drawing.Size(49, 21);
            this.kalanMiktarTextBox.TabIndex = 4;
            // 
            // LookUpFormMalSeriNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 436);
            this.Controls.Add(this.kalanMiktarTextBox);
            this.Controls.Add(this.malSeriNoTextBox);
            this.Controls.Add(this.gridControl1);
            this.KeyPreview = true;
            this.Name = "LookUpFormMalSeriNo";
            this.Text = "Mal Seri No";
            this.Load += new System.EventHandler(this.LookUpFormMalSeriNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLookUpStokMiktarlariBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource tblLookUpStokMiktarlariBindingSource;
        private DataSet1 dataSet1;
        private DevExpress.XtraGrid.Columns.GridColumn colMalKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colMalSeriNo;
        private DevExpress.XtraGrid.Columns.GridColumn colGirenMiktar;
        private DevExpress.XtraGrid.Columns.GridColumn colCikanMiktar;
        private DevExpress.XtraGrid.Columns.GridColumn colKalanMiktar;
        private DataSet1TableAdapters.tblLookUpStokMiktarlariTableAdapter tblLookUpStokMiktarlariTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox malSeriNoTextBox;
        private System.Windows.Forms.TextBox kalanMiktarTextBox;
    }
}