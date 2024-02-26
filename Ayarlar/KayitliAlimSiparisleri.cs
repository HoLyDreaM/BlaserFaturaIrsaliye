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
    public partial class KayitliAlimSiparisleri : DevExpress.XtraEditors.XtraForm
    {
        public KayitliAlimSiparisleri()
        {
            InitializeComponent();
        }

        public OtvliAlimIrsaliyesi frmOtvliAlimIrsaliyesi { get; set; }

        private void KayitliAlimSiparisleri_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(frmOtvliAlimIrsaliyesi.txtHesapKodu.Text))
            {
                this.tblKayitliAlimSiparisleriTableAdapter.Fill(this.dataSet2.tblKayitliAlimSiparisleri, frmOtvliAlimIrsaliyesi.txtHesapKodu.Text);
            }
            else
            {
                this.tblKayitliAlimSiparisleriTableAdapter.HesapsizSiparisler(this.dataSet2.tblKayitliAlimSiparisleri);
            }
        }

        private void grdKayitliSiparisler_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (gridView1.RowCount > 0)
                {
                    if (SiparisEvrakNo_TextBox.Text.Length > 6)
                    {
                        frmOtvliAlimIrsaliyesi.txtSiparisNo.Text = SiparisEvrakNo_TextBox.Text;
                        frmOtvliAlimIrsaliyesi.dtSiparisTarihi.DateTime = Convert.ToDateTime(txtSiparisTarih.Text);
                    }
                    frmOtvliAlimIrsaliyesi.ps_KayitliSiparisGetir(SiparisEvrakNo_TextBox.Text);
                    frmOtvliAlimIrsaliyesi.ps_kayitliIrsaliyeninCarisi(HesapKodu_TextBox.Text);
                    frmOtvliAlimIrsaliyesi.ps_KayitiliSiparisOnDegerleri(SiparisEvrakNo_TextBox.Text);
                    this.Dispose();
                }
        }

        private void KayitliAlimSiparisleri_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (SiparisEvrakNo_TextBox.Text.Length > 6)
                {
                    frmOtvliAlimIrsaliyesi.txtSiparisNo.Text = SiparisEvrakNo_TextBox.Text;
                    frmOtvliAlimIrsaliyesi.dtSiparisTarihi.DateTime = Convert.ToDateTime(txtSiparisTarih.Text);
                }
                frmOtvliAlimIrsaliyesi.ps_KayitliSiparisGetir(SiparisEvrakNo_TextBox.Text);
                frmOtvliAlimIrsaliyesi.ps_kayitliIrsaliyeninCarisi(HesapKodu_TextBox.Text);
                frmOtvliAlimIrsaliyesi.ps_KayitiliSiparisOnDegerleri(SiparisEvrakNo_TextBox.Text);
                this.Dispose();
            }
        }

        private void grdKayitliSiparisler_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (SiparisEvrakNo_TextBox.Text.Length > 6)
                {
                    frmOtvliAlimIrsaliyesi.txtSiparisNo.Text = SiparisEvrakNo_TextBox.Text;
                    frmOtvliAlimIrsaliyesi.dtSiparisTarihi.DateTime = Convert.ToDateTime(txtSiparisTarih.Text);
                }
                frmOtvliAlimIrsaliyesi.ps_KayitliSiparisGetir(SiparisEvrakNo_TextBox.Text);
                frmOtvliAlimIrsaliyesi.ps_kayitliIrsaliyeninCarisi(HesapKodu_TextBox.Text);
                frmOtvliAlimIrsaliyesi.ps_KayitiliSiparisOnDegerleri(SiparisEvrakNo_TextBox.Text);
                this.Dispose();
            }
        }
    }
}