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
    public partial class LookUpKayitliIrsaliye_iadeFatura : DevExpress.XtraEditors.XtraForm
    {
        public LookUpKayitliIrsaliye_iadeFatura()
        {
            InitializeComponent();
        }

        public OtvliSatistanIadeFaturasi frmOtvliSatisFaturasi { get; set; }

        private void LookUpKayitliIrsaliye_iadeFatura_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(frmOtvliSatisFaturasi.txtHesapKodu.Text))
            {
                this.tblLookUpKayitliiadeIrsaliyeleriTableAdapter.Fill(this.dataSet1.tblLookUpKayitliiadeIrsaliyeleri);
            }
            else
            {
                this.tblLookUpKayitliiadeIrsaliyeleriTableAdapter.Hesapliirsaliyeler(this.dataSet1.tblLookUpKayitliiadeIrsaliyeleri, frmOtvliSatisFaturasi.txtHesapKodu.Text);
            }
        }

        private void LookUpKayitliIrsaliye_iadeFatura_DoubleClick(object sender, EventArgs e)
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

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
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