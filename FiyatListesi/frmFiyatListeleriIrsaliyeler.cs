using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Blaser_ÖTV_Fatura_Irsaliye.FiyatListesi
{
    public partial class frmFiyatListeleriIrsaliyeler : DevExpress.XtraEditors.XtraForm
    {
        public frmFiyatListeleriIrsaliyeler()
        {
            InitializeComponent();
        }

        public OtvliSatisIrsaliyesi frmOtvliSatisIrsaliyesi { get; set; }

        private void frmFiyatListeleri_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'listeler.tblKayitliListeler' table. You can move, or remove it, as needed.
            this.tblKayitliListelerTableAdapter.Fill(this.listeler.tblKayitliListeler);

        }

        private void grdKayitliListeler_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (gridView1.RowCount > 0)
                {
                    frmOtvliSatisIrsaliyesi.txtListeNo.Text = txtListeNo.Text;
                    frmOtvliSatisIrsaliyesi.txtListeKodu.Text = txtListeKodu.Text;
                    frmOtvliSatisIrsaliyesi.txtListeAdi.Text = txtListeAdi.Text;
                    this.Dispose();
                }
        }

        private void frmFiyatListeleriIrsaliyeler_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                frmOtvliSatisIrsaliyesi.txtListeNo.Text = txtListeNo.Text;
                frmOtvliSatisIrsaliyesi.txtListeKodu.Text = txtListeKodu.Text;
                frmOtvliSatisIrsaliyesi.txtListeAdi.Text = txtListeAdi.Text;
                this.Dispose();
            }
        }

        private void grdKayitliListeler_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                frmOtvliSatisIrsaliyesi.txtListeNo.Text = txtListeNo.Text;
                frmOtvliSatisIrsaliyesi.txtListeKodu.Text = txtListeKodu.Text;
                frmOtvliSatisIrsaliyesi.txtListeAdi.Text = txtListeAdi.Text;
                this.Dispose();
            }
        }
    }
}