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
    public partial class frmFiyatListeleriAlimIrsaliyeleri : DevExpress.XtraEditors.XtraForm
    {
        public frmFiyatListeleriAlimIrsaliyeleri()
        {
            InitializeComponent();
        }

        public OtvliAlimIrsaliyesi frmOtvliAlimIrsaliyesi { get; set; }

        private void frmFiyatListeleriAlimIrsaliyeleri_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'listeler.tblKayitliListeler' table. You can move, or remove it, as needed.
            this.tblKayitliListelerTableAdapter.Fill(this.listeler.tblKayitliListeler);

        }

        private void grdKayitliListeler_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (gridView1.RowCount > 0)
                {
                    frmOtvliAlimIrsaliyesi.txtListeNo.Text = txtListeNo.Text;
                    frmOtvliAlimIrsaliyesi.txtListeKodu.Text = txtListeKodu.Text;
                    frmOtvliAlimIrsaliyesi.txtListeAdi.Text = txtListeAdi.Text;
                    this.Dispose();
                }
        }

        private void frmFiyatListeleriAlimIrsaliyeleri_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                frmOtvliAlimIrsaliyesi.txtListeNo.Text = txtListeNo.Text;
                frmOtvliAlimIrsaliyesi.txtListeKodu.Text = txtListeKodu.Text;
                frmOtvliAlimIrsaliyesi.txtListeAdi.Text = txtListeAdi.Text;
                this.Dispose();
            }
        }

        private void grdKayitliListeler_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                frmOtvliAlimIrsaliyesi.txtListeNo.Text = txtListeNo.Text;
                frmOtvliAlimIrsaliyesi.txtListeKodu.Text = txtListeKodu.Text;
                frmOtvliAlimIrsaliyesi.txtListeAdi.Text = txtListeAdi.Text;
                this.Dispose();
            }
        }
    }
}