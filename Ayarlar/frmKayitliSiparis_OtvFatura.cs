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
    public partial class frmKayitliSiparis_OtvFatura : DevExpress.XtraEditors.XtraForm
    {
        public frmKayitliSiparis_OtvFatura()
        {
            InitializeComponent();
        }

        public OtvliSatisFaturasi frmOtvliSatisFaturasi { get; set; }

        private void frmKayitliSiparis_OtvFatura_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(frmOtvliSatisFaturasi.txtHesapKodu.Text))
            {
                this.tblKayitliSiparislerTableAdapter.Fill(this.dataSet2.tblKayitliSiparisler, frmOtvliSatisFaturasi.txtHesapKodu.Text);
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
                        frmOtvliSatisFaturasi.txtSiparisNo.Text = SiparisEvrakNo_TextBox.Text;
                        frmOtvliSatisFaturasi.dtSiparisTarihi.DateTime = Convert.ToDateTime(txtSiparisTarih.Text);
                    }
                    frmOtvliSatisFaturasi.ps_KayitliSiparisGetir(SiparisEvrakNo_TextBox.Text);
                    frmOtvliSatisFaturasi.ps_kayitliIrsaliyeninCarisi(HesapKodu_TextBox.Text);
                    frmOtvliSatisFaturasi.ps_KayitiliSiparisOnDegerleri(SiparisEvrakNo_TextBox.Text);
                    this.Dispose();
                }
        }

        private void frmKayitliSiparis_OtvFatura_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (SiparisEvrakNo_TextBox.Text.Length > 6)
                {
                    frmOtvliSatisFaturasi.txtSiparisNo.Text = SiparisEvrakNo_TextBox.Text;
                    frmOtvliSatisFaturasi.dtSiparisTarihi.DateTime = Convert.ToDateTime(txtSiparisTarih.Text);
                }
                frmOtvliSatisFaturasi.ps_KayitliSiparisGetir(SiparisEvrakNo_TextBox.Text);
                frmOtvliSatisFaturasi.ps_kayitliIrsaliyeninCarisi(HesapKodu_TextBox.Text);
                frmOtvliSatisFaturasi.ps_KayitiliSiparisOnDegerleri(SiparisEvrakNo_TextBox.Text);
                this.Dispose();
            }
        }

        private void grdKayitliSiparisler_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (SiparisEvrakNo_TextBox.Text.Length > 6)
                {
                    frmOtvliSatisFaturasi.txtSiparisNo.Text = SiparisEvrakNo_TextBox.Text;
                    frmOtvliSatisFaturasi.dtSiparisTarihi.DateTime = Convert.ToDateTime(txtSiparisTarih.Text);
                }
                frmOtvliSatisFaturasi.ps_KayitliSiparisGetir(SiparisEvrakNo_TextBox.Text);
                frmOtvliSatisFaturasi.ps_kayitliIrsaliyeninCarisi(HesapKodu_TextBox.Text);
                frmOtvliSatisFaturasi.ps_KayitiliSiparisOnDegerleri(SiparisEvrakNo_TextBox.Text);
                this.Dispose();
            }
        }
    }
}