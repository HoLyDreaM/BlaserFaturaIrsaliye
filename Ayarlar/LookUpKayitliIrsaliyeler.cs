using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Blaser_ÖTV_Fatura_Irsaliye.Ayarlar
{
    public partial class LookUpKayitliIrsaliyeler : DevExpress.XtraEditors.XtraForm
    {
        public LookUpKayitliIrsaliyeler()
        {
            InitializeComponent();
        }

        public OtvliSatisIrsaliyesi frmOtvliSatisIrsaliyesi { get; set; }

        private void LookUpKayitliIrsaliyeler_Load(object sender, EventArgs e)
        {

            this.tblKayitliIrsaliyelerTableAdapter.Fill(this.dataSet2.tblKayitliIrsaliyeler);

        }

        private void grdKayitliIrsaliyeler_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (gridView1.RowCount > 0)
                {
                    if (Irsaliye_NoTextBox.Text.Length > 6)
                    {
                        frmOtvliSatisIrsaliyesi.txtIrsaliyeSeri.Text = Irsaliye_NoTextBox.Text.Substring(0, 2);
                        frmOtvliSatisIrsaliyesi.txtIrsaliyeNo.Text = Irsaliye_NoTextBox.Text.Substring(2, 6);
                    }
                    frmOtvliSatisIrsaliyesi.ps_kayitliIrsaliyeGetir(Irsaliye_NoTextBox.Text);
                    frmOtvliSatisIrsaliyesi.ps_kayitliIrsaliyeninCarisi(hesap_KoduTextBox.Text);
                    frmOtvliSatisIrsaliyesi.ps_kayitliIrsaliyeOnDegerleri(Irsaliye_NoTextBox.Text);
                    this.Dispose();
                }
        }

        private void LookUpKayitliIrsaliyeler_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (Irsaliye_NoTextBox.Text.Length > 6)
                {
                    frmOtvliSatisIrsaliyesi.txtIrsaliyeSeri.Text = Irsaliye_NoTextBox.Text.Substring(0, 2);
                    frmOtvliSatisIrsaliyesi.txtIrsaliyeNo.Text = Irsaliye_NoTextBox.Text.Substring(2, 6);
                }
                frmOtvliSatisIrsaliyesi.ps_kayitliIrsaliyeGetir(Irsaliye_NoTextBox.Text);
                frmOtvliSatisIrsaliyesi.ps_kayitliIrsaliyeninCarisi(hesap_KoduTextBox.Text);
                frmOtvliSatisIrsaliyesi.ps_kayitliIrsaliyeOnDegerleri(Irsaliye_NoTextBox.Text);
                this.Dispose();
            }
        }

        private void grdKayitliIrsaliyeler_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (Irsaliye_NoTextBox.Text.Length > 6)
                {
                    frmOtvliSatisIrsaliyesi.txtIrsaliyeSeri.Text = Irsaliye_NoTextBox.Text.Substring(0, 2);
                    frmOtvliSatisIrsaliyesi.txtIrsaliyeNo.Text = Irsaliye_NoTextBox.Text.Substring(2, 6);
                }
                frmOtvliSatisIrsaliyesi.ps_kayitliIrsaliyeGetir(Irsaliye_NoTextBox.Text);
                frmOtvliSatisIrsaliyesi.ps_kayitliIrsaliyeninCarisi(hesap_KoduTextBox.Text);
                frmOtvliSatisIrsaliyesi.ps_kayitliIrsaliyeOnDegerleri(Irsaliye_NoTextBox.Text);
                this.Dispose();
            }
        }
    }
}