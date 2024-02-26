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
    public partial class frmKayitliIrsaliye_OtvFatura : DevExpress.XtraEditors.XtraForm
    {
        public frmKayitliIrsaliye_OtvFatura()
        {
            InitializeComponent();
        }

        public OtvliSatisFaturasi frmOtvliSatisFaturasi { get; set; }

        private void frmKayitliIrsaliye_OtvFatura_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(frmOtvliSatisFaturasi.txtHesapKodu.Text))
            {
                this.tblKayitliIrsaliyelerTableAdapter.Fill(this.dataSet2.tblKayitliIrsaliyeler);
            }
            else
            {
                //this.tblKayitliIrsaliyelerTableAdapter.HesapliKayitliIrsaliye(this.dataSet2.tblKayitliIrsaliyeler, frmOtvliSatisFaturasi.txtHesapKodu.Text);
            }

        }

        private void grdKayitliIrsaliyeler_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (gridView1.RowCount > 0)
                {
                    if (Irsaliye_NoTextBox.Text.Length > 6)
                    {
                        frmOtvliSatisFaturasi.txtIrsaliyeNo.Text = Irsaliye_NoTextBox.Text;
                    }
                    frmOtvliSatisFaturasi.ps_kayitliIrsaliyeGetir(Irsaliye_NoTextBox.Text);
                    frmOtvliSatisFaturasi.ps_kayitliIrsaliyeninCarisi(hesap_KoduTextBox.Text);
                    frmOtvliSatisFaturasi.ps_kayitliIrsaliyeOnDegerleri(Irsaliye_NoTextBox.Text);
                    this.Dispose();
                }
        }

        private void frmKayitliIrsaliye_OtvFatura_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (Irsaliye_NoTextBox.Text.Length > 6)
                {
                    frmOtvliSatisFaturasi.txtIrsaliyeNo.Text = Irsaliye_NoTextBox.Text;
                }
                frmOtvliSatisFaturasi.ps_kayitliIrsaliyeGetir(Irsaliye_NoTextBox.Text);
                frmOtvliSatisFaturasi.ps_kayitliIrsaliyeninCarisi(hesap_KoduTextBox.Text);
                frmOtvliSatisFaturasi.ps_kayitliIrsaliyeOnDegerleri(Irsaliye_NoTextBox.Text);
                this.Dispose();
            }
        }

        private void grdKayitliIrsaliyeler_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (Irsaliye_NoTextBox.Text.Length > 6)
                {
                    frmOtvliSatisFaturasi.txtIrsaliyeNo.Text = Irsaliye_NoTextBox.Text;
                }
                frmOtvliSatisFaturasi.ps_kayitliIrsaliyeGetir(Irsaliye_NoTextBox.Text);
                frmOtvliSatisFaturasi.ps_kayitliIrsaliyeninCarisi(hesap_KoduTextBox.Text);
                frmOtvliSatisFaturasi.ps_kayitliIrsaliyeOnDegerleri(Irsaliye_NoTextBox.Text);
                this.Dispose();
            }
        }
    }
}