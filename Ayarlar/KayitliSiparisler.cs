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
    public partial class KayitliSiparisler : DevExpress.XtraEditors.XtraForm
    {
        public KayitliSiparisler()
        {
            InitializeComponent();
        }

        public OtvliSatisIrsaliyesi frmOtvliSatisIrsaliyesi { get; set; }

        private void KayitliSiparisler_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(frmOtvliSatisIrsaliyesi.txtHesapKodu.Text))
            {
                this.tblKayitliSiparislerTableAdapter.Fill(this.dataSet2.tblKayitliSiparisler, frmOtvliSatisIrsaliyesi.txtHesapKodu.Text);
            }
            else
            {
                this.tblKayitliSiparislerTableAdapter.HesapsizSiparisler(this.dataSet2.tblKayitliSiparisler);
            }
        }

        private void grdKayitliSiparisler_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (gridView1.RowCount > 0)
                {
                    if (SiparisEvrakNo_TextBox.Text.Length > 6)
                    {
                        frmOtvliSatisIrsaliyesi.txtSiparisNo.Text = SiparisEvrakNo_TextBox.Text;
                        frmOtvliSatisIrsaliyesi.dtSiparisTarihi.DateTime = Convert.ToDateTime(txtSiparisTarih.Text);
                    }
                    frmOtvliSatisIrsaliyesi.ps_KayitliSiparisGetir(SiparisEvrakNo_TextBox.Text);
                    frmOtvliSatisIrsaliyesi.ps_kayitliIrsaliyeninCarisi(HesapKodu_TextBox.Text);
                    frmOtvliSatisIrsaliyesi.ps_KayitiliSiparisOnDegerleri(SiparisEvrakNo_TextBox.Text);
                    this.Dispose();
                }
        }

        private void KayitliSiparisler_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (SiparisEvrakNo_TextBox.Text.Length > 6)
                {
                    frmOtvliSatisIrsaliyesi.txtSiparisNo.Text = SiparisEvrakNo_TextBox.Text;
                    frmOtvliSatisIrsaliyesi.dtSiparisTarihi.DateTime = Convert.ToDateTime(txtSiparisTarih.Text);
                }
                frmOtvliSatisIrsaliyesi.ps_KayitliSiparisGetir(SiparisEvrakNo_TextBox.Text);
                frmOtvliSatisIrsaliyesi.ps_kayitliIrsaliyeninCarisi(HesapKodu_TextBox.Text);
                frmOtvliSatisIrsaliyesi.ps_KayitiliSiparisOnDegerleri(SiparisEvrakNo_TextBox.Text);
                this.Dispose();
            }

        }

        private void grdKayitliSiparisler_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (SiparisEvrakNo_TextBox.Text.Length > 6)
                {
                    frmOtvliSatisIrsaliyesi.txtSiparisNo.Text = SiparisEvrakNo_TextBox.Text;
                    frmOtvliSatisIrsaliyesi.dtSiparisTarihi.DateTime = Convert.ToDateTime(txtSiparisTarih.Text);
                }
                frmOtvliSatisIrsaliyesi.ps_KayitliSiparisGetir(SiparisEvrakNo_TextBox.Text);
                frmOtvliSatisIrsaliyesi.ps_kayitliIrsaliyeninCarisi(HesapKodu_TextBox.Text);
                frmOtvliSatisIrsaliyesi.ps_KayitiliSiparisOnDegerleri(SiparisEvrakNo_TextBox.Text);
                this.Dispose();
            }
        }
    }
}