namespace Blaser_ÖTV_Fatura_Irsaliye.Ayarlar
{
    partial class LookUpSirketler
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
            this.dataSet1 = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1();
            this.tblSirketlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblSirketlerTableAdapter = new Blaser_ÖTV_Fatura_Irsaliye.DataSet1TableAdapters.tblSirketlerTableAdapter();
            this.lbSirket = new DevExpress.XtraEditors.ListBoxControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSirketlerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbSirket)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblSirketlerBindingSource
            // 
            this.tblSirketlerBindingSource.DataMember = "tblSirketler";
            this.tblSirketlerBindingSource.DataSource = this.dataSet1;
            // 
            // tblSirketlerTableAdapter
            // 
            this.tblSirketlerTableAdapter.ClearBeforeFill = true;
            // 
            // lbSirket
            // 
            this.lbSirket.DataSource = this.tblSirketlerBindingSource;
            this.lbSirket.DisplayMember = "Şirket Adı";
            this.lbSirket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSirket.Location = new System.Drawing.Point(0, 0);
            this.lbSirket.Name = "lbSirket";
            this.lbSirket.Size = new System.Drawing.Size(308, 379);
            this.lbSirket.TabIndex = 2;
            this.lbSirket.DoubleClick += new System.EventHandler(this.lbSirket_DoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 357);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(308, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(205, 17);
            this.toolStripStatusLabel1.Text = "Şirket Seçimi:\'ENTER\'   ;   Çıkış:\'ESC\'";
            // 
            // LookUpSirketler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 379);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbSirket);
            this.KeyPreview = true;
            this.Name = "LookUpSirketler";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şirket Seçimi";
            this.Load += new System.EventHandler(this.LookUpSirketler_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LookUpSirketler_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSirketlerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbSirket)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tblSirketlerBindingSource;
        private DataSet1TableAdapters.tblSirketlerTableAdapter tblSirketlerTableAdapter;
        private DevExpress.XtraEditors.ListBoxControl lbSirket;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

    }
}